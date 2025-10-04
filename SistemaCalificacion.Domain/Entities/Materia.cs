
namespace SistemaCalificacion.Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }

    }
}
