using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Tournament
    {
        [DisplayName("Tournament ID")]
        public int TournamentID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter tournament name.")]
        [DisplayName("Tournament Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter tournament category.")]
        [DisplayName("Tournament Category")]
        [StringLength(100)]
        public string Category { get; set; }

        [InverseProperty("Tournament")]
        public List<TournamentEvent> TournamentEvents { get; set; }

    }
}
