using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class ListNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "002dfb8b-8e62-4404-8cf9-015f945ca144", "AQAAAAEAACcQAAAAEJgD0Cg1sdrVKj81b2G8dWMO4p9MhM5vw6+9c22UVlM8AA6HbLQ7wdsJ49EngB22yw==", "e152a5f4-618e-4d3d-9fa3-546b8a300bb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ddc3c7d-c1b4-4c5d-92cb-8dcf084587ad", "AQAAAAEAACcQAAAAEGqD7AdUUx+fwuFEjxGhPnQNIEkAOezulth5gfJNk2YPaNpSd10rI5jQW8QUAcSg0w==", "c9a41ead-a49d-4de8-8625-565fb16c71b2" });
        }
    }
}
