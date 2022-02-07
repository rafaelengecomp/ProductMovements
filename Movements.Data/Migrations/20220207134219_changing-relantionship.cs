using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class changingrelantionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MANUAL_MOVIMENTS_PRODUCT_COSIF_CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodCosif",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropIndex(
                name: "IX_MANUAL_MOVIMENTS_CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.DropColumn(
                name: "CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.AddColumn<string>(
                name: "CosifCodCosif",
                table: "PRODUCT_COSIF",
                type: "nchar(11)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MANUAL_MOVIMENTS",
                keyColumns: new[] { "EntryNumber", "Month", "Year" },
                keyValues: new object[] { 1, 1, 2020 },
                column: "MovimentDate",
                value: new DateTime(2022, 2, 7, 10, 42, 18, 846, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 7, 10, 42, 18, 845, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 7, 10, 42, 18, 846, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_COSIF_CodProduct",
                table: "PRODUCT_COSIF",
                column: "CodProduct");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_COSIF_CosifCodCosif",
                table: "PRODUCT_COSIF",
                column: "CosifCodCosif");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodProduct",
                table: "PRODUCT_COSIF",
                column: "CodProduct",
                principalTable: "PRODUCT",
                principalColumn: "CodProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_COSIF_CosifCodCosif",
                table: "PRODUCT_COSIF",
                column: "CosifCodCosif",
                principalTable: "PRODUCT_COSIF",
                principalColumn: "CodCosif",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodProduct",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_COSIF_CosifCodCosif",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_COSIF_CodProduct",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_COSIF_CosifCodCosif",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropColumn(
                name: "CosifCodCosif",
                table: "PRODUCT_COSIF");

            migrationBuilder.AddColumn<string>(
                name: "CosifCodCosif",
                table: "MANUAL_MOVIMENTS",
                type: "nchar(11)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MANUAL_MOVIMENTS",
                keyColumns: new[] { "EntryNumber", "Month", "Year" },
                keyValues: new object[] { 1, 1, 2020 },
                column: "MovimentDate",
                value: new DateTime(2022, 2, 7, 10, 1, 14, 327, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 7, 10, 1, 14, 325, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 7, 10, 1, 14, 326, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.CreateIndex(
                name: "IX_MANUAL_MOVIMENTS_CosifCodCosif",
                table: "MANUAL_MOVIMENTS",
                column: "CosifCodCosif");

            migrationBuilder.AddForeignKey(
                name: "FK_MANUAL_MOVIMENTS_PRODUCT_COSIF_CosifCodCosif",
                table: "MANUAL_MOVIMENTS",
                column: "CosifCodCosif",
                principalTable: "PRODUCT_COSIF",
                principalColumn: "CodCosif",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodCosif",
                table: "PRODUCT_COSIF",
                column: "CodCosif",
                principalTable: "PRODUCT",
                principalColumn: "CodProduct",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
