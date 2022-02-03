using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movements.Data.Migrations
{
    public partial class Ajustando_propriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
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
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_COSIF",
                columns: table => new
                {
                    CodProduct = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    CodCosif = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    CodClassification = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: true),
                    Status = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_COSIF", x => new { x.CodProduct, x.CodCosif });
                    table.ForeignKey(
                        name: "FK_PRODUCT_COSIF_PRODUCT_CodProduct",
                        column: x => x.CodProduct,
                        principalTable: "PRODUCT",
                        principalColumn: "CodProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleProfiles",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleProfiles", x => new { x.ModuleId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_ModuleProfiles_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModuleProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAuthorised = table.Column<bool>(type: "bit", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MANUAL_MOVIMENTS",
                columns: table => new
                {
                    Month = table.Column<int>(type: "int", fixedLength: true, maxLength: 2, nullable: false),
                    Year = table.Column<int>(type: "int", fixedLength: true, maxLength: 4, nullable: false),
                    EntryNumber = table.Column<int>(type: "int", fixedLength: true, maxLength: 18, nullable: false),
                    CodProduct = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    CodCosif = table.Column<int>(type: "int", fixedLength: true, maxLength: 11, nullable: false),
                    Description = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    MovimentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCode = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    Value = table.Column<int>(type: "int", fixedLength: true, maxLength: 18, nullable: false),
                    CosifCodCosif = table.Column<string>(type: "nchar(11)", nullable: true),
                    CosifCodProduct = table.Column<string>(type: "nchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUAL_MOVIMENTS", x => new { x.EntryNumber, x.Month, x.Year, x.CodProduct, x.CodCosif });
                    table.ForeignKey(
                        name: "FK_MANUAL_MOVIMENTS_PRODUCT_COSIF_CosifCodProduct_CosifCodCosif",
                        columns: x => new { x.CosifCodProduct, x.CosifCodCosif },
                        principalTable: "PRODUCT_COSIF",
                        principalColumns: new[] { "CodProduct", "CodCosif" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedUser", "Icon", "IsActive", "Name", "Sequence", "URL", "UpdatedData", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, 0, "dashboard.png", true, "Dashboard", 1, "dashboard", null, 0 },
                    { 2, 0, "users.png", true, "Users", 2, "users", null, 0 },
                    { 3, 0, "accounts.png", true, "Account", 3, "accounts", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedUser", "IsActive", "IsDefault", "Name", "UpdatedData", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, 0, true, false, "Admin", null, 0 },
                    { 2, 0, true, true, "User", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "ModuleProfiles",
                columns: new[] { "ModuleId", "ProfileId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUser", "Email", "IsActive", "IsAuthorised", "Name", "Password", "ProfileId", "UpdatedData", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 2, 3, 16, 17, 33, 425, DateTimeKind.Local).AddTicks(666), 1, "admin@template.com", true, true, "Admin", "8D66A53A381493BEC08DA23CEF5A43767F20A42C", 1, null, 0 },
                    { 2, null, new DateTime(2022, 2, 3, 16, 17, 33, 425, DateTimeKind.Local).AddTicks(8656), 1, "user@template.com", true, true, "User", "8D66A53A381493BEC08DA23CEF5A43767F20A42C", 2, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MANUAL_MOVIMENTS_CosifCodProduct_CosifCodCosif",
                table: "MANUAL_MOVIMENTS",
                columns: new[] { "CosifCodProduct", "CosifCodCosif" });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleProfiles_ProfileId",
                table: "ModuleProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MANUAL_MOVIMENTS");

            migrationBuilder.DropTable(
                name: "ModuleProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PRODUCT_COSIF");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "PRODUCT");
        }
    }
}
