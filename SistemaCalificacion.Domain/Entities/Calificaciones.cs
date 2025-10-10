
using System.Data;

namespace SistemaCalificacion.Domain.Entities
{
        public class Calificaciones
        {
            public int Id { get; set; }
            public Guid EstudianteId { get; set; }
            public Estudiante? Estudiante { get; set; }
            public int MateriaId { get; set; }
            public Materia? Materia { get; set; } 
            public decimal Calificacion1 { get; set; }
            public decimal Calificacion2 { get; set; }
            public decimal Calificacion3 { get; set; }
            public decimal Calificacion4 { get; set; }
            public decimal Examen { get; set; }
            public double? Total { get; set; }
            public string? Clasificacion { get; set; }
            public string? Estado { get; set; }

            public Calificaciones()
            {
                Estado = "Pendiente";
            }

        }



}
