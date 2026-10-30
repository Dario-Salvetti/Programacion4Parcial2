using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEfCore.Migrations
{
    /// <inheritdoc />
    public partial class generalizacionVehiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.CreateTable(
                name: "vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Año = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehiculo");

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Año = table.Column<int>(type: "INTEGER", nullable: false),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                });
        }
    }
}
