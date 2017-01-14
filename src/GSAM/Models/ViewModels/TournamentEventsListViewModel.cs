using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models.ViewModels
{
    public class TournamentEventsListViewModel
    {
        public IEnumerable<TournamentEvent> TournamentEvents { get; set; }

        public PagingInfo PagingInfo { get; set; }

    }
}
