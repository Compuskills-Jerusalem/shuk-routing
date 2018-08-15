using ShukRouting.DataAccess.DataSource;
using System.Data.Entity;

namespace ShukRouting.DataAccess.Initializers
{
    public class CreatIfNotExsist : IDatabaseInitializer<ShukRoutingContext>
    {
        public void InitializeDatabase(ShukRoutingContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
        }
    }
}
