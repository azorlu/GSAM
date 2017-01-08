using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> Tournaments { get; }

        void SaveTournament(Tournament tournament);
        Tournament DeleteTournament(int tournamentID);

    }
}
