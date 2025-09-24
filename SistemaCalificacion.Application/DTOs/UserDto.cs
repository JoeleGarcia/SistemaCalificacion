
namespace SistemaCalificacion.Application.DTOs
{
    public record UserDto(int Id, string Username, string Password, string Email, string Cedula, string Matricula);

    public record LoginUserDto(string Username, string Password);

    public record RegisterUserDto(string Username, string Password , string Email , string Cedula , string Matricula);

}
