using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicians_Users_UserId",
                table: "Musicians");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicians_Users_UserId",
                table: "Musicians",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicians_Users_UserId",
                table: "Musicians");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicians_Users_UserId",
                table: "Musicians",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
