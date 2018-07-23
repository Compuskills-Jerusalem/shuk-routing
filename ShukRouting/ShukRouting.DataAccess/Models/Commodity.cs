using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukRouting.DataAccess.Models
{
    public class Commodity
    {
        [Display(Name = "Commodity ID")]
        public int CommodityID { get; set; }

        [Display(Name = "Commodity Name")]
        public string CommodityName { get; set; }
    }
}
