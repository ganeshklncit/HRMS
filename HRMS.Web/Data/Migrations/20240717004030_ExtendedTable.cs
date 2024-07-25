using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13a64665-8ce6-4d08-87a8-9814e266e391",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2adac24a-e0eb-49bc-afa9-ad135d95eb94", new DateOnly(1985, 7, 18), "Default", "Admin", "AQAAAAIAAYagAAAAEEOF1LUvTELccrgiZb8KVXCgPracMtQlr7fScM0uCOAdHVclZ9UwFFfM2BqKXnEXUw==", "dfd45848-6948-4e1d-95ca-da90f3e49b86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13a64665-8ce6-4d08-87a8-9814e266e391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f722a58-cbe4-4610-ada4-8abaabc14720", "AQAAAAIAAYagAAAAEDcoSjkfAMDLe072U8Lnr905ZCxhcWjpVTWtPRKAEWW2/9DQXgJr/FXUZrFrbHKT1A==", "851a05c5-bdf6-4f88-816f-30799ec8f65f" });
        }
    }
}
