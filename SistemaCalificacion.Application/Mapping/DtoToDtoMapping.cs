using AutoMapper;
using SistemaCalificacion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Mapping
{
    public class DtoToDtoMapping : Profile
    {

        public DtoToDtoMapping() {

            CreateMap<EstudianteDto, UpdateEstudianteDto>();

        }
       
    }
}
