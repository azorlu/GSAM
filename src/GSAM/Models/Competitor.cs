using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Competitor
    {
        [DisplayName("Competitor ID")]
        public int CompetitorID { get; set; }

        [Required(ErrorMessage = "Please select player(s).")]
        [DisplayName("First Player ID")]
        public int FirstPlayerID { get; set; }

        [DisplayName("Second Player ID")]
        public int SecondPlayerID { get; set; }

        [Required(ErrorMessage = "Please select tournament event.")]
        [DisplayName("Tournament Event ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select tournament event.")]
        public int TournamentEventID { get; set; }

        [ForeignKey("TournamentEventID")]
        public TournamentEvent TournamentEvent { get; set; }

        [ForeignKey("FirstPlayerID")]
        public Player FirstPlayer { get; set; }

        [ForeignKey("SecondPlayerID")]
        public Player SecondPlayer { get; set; }

        public Competitor()
        {
        }

        // TODO: add seed number property
    }
}
