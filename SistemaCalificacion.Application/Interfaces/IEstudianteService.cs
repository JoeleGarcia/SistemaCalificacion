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
        Task<CreateEstudianteDto> AddEstudianteAsync(CreateEstudianteDto estudiante);
        Task<bool> UpdateEstudianteAsync(Guid Id, UpdateEstudianteDto updateEstudiante);
        Task DeleteEstudianteByIdAsync(Guid Id);
        Task<IEnumerable<EstudianteDto>> GetAllEstudianteAsync();
        Task<EstudianteDto?> GetEstudianteByIdAsync(Guid Id);
        Task<bool> IsEmailEstudianteRegisteredAsync(string email);
        Task<bool> IsUsernameEstudianteRegisteredAsync(string username);

    }
}
