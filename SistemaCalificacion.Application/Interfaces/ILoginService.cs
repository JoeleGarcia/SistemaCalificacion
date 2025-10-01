using SistemaCalificacion.Application.DTOs;

namespace SistemaCalificacion.Application.Interfaces
{
    public interface ILoginService
    {

        Task<bool> RegisterAsync(RegisterUserDto registerDto);
        Task<UserDto> LoginAsync(string email , string password);
        Task LogoutAsync();
        Task<string> HashPassword(string password);

    }
}
