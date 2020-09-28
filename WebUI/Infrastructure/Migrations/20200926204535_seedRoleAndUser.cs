using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class seedRoleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "6ce81b0f-68f7-44a6-ba3b-66bcb9f1d7eb", "Administrator", "Administrator" },
                    { "2", "2fdb3267-c004-44aa-aa40-5c22d1bdca3c", "NormalUser", "NormalUser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "252947bb-1c4a-4d53-95d4-321f1c81c9c3", "invicti@security.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHNb7QfjEoStaBfgeFqZT2qE61UicGA3p99QUOxT05QA8gPfQhdlETbrdEEG2553sQ==", null, false, "a2c0a036-5ab3-44e9-85d8-9169901b807b", false, "InvictiSecurityCorp" },
                    { "2", 0, "d138e39b-8160-4cf6-b893-6670f5202904", "servetseker@security.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENW9gzKmo8qmQMLGo3E4Gz3lmcEAHb7ciIYfpspiK1NGEE1Sk8h60nLoConRcLETGQ==", null, false, "b261bc0b-0e6c-4321-ad12-122d24e7b665", false, "ServetSeker" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "2" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "1" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
