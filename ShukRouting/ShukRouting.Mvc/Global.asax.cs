using ShukRouting.DataAccess.DataSource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShukRouting.DataAccess.Initializers;
namespace ShukRouting.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if debug
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShukRoutingContext>());
#else
            Database.SetInitializer(new DropAndSeedInializer());
#endif
        }
    }
}
