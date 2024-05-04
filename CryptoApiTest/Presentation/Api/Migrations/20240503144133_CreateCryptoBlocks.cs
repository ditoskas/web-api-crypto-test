using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateCryptoBlocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoBlocks",
                columns: table => new
                {
                    CryptoBlockId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hash = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Height = table.Column<long>(type: "INTEGER", nullable: true),
                    Chain = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Total = table.Column<string>(type: "TEXT", nullable: true),
                    Fees = table.Column<long>(type: "INTEGER", nullable: true),
                    BaseFee = table.Column<long>(type: "INTEGER", nullable: true),
                    Size = table.Column<long>(type: "INTEGER", nullable: true),
                    Ver = table.Column<int>(type: "INTEGER", nullable: true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReceivedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CoinbaseAddr = table.Column<string>(type: "TEXT", nullable: true),
                    RelayedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Nonce = table.Column<int>(type: "INTEGER", nullable: true),
                    NTx = table.Column<int>(type: "INTEGER", nullable: true),
                    PrevBlock = table.Column<string>(type: "TEXT", nullable: true),
                    MrklRoot = table.Column<string>(type: "TEXT", nullable: true),
                    Depth = table.Column<int>(type: "INTEGER", nullable: true),
                    PrevBlockUrl = table.Column<string>(type: "TEXT", nullable: true),
                    TxUrl = table.Column<string>(type: "TEXT", nullable: true),
                    NextTxids = table.Column<string>(type: "TEXT", nullable: true),
                    CryptoNetworkId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoBlocks", x => x.CryptoBlockId);
                    table.ForeignKey(
                        name: "FK_CryptoBlocks_CryptoNetworks_CryptoNetworkId",
                        column: x => x.CryptoNetworkId,
                        principalTable: "CryptoNetworks",
                        principalColumn: "CryptoNetworkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CryptoInternalTransactions",
                columns: table => new
                {
                    CryptoInternalTransactionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hash = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CryptoBlockId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoInternalTransactions", x => x.CryptoInternalTransactionId);
                    table.ForeignKey(
                        name: "FK_CryptoInternalTransactions_CryptoBlocks_CryptoBlockId",
                        column: x => x.CryptoBlockId,
                        principalTable: "CryptoBlocks",
                        principalColumn: "CryptoBlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CryptoTransactions",
                columns: table => new
                {
                    CryptoTransactionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hash = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CryptoBlockId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoTransactions", x => x.CryptoTransactionId);
                    table.ForeignKey(
                        name: "FK_CryptoTransactions_CryptoBlocks_CryptoBlockId",
                        column: x => x.CryptoBlockId,
                        principalTable: "CryptoBlocks",
                        principalColumn: "CryptoBlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.CreateIndex(
                name: "IX_CryptoBlocks_CryptoNetworkId",
                table: "CryptoBlocks",
                column: "CryptoNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoBlocks_Hash",
                table: "CryptoBlocks",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CryptoInternalTransactions_CryptoBlockId",
                table: "CryptoInternalTransactions",
                column: "CryptoBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoInternalTransactions_Hash",
                table: "CryptoInternalTransactions",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CryptoTransactions_CryptoBlockId",
                table: "CryptoTransactions",
                column: "CryptoBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoTransactions_Hash",
                table: "CryptoTransactions",
                column: "Hash",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoInternalTransactions");

            migrationBuilder.DropTable(
                name: "CryptoTransactions");

            migrationBuilder.DropTable(
                name: "CryptoBlocks");

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "CryptoNetworks",
                keyColumn: "CryptoNetworkId",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4881));

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
        }
    }
}
