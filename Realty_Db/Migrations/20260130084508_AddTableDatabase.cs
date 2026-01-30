using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Realty_Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTableDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIBDD = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lot = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExclusive = table.Column<bool>(type: "bit", nullable: false),
                    IsMortagege = table.Column<bool>(type: "bit", nullable: false),
                    Squeare = table.Column<double>(type: "float", nullable: false),
                    NumOfRoms = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTitul = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeTitul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTitul = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndTitul = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "GIBDD", "Nm" },
                values: new object[,]
                {
                    { 1, "77", "Москва" },
                    { 2, "50", "Московсая область" },
                    { 3, "78", "Санкт_Петербург" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_Lot",
                table: "Houses",
                column: "Lot",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RegionId",
                table: "Houses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_HouseId",
                table: "Owners",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_NumTitul",
                table: "Owners",
                column: "NumTitul",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_GIBDD",
                table: "Regions",
                column: "GIBDD",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
