using Microsoft.AspNetCore.Http.HttpResults;
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
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<EstudianteDto> AddEstudianteAsync(EstudianteDto estudiante)
        {
            try
            {
                var _estudiante = new Estudiante
                {
                    Nombre = estudiante.Username,
                    Apellido = estudiante.Password,
                    Username    = estudiante.Username,
                    Password =  estudiante.Password,
                    EmailInsitucional  = estudiante.EmailInstitucional,
                    EmailPersonal = estudiante.EmailPersonal,
                    Carrera = estudiante.Carrera,
                    Cedula = estudiante.Cedula,
                    Matricula = estudiante.Matricula,
                    Status = estudiante.Status,

                };

                var estudianteAgregado = await _estudianteRepository.AddEstudianteAsync(_estudiante);
                return new EstudianteDto(estudianteAgregado.Id , estudianteAgregado.Nombre, estudianteAgregado.Apellido, estudianteAgregado.Username, estudianteAgregado.EmailInsitucional, estudianteAgregado.EmailPersonal, estudianteAgregado.Password, estudianteAgregado.Matricula, estudianteAgregado.Cedula, estudianteAgregado.Carrera, estudianteAgregado.Role, estudianteAgregado.Status);
            
            }
            catch (InfrastructureException ex)
            {
                throw new ApplicationException("No se pudo registrar el usuario. Intente más tarde.", ex);
            }
        }

        public async Task DeleteEstudianteByIdAsync(Guid id)
        {
            await _estudianteRepository.DeleteEstudianteByIdAsync(id);
        }

        public async Task<IEnumerable<EstudianteDto>> GetAllEstudianteAsync()
        {
            var estudiantes = await _estudianteRepository.GetAllEstudianteAsync();

            return estudiantes.Select(e => new EstudianteDto(e.Id , e.Nombre , e.Apellido , e.Username , e.EmailInsitucional , e.EmailPersonal , e.Password , e.Matricula , e.Cedula , e.Carrera, e.Role, e.Status));

        }

        public Task<bool> IsEmailEstudianteRegisteredAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameEstudianteRegisteredAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEstudianteAsync(Guid Id, EstudianteDto estudiante)
        {
            throw new NotImplementedException();
        }
    }
}
