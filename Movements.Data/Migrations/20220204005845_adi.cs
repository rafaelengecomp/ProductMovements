using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class adi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 21, 54, 31, 669, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 3, 21, 54, 31, 670, DateTimeKind.Local).AddTicks(7413));
        }
    }
}
