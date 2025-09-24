using SistemaCalificacion.Application.DTOs;

namespace SistemaCalificacion.Application.Interfaces
{
    public interface ILoginService
    {

        Task<bool> RegisterAsync(RegisterUserDto registerDto);
        Task<bool> LoginAsync(string username , string password);
        Task<bool> IsEmailRegisteredAsync(string email);
        Task<bool> IsUsernameRegisteredAsync(string username);
        Task<string> HashPassword(string password);

    }
}
