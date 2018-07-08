using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShukRouting.Mvc.Models
{
    public class StallModel
    {
        public int StallID { get; set; }
        public string StallName { get; set; }
        public int FirstCoord { get; set; }
        public int SecondCoord { get; set; }
        
    }
}