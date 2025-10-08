using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCalificacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMateria_Descripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Materia",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Materia",
                newName: "Description");
        }
    }
}
