using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Mvc.Data;
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

        // GET: Stall/Details
        // GET: Stall/Details/5
        [HttpGet]
        public PartialViewResult Details(string stallName)
        {
            var repo = new StallRepository();
            var stallNamesList = repo.GetStallsDetails(stallName);
            return PartialView(stallNamesList);
        }

        // GET: Stall/Create
        [HttpGet]
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


                return RedirectToAction("Index", "Home");
            }
            return View(Stall);
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
