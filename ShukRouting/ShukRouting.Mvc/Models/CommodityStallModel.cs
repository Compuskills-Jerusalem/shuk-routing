using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShukRouting.Models
{
    public class CommodityStallModel
    {
        public int CommodityID { get; set; }
        public string CommodityName { get; set; }

        public int StallID { get; set; }
        public string StallName { get; set; }
        public int FirstCoord { get; set; }
        public int SecondCoord { get; set; }

        public Decimal Price { get; set; }
        public int? Rating { get; set; }
        public DateTime TimeRegistered { get; set; }
        public string Notes { get; set; }
    }
}