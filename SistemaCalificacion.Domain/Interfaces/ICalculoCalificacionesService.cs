using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Domain.Interfaces
{
    public interface ICalculoCalificacionesService
    {
        decimal CalcularTotalCalificacion(Calificaciones calificaciones);
        string DeterminarClasificacion(decimal? totalCalificacion);
        string DeterminarEstado(string clasificacion);
    }
}
