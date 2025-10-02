namespace SistemaCalificacion.Application.DTOs
{
    public record EstudianteDto(Guid Id, string Nombre, string Apellido, string Username, string EmailInstitucional, string EmailPersonal, string? Password, string Matricula, string Cedula ,string Carrera ,string? Role, bool Status);

    public record UpdateEstudianteDto(string Nombre, string Apellido, string Username, string EmailInstitucional, string EmailPersonal, string Matricula, string Cedula, string Carrera, bool Status);

}
