using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Domain.Interfaces
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<Materia>> GetAllMateriatsAsync();
        Task<Materia> GetMateriaByIdAsync(int id);
        Task<Materia> CreateMateriaAsync(Materia materia);
        Task UpdateMateriaAsync(Materia materia);
        Task DeleteMateriaAsync(Materia materia);
    }
}
