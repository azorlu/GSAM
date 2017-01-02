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

        public Player DeletePlayer(int playerID)
        {
            Player dbEntry = context.Players.FirstOrDefault(p => p.PlayerID == playerID);
            if (dbEntry != null)
            {
                context.Players.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SavePlayer(Player player)
        {
            if (player.PlayerID == 0)
            {
                context.Players.Add(player);
            }
            else
            {
                Player dbPlayer = context.Players.FirstOrDefault(p => p.PlayerID == player.PlayerID);
                if (dbPlayer != null)
                {
                    dbPlayer.FirstName = player.FirstName;
                    dbPlayer.LastName = player.LastName;
                    dbPlayer.Gender = player.Gender;
                    dbPlayer.DateOfBirth = player.DateOfBirth;
                    dbPlayer.CountryCode = player.CountryCode;
                }
            }
            context.SaveChanges();
        }
    }
    
}
