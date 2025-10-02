namespace SistemaCalificacion.Application.DTOs
{
    public record EstudianteDto(Guid Id, string Nombre, string Apellido, string Username, string EmailInstitucional, string EmailPersonal, string Password, int Matricula, int Cedula ,string Carrera ,string? Role, bool Status);



}
