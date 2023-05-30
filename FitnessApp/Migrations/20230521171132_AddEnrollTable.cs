using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class AddEnrollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Enroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enroll_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enroll_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8fdc8ddd-f7dc-4d58-aa46-86d57cc772eb", "f7867764-0b24-4eac-a96b-3eaac550784f", "Member", "MEMBER" },
                    { "bc6d6fb9-7b8a-43e3-b1e6-677fee84d568", "baedae43-0b53-48cc-a017-a23e2e5c17c4", "Admin", "ADMİN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CareerStarted", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f45eada-9566-4057-acca-d6de6a5e142f", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c10ddc7-264c-4e5e-869d-df6fdf7e8c00", "mm@mm.mm", true, "", "", false, null, "MM@MM.MM", "MM@MM.MM", "AQAAAAEAACcQAAAAEF95TP0wayarQc5gJi0yHcab/AMAXfNV+BH/+uGD92fBO1ONfFq0c6gsvh2vVLnpYw==", null, false, "a285b109-b8e3-4dc0-9cea-b480195b42da", false, "mm@mm.mm" },
                    { "968d2a90-4001-45ec-8c80-7c84820ffe6c", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f2b9c3ee-4d7e-437b-b6d0-74deb0c1d6b0", "aa@aa.aa", true, "", "", false, null, "AA@AA.AA", "AA@AA.AA", "AQAAAAEAACcQAAAAEAHqzpFLoZ+dEfl17OW6WjGol0uUCS8NpcDinvGK83xCp8TQrWvvzmE9hmhF1xsf6A==", null, false, "9fd4fb19-705e-4fea-9972-8a5cadbab754", false, "aa@aa.aa" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8fdc8ddd-f7dc-4d58-aa46-86d57cc772eb", "3f45eada-9566-4057-acca-d6de6a5e142f" },
                    { "bc6d6fb9-7b8a-43e3-b1e6-677fee84d568", "968d2a90-4001-45ec-8c80-7c84820ffe6c" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enroll_CourseId",
                table: "Enroll",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enroll_UserId",
                table: "Enroll",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enroll");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fdc8ddd-f7dc-4d58-aa46-86d57cc772eb", "3f45eada-9566-4057-acca-d6de6a5e142f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc6d6fb9-7b8a-43e3-b1e6-677fee84d568", "968d2a90-4001-45ec-8c80-7c84820ffe6c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fdc8ddd-f7dc-4d58-aa46-86d57cc772eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc6d6fb9-7b8a-43e3-b1e6-677fee84d568");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f45eada-9566-4057-acca-d6de6a5e142f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "968d2a90-4001-45ec-8c80-7c84820ffe6c");

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
    }
}
