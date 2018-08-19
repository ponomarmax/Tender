using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tender.Models
{
    public class TenderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string  Organisator { get; set; }
        public string TenderKind { get; set; }
        public string Classification { get; set; }
        public decimal StartBudget { get; set; }
        public string Currency { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime GetProposeFromDate { get; set; }
        public DateTime GetProposeToDate { get; set; }

    }
}