using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleCarForum.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Content", "CreatedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "11111111-1111-1111-1111-111111111111", 1, "Looking for reliable turbo upgrade options for daily driving with moderate power gains. Any proven setups?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Best Turbo Setup for 2.0 TDI?" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "11111111-1111-1111-1111-111111111111", 1, "Is going Stage 2 really worth the additional stress on the engine components?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Stage 1 vs Stage 2 – Worth the Risk?" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "11111111-1111-1111-1111-111111111111", 1, "Experiencing misfires at high RPM after remap. Spark plugs and coils are new. What else to check?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "High RPM Misfire After Tune" },
                    { new Guid("20000000-0000-0000-0000-000000000001"), "11111111-1111-1111-1111-111111111111", 2, "What oil change interval do you follow for turbocharged petrol engines?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Oil Change Interval – 8k or 10k km?" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "11111111-1111-1111-1111-111111111111", 2, "Looking for durable brake pads for mixed city and highway driving.", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Brake Pads Recommendation" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "11111111-1111-1111-1111-111111111111", 2, "Losing coolant slowly but no visible leak. Where should I start diagnosing?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Coolant Leak – Hard to Detect" },
                    { new Guid("30000000-0000-0000-0000-000000000001"), "11111111-1111-1111-1111-111111111111", 3, "Got P0420 code. Is it always catalytic converter failure?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Check Engine Light – P0420" },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "11111111-1111-1111-1111-111111111111", 3, "Brand new battery but drains overnight. Possible parasitic draw?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Battery Drains Overnight" },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "11111111-1111-1111-1111-111111111111", 3, "Looking for a reliable OBD2 scanner for home diagnostics.", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "OBD Scanner Recommendations" },
                    { new Guid("40000000-0000-0000-0000-000000000001"), "11111111-1111-1111-1111-111111111111", 4, "Which is the smarter buy considering maintenance and fuel prices?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Used Diesel vs Petrol in 2025?" },
                    { new Guid("40000000-0000-0000-0000-000000000002"), "11111111-1111-1111-1111-111111111111", 4, "Is buying a 250k km car always a bad decision?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "High Mileage Car – Red Flag?" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "11111111-1111-1111-1111-111111111111", 4, "Looking for reliable SUV under reasonable budget with low maintenance costs.", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Best Budget SUV?" },
                    { new Guid("50000000-0000-0000-0000-000000000001"), "11111111-1111-1111-1111-111111111111", 5, "In your experience, which brand has proven most reliable over the years?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Most Reliable Car Brand?" },
                    { new Guid("50000000-0000-0000-0000-000000000002"), "11111111-1111-1111-1111-111111111111", 5, "Do you still prefer manual transmission in modern cars?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Manual vs Automatic – Still Relevant?" },
                    { new Guid("50000000-0000-0000-0000-000000000003"), "11111111-1111-1111-1111-111111111111", 5, "Do you think EVs will fully replace internal combustion engines?", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Future of Electric Vehicles" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000003"));
        }
    }
}
