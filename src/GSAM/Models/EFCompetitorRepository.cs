using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class EFCompetitorRepository : ICompetitorRepository
    {
        private ApplicationDbContext context;
        public EFCompetitorRepository(ApplicationDbContext adc)
        {
            context = adc;
        }
        public IEnumerable<Competitor> Competitors
        {
            get
            {
                IEnumerable<Competitor> competitors = context.Competitors
                .Include(c => c.TournamentEvent)
                .Include(c => c.FirstPlayer);
                //.Include(c => c.SecondPlayer); // TODO :: Include optional foreign key

                return competitors;
            }
        }
            
        public Competitor DeleteCompetitor(int competitorID)
        {
            Competitor dbEntry = FindCompetitorByID(competitorID);
            if (dbEntry != null)
            {
                context.Competitors.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Competitor FindCompetitorByID(int competitorID)
        {
            Competitor dbCompetitor = context.Competitors.FirstOrDefault(c => c.CompetitorID == competitorID);

            return dbCompetitor;
        }

        public void SaveCompetitor(Competitor Competitor)
        {
            if (Competitor.CompetitorID == 0)
            {
                context.Competitors.Add(Competitor);
            }
            else
            {
                Competitor dbCompetitor = FindCompetitorByID(Competitor.CompetitorID);
                if (dbCompetitor != null)
                {
                    dbCompetitor.FirstPlayerID = Competitor.FirstPlayerID;
                    dbCompetitor.SecondPlayerID = Competitor.SecondPlayerID;
                }
            }
            context.SaveChanges();
        }
    }
    
}
