using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Infrastructure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        public Task<Materia> CreateMateriaAsync(Materia materia)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMateriaAsync(Materia materia)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Materia>> GetAllMateriatsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Materia> GetMateriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMateriaAsync(Materia materia)
        {
            throw new NotImplementedException();
        }
    }
}
