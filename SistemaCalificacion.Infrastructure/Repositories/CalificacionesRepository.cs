using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaCalificacion.Application.Exceptions;
using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Domain.Interfaces;
using SistemaCalificacion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Infrastructure.Repositories
{
    public class CalificacionesRepository : ICalificacionesRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public CalificacionesRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Calificaciones> AddCalificacionAsync(Calificaciones calificaciones)
        {
            try
            {
                await _dbcontext.Calificaciones.AddAsync(calificaciones);
                await _dbcontext.SaveChangesAsync();
                return calificaciones;
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                throw new InfrastructureException("Timeout al consultar la base de datos", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InfrastructureException("Error en la Operacion Guardando Calificacion", ex);
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

        public async Task DeleteCalificacionAsync(int id)
        {
            var _calificaciones = await GetCalificacionByIdAsync(id);

            if (_calificaciones is null)
                throw new NotFoundException("Estudiante", string.Format("By Id {0}", id.ToString()));

            _dbcontext.Calificaciones.Remove(_calificaciones);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Calificaciones>> GetAllCalificacionesAsync()
        {
            return await _dbcontext.Calificaciones
                        .Include(e => e.Estudiante)
                        .Include(m => m.Materia)
                        .ToListAsync();
        }

        public async Task<Calificaciones?> GetCalificacionByIdAsync(int id)
        {
            return await _dbcontext.Calificaciones.FindAsync(id);
        }

        public async Task UpdateCalificacionAsync(Calificaciones calificaciones)
        {
            _dbcontext.Calificaciones.Update(calificaciones);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
