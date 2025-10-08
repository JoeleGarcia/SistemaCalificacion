using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Domain.Interfaces;
using SistemaCalificacion.Infrastructure.Data;
using SistemaCalificacion.Infrastructure.Repositories;

namespace SistemaCalificacion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<ICalificacionesRepository, CalificacionesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<IPasswordGenerator, PasswordGeneratorRepository>();

            services.AddScoped<ISessionManager, SessionManagerRepository>();

            services.AddAuthentication().AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Account/Login";
            });

            return services;
        }
    }
}
