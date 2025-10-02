using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object key)
            : base($"La entidad \"{entityName}\" con clave ({key}) no fue encontrada.")
        {
        }
    }

    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string message, string param ) : base(message) { }
    }

    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
