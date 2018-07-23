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
        public List<CommodityModel> GetCommodities()
        {
            using (var context = new ShukRoutingContext())
            {
                List<Commodity> Commodities = new List<Commodity>();

                Commodities = context.Commodities.AsNoTracking()
                                .ToList();

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

        public IEnumerable<SelectListItem> GetCommodetiesName()
        {
            var context = new ShukRoutingContext();

            List<SelectListItem> commodityNmaes = context.Commodities.AsNoTracking()
                                .OrderBy(x => x.CommodityName)
                                .Select(x => new SelectListItem
                                {
                                    Value = x.CommodityID.ToString(),
                                    Text = x.CommodityName
                                }).ToList();

            var comm = new SelectListItem
            {
                Value = null,
                Text = "Select Item ..."
            };

            commodityNmaes.Insert(0, comm);

            return commodityNmaes;
        }
    }
}