using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chum_chat_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChumChatInit25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCall_Calls_CallId",
                table: "UserCall");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCall_Users_UserId",
                table: "UserCall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCall",
                table: "UserCall");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "UserCall");

            migrationBuilder.RenameTable(
                name: "UserCall",
                newName: "UserCalls");

            migrationBuilder.RenameIndex(
                name: "IX_UserCall_CallId",
                table: "UserCalls",
                newName: "IX_UserCalls_CallId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserChat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Calls",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCalls",
                table: "UserCalls",
                columns: new[] { "UserId", "CallId" });

            migrationBuilder.CreateTable(
                name: "ChatUser",
                columns: table => new
                {
                    ChatsId = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsersId = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUser", x => new { x.ChatsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ChatUser_Chats_ChatsId",
                        column: x => x.ChatsId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCalls_Calls_CallId",
                table: "UserCalls",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCalls_Users_UserId",
                table: "UserCalls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCalls_Calls_CallId",
                table: "UserCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCalls_Users_UserId",
                table: "UserCalls");

            migrationBuilder.DropTable(
                name: "ChatUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCalls",
                table: "UserCalls");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Calls");

            migrationBuilder.RenameTable(
                name: "UserCalls",
                newName: "UserCall");

            migrationBuilder.RenameIndex(
                name: "IX_UserCalls_CallId",
                table: "UserCall",
                newName: "IX_UserCall_CallId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserChat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "UserCall",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCall",
                table: "UserCall",
                columns: new[] { "UserId", "CallId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCall_Calls_CallId",
                table: "UserCall",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCall_Users_UserId",
                table: "UserCall",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
