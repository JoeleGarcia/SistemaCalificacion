using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;
        private readonly IMapper _mapper;
        
        public MateriaService(IMateriaRepository materiaRepository, IMapper mapper) { 
            _materiaRepository = materiaRepository;
            _mapper = mapper;
        }

        public async Task<CreateMateriaDto> AddMateriaAsync(CreateMateriaDto createMateriaDto)
        {
            try
            {
                var _materia = _mapper.Map<Materia>(createMateriaDto);
                var materiaAgregado = await _materiaRepository.AddMateriaAsync(_materia);
                return new CreateMateriaDto(materiaAgregado.Id, materiaAgregado.Nombre, materiaAgregado.Descripcion, materiaAgregado.Status);

            }
            catch (InfrastructureException ex)
            {
                throw new ApplicationException("No se pudo registrar el usuario. Intente más tarde.", ex);
            }
        }

        public async Task DeleteMateriaAsync(int id)
        {
            await _materiaRepository.DeleteMateriaAsync(id);

        }

        public async Task<IEnumerable<MateriaDto>> GetAllMateriaAsync()
        {
            var estudiantes = await _materiaRepository.GetAllMateriaAsync();

            return estudiantes.Select(e => new MateriaDto(e.Id, e.Nombre, e.Descripcion, e.Status));

        }

        public async Task<MateriaDto> GetMateriaByIdAsync(int id)
        {
            var _materia = await _materiaRepository.GetMateriaByIdAsync(id);

            return new MateriaDto(_materia!.Id, _materia.Nombre, _materia.Descripcion, _materia.Status);
        }

        public async Task UpdateMateriaAsync(int id, UpdateMateriaDto updateMateriaDto)
        {
            var _materia = await _materiaRepository.GetMateriaByIdAsync(id);

            if (_materia is null)
            {
                throw new NotFoundException("Materia", id);
            }

            _materia.Nombre         = updateMateriaDto.Nombre;
            _materia.Descripcion = updateMateriaDto.Descripcion;
            _materia.Status         = updateMateriaDto.Status;

            await _materiaRepository.UpdateMateriaAsync(_materia);

        }
    }
}
