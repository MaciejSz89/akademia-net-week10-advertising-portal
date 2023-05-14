using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingPortal.Persistence.Migrations
{
    public partial class IdentificationNumber_Column_In_Advertisements_Table_Changed_To_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Advertisements_IdentificationNumber",
                table: "Advertisements");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "Advertisements",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_IdentificationNumber",
                table: "Advertisements",
                column: "IdentificationNumber",
                unique: true,
                filter: "[IdentificationNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Advertisements_IdentificationNumber",
                table: "Advertisements");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "Advertisements",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_IdentificationNumber",
                table: "Advertisements",
                column: "IdentificationNumber",
                unique: true);
        }
    }
}
