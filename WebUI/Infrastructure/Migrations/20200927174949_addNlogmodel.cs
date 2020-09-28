using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class addNlogmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Callsite = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    Logged = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "46b65e08-d961-4ebb-aea5-1c666ccd7b16");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0275f4b1-8b35-48fa-bef2-5e6191fcc94a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59610dd3-6baa-484b-99bc-368ccd6e96a9", "AQAAAAEAACcQAAAAEO86pCZo1MPow0WPX37hFJ7TLcwRiBCCL6SLLc+0W44wsXfDf4SSq51sCgCsmXLwqw==", "4aa9a43d-55ff-4a4d-b689-75dfb003927a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e997aa7-4da6-476a-9c78-a25061777363", "AQAAAAEAACcQAAAAEPy9CZ/NMrqjqrd7mpYzfo5z5xH8XRBiGGZL8Rp4TOmQf6FfAfyBs/ZCthQ6Hsxg1g==", "c30fd6c7-6dd1-4887-a214-bc4bd6038d6e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "caeb1a62-7a46-4703-a4eb-58d87ec5efb6", "AQAAAAEAACcQAAAAECwZw9HtEQ4ptmfrK2BQPKUhA4xjHSgxIePyeIIiAmtl+i3e1GGjEXAZUBn9OutnEw==", "51688b70-4752-40b8-acd1-b5d55579025c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

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
        }
    }
}
