using SistemaCalificacion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Interfaces
{
    public interface ICalificacionesService
    {
        Task<IEnumerable<SelectCalificacionesDto>> GetAllCalificacionesAsync();
        Task<CalificacionesDto> GetCalificacionesByIdAsync(int id);
        Task<CreateCalificacionesDto> AddCalificacionesAsync(CreateCalificacionesDto createCalificacionesDto);
        Task UpdateCalificacionesAsync(int id, UpdateCalificacionesDto updateCalificacionesDto);
        Task DeleteCalificacionesAsync(int id);
    }
}
