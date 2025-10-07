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
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping() {

            CreateMap<CreateMateriaDto, Materia>();

        }
    }
}
