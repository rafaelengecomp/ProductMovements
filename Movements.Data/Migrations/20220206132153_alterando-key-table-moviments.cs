using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class alterandokeytablemoviments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MANUAL_MOVIMENTS",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.AlterColumn<string>(
                name: "CodCosif",
                table: "MANUAL_MOVIMENTS",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "CodProduct",
                table: "MANUAL_MOVIMENTS",
                type: "nchar(4)",
                fixedLength: true,
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(4)",
                oldFixedLength: true,
                oldMaxLength: 4);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MANUAL_MOVIMENTS",
                table: "MANUAL_MOVIMENTS",
                columns: new[] { "EntryNumber", "Month", "Year" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MANUAL_MOVIMENTS",
                table: "MANUAL_MOVIMENTS");

            migrationBuilder.AlterColumn<string>(
                name: "CodProduct",
                table: "MANUAL_MOVIMENTS",
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

            migrationBuilder.AlterColumn<string>(
                name: "CodCosif",
                table: "MANUAL_MOVIMENTS",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MANUAL_MOVIMENTS",
                table: "MANUAL_MOVIMENTS",
                columns: new[] { "EntryNumber", "Month", "Year", "CodProduct", "CodCosif" });

            migrationBuilder.UpdateData(
                table: "MANUAL_MOVIMENTS",
                keyColumns: new[] { "CodCosif", "CodProduct", "EntryNumber", "Month", "Year" },
                keyValues: new object[] { "00000000001", "0001", 1, 1, 2020 },
                column: "MovimentDate",
                value: new DateTime(2022, 2, 3, 22, 2, 31, 639, DateTimeKind.Local).AddTicks(8846));

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
    }
}
