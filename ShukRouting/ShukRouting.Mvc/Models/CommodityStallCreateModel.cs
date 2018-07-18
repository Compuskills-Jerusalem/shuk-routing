using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Models
{
    public class CommodityStallCreateModel
    {
        [Display(Name = "Commodity Stall ID")]
        public int CommodityStallID { get; set; }

        public int CommodityID { get; set; }
        [Display(Name = "Commodity Name")]
        public string CommodityName { get; set; }

        public int StallID { get; set; }
        [Display(Name = "Stall Name")]
        public string StallName { get; set; }
        public IEnumerable<SelectListItem> StallNames { get; set; }

        public Decimal Price { get; set; }
        public int? Rating { get; set; }
        [Display(Name = "Time Registered")]
        public DateTime TimeRegistered { get; set; }
        public string Notes { get; set; }
    }
}
