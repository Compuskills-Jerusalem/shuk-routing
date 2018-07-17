using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukRouting.DataAccess.Models
{
    
    [Table("CommoditiesStalls")]
    public class CommodityStall
    {
        [Key]
        public int CommodityStallID { get; set; }

        public int CommodityID { get; set; }
        public virtual Commodity Commodity { get; set; }

        public int StallID { get; set; }
        public virtual Stall Stall { get; set; }

        public Decimal Price { get; set; }
        public int? Rating { get; set; }
        public DateTime TimeRegistered { get; set; }
        public string Notes { get; set; }
    }
}
