using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Interfaces
{
    public interface IPasswordGenerator
    {
        string GenerarPassword(int length = 12);

    }
}
