using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext context;
        public EFPlayerRepository(ApplicationDbContext adc)
        {
            context = adc;
        }
        public IEnumerable<Player> Players => context.Players;
    }
    
}
