using Microsoft.AspNetCore.Mvc;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Exceptions;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;

namespace SistemaCalificacion.Presentation.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILoginService _loginService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, ILoginService loginService)
        {
            _logger = logger;
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
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var sessionActive = GetSession();

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/");
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto, string? returnUrl = null)
        {
            try
            {
                if (string.IsNullOrEmpty(loginUserDto.Email) || string.IsNullOrEmpty(loginUserDto.Password))
                {
                    ModelState.AddModelError(string.Empty, "Username and password are required.");
                    return View("Login");
                }

                var UserData = await _loginService.LoginAsync(loginUserDto.Email, loginUserDto.Password);
                if (UserData is not null)
                {

                    _logger.LogInformation("Usuario {Username} inició sesión correctamente", loginUserDto.Email);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    SetSession(loginUserDto.Email);
                    TempData["SuccessMessage"] = "Login successful!";

                    return RedirectToAction("Index", "Home");
                }

                _logger.LogWarning("Intento de login fallido para el usuario {Username}", loginUserDto.Email);
                ModelState.AddModelError(string.Empty, "Verificar Username or password");

                return View("Login");

            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError(string.Empty, "Username o password no son válidos.");
                return View("Login");
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError(string.Empty, "Username o password no son válidos.");
                return View("Login");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Login para el usuario {Username}", loginUserDto?.Email);

                TempData["ErrorMessage"] = "Ocurrió un error inesperado. Intente nuevamente.";
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            //var sessionActive = GetSession();

            //if (sessionActive != null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {

            try 
            {
                if (!ModelState.IsValid)
                {
                    return View("Register", registerUserDto);
                }
                var isRegistered = await _loginService.RegisterAsync(registerUserDto);
                if (isRegistered)
                {
                    //SetSession(registerUserDto.Username);
                    TempData["SuccessMessage"] = "Registration successful!";
                    return RedirectToAction("Index", "Home");
                }

                return View("Register", registerUserDto);
                //return RedirectToAction(nameof(Register) , registerUserDto);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError(string.Empty, "Username o password no son válidos.");
                return View("Register", registerUserDto);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Error {Username}", ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Register", registerUserDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en registrar el usuario {Username}", registerUserDto?.Email);

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
            
        }

        [HttpPost]
        public IActionResult Logout()
        {

            _loginService.LogoutAsync();

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
