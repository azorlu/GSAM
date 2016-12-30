using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> Players { get; }
        void SavePlayer(Player player);
    }
}
