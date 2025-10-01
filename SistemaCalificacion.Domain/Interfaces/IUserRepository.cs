using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<bool> AddUserAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> IsEmailRegisteredAsync(string email);
        Task<bool> IsUsernameRegisteredAsync(string username);
        Task<User> ValidateCredentialsAsync(string email, string password);

    }
}
