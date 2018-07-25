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
        public int CommodityStallID { get; set; }

        public int CommodityID { get; set; }

        [Display(Name = "Commodity Name")]
        public string CommodityName { get; set; }
        public IEnumerable<SelectListItem> CommodityNames { get; set; }

        public int StallID { get; set; }

        [Display(Name = "Stall Name")]
        public string StallName { get; set; }
        public IEnumerable<SelectListItem> StallNames { get; set; }

        public Decimal Price { get; set; }

        [Range(1, 5)]
        [Display(Name = "Rate The Item")]
        public int? Rating { get; set; }

        public DateTime TimeRegistered { get; set; }
        public string Notes { get; set; }
    }
}
