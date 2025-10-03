using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaCalificacion.Domain.Entities
{
    public class Estudiante
    {

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; } = string.Empty;
        public string EmailInsitucional { get; set; }
        public string ?EmailPersonal { get; set; }
        public string ?Carrera { get; set; }
        public string Cedula { get; set; }
        public string Matricula { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Estudiante(string nombre, string apellido, string username , string password, string emailInsitucional , string emailPersonal , string carrera, string cedula ,string matricula , bool status = true)
        {

            if (string.IsNullOrWhiteSpace(cedula.ToString()))
                throw new ArgumentException("La Cedula no puede esta vacio");

            if (cedula.ToString().Length != 11)
                throw new ArgumentException("La Cedula tiene que ser de 11 Digitos");

            if (password.Length < 10)
                throw new ArgumentException("La contraseña debe tener al menos 10 Caracteres");

            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            Username = username.Trim();
            Password = password;
            EmailInsitucional = emailInsitucional;
            EmailPersonal = emailPersonal;
            Cedula = cedula;
            Carrera = carrera;
            Matricula = matricula;
            Status = status;


            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Role = "Estudiante";
            Status = true;

        }

        public Estudiante()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Role = "Estudiante";
            //Status = true;
        }

        public void UpdateCampos(string nombre, string apellido, string username, string emailInsitucional, string emailPersonal, string carrera, string cedula, string matricula, bool status = true)
        {
            if (string.IsNullOrWhiteSpace(cedula.ToString()))
                throw new ArgumentException("La Cedula no puede esta vacio");

            if (cedula.ToString().Length != 11)
                throw new ArgumentException("La Cedula tiene que ser de 11 Digitos");

            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            Username = username.Trim();
            EmailInsitucional = emailInsitucional;
            EmailPersonal = emailPersonal;
            Cedula = cedula;
            Carrera = carrera;
            Matricula = matricula;
            Status = status;

        }
    }
}
