using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IveApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Genre", "Name" },
                values: new object[] { 1, "Pop", "Dua Lipa" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name", "VenueId" },
                values: new object[] { 1, new DateOnly(2024, 10, 5), "Open Mic Night", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
