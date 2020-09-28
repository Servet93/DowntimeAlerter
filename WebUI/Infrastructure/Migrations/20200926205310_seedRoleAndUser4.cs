using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class seedRoleAndUser4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "1" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "28bf14d6-9ca2-4920-a05c-748d87040c79");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "587c2097-4c0d-401b-9415-5d8eb6c289d9");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "2" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4303e1f2-a59f-4dff-a935-b4c63e133dc7", "AQAAAAEAACcQAAAAEHcWcc9cvz16xvdF6ymGq1O8FKR0jfVo3qa5kTgLWfx+yFt1FAE3PTJqV78Tj0jnWw==", "fb1ba554-5789-49e5-9792-9571a3f57657" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "452b3e8c-8ffe-432f-b0ca-773f5e4fe487", "AQAAAAEAACcQAAAAEIypjnMNo5NcJ2YXs/pffIO8gpTBici5m6vPNQk70ZJRtnebhW2ao32HGgg5s8PCxQ==", "cf205f33-eb0d-44ba-8f86-db737ff38e85" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b494218e-e66c-4a1a-8876-5623af9408ff", "AQAAAAEAACcQAAAAEIpKeIV0JSEt2EfOLgKgpXsR3QX77+QUUjy3zaHNVF195UCtgxf3YxSta7khLx9EMg==", "391f5cfc-9abf-4019-8ac8-8fbd5e417229" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3", "2" });

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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1", "2" },
                    { "2", "1" }
                });

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
    }
}
