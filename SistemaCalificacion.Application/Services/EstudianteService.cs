using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPasswordGenerator _PasswordGeneratorRepository;


        public EstudianteService(IEstudianteRepository estudianteRepository , IPasswordGenerator passwordGenerator)
        {
            _estudianteRepository = estudianteRepository;
            _PasswordGeneratorRepository = passwordGenerator;
        }

        public async Task<EstudianteDto> AddEstudianteAsync(EstudianteDto estudiante)
        {


            try
            {
                var _estudiante = new Estudiante(
                
                    nombre: estudiante.Nombre,
                    apellido: estudiante.Apellido,
                    username: estudiante.Username,
                    password: _PasswordGeneratorRepository.GenerarPassword(),
                    emailInsitucional: estudiante.EmailInstitucional,
                    emailPersonal: estudiante.EmailPersonal,
                    carrera: estudiante.Carrera,
                    cedula: estudiante.Cedula,
                    matricula: estudiante.Matricula                    

                );

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

        public async Task<EstudianteDto?> GetEstudianteByIdAsync(Guid id)
        {
            var _estudiante = await _estudianteRepository.GetEstudianteByIdAsync(id);

            return new EstudianteDto(_estudiante!.Id, _estudiante.Nombre, _estudiante.Apellido, _estudiante.Username, _estudiante.EmailInsitucional, _estudiante.EmailPersonal, _estudiante.Password, _estudiante.Matricula, _estudiante.Cedula, _estudiante.Carrera, _estudiante.Role, _estudiante.Status);
        }

        public Task<bool> IsEmailEstudianteRegisteredAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameEstudianteRegisteredAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEstudianteAsync(Guid Id, UpdateEstudianteDto estudiante)
        {
            var _estudiante = await _estudianteRepository.GetEstudianteByIdAsync(Id);

            if (_estudiante is null)
            {
                return false;
            }

            _estudiante.UpdateCampos(
                nombre: estudiante.Nombre,
                apellido: estudiante.Apellido,
                username: estudiante.Username,
                emailInsitucional: estudiante.EmailInstitucional,
                emailPersonal: estudiante.EmailPersonal,
                matricula: estudiante.Matricula,
                cedula: estudiante.Cedula,
                carrera: estudiante.Carrera,
                status: estudiante.Status
             );

            await _estudianteRepository.UpdateEstudianteAsync(_estudiante);

            return true;
        }
    }
}
