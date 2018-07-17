using ShukRouting.DataAccess.DataSource;
using ShukRouting.DataAccess.Models;
using ShukRouting.Mvc.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Data
{
    public class StallsRepository
    {
        public List<StallModel> GetStalls(string stallName = null)
        {
            using (var context = new ShukRoutingContext())
            {
                List<Stall> stalls = new List<Stall>();

                if (stallName == null)
                {
                    stalls = context.Stalls.AsNoTracking()
                        .ToList();
                }
                else
                {
                    stalls = context.Stalls.AsNoTracking()
                      .Where(s => s.StallName == stallName)
                     .ToList();
                }

                if (stalls != null)
                {
                    List<StallModel> stallsDisplay = new List<StallModel>();
                    foreach (var stall in stalls)
                    {
                        var stallDisplay = new StallModel()
                        {
                            StallID = stall.StallID,
                            StallName = stall.StallName,
                            FirstCoord = stall.FirstCoord,
                            SecondCoord = stall.SecondCoord
                        };
                        stallsDisplay.Add(stallDisplay);
                    }
                    return stallsDisplay;
                }
                return null;
            }
        }

        public StallCreateModel CreateStall() // Create Stall
        {
            var stNameRepo = new StallNamesReppository();

            var stall = new StallCreateModel()
            {
                StallID = 10,//Guid.NewGuid().ToString(),
                StallNames = stNameRepo.GetStallNames(),
                FirstCoord = 10,
                SecondCoord = 10
            };
            return stall;
        }
    }


    public class StallNamesReppository
    {
        public IEnumerable<SelectListItem> GetStallNames()
        {
            using (var context = new ShukRoutingContext())
            {
                List<SelectListItem> stallNames = context.Stalls//.AsNoTracking()
                    .OrderBy(x => x.StallName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.StallID.ToString(),
                        Text = x.StallName
                    }).ToList();

                var stalltip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select stall ---"
                };

                stallNames.Insert(0, stalltip);
                return new SelectList(stallNames, "Value", "Text");

            }
        }
    }
}