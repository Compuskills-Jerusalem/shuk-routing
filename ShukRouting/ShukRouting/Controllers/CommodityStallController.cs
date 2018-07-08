using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Models;
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

        // GET: CommodityStall
        public ActionResult Index()
        {
            return View();
        }



        //Which stall has given food item
        public IQueryable StallPerItem(string name)
        {
            var result = ctx.CommoditiesStalls

              .Where(r => r.Commodity.CommodityName == name)
              .Select(r => new CommodityStallModel
              {
                  StallName = r.Stall.StallName,

              });

            return result;
        }

        // retuzrns Lowest price for given item
        
        public IQueryable LowestPrice(string name)
        {
            var result = ctx.CommoditiesStalls
                            .Where(r => r.Commodity.CommodityName == name)
                            .OrderBy(r => r.Price)
                            .Select(r => new CommodityStallModel
                            {
                                CommodityName = r.Commodity.CommodityName,
                                StallName = r.Stall.StallName,
                                Price = r.Price,
                                Rating = r.Rating ?? 0,
                                TimeRegistered = r.TimeRegistered,
                                Notes = r.Notes,
                            });
                            
            return result;
        }

        
        [HttpGet]
        public ActionResult Details(string name, string filter = "low")
        {

            if (filter == "low")
            {
                return View(LowestPrice(name));

            }
            else 
            {
                return View(StallPerItem(name));
            }


            
        }



       
        // GET: CommodityStall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommodityStall/Create
        [HttpPost]
        public ActionResult Create(CommodityStall commodityStall)
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
