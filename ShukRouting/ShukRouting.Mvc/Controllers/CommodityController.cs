using ShukRouting.DataAccess.DataSource;
using ShukRouting.Mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Controllers
{
    public class CommodityController : Controller
    {
        // GET: Commodity
        public ActionResult Index()
        {
            return View();
        }

        // GET: Commodity/Details/5
        [HttpGet]
        public ActionResult Details(string commodityName = "Apple")
        {
            var repo = new CommodityRepository();
            var result = repo.GetCommodities(commodityName);

            return View(result);
        }

        // GET: Commodity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commodity/Create
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

        // GET: Commodity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Commodity/Edit/5
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

        // GET: Commodity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commodity/Delete/5
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
    }
}
