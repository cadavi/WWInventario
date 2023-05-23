using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWInventario.Migrations
{
    public partial class FecIniNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaIncioGarantia",
                table: "Equipos",
                newName: "FechaInicioGarantia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaInicioGarantia",
                table: "Equipos",
                newName: "FechaIncioGarantia");
        }
    }
}
