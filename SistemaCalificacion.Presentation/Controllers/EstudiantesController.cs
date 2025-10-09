using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Exceptions;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using SistemaCalificacion.Domain.Entities;
using SistemaCalificacion.Presentation.Models;

namespace SistemaCalificacion.Presentation.Controllers
{
      
    public class EstudiantesController : Controller
    {
        private readonly IEstudianteService _estudianteService;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public EstudiantesController(ILogger<AccountController> logger, IEstudianteService estudianteService , IMapper mapper)
        {
            _logger = logger;
            _estudianteService = estudianteService;
            _mapper = mapper;
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

            //return PartialView("_Add");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {

            var _estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            var updateEstudiante = _mapper.Map<UpdateEstudianteDto>(_estudiante);

            return View(updateEstudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateEstudianteDto updateEstudianteDto)
        {

            if (!ModelState.IsValid)
            {

                return View("Update", updateEstudianteDto);
            }

            await _estudianteService.UpdateEstudianteAsync(id, updateEstudianteDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEstudianteDto createEstudianteDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Add", createEstudianteDto);
                }

                var estaAgregado = await _estudianteService.AddEstudianteAsync(createEstudianteDto);
                if (estaAgregado is not null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("Add", createEstudianteDto);
                //return RedirectToAction(nameof(Register) , registerUserDto);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError("_addError", "Username o password no son válidos.");
                return View("Add", createEstudianteDto);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Error {Username}", ex.Message);
                ModelState.AddModelError("_addError", ex.Message);
                return View("Add", createEstudianteDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en registrar el usuario {Username}", createEstudianteDto?.EmailInstitucional);

                ModelState.AddModelError("_addError", ex.Message);
                return View("Add", createEstudianteDto);
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
