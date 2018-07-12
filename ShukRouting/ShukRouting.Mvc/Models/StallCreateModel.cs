using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShukRouting.Mvc.Models
{
    public class StallCreateModel
    {
        [Display(Name = " Stall ID")]
        public int StallID { get; set; }

        [Required]
        [Display(Name = "Stall Name")]
        [StringLength(75)]
        public string StallName { get; set; }
        public IEnumerable<SelectListItem> StallNames { get; set; }

        [Required]
        [Display(Name = "First Coord")]
        public int FirstCoord { get; set; }

        [Required]
        [Display(Name = "Second Coord")]
        public int SecondCoord { get; set; }
    }
}