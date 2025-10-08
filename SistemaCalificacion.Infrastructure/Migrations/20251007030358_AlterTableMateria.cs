using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCalificacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Materia",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Materia_Name",
                table: "Materia",
                newName: "IX_Materia_Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Materia",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Materia_Nombre",
                table: "Materia",
                newName: "IX_Materia_Name");
        }
    }
}
