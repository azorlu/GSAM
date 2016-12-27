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
        public IEnumerable<TournamentEvent> TournamentEvents => context.TournamentEvents;
    }
}
