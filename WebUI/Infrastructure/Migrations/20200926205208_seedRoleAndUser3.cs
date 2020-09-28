using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class seedRoleAndUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3b97e7e0-47d8-48f6-836b-49a87ac4ede5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5a9ec20b-9536-44de-9b28-4fa5d646a36b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79417b78-db2b-4768-9d33-b082e4d6197a", "AQAAAAEAACcQAAAAEJC3+uut+aP0BrfV0BTQRX+2ajOdop9UGzqvAMO3EstkwQm5LMm4V0qJ13sgWX8vAw==", "18c0e678-c022-43a1-99df-82dd03d39eeb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1db91785-fc96-4f0b-9181-ccfce94a725f", "AQAAAAEAACcQAAAAEGksjlOupLT+DM+CMpXcb2xSH3SXvLczCmWNtEKr86wERTjhfxIXmeG+gd1a0l3rGw==", "4af729c4-ecce-4d41-ba15-901d6d773375" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "391d3b20-e796-444a-ad87-260baff41482", "AQAAAAEAACcQAAAAEKmCT5WwexdIMwaND3A7fZu1gxbzZ8ATnDkI7BwXG763lw22m6zluL9Us1W/VchE+g==", "b2e585e6-c511-41e8-a627-76149684d450" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5d6dcae-4d15-49b0-a55b-74645cbc6051", "AQAAAAEAACcQAAAAEOIm6MQCz3Gt21IdzPtDj4wBt6thBew/1DhBsE3pxspKbhzfwW0WX1Od5v5dHdtLEg==", "536bd7d0-bfda-4261-9ea0-39bb425842cb" });
        }
    }
}
