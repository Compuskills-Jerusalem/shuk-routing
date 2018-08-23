using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Data
{
    public class CommodityRepository
    {
        public List<CommodityModel> GetCommodities(int? commodityID = null)
        {
            using (var context = new ShukRoutingContext())
            {
                List<Commodity> Commodities = new List<Commodity>();

                if (commodityID != null)
                {
                    Commodities = context.Commodities.AsNoTracking()
                   .Where(x => x.CommodityID == commodityID)
                   .ToList();
                }
                else
                {
                    Commodities = context.Commodities.AsNoTracking()
                    .ToList();
                }

                if (Commodities != null)
                {
                    List<CommodityModel> CommoditiesDisplay = new List<CommodityModel>();

                    foreach (var commodity in Commodities)
                    {
                        var commoditieDisplay = new CommodityModel()
                        {
                            CommodityID = commodity.CommodityID,
                            CommodityName = commodity.CommodityName
                        };
                        CommoditiesDisplay.Add(commoditieDisplay);
                    }
                    return CommoditiesDisplay;
                }
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetCommoditiesNames()
        {
            using (var context = new ShukRoutingContext())
            {
                List<SelectListItem> commodityNames = context.Commodities.AsNoTracking()
                                    .OrderBy(x => x.CommodityName)
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.CommodityID.ToString(),
                                        Text = x.CommodityName
                                    }).ToList();

                var commodityTip = new SelectListItem
                {
                    Value = null,
                    Text = "--- select Item ---"
                };

                commodityNames.Insert(0, commodityTip);
                return new SelectList(commodityNames, "Value", "Text");
            }
        }

        public IEnumerable<CommodityModel> GetCommoditiesNamesForLayout()
        {
            using (var context = new ShukRoutingContext())
            {
                var commodityNames = context.Commodities.AsNoTracking()
                                    .OrderBy(x => x.CommodityName)
                                    .Select(x => new CommodityModel()
                                    {
                                        CommodityID = x.CommodityID,
                                        CommodityName = x.CommodityName

                                    }).ToList();

                return commodityNames;
            }
        }

        public bool SaveNewCommodity(CommodityModel commodity)
        {
            if (commodity != null)
            {
                using (var context = new ShukRoutingContext())
                {
                    Commodity Commodity = new Commodity()
                    {
                        CommodityID = commodity.CommodityID,
                        CommodityName = commodity.CommodityName
                    };
                    context.Commodities.Add(Commodity);
                    context.SaveChanges();
                }
                return true;
            }
            return false;
        }
    }
}