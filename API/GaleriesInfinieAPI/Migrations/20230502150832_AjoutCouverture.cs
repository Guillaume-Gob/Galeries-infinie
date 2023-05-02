using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class AjoutCouverture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "455b5c1e-5ff2-47e2-8965-bb72ac78aa74", "AQAAAAEAACcQAAAAEINUXtLhF8hF28wvwdkWECnrFEaaJ2Z3b1K5tGe5/9RMZ0tsWvvqt3QkiuWygSdcqw==", "6cd6f17b-74fc-46e1-a188-8ef52ed0c5aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d10c04-c4d1-451e-b7c6-d0bb092ada99", "AQAAAAEAACcQAAAAEFHaYK4FBAB2oewBBHqAJGaVDOKU9zMz40K6cjyXMwlVjUpm1xGOcuJDeyp+5alFNA==", "714af2c7-d978-46c7-91e5-a827451b9919" });

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FileName", "MimeType" },
                values: new object[] { "8F8BC7A2-01A4-40CD-80FB-34B401A038A1.jfif", "image/jfif" });

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FileName", "MimeType" },
                values: new object[] { "B5669E0D-8906-49E5-9963-EFB5913EE6AC.png", "image/png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b595764-3d87-454d-8dcd-87a45269c6d7", "AQAAAAEAACcQAAAAEACvwyfp3SDXdrwHiXkN/5fpVMKp0HRAJy3ucT9bOKAKmAvdyyOr/ZwW8HFBRUtqDw==", "0cad36d5-c322-44b3-abab-cdbc1024ab0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55db9e29-57bc-4239-a23e-da621c833726", "AQAAAAEAACcQAAAAEDOmLzQv9dyiOYNMYzR9wTQispsbCn7kqB/mfrYDpVQgndqJ2fkO6lUxyUz6mKkmKA==", "99030c60-72c7-4c74-b7f3-cb2a7cc2b2fd" });

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FileName", "MimeType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FileName", "MimeType" },
                values: new object[] { null, null });
        }
    }
}
