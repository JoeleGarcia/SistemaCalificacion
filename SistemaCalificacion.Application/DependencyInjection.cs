using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using SistemaCalificacion.Application.Validator;
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

            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<ICalificacionesService, CalificacionesService>();
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<IValidator<LoginUserDto>, LoginUserDtoValidator>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IValidator<UserDto>, UserDtoValidator>();

            services.AddScoped<IValidator<UpdateCalificacionesDto>, UpdateCalificacionesDtoValidator>();
            services.AddScoped<IValidator<CreateCalificacionesDto>, CreateCalificacionesDtoValidator>();

            services.AddScoped<IValidator<UpdateEstudianteDto>, UpdateEstudianteDtoValidator>();
            services.AddScoped<IValidator<CreateEstudianteDto>, CreateEstudianteDtoValidator>();



            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            services.AddFluentValidationAutoValidation();

            return services;
        }

    }
}
