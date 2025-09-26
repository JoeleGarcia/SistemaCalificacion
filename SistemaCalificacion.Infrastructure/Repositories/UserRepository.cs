using Microsoft.EntityFrameworkCore;
using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Domain.Interfaces;
using SistemaCalificacion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public Task<bool> AddUserAsync(User user)
        {

            _dbcontext.Users.Add(user);
            var result = _dbcontext.SaveChangesAsync();
            return Task.FromResult(result.Result > 0);

        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailRegisteredAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameRegisteredAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password.Equals(password));
            if (user != null)
            {
                return true;
            }
            return false;
        }

    }
}
