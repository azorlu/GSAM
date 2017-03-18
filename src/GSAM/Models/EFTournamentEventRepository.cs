using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class EFTournamentEventRepository : ITournamentEventRepository
    {
        private ApplicationDbContext context;
        public EFTournamentEventRepository(ApplicationDbContext adc)
        {
            context = adc;
        }
        public IEnumerable<TournamentEvent> TournamentEvents => context.TournamentEvents
                                                        .Include(e => e.Tournament)
                                                        .Include(e => e.Competitors);

        public TournamentEvent DeleteTournamentEvent(int tournamentEventID)
        {
            TournamentEvent dbEntry = context.TournamentEvents.FirstOrDefault(t => t.TournamentEventID == tournamentEventID);
            if (dbEntry != null)
            {
                context.TournamentEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveTournamentEvent(TournamentEvent tournamentEvent)
        {
            if (tournamentEvent.TournamentEventID == 0)
            {
                context.TournamentEvents.Add(tournamentEvent);
            }
            else
            {
                TournamentEvent dbTournamentEvent = 
                    context.TournamentEvents.FirstOrDefault(t => t.TournamentEventID == tournamentEvent.TournamentEventID);
                if (dbTournamentEvent != null)
                {
                    dbTournamentEvent.Name = tournamentEvent.Name;
                    dbTournamentEvent.StartDate = tournamentEvent.StartDate;
                    dbTournamentEvent.EndDate = tournamentEvent.EndDate;
                    dbTournamentEvent.CourtSurfaceType = tournamentEvent.CourtSurfaceType;
                    dbTournamentEvent.MatchType = tournamentEvent.MatchType;
                }
            }
            context.SaveChanges();
        }
    }
}
