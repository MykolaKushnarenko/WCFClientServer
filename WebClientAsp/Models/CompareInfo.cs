using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientAsp.Models
{
    public class CompareInfo
    {
        public string Person { get; set; }
        public string Address { get; set; }
        public string Compile { get; set; }
        public HttpPostedFileBase upload { get; set; }
    }
}