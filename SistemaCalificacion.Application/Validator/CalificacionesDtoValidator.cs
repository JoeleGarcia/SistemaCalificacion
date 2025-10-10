using FluentValidation;
using SistemaCalificacion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Validator
{


    //public class CalificacionesDtoValidator : AbstractValidator<CalificacionesDto>
    //{
    //    public CalificacionesDtoValidator()
    //    {

    //        RuleFor(x => x.EstudianteId)
    //            .NotEmpty().WithMessage("El EstudianteId es obligatorio.");

    //        RuleFor(x => x.MateriaId)
    //            .GreaterThan(0).WithMessage("Debe seleccionar una materia válida.");

    //        RuleFor(x => x.Calificacion1)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion1.HasValue)
    //            .WithMessage("La Calificación 1 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Calificacion2)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion2.HasValue)
    //            .WithMessage("La Calificación 2 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Calificacion3)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion3.HasValue)
    //            .WithMessage("La Calificación 3 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Calificacion4)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion4.HasValue)
    //            .WithMessage("La Calificación 4 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Examen)
    //            .InclusiveBetween(0, 100).When(x => x.Examen.HasValue)
    //            .WithMessage("El Examen debe estar entre 0 y 100.");
    //    }

    //}

    public class CreateCalificacionesDtoValidator : AbstractValidator<CreateCalificacionesDto>
    {
        public CreateCalificacionesDtoValidator()
        {

            RuleFor(x => x.EstudianteId)
                .NotEmpty().WithMessage("El EstudianteId es obligatorio.");

            RuleFor(x => x.MateriaId)
                .GreaterThan(0).WithMessage("Debe seleccionar una materia válida.");

            RuleFor(x => x.Calificacion1)
                .InclusiveBetween(0, 100).When(x => x.Calificacion1.HasValue)
                .WithMessage("La Calificación 1 debe estar entre 0 y 100.");

            RuleFor(x => x.Calificacion2)
                .InclusiveBetween(0, 100).When(x => x.Calificacion2.HasValue)
                .WithMessage("La Calificación 2 debe estar entre 0 y 100.");

            RuleFor(x => x.Calificacion3)
                .InclusiveBetween(0, 100).When(x => x.Calificacion3.HasValue)
                .WithMessage("La Calificación 3 debe estar entre 0 y 100.");

            RuleFor(x => x.Calificacion4)
                .InclusiveBetween(0, 100).When(x => x.Calificacion4.HasValue)
                .WithMessage("La Calificación 4 debe estar entre 0 y 100.");

            RuleFor(x => x.Examen)
                .InclusiveBetween(0, 100).When(x => x.Examen.HasValue)
                .WithMessage("El Examen debe estar entre 0 y 100.");

        }
    }



    public class UpdateCalificacionesDtoValidator : AbstractValidator<UpdateCalificacionesDto>
    {
        public UpdateCalificacionesDtoValidator()
        {

            RuleFor(x => x.EstudianteId)
                .NotEmpty().WithMessage("El EstudianteId es obligatorio.");

            RuleFor(x => x.MateriaId)
                .GreaterThan(0).WithMessage("Debe seleccionar una materia válida.");

            RuleFor(x => x.Calificacion1)
                .InclusiveBetween(0, 100)
                .WithMessage("La Calificación 1 debe estar entre 0 y 100.");

            RuleFor(x => x.Calificacion2)
                .InclusiveBetween(0, 100)
                .WithMessage("La Calificación 2 debe estar entre 0 y 100.");

            RuleFor(x => x.Calificacion3)
                .InclusiveBetween(0, 100)
                .WithMessage("La Calificación 3 debe estar entre 0 y 100.");

            RuleFor(x => x.Calificacion4)
                .InclusiveBetween(0, 100)
                .WithMessage("La Calificación 4 debe estar entre 0 y 100.");

            RuleFor(x => x.Examen)
                .InclusiveBetween(0, 100)
                .WithMessage("El Examen debe estar entre 0 y 100.");

        }
    }



    //public class SelectCalificacionesDtoValidator : AbstractValidator<SelectCalificacionesDto>
    //{
    //    public SelectCalificacionesDtoValidator()
    //    {

    //        RuleFor(x => x.EstudianteId)
    //            .NotEmpty().WithMessage("El EstudianteId es obligatorio.");

    //        RuleFor(x => x.MateriaId)
    //            .GreaterThan(0).WithMessage("Debe seleccionar una materia válida.");

    //        RuleFor(x => x.Calificacion1)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion1.HasValue)
    //            .WithMessage("La Calificación 1 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Calificacion2)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion2.HasValue)
    //            .WithMessage("La Calificación 2 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Calificacion3)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion3.HasValue)
    //            .WithMessage("La Calificación 3 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Calificacion4)
    //            .InclusiveBetween(0, 100).When(x => x.Calificacion4.HasValue)
    //            .WithMessage("La Calificación 4 debe estar entre 0 y 100.");

    //        RuleFor(x => x.Examen)
    //            .InclusiveBetween(0, 100).When(x => x.Examen.HasValue)
    //            .WithMessage("El Examen debe estar entre 0 y 100.");

    //    }
    //}

}
