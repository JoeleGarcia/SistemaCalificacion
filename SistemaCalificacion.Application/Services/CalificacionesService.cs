using AutoMapper;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Exceptions;
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
    public class CalificacionesService : ICalificacionesService, ICalculoCalificacionesService
    {
        private readonly ICalificacionesRepository _calificacionesRepository;
        private readonly IMapper _mapper;

        public CalificacionesService(ICalificacionesRepository calificacionesRepository, IMapper mapper)
        {
            _calificacionesRepository = calificacionesRepository;
            _mapper = mapper;
        }
        public async Task<CreateCalificacionesDto> AddCalificacionesAsync(CreateCalificacionesDto createCalificacionesDto)
        {
            try
            {
                var _createCalificacion = _mapper.Map<Calificaciones>(createCalificacionesDto);
                
                _createCalificacion.Estado = "Pendiente";

                decimal? total = CalcularTotalCalificacion(_createCalificacion);

                if (total is not null)
                {
                    string clasificacion = DeterminarClasificacion(total);
                    string estado = DeterminarEstado(clasificacion);

                    _createCalificacion.Total = ((double?)total);
                    _createCalificacion.Clasificacion = clasificacion;
                    _createCalificacion.Estado = estado;
                }

                if (_createCalificacion.Estado is not null && total is null)
                {
                    _createCalificacion.Total = null;
                    _createCalificacion.Clasificacion = null;
                    _createCalificacion.Estado = "Pendiente";
                }

                var _calificacionAgregado = await _calificacionesRepository.AddCalificacionAsync(_createCalificacion);

            var calificacion = _mapper.Map<CreateCalificacionesDto>(_calificacionAgregado);
                
                return calificacion;

            }
            catch (InfrastructureException ex)
            {
                throw new ApplicationException("No se pudo registrar la Calificacion. Intente más tarde.", ex);
            }
        }

        public decimal CalcularTotalCalificacion(Calificaciones calificaciones)
        {

            var todasLasCalificaciones = new[]
            {
                calificaciones.Calificacion1,
                calificaciones.Calificacion2,
                calificaciones.Calificacion3,
                calificaciones.Calificacion4,
                calificaciones.Examen
            };



            decimal? sumaCalificaciones =     calificaciones.Calificacion1 +
                                              calificaciones.Calificacion2 +
                                              calificaciones.Calificacion3 +
                                              calificaciones.Calificacion4;

            decimal? promedioNormal = sumaCalificaciones / 4m;

            decimal? valorExamen = calificaciones.Examen;
            decimal? total = (promedioNormal * 0.70m) + (valorExamen * 0.30m);

            return Math.Round(total.Value, 2);
        }

        public string DeterminarClasificacion(decimal? totalCalificacion)
        {
            if (totalCalificacion >= 90m) return "A";
            if (totalCalificacion >= 80m) return "B";
            if (totalCalificacion >= 70m) return "C";
            return "F";
        }

        public string DeterminarEstado(string clasificacion)
        {
            return clasificacion switch
            {
                "F" => "Reprobado",
                _   => "Aprobado"
            };
        }

        public async Task DeleteCalificacionesAsync(int id)
        {
            await _calificacionesRepository.DeleteCalificacionAsync(id);
        }

        public async Task<IEnumerable<SelectCalificacionesDto>> GetAllCalificacionesAsync()
        {
            var _calificaciones = await _calificacionesRepository.GetAllCalificacionesAsync();
            
            var calificacionesDto = _mapper.Map<IEnumerable<SelectCalificacionesDto>>(_calificaciones);

            return calificacionesDto;

        }

        public async Task<CalificacionesDto> GetCalificacionesByIdAsync(int id)
        {
            var _calificaciones = await _calificacionesRepository.GetCalificacionByIdAsync(id);

            var calificacionesDto = _mapper.Map<CalificacionesDto>(_calificaciones);

            return calificacionesDto;
        }

        public async Task UpdateCalificacionesAsync(int id, UpdateCalificacionesDto updateCalificacionesDto)
        {
            var _calificaciones = await _calificacionesRepository.GetCalificacionByIdAsync(id);



            if (_calificaciones is null)
            {
                throw new NotFoundException("Calificaion", id);
            }

            _calificaciones.Calificacion1 = updateCalificacionesDto.Calificacion1;
            _calificaciones.Calificacion2 = updateCalificacionesDto.Calificacion2;
            _calificaciones.Calificacion3 = updateCalificacionesDto.Calificacion3;
            _calificaciones.Calificacion4 = updateCalificacionesDto.Calificacion4;

            _calificaciones.MateriaId = updateCalificacionesDto.MateriaId;
            _calificaciones.EstudianteId = updateCalificacionesDto.EstudianteId;
            _calificaciones.Examen  =   updateCalificacionesDto.Examen;

            decimal? total = CalcularTotalCalificacion(_calificaciones);

            if(total is not null)
            {
                string clasificacion = DeterminarClasificacion(total);
                string estado = DeterminarEstado(clasificacion);

                _calificaciones.Total           = ((double?)total);
                _calificaciones.Clasificacion   = clasificacion;
                _calificaciones.Estado          = estado;
            }

            if(_calificaciones.Estado is not null && total is null)
            {
                _calificaciones.Total = null;
                _calificaciones.Clasificacion = null;
                _calificaciones.Estado = "Pendiente";
            }

            await _calificacionesRepository.UpdateCalificacionAsync(_calificaciones);
        }
    }
}
