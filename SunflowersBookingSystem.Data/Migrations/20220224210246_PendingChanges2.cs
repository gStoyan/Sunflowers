using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunflowersBookingSystem.Data.Migrations
{
    public partial class PendingChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "37c02888-a8be-4142-befa-a81272bd1f5d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fa4b8e00-4cbc-42e9-8ae9-a249b778e9b4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "997f0d89-a0a9-4f8a-bdd8-0089f11dd718");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3d0f88ce-8db2-43d1-9672-38bb75d0a0bd");
        }
    }
}
