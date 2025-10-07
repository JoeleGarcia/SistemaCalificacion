using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Interfaces
{
    public interface IMateriaService
    {
        Task<IEnumerable<MateriaDto>> GetAllMateriaAsync();
        Task<MateriaDto> GetMateriaByIdAsync(int id);
        Task<CreateMateriaDto> AddMateriaAsync(CreateMateriaDto createMateriaDto);
        Task UpdateMateriaAsync(int id, UpdateMateriaDto updateMateriaDto);
        Task DeleteMateriaAsync(int id);
    }
}
