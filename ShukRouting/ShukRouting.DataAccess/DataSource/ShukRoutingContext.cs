using ShukRouting.DataAccess.Models;
using System.Data.Entity;

namespace ShukRouting.DataAccess.DataSource
{
    public class ShukRoutingContext : DbContext
    {

        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Stall> Stalls { get; set; }
        public DbSet<CommodityStall> CommoditiesStalls { get; set; }
    }
}
