using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using SistemaCalificacion.Domain.Interfaces;
using SistemaCalificacion.Infrastructure.Data;
using SistemaCalificacion.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register the UserRepository with dependency injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }


    }
}
