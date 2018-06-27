using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Controllers
{

    public class StallController : Controller
    {
        private ShukRoutingContext ctx = new ShukRoutingContext();
        // GET: Stall
        public ActionResult Index()
        {
            return View();
        }

        // GET: Stall/Details/5
        [HttpGet]
        public PartialViewResult Details()
        {
            //var result = ctx.Stalls
            //   stall in stalls
            //            .Select(r => new StallModel
            //            {
            //                StallID = r.ID,
            //                StallName = r.StallName,
            //                FirstCoord = r.FirstCoord,
            //                SecondCoord = r.SecondCoord,
            //                CommodityID = r.ID
            //            });
            var result = from stall in ctx.Stalls
                         from com in ctx.Commodities
                         where stall.StallID == 1
                         select new StallModel
                         {
                             StallID = stall.StallID,
                            StallName = stall.StallName,
                            FirstCoord = stall.FirstCoord,
                            SecondCoord=stall.SecondCoord,
                            CommodityID = com.CommodityID
                         };

              return PartialView(result);
        }

        // GET: Stall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stall/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stall/Edit/5
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

        // GET: Stall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stall/Delete/5
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
