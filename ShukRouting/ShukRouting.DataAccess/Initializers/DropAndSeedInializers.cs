using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukRouting.DataAccess.Initializers
{
    public class DropAndSeedInializer : IDatabaseInitializer<ShukRoutingContext>
    {
        public void InitializeDatabase(ShukRoutingContext context)
        {
            if (!context.Database.CompatibleWithModel(false))
            {
                context.Database.Delete();
                context.Database.Create();
                Seed(context);
            }
        }

        private void Seed(ShukRoutingContext ctx)
        {
            ctx.Stalls.Add(new Stall
            {
                StallID = 1,
                StallName = "Bob's",
                FirstCoord = 1,
                SecondCoord = 1
            });

            ctx.SaveChanges();
        }
    }
}
