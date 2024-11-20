using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequiredFromServiceDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 40, 56, 443, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 40, 56, 443, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 40, 56, 443, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 20, 21, 40, 56, 443, DateTimeKind.Local).AddTicks(2355));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
