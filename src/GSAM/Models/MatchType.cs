using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GSAM.Models
{
    public enum MatchType
    {
        [Display(Name="Other")]
        Other,
        [Display(Name="Men's Singles")]
        MensSingles,
        [Display(Name="Women's Singles")]
        WomensSingles,
        [Display(Name="Men's Doubles")]
        MensDoubles,
        [Display(Name="Women's Doubles")]
        WomensDoubles,
        [Display(Name="Mixed Doubles")]
        MixedDoubles
    }
}
