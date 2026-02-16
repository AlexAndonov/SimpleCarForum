using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleCarForum.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Discussions about engines, tuning, performance upgrades, turbo setups, and power optimization.", "Engine & Performance" },
                    { 2, "Troubleshooting issues, regular maintenance, DIY repairs, and service advice.", "Maintenance & Repairs" },
                    { 3, "Battery problems, sensors, ECU errors, OBD diagnostics, and electrical system discussions.", "Electrical & Diagnostics" },
                    { 4, "Car buying tips, resale advice, market insights, and vehicle recommendations.", "Buying & Selling Advice" },
                    { 5, "Open discussions about cars, brands, news, and automotive trends.", "General Discussion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
