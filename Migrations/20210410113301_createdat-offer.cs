using Microsoft.EntityFrameworkCore.Migrations;

namespace Home_Sewa.Migrations
{
    public partial class createdatoffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "Problems",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Problems",
                newName: "AddedDate");
        }
    }
}
