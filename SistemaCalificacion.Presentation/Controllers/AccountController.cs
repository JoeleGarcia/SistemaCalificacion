using Microsoft.AspNetCore.Mvc;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;

namespace SistemaCalificacion.Presentation.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }

    }
}
