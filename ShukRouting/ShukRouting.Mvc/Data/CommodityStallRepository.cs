using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShukRouting.Mvc.Data
{
    public class CommodityStallRepository
    {
        public List<CommodityStallModel> StallPerCommodityID(int? commodityID)
        {
            using (var context = new ShukRoutingContext())
            {
                List<CommodityStall> Stalls = new List<CommodityStall>();

                Stalls = context.CommoditiesStalls.AsNoTracking()
                    .Where(s => s.CommodityID == commodityID)
                    .ToList();

                if (Stalls != null)
                {
                    List<CommodityStallModel> stallsDisplay = new List<CommodityStallModel>();

                    foreach (var stall in Stalls)
                    {
                        var stallDisplay = new CommodityStallModel()
                        {
                            StallName = stall.Stall.StallName,
                            FirstCoord = stall.Stall.FirstCoord,
                            SecondCoord = stall.Stall.SecondCoord
                        };
                        stallsDisplay.Add(stallDisplay);
                    }
                    return stallsDisplay;
                }
                return null;
            }
        }

        public List<CommodityStallModel> LowestPriceForItem(int? commodityID)
        {
            using (var context = new ShukRoutingContext())
            {
                List<CommodityStall> Stalls = new List<CommodityStall>();

                Stalls = context.CommoditiesStalls.AsNoTracking()
                    .Where(s => s.CommodityID == commodityID)
                    .OrderBy(s => s.Price)
                    .ToList();

                if (Stalls != null)
                {
                    List<CommodityStallModel> StallsDisplay = new List<CommodityStallModel>();

                    foreach (var stall in Stalls)
                    {
                        var Stalldisplay = new CommodityStallModel()
                        {
                            CommodityName = stall.Commodity.CommodityName,
                            StallName = stall.Stall.StallName,
                            Price = stall.Price,
                            Rating = stall.Rating,
                            TimeRegistered = stall.TimeRegistered,
                            Notes = stall.Notes
                        };
                        StallsDisplay.Add(Stalldisplay);
                    }
                    return StallsDisplay;
                }
                return null;
            }
        }

        public CommodityStallCreateModel CreateCommStall()
        {
            var stallRepo = new StallRepository();
            var commodityRepo = new CommodityRepository();

            var commStallModel = new CommodityStallCreateModel()
            {
                CommodityNames = commodityRepo.GetCommodetiesName(),
                StallNames = stallRepo.GetStallNames(),
            };

            return commStallModel;
        }

        public bool CommodityStallSave(CommodityStallCreateModel commodityStallCreateModel)
        {
            if (commodityStallCreateModel != null)
            {
                using (var context = new ShukRoutingContext())
                {
                    var commoditystall = new CommodityStall()
                    {
                        CommodityID = commodityStallCreateModel.CommodityID,
                        StallID = commodityStallCreateModel.StallID,
                        Price = commodityStallCreateModel.Price,
                        Rating = commodityStallCreateModel.Rating,
                        TimeRegistered = DateTime.Now,
                        Notes = commodityStallCreateModel.Notes


                    };
                    commoditystall.Commodity = context.Commodities.Find(commodityStallCreateModel.CommodityID);

                    context.CommoditiesStalls.Add(commoditystall);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}