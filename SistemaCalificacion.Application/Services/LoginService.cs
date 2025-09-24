using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Domain.Interfaces;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<string> HashPassword(string password)
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

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _userRepository.ValidateCredentialsAsync(username, password);
            return response;
        }

        public async Task<bool> RegisterAsync(RegisterUserDto registerDto)
        {

            var user = new User
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
                Matricula = registerDto.Matricula,
                Cedula = registerDto.Cedula,
                Email = registerDto.Email
            };

            var userRegistered = await _userRepository.AddUserAsync(user);

            return userRegistered;
        }

  
    }
}
