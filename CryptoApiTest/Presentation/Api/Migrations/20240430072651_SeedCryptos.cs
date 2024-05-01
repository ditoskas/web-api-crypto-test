using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCryptos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cryptos",
                columns: new[] { "CryptoId", "CreatedAt", "Description", "Symbol", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5946), "Bitcoin", "BTC", null },
                    { 2L, new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5948), "Ethereum", "ETH", null },
                    { 3L, new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5949), "Litecoin", "LTC", null },
                    { 4L, new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5950), "Dash", "Dash", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 4L);
        }
    }
}
