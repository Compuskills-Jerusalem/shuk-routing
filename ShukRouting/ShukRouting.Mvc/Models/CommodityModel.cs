using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Models
{
    public class CommodityModel
    {
        public int CommodityID { get; set; }
        public string CommodityName { get; set; }
        public IEnumerable<SelectListItem> CommodityNames { get; set; }
    }
}