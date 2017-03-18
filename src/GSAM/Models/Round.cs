using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Round
    {
        [DisplayName("Round ID")]
        public int RoundID { get; set; }

        [DisplayName("Tournament Event ID")]
        public int TournamentEventID { get; set; }

        [DisplayName("Competitor Count")]
        public int CompetitorCount { get; set; }

        public Round()
        {
        }
    }
}
