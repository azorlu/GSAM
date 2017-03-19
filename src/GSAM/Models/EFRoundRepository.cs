using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class EFRoundRepository : IRoundRepository
    {
        private ApplicationDbContext context;
        public EFRoundRepository(ApplicationDbContext adc)
        {
            context = adc;
        }
        public IEnumerable<Round> Rounds => context.Rounds;
        public Round DeleteRound(int roundID)
        {
            Round dbEntry = context.Rounds.FirstOrDefault(r => r.RoundID == roundID);
            if (dbEntry != null)
            {
                context.Rounds.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveRound(Round round)
        {
            if (round.RoundID == 0)
            {
                context.Rounds.Add(round);
            }
            else
            {
                Round dbRound = 
                    context.Rounds.FirstOrDefault(r => r.RoundID == round.RoundID);
                if (dbRound != null)
                {
                    dbRound.RoundNumber = round.RoundNumber;
                }
            }
            context.SaveChanges();
        }
    }
}
