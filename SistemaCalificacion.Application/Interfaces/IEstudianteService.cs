using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Interfaces
{
    public interface IEstudianteService
    {
        Task<EstudianteDto> AddEstudianteAsync(EstudianteDto estudiante);
        Task<bool> UpdateEstudianteAsync(Guid Id, EstudianteDto estudiante);
        Task DeleteEstudianteByIdAsync(Guid id);
        Task<IEnumerable<EstudianteDto>> GetAllEstudianteAsync();
        Task<bool> IsEmailEstudianteRegisteredAsync(string email);
        Task<bool> IsUsernameEstudianteRegisteredAsync(string username);

    }
}
