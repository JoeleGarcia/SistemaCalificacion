using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Domain.Interfaces
{
    public interface ICalificacionesRepository
    {
        Task<IEnumerable<Calificaciones>> GetAllCalificacionesAsync();
        Task<Calificaciones?> GetCalificacionByIdAsync(int id);
        Task<Calificaciones> AddCalificacionAsync(Calificaciones calificaciones);
        Task UpdateCalificacionAsync(Calificaciones calificaciones);
        Task DeleteCalificacionAsync(int id);
    }
}
