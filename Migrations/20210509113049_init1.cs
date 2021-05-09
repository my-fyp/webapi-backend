using Microsoft.EntityFrameworkCore.Migrations;

namespace Home_Sewa.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorProfession_Profession_ProfessionId",
                table: "VendorProfession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profession",
                table: "Profession");

            migrationBuilder.RenameTable(
                name: "Profession",
                newName: "Professions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professions",
                table: "Professions",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorProfession_Professions_ProfessionId",
                table: "VendorProfession",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorProfession_Professions_ProfessionId",
                table: "VendorProfession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professions",
                table: "Professions");

            migrationBuilder.RenameTable(
                name: "Professions",
                newName: "Profession");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profession",
                table: "Profession",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorProfession_Profession_ProfessionId",
                table: "VendorProfession",
                column: "ProfessionId",
                principalTable: "Profession",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
