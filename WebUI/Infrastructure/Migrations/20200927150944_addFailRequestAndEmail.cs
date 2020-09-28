using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class addFailRequestAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationFailRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFailRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFailRequests_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAdresses_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4774cf9a-4759-46ce-aabd-1477f8c08415");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "cdd7a1c3-c0c0-4d46-8dbc-2fe5bf0151fd");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "228a1f51-e682-40cf-9434-b2cf4314b5ed", "AQAAAAEAACcQAAAAEE1Z0Xq+jDMoLd6F7ot6OTyFiNK9XcYS4J14/oejZJznfg4f9ISW7T4qtbT/Rg1yJg==", "e00ec616-5e48-452e-922f-361d84868030" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f626f294-e0d7-48d9-98d8-1eb4264c534a", "AQAAAAEAACcQAAAAELkNSIM4zQFFdZOzF+q8mSvv4jZtqsVA+OGRPQ1QMp+58Ii8DZD9dliPUhiu8kFYpQ==", "afbf5758-0981-4c80-ba57-562e26f60950" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "833d21c4-3520-44d1-838b-c7f9ad799dc1", "AQAAAAEAACcQAAAAELTObeqk6go49uhP8V+qUtF/VX8kUNBP69aV8pBIc06Xsu/SpXcrtn+xa96Q+xGSwQ==", "e5a65deb-9815-4e7c-8f49-cd9517bdf2da" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFailRequests_ApplicationId",
                table: "ApplicationFailRequests",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAdresses_ApplicationId",
                table: "EmailAdresses",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationFailRequests");

            migrationBuilder.DropTable(
                name: "EmailAdresses");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5fc28a96-ba09-4619-82e0-2577e26b4255");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0057efd1-3fc2-4589-a6ec-75b6619b8aaa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1de84b4b-69e4-462d-bf8b-bb09c4645603", "AQAAAAEAACcQAAAAELYtlaLLaq0Dc99C9p27zAAhguwXYxeVA4X7C/57fknDYe0ZcYUxcZy+lvCYB1Xaxg==", "838c521e-8830-4c7e-ab6f-2db601c97cb3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d16cc8b3-77a5-408a-9eb0-2d1e66912e04", "AQAAAAEAACcQAAAAEJmOVrLirtSMnhHivpjgznXb427Sa6jBEvCfTLnCcQun7yjYzN1/1ugA+JGWFk4T8Q==", "622e1996-79c1-4c52-a541-4530a9baf9b2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d65ab88-f652-49e7-ab69-b8d854991a8f", "AQAAAAEAACcQAAAAEBUsN29Xe0rCpbDQvucXTKFX4u5gm+kMug9DQG9s5cjpOh9zgcjjcUUbLBnSiGegNg==", "da93b4fa-d0cf-4651-b2fd-431f6b73e905" });
        }
    }
}
