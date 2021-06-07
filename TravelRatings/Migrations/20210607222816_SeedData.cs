using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelRatings.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "AverageRating", "City", "Country" },
                values: new object[] { 1, 3.14m, "Portland", "United States" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 1);
        }
    }
}
