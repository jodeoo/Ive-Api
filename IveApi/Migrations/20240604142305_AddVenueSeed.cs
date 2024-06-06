using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IveApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVenueSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "MaxLat", "MaxLong", "MinLat", "MinLong", "Name" },
                values: new object[] { 1, 200, 3.4350000000000001, 3.556, 0.34499999999999997, 0.43534, "Venue" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
