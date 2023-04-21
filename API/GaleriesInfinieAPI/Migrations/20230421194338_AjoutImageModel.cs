using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class AjoutImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Galerie");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Galerie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Galerie",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Galerie");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Galerie");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Galerie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "920d9977-bffe-482c-9223-91d24b81960a", "AQAAAAEAACcQAAAAENK9Ce585PuJv0sgr3apwvbm/x/TRBnf/ikgea1IWkOiuFfFMtdGblEFffF5hlWDNw==", "1b580d32-5291-4b64-95c3-0d0167bb67be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "892c26de-2d91-42c1-b8df-dfa2c8682c35", "AQAAAAEAACcQAAAAENUinK9xKZilLd4HGP344z1i7aHxEsrDeM0gPEojRvE6qDNoC4+vqSS9GK8qC9wrlw==", "abdfdbe7-ae31-4e96-a9da-11981fcc77fa" });

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "aaaaa/aaaa.img");

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "aaaaa/aaaa.img");
        }
    }
}
