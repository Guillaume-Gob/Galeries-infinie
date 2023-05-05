using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class seedfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "192f2872-9e22-4e87-9cbe-f3fed0d5b81d", "AQAAAAEAACcQAAAAEHmnz+6IQv90CmdWPqoOKal7rB3RYJdFWBlVJ3oIou+QVojUrsnqdoOQLcY/loveJw==", "11497685-254f-44a8-a842-de808663cecb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73fb754b-3088-4ee8-ae96-b41a6fc60ef9", "AQAAAAEAACcQAAAAECXLlVO9Vn2gBaTKOkDpq8OTjich93BXf4m5twkaHuqN92Jv3EkgXS9PXSotYQMK0Q==", "7a324d6c-ad0a-46e9-b4cd-6a9b4fc5a4e0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d41623e5-ec2e-4c55-9843-c129d707b591", "AQAAAAEAACcQAAAAEC1FBYkwyPxP06xpzs3v7PrvXEzMnLQMuF7Eq8mRj9MDFAo2bYq4hBCA6AWg7Bc8iQ==", "0e3c4777-acab-4df1-a216-5b109895b9e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ce4c63-374c-4838-bab7-eefb8dfc84d8", "AQAAAAEAACcQAAAAEMX5WE+gJ/eDGWZ0+5GXrz78OSJsijYYPl1qes2VvpvWLqSEx41QhOSYLtgZu9+a1Q==", "a5691b8e-d8cb-4a81-852e-48cc31815c06" });
        }
    }
}
