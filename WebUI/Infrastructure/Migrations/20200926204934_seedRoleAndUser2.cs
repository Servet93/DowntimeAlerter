using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class seedRoleAndUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d545f235-6430-4cbd-9be8-2da5e06f7ca4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5435a5a9-866a-4563-93af-b3ca3436b88e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "276ed1d7-8585-441b-be76-e94bace4f7a3", "AQAAAAEAACcQAAAAEOuNvdwa7nk5p4bE3Jmh81a3t03F/w3rQIxMb/BVm4oY1XLt6uoAwvkFFSzopixJiA==", "64d374d3-dbf9-4979-acd4-15b32a270da9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6304107-0b11-474b-97d0-b991651f6d48", "AQAAAAEAACcQAAAAEP9vFbGYjW4kyjqPD3Sc1iZgfmiTHJmse8QVv1fublS5irOMKIm7EJ3OHpRHmXtpXQ==", "ef808d2b-1d2e-44f4-a7a9-45ff55cb52cd" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3", 0, "c5d6dcae-4d15-49b0-a55b-74645cbc6051", "serkanseker@security.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOIm6MQCz3Gt21IdzPtDj4wBt6thBew/1DhBsE3pxspKbhzfwW0WX1Od5v5dHdtLEg==", null, false, "536bd7d0-bfda-4261-9ea0-39bb425842cb", false, "SerkanSeker" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6ce81b0f-68f7-44a6-ba3b-66bcb9f1d7eb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2fdb3267-c004-44aa-aa40-5c22d1bdca3c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "252947bb-1c4a-4d53-95d4-321f1c81c9c3", "AQAAAAEAACcQAAAAEHNb7QfjEoStaBfgeFqZT2qE61UicGA3p99QUOxT05QA8gPfQhdlETbrdEEG2553sQ==", "a2c0a036-5ab3-44e9-85d8-9169901b807b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d138e39b-8160-4cf6-b893-6670f5202904", "AQAAAAEAACcQAAAAENW9gzKmo8qmQMLGo3E4Gz3lmcEAHb7ciIYfpspiK1NGEE1Sk8h60nLoConRcLETGQ==", "b261bc0b-0e6c-4321-ad12-122d24e7b665" });
        }
    }
}
