using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Models;
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
        public List<CommodityStallModel> StallPerItemName(string commodityName)
        {
            using (var context = new ShukRoutingContext())
            {
                List<CommodityStall> Stalls = new List<CommodityStall>();

                Stalls = context.CommoditiesStalls.AsNoTracking()
                    .Where(s => s.Commodity.CommodityName == commodityName)
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

        public List<CommodityStallModel> LowestPriceForItem(string itemName)
        {
            using (var context = new ShukRoutingContext())
            {
                List<CommodityStall> Stalls = new List<CommodityStall>();

                Stalls = context.CommoditiesStalls.AsNoTracking()
                    .Where(s => s.Commodity.CommodityName == itemName)
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
            var repo = new StallRepository();

            var commStallModel = new CommodityStallCreateModel()
            {
                StallNames = repo.GetStallNames(),
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
                        CommodityStallID = commodityStallCreateModel.CommodityStallID,
                        CommodityID = commodityStallCreateModel.CommodityID,
                        StallID = commodityStallCreateModel.StallID,
                        Price = commodityStallCreateModel.Price,
                        Rating = commodityStallCreateModel.Rating,
                        TimeRegistered = commodityStallCreateModel.TimeRegistered,
                        Notes = commodityStallCreateModel.Notes

                    };
                    context.CommoditiesStalls.Add(commoditystall);
                    context.SaveChanges();
                   // return true;
                }
            }
            return false;
        }
    }
}