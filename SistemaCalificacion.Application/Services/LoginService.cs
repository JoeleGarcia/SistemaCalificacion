using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Exceptions;
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
        private readonly ISessionManager _sessionManagerRepository;


        public LoginService(IUserRepository userRepository , ISessionManager sessionManagerRepository)
        {
            _userRepository = userRepository;
            _sessionManagerRepository = sessionManagerRepository;
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


        public async Task<UserDto> LoginAsync(string username, string password)
        {
            var response = await _userRepository.ValidateCredentialsAsync(username, password);

            if (response is null)
            {
                return null;
            }

            await _sessionManagerRepository.SignInAsync(response);

            return new UserDto(response.Nombre, response.Apellido, response.Username, response.Email, response.Role, response.Status);
            
        }

        public async Task LogoutAsync()
        {
            await _sessionManagerRepository.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterUserDto registerDto)
        {
            try
            {
                var user = new User
                {
                    Username = registerDto.Username,
                    Password = registerDto.Password,
                    Email = registerDto.Email,
                    Nombre = registerDto.Nombre,
                    Apellido = registerDto.Apellido                    
                };

                var userRegistered = await _userRepository.AddUserAsync(user);

                return userRegistered;
            }
            catch (InfrastructureException ex)
            {
                throw new ApplicationException("No se pudo registrar el usuario. Intente más tarde.", ex);
            }

        }

  
    }
}
