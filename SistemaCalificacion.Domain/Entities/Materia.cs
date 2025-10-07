
namespace SistemaCalificacion.Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Status { get; set; }
        public ICollection<Calificaciones> Calificaciones { get; set; } = new HashSet<Calificaciones>();

    }
}
