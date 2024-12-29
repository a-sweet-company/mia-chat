using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindful_AI_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveChatHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatHistories_Users_UserId",
                table: "ChatHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatHistories",
                table: "ChatHistories");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ChatHistories");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "ChatHistories");

            migrationBuilder.RenameTable(
                name: "ChatHistories",
                newName: "ChatHistory");

            migrationBuilder.RenameIndex(
                name: "IX_ChatHistories_UserId",
                table: "ChatHistory",
                newName: "IX_ChatHistory_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ChatHistoryId",
                table: "Message",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChatHistory",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatHistory",
                table: "ChatHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatHistoryId",
                table: "Message",
                column: "ChatHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatHistory_Users_UserId",
                table: "ChatHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_ChatHistory_ChatHistoryId",
                table: "Message",
                column: "ChatHistoryId",
                principalTable: "ChatHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatHistory_Users_UserId",
                table: "ChatHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_ChatHistory_ChatHistoryId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ChatHistoryId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatHistory",
                table: "ChatHistory");

            migrationBuilder.DropColumn(
                name: "ChatHistoryId",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "ChatHistory",
                newName: "ChatHistories");

            migrationBuilder.RenameIndex(
                name: "IX_ChatHistory_UserId",
                table: "ChatHistories",
                newName: "IX_ChatHistories_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChatHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ChatHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "ChatHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatHistories",
                table: "ChatHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatHistories_Users_UserId",
                table: "ChatHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
