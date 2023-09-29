using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class updatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Musicians_MusicianId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MusicianId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "MusicianId",
                table: "Musicians",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "MusicianId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MusicianId",
                table: "Users",
                column: "MusicianId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Musicians_MusicianId",
                table: "Users",
                column: "MusicianId",
                principalTable: "Musicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Musicians_MusicianId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MusicianId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Musicians",
                newName: "MusicianId");

            migrationBuilder.AlterColumn<int>(
                name: "MusicianId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MusicianId",
                table: "Users",
                column: "MusicianId",
                unique: true,
                filter: "[MusicianId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Musicians_MusicianId",
                table: "Users",
                column: "MusicianId",
                principalTable: "Musicians",
                principalColumn: "MusicianId");
        }
    }
}
