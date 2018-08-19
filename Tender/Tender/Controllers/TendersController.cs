using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tender.Models;
using Tender.Services;

namespace Tender.Controllers
{
    public class TendersController : Controller
    {
        TenderService service = new TenderService();
        int pageSize = 6;
        /// <summary>
        /// Has two filters by Organisators and by Kinds. There are creating list where you can choose parameters for sorting tender's list
        /// </summary>
        void CreateFilter()
        {
            List<Models.Filter> filters = new List<Models.Filter>();
            filters.Add(new Models.Filter { Name = "Organisator", filterList = service.GetAllOrganisators().ToDictionary(org => org, org => false) });
            filters.Add(new Models.Filter { Name = "Kind", filterList = service.GetAllKinds().ToDictionary(kind => kind, kind => false) });
            Session["Filters"] = filters;

            List<SelectListItem> sortList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="start budget (low prices are higher)",
                    Value="budgetAsc"
                },
                new SelectListItem
                {
                    Text="publish dates (early dates are higher)",
                    Value="dateAsc",
                    Selected =true
                }
                ,
                new SelectListItem
                {
                    Text="publish dates (late dates are higher)",
                    Value="dateDesc"
                }
                ,
                new SelectListItem
                {
                    Text="start budget (high price are higher)",
                    Value="budgetDesc"
                }
            };
            Session["SortBy"] = "dateAsc";
            Session["sortList"] = sortList;
        }

        /// <summary>
        /// Auxiliary method for method ApplyFilter
        /// </summary>
        /// <param name="tender"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        string GetValuePropertyByName(TenderModel tender, string propertyName)
        {
            switch (propertyName)
            {
                case "Organisator": return tender.Organisator;
                case "Kind": return tender.TenderKind;
            }
            return "";
        }
        public ActionResult Index(int page = 1)
        {
            CreateFilter();

            var result = service.GetAllTenders();
            result = SortTenders("", result);
            ViewBag.currentPage = page;
            ViewBag.LastPage = Math.Ceiling(result.Count * 1.0 / pageSize);
            ViewBag.PageSize = pageSize;
            return View(result.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }
        [HttpGet]
        public ActionResult Indexx(string filterParam, DateTime? startDate, DateTime? finishDate, int? LastPage, string word, string sortOrder, bool isFilterChecked = false, int CurrentPage = 1)
        {
            if (Session["Filters"] == null)
                CreateFilter();

            var result = service.GetAllTenders();
            result = ApplyFilters(result, startDate, finishDate, filterParam, isFilterChecked);
            result = Search(word, result);
            result = SortTenders(sortOrder, result);

            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = CurrentPage;
            ViewBag.LastPage = Math.Ceiling(result.Count * 1.0 / pageSize);
            return PartialView("DisplayPost", result.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Apply dates, Organisator and Kind filter
        /// </summary>
        /// <param name="result"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <param name="filterParam"></param>
        /// <param name="isFilterChecked"></param>
        /// <returns></returns>
        List<TenderModel> ApplyFilters(List<TenderModel> result, DateTime? startDate, DateTime? finishDate, string filterParam, bool isFilterChecked = false)
        {
            if (result == null) throw new NullReferenceException("Tenders collection is null. It must have some items for applying filters");
            var temp = new List<TenderModel>();
            var filterNew = new List<Models.Filter>();

            bool hasFilterCheckedItem = false;
            foreach (Models.Filter filter in Session["Filters"] as List<Models.Filter>)//has two filter (Organisator and Kind)
            {
                if (filterParam != null && filter.filterList.ContainsKey(filterParam))
                    filter.filterList[filterParam] = !filter.filterList[filterParam];
                foreach (var item in filter.filterList)// sort out all ways in each filter. filterList represents Dictionary, where key is name parameter and value contains info whether was it key checked
                    if (item.Value)
                    {
                        temp.AddRange(result.Where(tender => GetValuePropertyByName(tender, filter.Name) == item.Key));
                        hasFilterCheckedItem = true;
                    }

                if (hasFilterCheckedItem)
                {
                    hasFilterCheckedItem = false;
                    result = temp;
                }
                filterNew.Add(filter);
                temp = new List<TenderModel>();
            }
            Session["Filters"] = filterNew;//refresh filter

            if (startDate != null)
                Session["startDate"] = startDate;
            if (startDate == null && Session["startDate"] != null)
                startDate = Session["startDate"] as DateTime?;

            if (finishDate != null)
                Session["finishDate"] = finishDate;
            if (finishDate == null && Session["finishDate"] != null)
                finishDate = Session["finishDate"] as DateTime?;

            if (startDate == null && finishDate != null)
                result = result.Where(t => t.PublishDate <= finishDate).ToList();
            if (startDate != null && finishDate == null)
                result = result.Where(t => t.PublishDate >= startDate).ToList();
            if (result != null && finishDate != null)
                result = result.Where(t => t.PublishDate >= startDate && t.PublishDate <= finishDate).ToList();
            return result;

        }

        List<TenderModel> Search(string word, List<TenderModel> tenders)
        {
            if (tenders == null) throw new NullReferenceException("Tenders collection is null. It must have some items for searching");
            if (String.IsNullOrEmpty(word) && Session["searchWord"] != null)
                word = Session["searchWord"] as string;
            var temp = new List<TenderModel>();
            Session["searchWord"] = word;
            if (!String.IsNullOrEmpty(word))
            {
                foreach (var tender in tenders)
                    if (tender.Name.Contains(word) || tender.Description.Contains(word))
                        temp.Add(tender);
                tenders = temp;
            }

            return tenders;
        }

        /// <summary>
        /// By default it sorts by publish date in ascending order
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="tenders"></param>
        /// <returns></returns>
        List<TenderModel> SortTenders(string sortOrder, List<TenderModel> tenders)
        {
            if (tenders == null) throw new NullReferenceException("Tenders collection is null. It must have some items for sorting");
            if (String.IsNullOrEmpty(sortOrder) && Session["SortBy"] != null)
                sortOrder = Session["SortBy"] as string;
            Session["SortBy"] = sortOrder;
            switch (sortOrder)
            {
                case "budgetDesc":
                    return tenders.OrderByDescending(s => s.StartBudget).ToList();
                case "budgetAsc":
                    return tenders.OrderBy(s => s.StartBudget).ToList();
                case "dateDesc":
                    return tenders.OrderByDescending(s => s.PublishDate).ToList();
                default:
                    return tenders.OrderBy(s => s.PublishDate).ToList();
            }
        }
        ///GET: Tenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TenderModel tender = service.Find((int)id);
            if (tender == null)
                return HttpNotFound();
            return View(tender);
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
