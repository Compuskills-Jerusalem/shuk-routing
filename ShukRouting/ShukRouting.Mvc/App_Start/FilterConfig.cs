using ShukRouting.Mvc.Controllers;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AddCommoditiesToViewBagFilterAttribute());
        }
    }
}
