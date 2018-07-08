using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Mvc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Controllers
{

    public class StallController : Controller
    {

        private ShukRoutingContext ctx = new ShukRoutingContext();

        // GET: Stall
        public ActionResult Index()
        {
            return View();
        }
        public IQueryable StallDetails()
        {
            var result = ctx.CommoditiesStalls
                .Select(r => new StallModel
                {

                    StallID = r.StallID,
                    StallName = r.Stall.StallName,
                    FirstCoord = r.Stall.FirstCoord,
                    SecondCoord = r.Stall.SecondCoord,

                });
            return result;
        }



<<<<<<< HEAD:ShukRouting/ShukRouting/Controllers/StallController.cs
        public ActionResult Details()
        {
            return View(StallDetails());
=======
        // GET: Stall/Details/5
        [HttpGet]
        public ActionResult Details(string Name)
        {
            var result = ctx.Stalls
                         .Select(s => new StallModel
                         {
                             StallID = s.StallID,
                             StallName = s.StallName,
                             FirstCoord = s.FirstCoord,
                             SecondCoord = s.SecondCoord,
                         });

            return View(result);
>>>>>>> f8dba0f28e9f7ed9fbd0c9cce82d00e217b91046:ShukRouting/ShukRouting.Mvc/Controllers/StallController.cs
        }


        // GET: Stall/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stall Stall)
        {
            if (ModelState.IsValid)
            {

                ctx.Stalls.Add(Stall);
                ctx.SaveChanges();


                return RedirectToAction("About", "Home");
            }
            return View(Stall);
        }

<<<<<<< HEAD:ShukRouting/ShukRouting/Controllers/StallController.cs
=======


>>>>>>> f8dba0f28e9f7ed9fbd0c9cce82d00e217b91046:ShukRouting/ShukRouting.Mvc/Controllers/StallController.cs
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
