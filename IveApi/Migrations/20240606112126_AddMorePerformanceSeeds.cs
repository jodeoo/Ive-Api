using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IveApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePerformanceSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name", "VenueId" },
                values: new object[] { 3, new DateOnly(2024, 9, 15), "Pop Night", 2 });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "ArtistId", "EventId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumns: new[] { "ArtistId", "EventId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumns: new[] { "ArtistId", "EventId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
