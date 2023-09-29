using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfBand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfFoundation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicianBand",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticiapationDateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticiapationDateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianBand", x => new { x.BandID, x.MusicianId });
                    table.ForeignKey(
                        name: "FK_MusicianBand_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianBand_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicianBand_MusicianId",
                table: "MusicianBand",
                column: "MusicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianBand");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
