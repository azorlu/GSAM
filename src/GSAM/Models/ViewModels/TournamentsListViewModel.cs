using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models.ViewModels
{
    public class TournamentsListViewModel
    {
        public IEnumerable<Tournament> Tournaments { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

    }
}
