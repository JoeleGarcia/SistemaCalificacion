using Microsoft.EntityFrameworkCore;
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
        public Task<Calificaciones> AddCalificacionAsync(Calificaciones calificaciones)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCalificacionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Calificaciones>> GetAllCalificacionesAsync()
        {
            return await _dbcontext.Calificaciones
                        .Include(e => e.Estudiante)
                        .Include(m => m.Materia)
                        .ToListAsync();
        }

        public Task<Calificaciones?> GetCalificacionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCalificacionAsync(Calificaciones calificaciones)
        {
            throw new NotImplementedException();
        }
    }
}
