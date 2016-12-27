using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class TournamentEvent
    {
        public int TournamentEventID { get; set; }
   
        public string Name { get; set; }

        public MatchType MatchType { get; set; }

        public CourtSurfaceType CourtSurfaceType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TournamentID { get; set; }
        [ForeignKey("TournamentID")]
        public Tournament Tournament { get; set; }

    }
}
