using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCalificacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumn_tipos_de_datos_Tabla_Estudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Estudiante_Cedula",
                table: "Estudiante");

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Estudiante",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_Cedula",
                table: "Estudiante",
                column: "Cedula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudiante_Cedula",
                table: "Estudiante");

            migrationBuilder.AlterColumn<int>(
                name: "Matricula",
                table: "Estudiante",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Estudiante",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Estudiante_Cedula",
                table: "Estudiante",
                column: "Cedula");
        }
    }
}
