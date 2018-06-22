using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukRouting.DataAccess.Models
{
   public class Stall
    {
        public int ID { get; set; }
        public string StallName { get; set; }
        public int FirstCoord { get; set; }
        public int SecondCoord { get; set; }
    }
}
