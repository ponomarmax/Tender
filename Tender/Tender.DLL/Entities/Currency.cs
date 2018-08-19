using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.DAL.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tend> Tends { get; set; }

    }
}
