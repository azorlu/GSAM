using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSAM.Migrations
{
    public partial class round : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoundNumber = table.Column<int>(nullable: false),
                    TournamentEventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_FirstPlayerID",
                table: "Competitors",
                column: "FirstPlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_SecondPlayerID",
                table: "Competitors",
                column: "SecondPlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Players_FirstPlayerID",
                table: "Competitors",
                column: "FirstPlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Players_SecondPlayerID",
                table: "Competitors",
                column: "SecondPlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Players_FirstPlayerID",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Players_SecondPlayerID",
                table: "Competitors");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_FirstPlayerID",
                table: "Competitors");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_SecondPlayerID",
                table: "Competitors");
        }
    }
}
