using ShukRouting.Mvc.Data;
using ShukRouting.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new CommodityRepository();

            var commModel = new CommodityModel()
            {
                CommodityNames = repo.GetCommodetiesName(),
            };
            return View(commModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}