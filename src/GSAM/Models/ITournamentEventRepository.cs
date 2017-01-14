using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public interface ITournamentEventRepository
    {
        IEnumerable<TournamentEvent> TournamentEvents { get; }

        void SaveTournamentEvent(TournamentEvent tournamentEvent);
        TournamentEvent DeleteTournamentEvent(int tournamentEventID);
    }
}
