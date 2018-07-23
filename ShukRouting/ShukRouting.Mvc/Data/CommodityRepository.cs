using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShukRouting.Mvc.Data
{
    public class CommodityRepository
    {
        public List<CommodityModel> GetCommodities()
        {
            List<CommodityModel> CommoditiesDisplay = new List<CommodityModel>();
            using (var ctx = new ShukRoutingContext())
            {
                var commodities = ctx.Commodities.AsNoTracking()
                                .ToList();

                foreach (var item in commodities)
                {
                    var comm = new CommodityModel
                    {
                        CommodityID = item.CommodityID,
                        CommodityName = item.CommodityName
                    };
                    CommoditiesDisplay.Add(comm);
                }

            }
            return CommoditiesDisplay;
        }
    }
}