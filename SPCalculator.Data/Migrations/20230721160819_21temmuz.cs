using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SPCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class _21temmuz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterPoint = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SprintName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePoint = table.Column<double>(type: "float", nullable: true),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprints_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sprints_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SprintFunctions",
                columns: table => new
                {
                    SprintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintFunctions", x => new { x.SprintId, x.FunctionId });
                    table.ForeignKey(
                        name: "FK_SprintFunctions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintFunctions_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SprintParameters",
                columns: table => new
                {
                    SprintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintParameters", x => new { x.SprintId, x.ParameterId });
                    table.ForeignKey(
                        name: "FK_SprintParameters_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintParameters_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FunctionName", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("174f50fe-10cc-4b07-943e-023b0a0a47c6"), new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6608), null, "Ekran Güncelleme", false, null },
                    { new Guid("c33f282a-664b-4042-b967-f544ecf86b79"), new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6604), null, "Ekran Ekleme", false, null }
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "ParameterDesc", "ParameterName", "ParameterPoint", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3c22b6b0-45c7-455e-9bca-da2c051b5011"), new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6769), null, false, "Pop-up Ekran Ekleme", "Ekran Ekleme", 4, null },
                    { new Guid("4461add9-168b-468f-8d8a-bc333690d8b3"), new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6772), null, false, "Pop-up Ekran Güncelleme", "Ekran Güncelleme", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Sprints",
                columns: new[] { "Id", "BasePoint", "CreatedDate", "DeletedDate", "DifficultyLevel", "FunctionId", "IsDeleted", "ItemNo", "ParameterId", "SprintName", "UpdatedDate", "VersionInfo" },
                values: new object[,]
                {
                    { new Guid("53df0cc3-e8c0-47cb-8977-5f4b12c07da7"), 0.0, new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6870), null, "Easy", new Guid("c33f282a-664b-4042-b967-f544ecf86b79"), false, "EES-48940", new Guid("3c22b6b0-45c7-455e-9bca-da2c051b5011"), "Sprint 1", null, "EES - 4.13-2023.R10 05/30" },
                    { new Guid("7f35feb9-f7f3-41a4-abb6-f5ed5ec0e8bd"), 0.0, new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6874), null, "Easy", new Guid("174f50fe-10cc-4b07-943e-023b0a0a47c6"), false, "EES-48940", new Guid("4461add9-168b-468f-8d8a-bc333690d8b3"), "Sprint 2", null, "EES - 4.13-2023.R10 05/30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SprintFunctions_FunctionId",
                table: "SprintFunctions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SprintParameters_ParameterId",
                table: "SprintParameters",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_FunctionId",
                table: "Sprints",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ParameterId",
                table: "Sprints",
                column: "ParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SprintFunctions");

            migrationBuilder.DropTable(
                name: "SprintParameters");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
