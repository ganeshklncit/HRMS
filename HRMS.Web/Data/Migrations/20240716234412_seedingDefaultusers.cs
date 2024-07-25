using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingDefaultusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33041056-5919-4342-a364-62b942511fed", null, "Supervisor", "SUPERVISOR" },
                    { "6b310686-884d-422c-8c10-94f7788ef935", null, "Administrator", "ADMINISTRATOR" },
                    { "aa5b3338-5e96-4800-b3fd-f563c93f0e4c", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "13a64665-8ce6-4d08-87a8-9814e266e391", 0, "3f722a58-cbe4-4610-ada4-8abaabc14720", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDcoSjkfAMDLe072U8Lnr905ZCxhcWjpVTWtPRKAEWW2/9DQXgJr/FXUZrFrbHKT1A==", null, false, "851a05c5-bdf6-4f88-816f-30799ec8f65f", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6b310686-884d-422c-8c10-94f7788ef935", "13a64665-8ce6-4d08-87a8-9814e266e391" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33041056-5919-4342-a364-62b942511fed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5b3338-5e96-4800-b3fd-f563c93f0e4c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6b310686-884d-422c-8c10-94f7788ef935", "13a64665-8ce6-4d08-87a8-9814e266e391" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b310686-884d-422c-8c10-94f7788ef935");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13a64665-8ce6-4d08-87a8-9814e266e391");
        }
    }
}
