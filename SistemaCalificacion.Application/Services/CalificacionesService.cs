using AutoMapper;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Services
{
    public class CalificacionesService : ICalificacionesService
    {
        private readonly ICalificacionesRepository _calificacionesRepository;
        private readonly IMapper _mapper;

        public CalificacionesService(ICalificacionesRepository calificacionesRepository, IMapper mapper)
        {
            _calificacionesRepository = calificacionesRepository;
            _mapper = mapper;
        }
        public Task<CreateCalificacionesDto> AddCalificacionesAsync(CreateCalificacionesDto createCalificacionesDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCalificacionesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectCalificacionesDto>> GetAllCalificacionesAsync()
        {
            var _calificaciones = await _calificacionesRepository.GetAllCalificacionesAsync();
            
            var calificacionesDto = _mapper.Map<IEnumerable<SelectCalificacionesDto>>(_calificaciones);

            return calificacionesDto;

        }

        public Task<CalificacionesDto> GetCalificacionesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCalificacionesAsync(int id, UpdateCalificacionesDto updateCalificacionesDto)
        {
            throw new NotImplementedException();
        }
    }
}
