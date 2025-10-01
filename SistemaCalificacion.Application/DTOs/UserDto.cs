
namespace SistemaCalificacion.Application.DTOs
{
    public record UserDto(string ?Nombre , string Apellido, string Username, string Email, string Role, bool Status );

    public record LoginUserDto(string Email, string Password);

    public record RegisterUserDto(string Nombre, string Apellido, string Username, string Email, string Password , string ConfirmPassword );

}
