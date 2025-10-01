using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Domain.Entities
{
    public class Estudiante
    {

        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Username { get; set; }
        public string? Password { get; set; } = string.Empty;
        public required string EmailInsitucional { get; set; }
        public string ?EmailPersonal { get; set; }
        public string ?Carrera { get; set; }
        public int Cedula { get; set; }
        public int Matricula { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Estudiante()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Role = "Estudiante";
            Status = true;
        }

    }
}
