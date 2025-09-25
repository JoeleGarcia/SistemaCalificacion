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

        [HttpGet]
        public IActionResult Login()
        {
            var sessionActive = GetSession();

            if (sessionActive != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Username and password are required.");
                return View("Login");
            }

            var isValidUser = await _loginService.LoginAsync(username, password);
            if (isValidUser)
            {
                SetSession(username);
                TempData["SuccessMessage"] = "Login successful!";

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Verificar Username or password");

            return View("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var sessionActive = GetSession();

            if (sessionActive != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var isRegistered = await _loginService.RegisterAsync(registerUserDto);
            if (isRegistered)
            {
                SetSession(registerUserDto.Username);
                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("Index", "Home");
            }
            return View(registerUserDto);
        }

        public IActionResult Logout()
        {
            var sessionActive = GetSession();

            if (sessionActive != null)
            {
                ClearSession();
                TempData["SuccessMessage"] = "You have been logged out successfully.";
            }

            return RedirectToAction("Index", "Account");
        }
    }
}
