using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IveApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeeds2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Genre", "Name" },
                values: new object[,]
                {
                    { 2, "Pop", "Taylor Swift" },
                    { 3, "Pop", "Elton John" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "VenueId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "MaxLat", "MaxLong", "MinLat", "MinLong", "Name" },
                values: new object[,]
                {
                    { 2, 200, 3.4350000000000001, 3.556, 0.34499999999999997, 0.43534, "Pub" },
                    { 3, 300, -3.2400000000000002, -3.24234, 0.32432, 0.43240000000000001, "Cocktail Bar" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name", "VenueId" },
                values: new object[] { 2, new DateOnly(2024, 8, 20), "Talent Show", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "VenueId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "MaxLat", "MaxLong", "MinLat", "MinLong", "Name" },
                values: new object[] { 1, 200, 3.4350000000000001, 3.556, 0.34499999999999997, 0.43534, "Venue" });
        }
    }
}
