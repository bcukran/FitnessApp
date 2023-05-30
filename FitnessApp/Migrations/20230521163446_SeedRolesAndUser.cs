using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2037d907-b91d-4f29-8671-6a4c5d0393c6", "26b84c98-6456-4171-b965-35b7e30ac41b", "Admin", "ADMİN" },
                    { "f7e5a81b-492d-4507-b1aa-32710db76c60", "7c1a9c00-0fae-434a-b2da-177268e4193e", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CareerStarted", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "617032f5-075a-4555-9875-c7a4222e1962", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fe2cb688-b596-4b56-8674-b22563fa400c", "mm@mm.mm", true, "", "", false, null, "MM@MM.MM", "MM@MM.MM", "AQAAAAEAACcQAAAAEIk2Ti6q1lFz+HWl0qtzrgjBBkl75EJKCBpUk/eMsXsOUtjb6zWHh/HUntyd0J/bpQ==", null, false, "d41fc622-8e82-4141-a143-bd759bc6672a", false, "mm@mm.mm" },
                    { "d6786510-61fa-407d-ad58-78cc07f90805", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "16aa9e43-808e-4c4c-85b7-be13d5a14303", "aa@aa.aa", true, "", "", false, null, "AA@AA.AA", "AA@AA.AA", "AQAAAAEAACcQAAAAEJ1+9qMFLdIdGRUwYSp4vCBDUcs9TQkYGDJ0cBkO55j05fJ5Y7+AYY/czrsFKzxElA==", null, false, "7f5efbaf-962c-4c44-b63a-59d6febb7022", false, "aa@aa.aa" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f7e5a81b-492d-4507-b1aa-32710db76c60", "617032f5-075a-4555-9875-c7a4222e1962" },
                    { "2037d907-b91d-4f29-8671-6a4c5d0393c6", "d6786510-61fa-407d-ad58-78cc07f90805" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7e5a81b-492d-4507-b1aa-32710db76c60", "617032f5-075a-4555-9875-c7a4222e1962" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2037d907-b91d-4f29-8671-6a4c5d0393c6", "d6786510-61fa-407d-ad58-78cc07f90805" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2037d907-b91d-4f29-8671-6a4c5d0393c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e5a81b-492d-4507-b1aa-32710db76c60");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "617032f5-075a-4555-9875-c7a4222e1962");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6786510-61fa-407d-ad58-78cc07f90805");
        }
    }
}
