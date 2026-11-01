using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoVehiculoToVehiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoVehiculo",
                table: "vehiculo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoVehiculo",
                table: "vehiculo");
        }
    }
}
