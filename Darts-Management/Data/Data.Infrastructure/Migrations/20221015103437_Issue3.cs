using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Darts.Data.Infrastructure.Migrations
{
    public partial class Issue3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingSpieler",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpielerID = table.Column<int>(nullable: false),
                    TrainingID = table.Column<int>(nullable: false),
                    AngemeldetAm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSpieler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingSpieler_Spieler_SpielerID",
                        column: x => x.SpielerID,
                        principalTable: "Spieler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingSpieler_Training_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Training",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSpieler_SpielerID",
                table: "TrainingSpieler",
                column: "SpielerID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSpieler_TrainingID",
                table: "TrainingSpieler",
                column: "TrainingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingSpieler");
        }
    }
}
