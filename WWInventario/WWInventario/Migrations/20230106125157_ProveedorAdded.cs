using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWInventario.Migrations
{
    public partial class ProveedorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSecundario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoSecundario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
