using ShukRouting.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShukRouting.DataAccess.Models;

namespace ShukRouting.DataAccess.DataSource
{
   public class ShukRoutingContext: DbContext
    {
        
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Stall> Stalls { get; set; }
        public DbSet<CommodityStall> CommoditiesStalls { get; set; }
    }
}
