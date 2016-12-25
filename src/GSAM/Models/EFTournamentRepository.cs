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
        public IEnumerable<Tournament> Tournaments => context.Tournaments;
    }
}
