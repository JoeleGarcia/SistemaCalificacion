
using System.Data;
using System.Net.NetworkInformation;

namespace SistemaCalificacion.Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Status { get; set; }
        public ICollection<Calificaciones> Calificaciones { get; set; }

    }
}
