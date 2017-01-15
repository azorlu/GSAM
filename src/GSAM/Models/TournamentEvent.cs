using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class TournamentEvent
    {
        [DisplayName("Event ID")]
        public int TournamentEventID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter tournament event name.")]
        [DisplayName("Event Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select match type.")]
        [DisplayName("Match Type")]
        public MatchType MatchType { get; set; }

        [Required(ErrorMessage = "Please select court surface type.")]
        [DisplayName("Court Surface Type")]
        public CourtSurfaceType CourtSurfaceType { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select start date.")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select end date.")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please select tournament.")]
        [DisplayName("Tournament ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select tournament.")]
        public int TournamentID { get; set; }
        [ForeignKey("TournamentID")]
        public Tournament Tournament { get; set; }

        [InverseProperty("TournamentEvent")]
        public List<Competitor> Competitors { get; set; }

    }
}
