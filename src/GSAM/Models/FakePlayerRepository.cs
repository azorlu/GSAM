using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class FakePlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> Players => new List<Player>
        {
            new Player { PlayerID = 1, FirstName = "Björn", LastName = "Borg", CountryCode = "SWE",
                Gender = 'M', DateOfBirth = new DateTime(1956, 6, 6) },
            new Player { PlayerID = 2, FirstName = "Jimmy", LastName = "Connors", CountryCode = "USA",
                Gender = 'M', DateOfBirth = new DateTime(1952, 9, 2) },
            new Player { PlayerID = 3, FirstName = "John", LastName = "McEnroe", CountryCode = "USA",
                Gender = 'M', DateOfBirth = new DateTime(1959, 2, 16) },
             new Player { PlayerID = 4, FirstName = "Ivan", LastName = "Lendl", CountryCode = "USA",
                Gender = 'M' }
        };
    }
}
