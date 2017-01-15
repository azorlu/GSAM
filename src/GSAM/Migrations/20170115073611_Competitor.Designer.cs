using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GSAM.Models;

namespace GSAM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170115073611_Competitor")]
    partial class Competitor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GSAM.Models.Competitor", b =>
                {
                    b.Property<int>("CompetitorID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstPlayerID");

                    b.Property<int>("SecondPlayerID");

                    b.Property<int>("TournamentEventID");

                    b.HasKey("CompetitorID");

                    b.HasIndex("TournamentEventID");

                    b.ToTable("Competitors");
                });

            modelBuilder.Entity("GSAM.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GSAM.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TournamentID");

                    b.HasKey("TournamentEventID");

                    b.HasIndex("TournamentID");

                    b.ToTable("TournamentEvents");
                });

            modelBuilder.Entity("GSAM.Models.Competitor", b =>
                {
                    b.HasOne("GSAM.Models.TournamentEvent", "TournamentEvent")
                        .WithMany("Competitors")
                        .HasForeignKey("TournamentEventID")
                        .OnDelete(DeleteBehavior.Cascade);
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
