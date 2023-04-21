using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class DataseedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5047ee18-3761-4373-ba9f-f88c1bd17a12", "AQAAAAEAACcQAAAAEEoultsOuhCum4t9acQOSPVVW7fatCHZLh4gXnKDx2s5xf5OGB8biSg55IZYjDhTrQ==", "bfac39d0-a533-4ce8-bd63-0c4bb06195dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "803e3d1f-dc68-4459-b98f-69f48e8d34d9", "AQAAAAEAACcQAAAAEHS1Oz76HinrL3ye9Qp1aCuQc5TTvwc+Fz32y+vDJ1jemH4dwS4PG7nKmK5yTEX46Q==", "ddc9d5fd-5a63-4aa4-80a8-362dfb8f7ee2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49b895d1-c5a7-4f4c-bb79-c79182972f2a", "AQAAAAEAACcQAAAAEGVrIoAwT/bW4A2tJc0clU/A3lAg59TDcl1mQqq5RQNlpJmWPaqd4EVSfQV9o8l2Iw==", "c8c44c2e-07e8-4e75-9e09-4872df63e4bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5843107b-f85d-4128-b5c6-a1f3fe979f85", "AQAAAAEAACcQAAAAEPLamj9ZVW1TNNnjofvSkE7fgBCVbZoo06Lp5icNmANmVib6eqwI1Nw0kqdnNZ6ODA==", "945eeeb0-e415-41d9-8ca2-8ae595e686b3" });
        }
    }
}
