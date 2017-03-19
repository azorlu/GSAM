using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public interface IRoundRepository
    {
        IEnumerable<Round> Rounds { get; }

        void SaveRound(Round round);

        Round DeleteRound(int roundID);

    }
}
