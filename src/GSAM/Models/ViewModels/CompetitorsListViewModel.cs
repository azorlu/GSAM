using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models.ViewModels
{
    public class CompetitorsListViewModel
    {
        public IEnumerable<Competitor> Competitors { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public TournamentEvent TournamentEvent { get; set; }

    }
}
