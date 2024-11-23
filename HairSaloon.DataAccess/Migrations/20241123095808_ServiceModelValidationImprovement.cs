using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ServiceModelValidationImprovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 23, 10, 58, 8, 332, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 23, 10, 58, 8, 332, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 23, 10, 58, 8, 332, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 23, 10, 58, 8, 332, DateTimeKind.Local).AddTicks(4763));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
    }
}
