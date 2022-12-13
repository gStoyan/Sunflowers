using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunflowersBookingSystem.Data.Migrations
{
    public partial class ProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "nvarchar(240)",
                maxLength: 240,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End Date", "Start Date" },
                values: new object[] { new DateTime(2022, 12, 13, 11, 11, 15, 619, DateTimeKind.Utc).AddTicks(2005), new DateTime(2022, 12, 13, 13, 11, 15, 619, DateTimeKind.Local).AddTicks(1975) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End Date", "Start Date" },
                values: new object[] { new DateTime(2022, 12, 13, 11, 11, 15, 619, DateTimeKind.Utc).AddTicks(2010), new DateTime(2022, 12, 13, 13, 11, 15, 619, DateTimeKind.Local).AddTicks(2009) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End Date", "Start Date" },
                values: new object[] { new DateTime(2022, 12, 12, 22, 28, 25, 76, DateTimeKind.Utc).AddTicks(2651), new DateTime(2022, 12, 13, 0, 28, 25, 76, DateTimeKind.Local).AddTicks(2620) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End Date", "Start Date" },
                values: new object[] { new DateTime(2022, 12, 12, 22, 28, 25, 76, DateTimeKind.Utc).AddTicks(2659), new DateTime(2022, 12, 13, 0, 28, 25, 76, DateTimeKind.Local).AddTicks(2657) });
        }
    }
}
