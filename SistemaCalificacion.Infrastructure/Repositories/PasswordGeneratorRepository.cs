using SistemaCalificacion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Infrastructure.Repositories
{
    public class PasswordGeneratorRepository : IPasswordGenerator
    {
        private static Random rnd = new Random();

        public string GenerarPassword(int length = 12)
        {

            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string contrasena = "";

            for (int i = 0; i < length; i++)
            {
                contrasena += caracteres[rnd.Next(caracteres.Length)];
            }

            return contrasena;
        }
    }
}
