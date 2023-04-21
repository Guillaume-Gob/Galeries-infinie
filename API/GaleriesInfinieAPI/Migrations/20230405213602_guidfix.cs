using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class guidfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GalerieUtilisateur",
                keyColumns: new[] { "GaleriesId", "PropriétairesId" },
                keyValues: new object[] { 1, "2FB4F664 - 2E39 - 4C56 - BC88 - 1DA9DFA859F8" });

            migrationBuilder.DeleteData(
                table: "GalerieUtilisateur",
                keyColumns: new[] { "GaleriesId", "PropriétairesId" },
                keyValues: new object[] { 2, "00E5F11B - 096E-43F0 - B98B - EEE5F672B7B7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B - 096E-43F0 - B98B - EEE5F672B7B7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664 - 2E39 - 4C56 - BC88 - 1DA9DFA859F8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00E5F11B-096E-43F0-B98B-EEE5F672B7B7", 0, "49b895d1-c5a7-4f4c-bb79-c79182972f2a", "Gmail@Hotmail.ca", false, false, null, "GMAIL@HOTMAIL.CA", "JEAN-GUY", "AQAAAAEAACcQAAAAEGVrIoAwT/bW4A2tJc0clU/A3lAg59TDcl1mQqq5RQNlpJmWPaqd4EVSfQV9o8l2Iw==", null, false, "c8c44c2e-07e8-4e75-9e09-4872df63e4bd", false, "Jean-Guy" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8", 0, "5843107b-f85d-4128-b5c6-a1f3fe979f85", "Hotmail@Hotmail.ca", false, false, null, "HOTMAIL@HOTMAIL.CA", "MAURICE", "AQAAAAEAACcQAAAAEPLamj9ZVW1TNNnjofvSkE7fgBCVbZoo06Lp5icNmANmVib6eqwI1Nw0kqdnNZ6ODA==", null, false, "945eeeb0-e415-41d9-8ca2-8ae595e686b3", false, "Maurice" });

            migrationBuilder.InsertData(
                table: "GalerieUtilisateur",
                columns: new[] { "GaleriesId", "PropriétairesId" },
                values: new object[] { 1, "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8" });

            migrationBuilder.InsertData(
                table: "GalerieUtilisateur",
                columns: new[] { "GaleriesId", "PropriétairesId" },
                values: new object[] { 2, "00E5F11B-096E-43F0-B98B-EEE5F672B7B7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GalerieUtilisateur",
                keyColumns: new[] { "GaleriesId", "PropriétairesId" },
                keyValues: new object[] { 1, "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8" });

            migrationBuilder.DeleteData(
                table: "GalerieUtilisateur",
                keyColumns: new[] { "GaleriesId", "PropriétairesId" },
                keyValues: new object[] { 2, "00E5F11B-096E-43F0-B98B-EEE5F672B7B7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00E5F11B - 096E-43F0 - B98B - EEE5F672B7B7", 0, "4e44ebce-4cc7-4023-bbdc-251de2b25264", "Gmail@Hotmail.ca", false, false, null, "GMAIL@HOTMAIL.CA", "JEAN-GUY", "AQAAAAEAACcQAAAAEOuiVFIBt8KXO6nFkSALbwaxEv0SI2Jkbqw6gwiZET7vzPJPzHvBDiAkPJBiA1nZhw==", null, false, "805f89e2-1c50-4563-90a9-9b2b3b2fed95", false, "Jean-Guy" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2FB4F664 - 2E39 - 4C56 - BC88 - 1DA9DFA859F8", 0, "23c3193b-bf11-43ef-8a8e-429043267f35", "Hotmail@Hotmail.ca", false, false, null, "HOTMAIL@HOTMAIL.CA", "MAURICE", "AQAAAAEAACcQAAAAEEQFRmOsqLePuGJ4NVqbPI7hlrGjVHQjauDptdjmD/pv00uzHeri3yi1dS2mU8Vy9g==", null, false, "738b1d31-33da-4ac4-91ec-42b9df9e4b7b", false, "Maurice" });

            migrationBuilder.InsertData(
                table: "GalerieUtilisateur",
                columns: new[] { "GaleriesId", "PropriétairesId" },
                values: new object[] { 1, "2FB4F664 - 2E39 - 4C56 - BC88 - 1DA9DFA859F8" });

            migrationBuilder.InsertData(
                table: "GalerieUtilisateur",
                columns: new[] { "GaleriesId", "PropriétairesId" },
                values: new object[] { 2, "00E5F11B - 096E-43F0 - B98B - EEE5F672B7B7" });
        }
    }
}
