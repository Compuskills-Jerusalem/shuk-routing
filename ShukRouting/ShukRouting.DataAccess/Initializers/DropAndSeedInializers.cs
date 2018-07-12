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
 public   class DropAndSeedInializers : IDatabaseInitializer<ShukRoutingContext>
    {
        public void InitializeDatabase(ShukRoutingContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }

            if (!context.Database.CompatibleWithModel(false))
            {
                context.Database.Delete();
                context.Database.Create();
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
