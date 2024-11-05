using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_Id",
                        column: x => x.Id,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Stylizacja włosów", "Strzyżenie męskie", 50 },
                    { 2, "Stylizacja włosów", "Strzyżenie damskie", 50 },
                    { 3, "Stylizacja włosów", "Farbowanie włosów", 50 },
                    { 4, "Pielęgnacja", "Depilacja", 50 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "ServiceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 5, 23, 54, 23, 152, DateTimeKind.Local).AddTicks(7993), 1 },
                    { 2, new DateTime(2024, 11, 5, 23, 54, 23, 152, DateTimeKind.Local).AddTicks(8031), 2 },
                    { 3, new DateTime(2024, 11, 5, 23, 54, 23, 152, DateTimeKind.Local).AddTicks(8033), 3 },
                    { 4, new DateTime(2024, 11, 5, 23, 54, 23, 152, DateTimeKind.Local).AddTicks(8035), 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
