using Microsoft.Extensions.DependencyInjection;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped<ILoginService, LoginService>();

            return services;
        }

    }
}
