using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateCryptoNetworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoNetworks",
                columns: table => new
                {
                    CryptoNetworkId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CryptoId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoNetworks", x => x.CryptoNetworkId);
                    table.ForeignKey(
                        name: "FK_CryptoNetworks_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "CryptoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CryptoNetworks",
                columns: new[] { "CryptoNetworkId", "CreatedAt", "CryptoId", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4876), 1L, "Main network for BTC", "main"},
                    { 2L, new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4877), 1L, "Test network for BTC", "test3" },
                    { 3L, new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4879), 2L, "Main network for ETH", "main"},
                    { 4L, new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4880), 3L, "Main network for LTC", "main" },
                    { 5L, new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4881), 4L, "Main network for Dash", "main" }
                });

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.CreateIndex(
                name: "IX_CryptoNetworks_CryptoId",
                table: "CryptoNetworks",
                column: "CryptoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoNetworks");

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 30, 7, 26, 51, 638, DateTimeKind.Utc).AddTicks(5950));
        }
    }
}
