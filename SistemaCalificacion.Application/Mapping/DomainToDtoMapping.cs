using AutoMapper;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Mapping
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping() {

            CreateMap<Estudiante, EstudianteDto>()
            .ForCtorParam(nameof(EstudianteDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(EstudianteDto.Nombre), opt => opt.MapFrom(src => src.Nombre))
            .ForCtorParam(nameof(EstudianteDto.Apellido), opt => opt.MapFrom(src => src.Apellido))
            .ForCtorParam(nameof(EstudianteDto.Username), opt => opt.MapFrom(src => src.Username))
            .ForCtorParam(nameof(EstudianteDto.EmailInstitucional), opt => opt.MapFrom(src => src.EmailInsitucional)) 
            .ForCtorParam(nameof(EstudianteDto.EmailPersonal), opt => opt.MapFrom(src => src.EmailPersonal))
            .ForCtorParam(nameof(EstudianteDto.Password), opt => opt.MapFrom(src => src.Password))
            .ForCtorParam(nameof(EstudianteDto.Matricula), opt => opt.MapFrom(src => src.Matricula))
            .ForCtorParam(nameof(EstudianteDto.Cedula), opt => opt.MapFrom(src => src.Cedula))
            .ForCtorParam(nameof(EstudianteDto.Carrera), opt => opt.MapFrom(src => src.Carrera))
            .ForCtorParam(nameof(EstudianteDto.Role), opt => opt.MapFrom(src => src.Role))
            .ForCtorParam(nameof(EstudianteDto.Status), opt => opt.MapFrom(src => src.Status));

            CreateMap<Materia, MateriaDto>();

            CreateMap<Calificaciones, SelectCalificacionesDto>();
      
        }
    }
}
