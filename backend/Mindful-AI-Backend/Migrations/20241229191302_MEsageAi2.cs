using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindful_AI_Backend.Migrations
{
    /// <inheritdoc />
    public partial class MEsageAi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "aiId",
                table: "Message",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_aiId",
                table: "Message",
                column: "aiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Ai_aiId",
                table: "Message",
                column: "aiId",
                principalTable: "Ai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Ai_aiId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_aiId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "aiId",
                table: "Message");
        }
    }
}
