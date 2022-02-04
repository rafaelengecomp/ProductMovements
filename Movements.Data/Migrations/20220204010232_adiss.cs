using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class adiss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MANUAL_MOVIMENTS",
                columns: new[] { "CodCosif", "CodProduct", "EntryNumber", "Month", "Year", "CosifCodCosif", "CosifCodProduct", "Description", "MovimentDate", "UserCode", "Value" },
                values: new object[] { "00000000001", "0001", 1, 1, 2020, null, null, "Notebook", new DateTime(2022, 2, 3, 22, 2, 31, 639, DateTimeKind.Local).AddTicks(8846), "TESTE", 10000 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 22, 2, 31, 638, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 22, 2, 31, 639, DateTimeKind.Local).AddTicks(6643));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MANUAL_MOVIMENTS",
                keyColumns: new[] { "CodCosif", "CodProduct", "EntryNumber", "Month", "Year" },
                keyValues: new object[] { "00000000001", "0001", 1, 1, 2020 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 21, 58, 44, 538, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 21, 58, 44, 540, DateTimeKind.Local).AddTicks(1307));
        }
    }
}
