using FluentValidation;
using FluentValidation.Validators;
using SistemaCalificacion.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificacion.Application.Validator
{

    // https://docs.fluentvalidation.net/en/latest/inheritance.html
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El Enail de usuario no puede estar vacío.")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("El Email de usuario no es un formato de correo valido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.");
        }
    }

   
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {

            RuleFor(x => new LoginUserDto(x.Email , x.Password))
                .SetValidator(new LoginUserDtoValidator());

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El Nombre no puede estar vacía.")
                .MinimumLength(3).WithMessage("El Nombre debe tener al menos 3 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El Apellido no puede estar vacía.")
                .MinimumLength(3).WithMessage("El Apellido debe tener al menos 3 caracteres.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirmar contraseña no puede estar vacio")
                .Equal(x => x.Password).WithMessage("La confirmacion de la contraseña no coinciden");

        }
    }

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El Enail de usuario no puede estar vacío.")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("El Email de usuario no es un formato de correo valido.");


            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El Nombre no puede estar vacía.")
                .MinimumLength(3).WithMessage("El Nombre debe tener al menos 3 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El Apellido no puede estar vacía.")
                .MinimumLength(3).WithMessage("El Apellido debe tener al menos 3 caracteres.");

        }
    }




}