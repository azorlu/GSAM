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

        [DisplayName("Round Number")]
        public int RoundNumber { get; set; }

        // to-do :: get competitor count from db (round of 16, semi-final etc.)

        public Round()
        {
        }
    }
}
