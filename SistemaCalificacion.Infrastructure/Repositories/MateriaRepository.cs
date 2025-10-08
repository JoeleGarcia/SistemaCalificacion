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
    public class MateriaRepository : IMateriaRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public MateriaRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Materia> AddMateriaAsync(Materia materia)
        {
            try
            {
                await _dbcontext.Materia.AddAsync(materia);
                await _dbcontext.SaveChangesAsync();
                return materia;
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                throw new InfrastructureException("Timeout al consultar la base de datos", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InfrastructureException("Error en la consulta de Materia", ex);
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

        public async Task DeleteMateriaAsync(int id)
        {
            var _materia = await GetMateriaByIdAsync(id);

            if (_materia is null)
                throw new NotFoundException("Estudiante", string.Format("By Id {id}" , id) );

            _dbcontext.Materia.Remove(_materia);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Materia>> GetAllMateriaAsync()
        {
            return await _dbcontext.Materia.ToListAsync();
        }

        public async Task<Materia?> GetMateriaByIdAsync(int id)
        {
            return await _dbcontext.Materia.FindAsync(id);
        }

        public async Task UpdateMateriaAsync(Materia materia)
        {
            _dbcontext.Materia.Update(materia);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
