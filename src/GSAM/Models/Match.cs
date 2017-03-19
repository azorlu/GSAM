using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Match
    {
        [DisplayName("Match ID")]
        public int MatchID { get; set; }

        [DisplayName("Tournament Event ID")]
        public int TournamentEventID { get; set; }

        [DisplayName("Round ID")]
        public int RoundID { get; set; }

        [DisplayName("Match Type")]
        public MatchType MatchType { get; set; }

        [DisplayName("Home")]
        public Competitor HomeCompetitor { get; set; }

        [DisplayName("Away")]
        public Competitor AwayCompetitor { get; set; }

        [DisplayName("Home Score")]
        public int HomeScore { get; set; }

        [DisplayName("Away Score")]
        public int AwayScore { get; set; }

        [DisplayName("Completed")]
        public bool Completed { get; set; }

        [DisplayName("Winner ID")]
        public int WinnerID { get; set; }

        [DisplayName("Loser Retired")]
        public bool LoserRetired { get; set; }

        [DisplayName("Loser Disqualified")]
        public bool LoserDisqualified { get; set; }

        public Match()
        {
        }
    }
}
