
namespace SistemaCalificacion.Domain.Entities
{
    public class Estudiante
    {

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } = string.Empty;
        public string EmailInsitucional { get; set; }
        public string ?EmailPersonal { get; set; }
        public string Carrera { get; set; }
        public string Cedula { get; set; }
        public string Matricula { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Calificaciones> Calificaciones { get; set; } = new HashSet<Calificaciones>();

        //public Estudiante(string nombre, string apellido, string username , string password, string emailInsitucional , string? emailPersonal , string carrera, string cedula ,string matricula , bool status = false)
        //{
        //    Nombre              = nombre.TrimEnd();
        //    Apellido            = apellido.TrimEnd();
        //    Username            = username.TrimEnd();
        //    Password            = password;
        //    EmailInsitucional   = emailInsitucional.TrimEnd();
        //    EmailPersonal       = emailPersonal;
        //    Cedula              = cedula.TrimEnd();
        //    Carrera             = carrera.TrimEnd();
        //    Matricula           = matricula.TrimEnd();

        //    Id = Guid.NewGuid();
        //    CreatedAt = DateTime.UtcNow;
        //    UpdatedAt = DateTime.UtcNow;
        //    Role = "Estudiante";
        //    Status = status;
        //}

        public Estudiante()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Role = "Estudiante";
        }

    }
}
