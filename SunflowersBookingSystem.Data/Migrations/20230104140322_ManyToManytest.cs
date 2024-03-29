﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunflowersBookingSystem.Data.Migrations
{
    public partial class ManyToManytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

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
                    ProfilePicture = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "ReservationRooms",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRooms", x => new { x.ReservationsId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_ReservationRooms_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationRooms_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Booked", "Capacity", "Number" },
                values: new object[,]
                {
                    { 1, true, 2, 1 },
                    { 2, false, 2, 2 },
                    { 3, false, 4, 3 },
                    { 4, false, 4, 4 },
                    { 5, false, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Country", "Email", "FirstName", "PasswordHash", "Phone", "ProfilePicture", "SecondName" },
                values: new object[,]
                {
                    { 1, "Bulgaria", "my@email.com", "Sa", null, "012345678", null, "An" },
                    { 2, "Bulgaria", "my@email.com", "E", null, "012345678", null, "I" },
                    { 3, "Bulgaria", "testing@res.bg", "Se", null, "012345678", null, "Ed" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Arrival Time", "Comment", "End Date", "Start Date", "UserId" },
                values: new object[] { 1, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Local), "It was aight", new DateTime(2023, 1, 4, 14, 3, 22, 338, DateTimeKind.Utc).AddTicks(5208), new DateTime(2023, 1, 4, 16, 3, 22, 338, DateTimeKind.Local).AddTicks(5167), 3 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Arrival Time", "Comment", "End Date", "Start Date", "UserId" },
                values: new object[] { 2, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Local), "same", new DateTime(2023, 1, 4, 14, 3, 22, 338, DateTimeKind.Utc).AddTicks(5215), new DateTime(2023, 1, 4, 16, 3, 22, 338, DateTimeKind.Local).AddTicks(5213), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_RoomsId",
                table: "ReservationRooms",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationRooms");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
