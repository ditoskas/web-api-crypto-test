using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    CryptoId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.CryptoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_Symbol",
                table: "Cryptos",
                column: "Symbol",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cryptos");
        }
    }
}
