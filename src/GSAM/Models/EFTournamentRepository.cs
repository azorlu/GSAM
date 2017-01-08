using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class EFTournamentRepository : ITournamentRepository
    {
        private ApplicationDbContext context;
        public EFTournamentRepository(ApplicationDbContext adc)
        {
            context = adc;
        }
        public IEnumerable<Tournament> Tournaments => context.Tournaments.Include(t => t.TournamentEvents);

        public Tournament DeleteTournament(int tournamentID)
        {
            Tournament dbEntry = context.Tournaments.FirstOrDefault(t => t.TournamentID == tournamentID);
            if (dbEntry != null)
            {
                context.Tournaments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveTournament(Tournament tournament)
        {
            if (tournament.TournamentID == 0)
            {
                context.Tournaments.Add(tournament);
            }
            else
            {
                Tournament dbTournament = context.Tournaments.FirstOrDefault(t => t.TournamentID == tournament.TournamentID);
                if (dbTournament != null)
                {
                    dbTournament.Name = tournament.Name;
                    dbTournament.Category = tournament.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
