using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IveApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeeds3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "ArtistId", "EventId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumns: new[] { "ArtistId", "EventId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumns: new[] { "ArtistId", "EventId" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
