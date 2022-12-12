using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunflowersBookingSystem.Data.Migrations
{
    public partial class phoneCountryRequiredRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(name: "Start Date", type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(name: "End Date", type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(name: "Arrival Time", type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(245)", maxLength: 245, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Email", "FirstName", "PasswordHash", "Phone", "SecondName" },
                values: new object[] { 1, "Bulgaria", "my@email.com", "Sa", null, "012345678", "An" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Email", "FirstName", "PasswordHash", "Phone", "SecondName" },
                values: new object[] { 2, "Bulgaria", "my@email.com", "E", null, "012345678", "I" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Email", "FirstName", "PasswordHash", "Phone", "SecondName" },
                values: new object[] { 3, "Bulgaria", "testing@res.bg", "Se", null, "012345678", "Ed" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Arrival Time", "Comment", "End Date", "Email", "Start Date", "UserId" },
                values: new object[] { 1, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), "It was aight", new DateTime(2022, 12, 12, 22, 28, 25, 76, DateTimeKind.Utc).AddTicks(2651), 1408, new DateTime(2022, 12, 13, 0, 28, 25, 76, DateTimeKind.Local).AddTicks(2620), 3 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Arrival Time", "Comment", "End Date", "Email", "Start Date", "UserId" },
                values: new object[] { 2, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), "same", new DateTime(2022, 12, 12, 22, 28, 25, 76, DateTimeKind.Utc).AddTicks(2659), 404, new DateTime(2022, 12, 13, 0, 28, 25, 76, DateTimeKind.Local).AddTicks(2657), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
