using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWInventario.Migrations
{
    public partial class FechasGarantiasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaGarantia",
                table: "Equipos",
                newName: "FechaIncioGarantia");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinGarantia",
                table: "Equipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinGarantia",
                table: "Equipos");

            migrationBuilder.RenameColumn(
                name: "FechaIncioGarantia",
                table: "Equipos",
                newName: "FechaGarantia");
        }
    }
}
