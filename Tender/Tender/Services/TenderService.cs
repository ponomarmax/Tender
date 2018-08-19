using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Tender.Models;
using Tender.DAL.EF;
using Tender.DAL.Entities;

namespace Tender.Services
{
    public class TenderService
    {

        private TenderContext db = new TenderContext();
        protected IMapper mapperBusinessToView;
        public TenderService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tend, TenderModel>()
                .ForMember(x => x.Organisator, n => n.MapFrom(org => org.Organisator.Name))
                .ForMember(x => x.TenderKind, n => n.MapFrom(org => org.TenderKind.Name))
                .ForMember(x => x.Currency, n => n.MapFrom(org => org.Currency.Name))
                .ForMember(x => x.Classification, n => n.MapFrom(org => org.Classification.Activity));
            });
            config.AssertConfigurationIsValid();
            mapperBusinessToView = config.CreateMapper();
        }

        public List<string> GetAllOrganisators()
        {
            List<string> organisators = new List<string>();
            foreach (var org in db.Organisations.ToList())
                organisators.Add(org.Name);
            return organisators;
        }
        public List<string> GetAllKinds()
        {
            List<string> kinds = new List<string>();
            foreach (var kind in db.Kinds.ToList())
                kinds.Add(kind.Name);
            return kinds;
        }
        public List<TenderModel> GetAllTenders()
        {
            IEnumerable<TenderModel> tenders = mapperBusinessToView.Map<IEnumerable<TenderModel>>(db.Tenders);
            return tenders.ToList();
        }
        public TenderModel Find(int id)
        {
            TenderModel tender = mapperBusinessToView.Map<TenderModel>(db.Tenders.Where(t => t.Id == id).FirstOrDefault());
            return tender;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}