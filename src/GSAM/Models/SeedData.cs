using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GSAM.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            #region Seed Tournaments

            if (!context.Tournaments.Any())
            {
                context.Tournaments.AddRange(
                    new Tournament {  Name = "Wimbledon Championships", Category = "Grand Slam" }, 
                    new Tournament {  Name = "French Open", Category = "Grand Slam" },
                    new Tournament { Name = "US Open", Category = "Grand Slam" },
                    new Tournament { Name = "Australian Open", Category = "Grand Slam" },
                    new Tournament { Name = "Turbo Tennis", Category = "Exhibition" }
                    );
                context.SaveChanges();
            }

            #endregion

            #region Seed Tournament Events

            if (!context.TournamentEvents.Any())
            {
                context.TournamentEvents.AddRange(
                    new TournamentEvent {
                        TournamentID = 1,
                        Name = "Wimbledon Championships – Men's Singles",
                        StartDate = new DateTime(1980, 6, 1),
                        EndDate = new DateTime(1980, 6, 23),
                        CourtSurfaceType = CourtSurfaceType.Grass,
                        MatchType = MatchType.MensSingles
                    },
                     new TournamentEvent
                     {
                         TournamentID = 1,
                         Name = "Wimbledon Championships – Men's Doubles",
                         StartDate = new DateTime(1980, 6, 1),
                         EndDate = new DateTime(1980, 6, 23),
                         CourtSurfaceType = CourtSurfaceType.Grass,
                         MatchType = MatchType.MensDoubles
                     }
                    );
                context.SaveChanges();
            }

            #endregion

            #region Seed Players
            if (!context.Players.Any())
            {
                context.Players.AddRange(
                    new Player
                    {
                        FirstName = "Björn",
                        LastName = "Borg",
                        CountryCode = "SWE",
                        Gender = true,
                        DateOfBirth = new DateTime(1956, 6, 6)
                    },
                    new Player
                    {
                        FirstName = "Jimmy",
                        LastName = "Connors",
                        CountryCode = "USA",
                        Gender = true,
                        DateOfBirth = new DateTime(1952, 9, 2)
                    },
                    new Player
                    {
                        FirstName = "John",
                        LastName = "McEnroe",
                        CountryCode = "USA",
                        Gender = true,
                        DateOfBirth = new DateTime(1959, 2, 16)
                    },
                     new Player
                     {
                         FirstName = "Ivan",
                         LastName = "Lendl",
                         CountryCode = "USA",
                         Gender = true,
                         DateOfBirth = new DateTime(1960, 3, 7)
                     }
                    );
                context.SaveChanges();
            } 
            #endregion
        }
    }
}
