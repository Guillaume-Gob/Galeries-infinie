using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaleriesInfinieAPI.Migrations
{
    public partial class Manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalerieUtilisateur");

            migrationBuilder.CreateTable(
                name: "GalerieUser",
                columns: table => new
                {
                    GaleriesId = table.Column<int>(type: "int", nullable: false),
                    PropriétairesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalerieUser", x => new { x.GaleriesId, x.PropriétairesId });
                    table.ForeignKey(
                        name: "FK_GalerieUser_AspNetUsers_PropriétairesId",
                        column: x => x.PropriétairesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalerieUser_Galerie_GaleriesId",
                        column: x => x.GaleriesId,
                        principalTable: "Galerie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cfe6c71-c71c-47b7-91f8-6350b362aadc", "AQAAAAEAACcQAAAAEPKODbhJd8A1lOW5SMKRk+ALsTauE+Di0qJy8icIZGaI0Rxc9nFh0b+XpNMBvsA+1Q==", "c45dabb8-89ff-42e0-82b4-ce51fa469b90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18405eb2-ccba-4607-aa6c-6b3efb6f43f2", "AQAAAAEAACcQAAAAEOWPYtr8SumPKrOrsL/RGp4h1VbvTaW+wtQBR3rG/Jxbs5FrjulqLSADt96CHz2EYg==", "3762fb86-14c2-4f39-b31a-aa01ba92a9b1" });

            migrationBuilder.InsertData(
                table: "GalerieUser",
                columns: new[] { "GaleriesId", "PropriétairesId" },
                values: new object[,]
                {
                    { 1, "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8" },
                    { 2, "00E5F11B-096E-43F0-B98B-EEE5F672B7B7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalerieUser_PropriétairesId",
                table: "GalerieUser",
                column: "PropriétairesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalerieUser");

            migrationBuilder.CreateTable(
                name: "GalerieUtilisateur",
                columns: table => new
                {
                    GaleriesId = table.Column<int>(type: "int", nullable: false),
                    PropriétairesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalerieUtilisateur", x => new { x.GaleriesId, x.PropriétairesId });
                    table.ForeignKey(
                        name: "FK_GalerieUtilisateur_AspNetUsers_PropriétairesId",
                        column: x => x.PropriétairesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalerieUtilisateur_Galerie_GaleriesId",
                        column: x => x.GaleriesId,
                        principalTable: "Galerie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "GalerieUtilisateur",
                columns: new[] { "GaleriesId", "PropriétairesId" },
                values: new object[,]
                {
                    { 1, "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8" },
                    { 2, "00E5F11B-096E-43F0-B98B-EEE5F672B7B7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalerieUtilisateur_PropriétairesId",
                table: "GalerieUtilisateur",
                column: "PropriétairesId");
        }
    }
}
