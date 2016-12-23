using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSAM.Models;

namespace GSAM.Models.ViewModels
{
    public class PlayersListViewModel
    {
        public IEnumerable<Player> Players { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
