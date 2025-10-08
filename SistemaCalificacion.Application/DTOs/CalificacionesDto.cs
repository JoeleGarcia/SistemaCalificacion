


namespace SistemaCalificacion.Application.DTOs { 

    public record CalificacionesDto(int Id, Guid EstudianteId, int MateriaId, decimal? Calificacion1, decimal? Calificacion2, decimal? Calificacion3, decimal? Calificacion4, decimal? Examen, double? Total, string? Clasificacion, string Estado);
    public record SelectCalificacionesDto(int Id, Guid EstudianteId ,  EstudianteDto? Estudiante , int MateriaId, MateriaDto? Materia , decimal? Calificacion1, decimal? Calificacion2, decimal? Calificacion3, decimal? Calificacion4, decimal? Examen, double? Total, string? Clasificacion, string Estado);
    public record CreateCalificacionesDto(int Id, Guid EstudianteId, int MateriaId, decimal? Calificacion1, decimal? Calificacion2, decimal? Calificacion3, decimal? Calificacion4, decimal? Examen, double? Total, string? Clasificacion, string? Estado); 
    public record UpdateCalificacionesDto(Guid EstudianteId, int MateriaId, decimal? Calificacion1, decimal? Calificacion2, decimal? Calificacion3, decimal? Calificacion4, decimal? Examen, double? Total, string? Clasificacion, string? Estado); 

}
