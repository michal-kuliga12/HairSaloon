using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedServiceAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 33, 8, 97, DateTimeKind.Local).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 33, 8, 97, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 33, 8, 97, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 33, 8, 97, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "DurationInMinutes" },
                values: new object[] { "Strzyżenie", "", 60 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "DurationInMinutes" },
                values: new object[] { "Farbowanie", "", 90 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "DurationInMinutes" },
                values: new object[] { "Pakiety", "", 30 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "DurationInMinutes" },
                values: new object[] { "", 30 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 12, 22, 27, 53, 230, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 12, 22, 27, 53, 230, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 12, 22, 27, 53, 230, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 12, 22, 27, 53, 230, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Stylizacja włosów");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Stylizacja włosów");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "Stylizacja włosów");
        }
    }
}
