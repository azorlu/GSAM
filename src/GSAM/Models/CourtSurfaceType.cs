using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GSAM.Models
{
    public enum CourtSurfaceType
    {
        [Display(Name="Other")]
        Other,
        [Display(Name="Carpet")]
        Carpet,
        [Display(Name="Clay")]
        Clay,
        [Display(Name="Grass")]
        Grass,
        [Display(Name="Hard")]
        Hard
    }
}
