using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class Ajustando_Preenchimento_automatico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PRODUCT",
                columns: new[] { "CodProduct", "Description", "Status" },
                values: new object[,]
                {
                    { "0001", "Notebook", "A" },
                    { "0002", "Book", "I" },
                    { "0003", "Head Phone", "A" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 16, 40, 31, 19, DateTimeKind.Local).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 16, 40, 31, 20, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.InsertData(
                table: "PRODUCT_COSIF",
                columns: new[] { "CodCosif", "CodProduct", "CodClassification", "Status" },
                values: new object[] { "00000000001", "0001", "000001", "A" });

            migrationBuilder.InsertData(
                table: "PRODUCT_COSIF",
                columns: new[] { "CodCosif", "CodProduct", "CodClassification", "Status" },
                values: new object[] { "00000000002", "0002", "000002", "I" });

            migrationBuilder.InsertData(
                table: "PRODUCT_COSIF",
                columns: new[] { "CodCosif", "CodProduct", "CodClassification", "Status" },
                values: new object[] { "00000000003", "0003", "000003", "A" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCT_COSIF",
                keyColumns: new[] { "CodCosif", "CodProduct" },
                keyValues: new object[] { "00000000001", "0001" });

            migrationBuilder.DeleteData(
                table: "PRODUCT_COSIF",
                keyColumns: new[] { "CodCosif", "CodProduct" },
                keyValues: new object[] { "00000000002", "0002" });

            migrationBuilder.DeleteData(
                table: "PRODUCT_COSIF",
                keyColumns: new[] { "CodCosif", "CodProduct" },
                keyValues: new object[] { "00000000003", "0003" });

            migrationBuilder.DeleteData(
                table: "PRODUCT",
                keyColumn: "CodProduct",
                keyValue: "0001");

            migrationBuilder.DeleteData(
                table: "PRODUCT",
                keyColumn: "CodProduct",
                keyValue: "0002");

            migrationBuilder.DeleteData(
                table: "PRODUCT",
                keyColumn: "CodProduct",
                keyValue: "0003");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 16, 17, 33, 425, DateTimeKind.Local).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 16, 17, 33, 425, DateTimeKind.Local).AddTicks(8656));
        }
    }
}
