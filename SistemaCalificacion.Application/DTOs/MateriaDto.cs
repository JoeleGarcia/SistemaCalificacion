
namespace SistemaCalificacion.Application.DTOs
{
        public record MateriaDto(int Id, string Name, string Description,bool Status);
        public record CreateMateriaDto(int Id, string Name, string Description, bool Status);
        public record UpdateMateriaDto(string Name, string Description, bool Status);

}
