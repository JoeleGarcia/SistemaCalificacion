using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Domain.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<Estudiante> AddEstudianteAsync(Estudiante estudiante);
        Task UpdateEstudianteAsync(Estudiante estudiante);
        Task<IEnumerable<Estudiante>> GetAllEstudianteAsync();
        Task DeleteEstudianteByIdAsync(Guid id);
        Task<Estudiante?> GetEstudianteByIdAsync(Guid id);
        Task<Estudiante?> GetEstudianteByEmailAsync(string email);
        Task<Estudiante?> GetEstudianteByUsernameAsync(string username);
        Task<bool> IsEmailEstudianteRegisteredAsync(string email);
        Task<bool> IsUsernameEstudianteRegisteredAsync(string username);
    }
}
