using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWInventario.Migrations
{
    public partial class CompPaisChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Sucursales");

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "Companias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "Companias");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Sucursales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
