using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.DAL.Entities
{
    public class Organisation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tend> Tends { get; set; }

    }
}
