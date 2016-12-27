using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GSAM.Models;

namespace GSAM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GSAM.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GSAM.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("GSAM.Models.TournamentEvent", b =>
                {
                    b.Property<int>("TournamentEventID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourtSurfaceType");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MatchType");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TournamentID");

                    b.HasKey("TournamentEventID");

                    b.HasIndex("TournamentID");

                    b.ToTable("TournamentEvents");
                });

            modelBuilder.Entity("GSAM.Models.TournamentEvent", b =>
                {
                    b.HasOne("GSAM.Models.Tournament", "Tournament")
                        .WithMany("TournamentEvents")
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
