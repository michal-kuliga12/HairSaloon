using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 6, 13, 55, 8, 98, DateTimeKind.Local).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 6, 13, 55, 8, 98, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 6, 13, 55, 8, 98, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 6, 13, 55, 8, 98, DateTimeKind.Local).AddTicks(4472));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 6, 12, 46, 27, 877, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 6, 12, 46, 27, 877, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 6, 12, 46, 27, 877, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 6, 12, 46, 27, 877, DateTimeKind.Local).AddTicks(6383));
        }
    }
}
