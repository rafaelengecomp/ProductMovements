using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class changingkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MANUAL_MOVIMENTS_PRODUCT_COSIF_CosifCodProduct_CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodProduct",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_COSIF",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropIndex(
                name: "IX_MANUAL_MOVIMENTS_CosifCodProduct_CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.DropColumn(
                name: "CosifCodProduct",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.AlterColumn<string>(
                name: "CodProduct",
                table: "PRODUCT_COSIF",
                type: "nchar(4)",
                fixedLength: true,
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(4)",
                oldFixedLength: true,
                oldMaxLength: 4);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_COSIF",
                table: "PRODUCT_COSIF",
                column: "CodCosif");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MANUAL_MOVIMENTS_PRODUCT_COSIF_CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodCosif",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_COSIF",
                table: "PRODUCT_COSIF");

            migrationBuilder.DropIndex(
                name: "IX_MANUAL_MOVIMENTS_CosifCodCosif",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.AlterColumn<string>(
                name: "CodProduct",
                table: "PRODUCT_COSIF",
                type: "nchar(4)",
                fixedLength: true,
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(4)",
                oldFixedLength: true,
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CosifCodProduct",
                table: "MANUAL_MOVIMENTS",
                type: "nchar(4)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_COSIF",
                table: "PRODUCT_COSIF",
                columns: new[] { "CodProduct", "CodCosif" });

            migrationBuilder.UpdateData(
                table: "MANUAL_MOVIMENTS",
                keyColumns: new[] { "EntryNumber", "Month", "Year" },
                keyValues: new object[] { 1, 1, 2020 },
                column: "MovimentDate",
                value: new DateTime(2022, 2, 6, 10, 21, 52, 583, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 6, 10, 21, 52, 582, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 6, 10, 21, 52, 583, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.CreateIndex(
                name: "IX_MANUAL_MOVIMENTS_CosifCodProduct_CosifCodCosif",
                table: "MANUAL_MOVIMENTS",
                columns: new[] { "CosifCodProduct", "CosifCodCosif" });

            migrationBuilder.AddForeignKey(
                name: "FK_MANUAL_MOVIMENTS_PRODUCT_COSIF_CosifCodProduct_CosifCodCosif",
                table: "MANUAL_MOVIMENTS",
                columns: new[] { "CosifCodProduct", "CosifCodCosif" },
                principalTable: "PRODUCT_COSIF",
                principalColumns: new[] { "CodProduct", "CodCosif" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_COSIF_PRODUCT_CodProduct",
                table: "PRODUCT_COSIF",
                column: "CodProduct",
                principalTable: "PRODUCT",
                principalColumn: "CodProduct",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
