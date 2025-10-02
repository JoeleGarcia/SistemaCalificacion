using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Exceptions;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using SistemaCalificacion.Presentation.Models;

namespace SistemaCalificacion.Presentation.Controllers
{

    public class EstudiantesViewModel
    {
        public IEnumerable<EstudianteDto> ?estudianteDtos { get; set; }
        public IEnumerable<TransactionsToast> ?transactionsToasts { get; set; }
        // Puedes agregar más colecciones aquí
    }

    public class EstudiantesController : Controller
    {
        private readonly IEstudianteService _estudianteService;
        private readonly ILogger<AccountController> _logger;

        public EstudiantesController(ILogger<AccountController> logger, IEstudianteService estudianteService)
        {
            _logger = logger;
            _estudianteService = estudianteService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var estudiantes = await _estudianteService.GetAllEstudianteAsync();
            ViewBag.JavascriptToRun = "ShowErrorPopup()";
            return View(estudiantes);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            await _estudianteService.DeleteEstudianteByIdAsync(id);

            SetSuccessToast("Deleted successfully", "bg-danger");
            TempData["DisplayToast"] = true;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EstudianteDto estudianteDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Add", estudianteDto);
                }

                var estaAgregado = await _estudianteService.AddEstudianteAsync(estudianteDto);
                if (estaAgregado is not null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("Add", estudianteDto);
                //return RedirectToAction(nameof(Register) , registerUserDto);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError(string.Empty, "Username o password no son válidos.");
                return View("Add", estudianteDto);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Error {Username}", ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Add", estudianteDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en registrar el usuario {Username}", estudianteDto?.EmailInstitucional);

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }

        }
        private void SetSuccessToast(string message, string cssClass)
        {
            // Add success toast message for the current operation
            TempData["TransactionsToast"] = JsonConvert.SerializeObject(new List<TransactionsToast>
            {
                new TransactionsToast
                {
                    Message = message,
                    CssClass = cssClass
                }
            });
        }

    }
}
