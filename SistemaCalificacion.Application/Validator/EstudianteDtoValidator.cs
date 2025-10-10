using FluentValidation;
using FluentValidation.Validators;
using SistemaCalificacion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Validator
{
    public class CreateEstudianteDtoValidator : AbstractValidator<CreateEstudianteDto>
    {
        public CreateEstudianteDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MinimumLength(4).WithMessage("El nombre de usuario debe tener al menos 4 caracteres.");

            RuleFor(x => x.EmailInstitucional)
                .NotEmpty().WithMessage("El correo institucional es obligatorio.")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Debe ingresar un correo institucional válido.");

            RuleFor(x => x.Matricula)
                .NotEmpty().WithMessage("La matrícula es obligatoria.")
                .Must(SoloNumeros).WithMessage("La cédula solo debe contener caracteres numéricos.")
                .Length(9).WithMessage("La matrícula no puede exceder los 9 caracteres.");

            RuleFor(x => x.Cedula)
                .NotEmpty().WithMessage("La cédula es obligatoria.")
                .Must(SoloNumeros).WithMessage("La cédula solo debe contener caracteres numéricos.")
                .Length(11).WithMessage("La cédula debe tener exactamente 11 caracteres.");

            RuleFor(x => x.Carrera)
                .NotEmpty().WithMessage("La carrera es obligatoria.");

        }

        private bool SoloNumeros(string value)
        {
            if (value != null && value.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }


    public class UpdateEstudianteDtoValidator : AbstractValidator<UpdateEstudianteDto>
    {
        public UpdateEstudianteDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MinimumLength(4).WithMessage("El nombre de usuario debe tener al menos 4 caracteres.");

            RuleFor(x => x.EmailInstitucional)
                .NotEmpty().WithMessage("El correo institucional es obligatorio.")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Debe ingresar un correo institucional válido.");

            RuleFor(x => x.Matricula)
                .NotEmpty().WithMessage("La matrícula es obligatoria.")
                .Matches(@"^\d+$").WithMessage("La matrícula solo debe contener números.")
                .Length(9).WithMessage("La matrícula no puede exceder los 11 caracteres.");

            RuleFor(x => x.Cedula)
                .NotEmpty().WithMessage("La cédula es obligatoria.")
                .Must(SoloNumeros).WithMessage("La cédula solo debe contener caracteres numéricos.")
                .Length(11).WithMessage("La cédula debe tener exactamente 11 caracteres.");

            RuleFor(x => x.Carrera)
                .NotEmpty().WithMessage("La carrera es obligatoria.");

        }

        private bool SoloNumeros(string value)
        {
            if (value != null && value.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }

}
