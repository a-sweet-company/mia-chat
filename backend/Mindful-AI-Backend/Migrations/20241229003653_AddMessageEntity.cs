using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindful_AI_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ais",
                table: "Ais");

            migrationBuilder.RenameTable(
                name: "Ais",
                newName: "Ai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ai",
                table: "Ai",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ai",
                table: "Ai");

            migrationBuilder.RenameTable(
                name: "Ai",
                newName: "Ais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ais",
                table: "Ais",
                column: "Id");
        }
    }
}
