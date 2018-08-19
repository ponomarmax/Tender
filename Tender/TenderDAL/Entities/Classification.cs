using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.DAL.Entities
{
    public class Classification
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public virtual ICollection<Tend> Tends { get; set; }
    }
}
