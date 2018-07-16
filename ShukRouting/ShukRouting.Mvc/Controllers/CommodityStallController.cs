using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Models;
using ShukRouting.Mvc.Data;
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
        public ActionResult Details(string name, string filter = "low")
        {
            var repo = new CommodityStallRepository();

            if (filter == "low")
            {
                var results = repo.LowestPriceForItem(name);
                return View(results);
            }
            else
            {
                var results = repo.StallPerItemName(name);
                return View(results);
            }
        }

        // GET: CommodityStall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommodityStall/Create
        //This method will be moved to CommoditiesStallRepository
        [HttpPost]
        public ActionResult Create(CommoditiesStalls commodityStall)
        {
            if (ModelState.IsValid)
            {
                ctx.CommoditiesStalls.Add(commodityStall);
                //ctx.Stalls.Add(Stall);
                ctx.SaveChanges();


                return RedirectToAction("Details");
            }

            return View();
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
