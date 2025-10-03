using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaCalificacion.Application.Exceptions;
using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Domain.Interfaces;
using SistemaCalificacion.Infrastructure.Data;

namespace SistemaCalificacion.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public EstudianteRepository(ApplicationDbContext context) { 

            _dbcontext = context;
        
        }

        public async Task<Estudiante> AddEstudianteAsync(Estudiante estudiante)
        {
            try
            {
                await _dbcontext.Estudiante.AddAsync(estudiante);
                await _dbcontext.SaveChangesAsync();
                return estudiante;
            }
            catch (SqlException ex) when (ex.Number == -2) // Timeout específico
            {
                throw new InfrastructureException("Timeout al consultar la base de datos", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InfrastructureException("Error en la consulta de Estudiante", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new InfrastructureException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new InfrastructureException("Error inesperado en la base de datos", ex);
            }
        }

        public async Task DeleteEstudianteByIdAsync(Guid id)
        {

            if (id == Guid.Empty)
                throw new InvalidArgumentException("Valor inválido.", nameof(id));

            var estudiante = await GetEstudianteByIdAsync(id);

            if (estudiante is null)
            {
                throw new NotFoundException("Estudiante" , "ById");
            }

            _dbcontext.Estudiante.Remove(estudiante);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudianteAsync()
        {
            return await _dbcontext.Estudiante.ToListAsync();
        }

        public Task<Estudiante?> GetEstudianteByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante?> GetEstudianteByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailEstudianteRegisteredAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameEstudianteRegisteredAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEstudianteAsync(Estudiante estudiante)
        {
            _dbcontext.Estudiante.Update(estudiante);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Estudiante?> GetEstudianteByIdAsync(Guid id)
        {
            return await _dbcontext.Estudiante.FindAsync(id);
        }
    }
}
