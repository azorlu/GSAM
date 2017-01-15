using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public interface ICompetitorRepository
    {
        IEnumerable<Competitor> Competitors { get; }
        void SaveCompetitor(Competitor competitor);
        Competitor DeleteCompetitor(int competitorID);
        Competitor FindCompetitorByID(int competitorID);
    }
}
