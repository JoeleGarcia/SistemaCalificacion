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

        public string? GetSession()
        {
            return HttpContext.Session.GetString("isSessionActive");
        }

        public void SetSession(string username)
        {
            HttpContext.Session.SetString("isSessionActive", username);
        }

        public void ClearSession()
        {
            HttpContext.Session.Remove("isSessionActive");
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        
    }
}
