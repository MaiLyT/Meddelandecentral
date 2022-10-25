using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meddelandecentral.Database
{
    public partial class Initdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    User = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomName = table.Column<string>(type: "TEXT", nullable: true),
                    isCleaned = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notis = table.Column<string>(type: "TEXT", nullable: false),
                    isDone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName", "isCleaned" },
                values: new object[] { 1, "Room 1", false });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName", "isCleaned" },
                values: new object[] { 2, "Room 2", false });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName", "isCleaned" },
                values: new object[] { 3, "Room 3", true });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName", "isCleaned" },
                values: new object[] { 4, "Room 4", true });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName", "isCleaned" },
                values: new object[] { 5, "Room 5", true });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName", "isCleaned" },
                values: new object[] { 6, "Conference Room", false });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Notis", "RoomId", "isDone" },
                values: new object[] { 1, "Wakeup call att 05:00 am", 1, false });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_RoomId",
                table: "Todos",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
