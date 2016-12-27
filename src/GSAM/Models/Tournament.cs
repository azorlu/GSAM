using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        [InverseProperty("Tournament")]
        public List<TournamentEvent> TournamentEvents { get; set; }

    }
}
