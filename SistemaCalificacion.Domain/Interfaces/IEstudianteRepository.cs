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
        Task<bool> AddEstudianteAsync(Estudiante estudiante);
        Task<bool> UpdateEstudianteAsync(Estudiante estudiante);
        Task<IEnumerable<Estudiante>> GetAllEstudianteAsync();
        Task<User?> DeleteEstudianteByIdAsync(int id);
        Task<User?> GetEstudianteByIdAsync(int id);
        Task<User?> GetEstudianteByEmailAsync(string email);
        Task<User?> GetEstudianteByUsernameAsync(string username);
        Task<bool> IsEmailEstudianteRegisteredAsync(string email);
        Task<bool> IsUsernameEstudianteRegisteredAsync(string username);
    }
}
