using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class changingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MANUAL_MOVIMENTS",
                columns: table => new
                {
                    Month = table.Column<int>(type: "int", fixedLength: true, maxLength: 2, nullable: false),
                    Year = table.Column<int>(type: "int", fixedLength: true, maxLength: 4, nullable: false),
                    EntryNumber = table.Column<int>(type: "int", fixedLength: true, maxLength: 18, nullable: false),
                    CodProduct = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    CodCosif = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: true),
                    Description = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    MovimentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCode = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Value = table.Column<int>(type: "int", fixedLength: true, maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUAL_MOVIMENTS", x => new { x.EntryNumber, x.Month, x.Year });
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    CodProduct = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.CodProduct);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_COSIF",
                columns: table => new
                {
                    CodCosif = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    CodProduct = table.Column<string>(type: "nchar(4)", nullable: true),
                    CodClassification = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    Status = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_COSIF", x => x.CodCosif);
                    table.ForeignKey(
                        name: "FK_PRODUCT_COSIF_PRODUCT_CodProduct",
                        column: x => x.CodProduct,
                        principalTable: "PRODUCT",
                        principalColumn: "CodProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PRODUCT",
                columns: new[] { "CodProduct", "Description", "Status" },
                values: new object[,]
                {
                    { "0001", "Notebook", "A" },
                    { "0002", "Book", "I" },
                    { "0003", "Head Phone", "A" }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_COSIF",
                columns: new[] { "CodCosif", "CodClassification", "CodProduct", "Status" },
                values: new object[,]
                {
                    { "00000000001", "000001", null, "A" },
                    { "00000000002", "000002", null, "I" },
                    { "00000000003", "000003", null, "A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_COSIF_CodProduct",
                table: "PRODUCT_COSIF",
                column: "CodProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MANUAL_MOVIMENTS");

            migrationBuilder.DropTable(
                name: "PRODUCT_COSIF");

            migrationBuilder.DropTable(
                name: "PRODUCT");
        }
    }
}
