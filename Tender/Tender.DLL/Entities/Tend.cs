using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tender.DAL.Entities
{
    public class Tend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Organisation Organisator { get; set; }
        public virtual Kind TenderKind { get; set; }
        public virtual Classification Classification { get; set; }
        public decimal StartBudget { get; set; }
        public virtual Currency Currency { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime GetProposeFromDate { get; set; }
        public DateTime GetProposeToDate { get; set; }

    }
}