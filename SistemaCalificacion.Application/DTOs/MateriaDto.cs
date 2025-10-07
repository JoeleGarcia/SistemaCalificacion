
namespace SistemaCalificacion.Application.DTOs
{
        public record MateriaDto(int Id, string Nombre, string Descripcion, bool Status);
        public record CreateMateriaDto(int Id, string Nombre, string Descripcion, bool Status);
        public record UpdateMateriaDto(string Nombre, string Descripcion, bool Status);

}
