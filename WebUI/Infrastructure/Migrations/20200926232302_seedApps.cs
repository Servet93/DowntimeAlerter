using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Infrastructure.Migrations
{
    public partial class seedApps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Applications",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "JobId", "Name", "RequestIntervalAtMinute", "Url", "UserId" },
                values: new object[,]
                {
                    { 2, null, "Google", 20, "https://www.google.com.tr", "2" },
                    { 15, null, "Huawei 2", 10, "https://e.huawei.com/tr/huaweiconnect2020?utm_source=google&utm_medium=cpc&utm_campaign=01MHQHQ2052ZZL&utm_content=General&utm_term=Huawei&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-38oXMToS-y814N23FBg35Scr2JUmsbgBsdqYpZaNSVGkU-vO7scbkaArBAEALw_wcB", "3" },
                    { 14, null, "Vestel 2", 5, "https://www.vestel.com.tr/?gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-39gET4hChHg3TxYsrxCV97bFozXj-tS1BLXDo2NqVOyDT7Nnq4wEwaAutKEALw_wcB&gclsrc=aw.ds", "3" },
                    { 13, null, "Oppo 2", 5, "https://www.oppo.com/tr/smartphones/?utm_source=google&utm_medium=search&utm_campaign=cn_alwayson&utm_content=ak%C4%B1ll%C4%B1%20telefonlar&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-0hkFPTs743FUnXof9wRSt4fgPlzfWzBmlJHJTc6bUycU0UjtGgOgkaAugfEALw_wcB", "3" },
                    { 12, null, "General Mobile 2", 5, "https://www.generalmobile.com/tr", "3" },
                    { 10, null, "Samsung 2", 10, "https://www.samsung.com/tr/", "3" },
                    { 9, null, "Google 2", 20, "https://www.google.com.tr", "3" },
                    { 11, null, "Xiaomi 2", 5, "https://www.mi.com/tr/", "3" },
                    { 7, null, "Vestel", 5, "https://www.vestel.com.tr/?gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-39gET4hChHg3TxYsrxCV97bFozXj-tS1BLXDo2NqVOyDT7Nnq4wEwaAutKEALw_wcB&gclsrc=aw.ds", "2" },
                    { 6, null, "Oppo", 5, "https://www.oppo.com/tr/smartphones/?utm_source=google&utm_medium=search&utm_campaign=cn_alwayson&utm_content=ak%C4%B1ll%C4%B1%20telefonlar&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-0hkFPTs743FUnXof9wRSt4fgPlzfWzBmlJHJTc6bUycU0UjtGgOgkaAugfEALw_wcB", "2" },
                    { 5, null, "General Mobile", 5, "https://www.generalmobile.com/tr", "2" },
                    { 4, null, "Xiaomi", 5, "https://www.mi.com/tr/", "2" },
                    { 3, null, "Samsung", 10, "https://www.samsung.com/tr/", "2" },
                    { 8, null, "Huawei", 10, "https://e.huawei.com/tr/huaweiconnect2020?utm_source=google&utm_medium=cpc&utm_campaign=01MHQHQ2052ZZL&utm_content=General&utm_term=Huawei&gclid=Cj0KCQjwzbv7BRDIARIsAM-A6-38oXMToS-y814N23FBg35Scr2JUmsbgBsdqYpZaNSVGkU-vO7scbkaArBAEALw_wcB", "2" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Applications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

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
    }
}
