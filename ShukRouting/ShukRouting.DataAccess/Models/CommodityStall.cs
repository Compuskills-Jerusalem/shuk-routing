using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukRouting.DataAccess.Models
{
    public class CommodityStall
    {
        public int ID { get; set; }

        public int CommodityID { get; set; }
        public virtual Commodity Commodity { get; set; }

        public int StallID { get; set; }
        public virtual Stall Stall { get; set; }

        public double Price { get; set; }
        public int Rating { get; set; }
        public DateTime TimeRegistered { get; set; }
        public string Notes { get; set; }
    }
}
