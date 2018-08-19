using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tender.Models
{
    public class Filter
    {
        public string Name { get; set; }
        public Dictionary<string,bool> filterList { get; set; }
        
    }
}