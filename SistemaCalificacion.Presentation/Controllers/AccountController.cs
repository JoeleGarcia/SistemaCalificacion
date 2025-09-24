using Microsoft.AspNetCore.Mvc;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;

namespace SistemaCalificacion.Presentation.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

    }
}
