using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhoneNumber", "Date", "EmployeeId", "ServiceId" },
                values: new object[,]
                {
                    { 1, "test@gmail.com", "Michal", null, 222666111, new DateTime(2024, 12, 8, 19, 49, 17, 974, DateTimeKind.Local).AddTicks(2672), "b9fd838c-5e26-49f9-953a-c00e3b34b9da", 6 },
                    { 2, "test1@gmail.com", "Michal1", null, 222666111, new DateTime(2024, 12, 8, 19, 49, 17, 974, DateTimeKind.Local).AddTicks(2710), "ae06c675-dbfb-4f62-b546-02cc6e8a1d09", 5 },
                    { 3, "test2@gmail.com", "Michal2", null, 222666111, new DateTime(2024, 12, 8, 19, 49, 17, 974, DateTimeKind.Local).AddTicks(2712), "ae06c675-dbfb-4f62-b546-02cc6e8a1d09", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
