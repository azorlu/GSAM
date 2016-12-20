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
        }
    }
}
