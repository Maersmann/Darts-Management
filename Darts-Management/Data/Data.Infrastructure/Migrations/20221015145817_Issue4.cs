using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Darts.Data.Infrastructure.Migrations
{
    public partial class Issue4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestleistung",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Art = table.Column<int>(nullable: false),
                    Herkunft = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: true),
                    TrainingSpielerID = table.Column<int>(nullable: true),
                    GeworfenAm = table.Column<DateTime>(nullable: true),
                    SpielerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestleistung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bestleistung_Spieler_SpielerID",
                        column: x => x.SpielerID,
                        principalTable: "Spieler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bestleistung_TrainingSpieler_TrainingSpielerID",
                        column: x => x.TrainingSpielerID,
                        principalTable: "TrainingSpieler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestleistung_SpielerID",
                table: "Bestleistung",
                column: "SpielerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestleistung_TrainingSpielerID",
                table: "Bestleistung",
                column: "TrainingSpielerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestleistung");
        }
    }
}
