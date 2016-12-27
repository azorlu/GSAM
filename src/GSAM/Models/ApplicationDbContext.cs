using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentEvent> TournamentEvents { get; set; }

    }
}
