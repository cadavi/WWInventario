using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWInventario.Migrations
{
    public partial class ApellidosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Usuarios");
        }
    }
}
