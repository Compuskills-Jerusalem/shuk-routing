using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Models;
using ShukRouting.Mvc.Data;
using ShukRouting.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Controllers
{
    public class CommodityStallController : Controller
    {
        private ShukRoutingContext ctx = new ShukRoutingContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Details(string name= "Banana", string filter = "low")
        {   
            var repo = new CommodityStallRepository();

            if (filter == "low")
            {
                var results = repo.LowestPriceForItem(name);
                return PartialView(results);
            }
            else
            {
                var results = repo.StallPerItemName(name);
                return PartialView(results);
            }
        }

        // GET: CommodityStall/Create
        public ActionResult Create()
        {
            var repo = new CommodityStallRepository();
            var result = repo.CreateCommStall();

            return View(result);
        }

        // POST: CommodityStall/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "CommodityStallID, CommodityID, StallID, Price, Rating, TimeRegistered, Notes")]CommodityStallCreateModel model)
        {
            var repo = new CommodityStallRepository();
            bool saved = repo.CommodityStallSave(model);
            if (saved)
            {
                return RedirectToAction("Details");
            }
            return View(model);
        }

        // GET: CommodityStall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommodityStall/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CommodityStall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommodityStall/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
