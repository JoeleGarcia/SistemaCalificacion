using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Exceptions;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using System.Linq;

namespace SistemaCalificacion.Presentation.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ICalificacionesService _calificacionesService;
        private readonly IMateriaService _materiaService;
        private readonly IEstudianteService _estudianteService;

        private readonly IMapper _mapper;

        public CalificacionesController(ILogger<AccountController> logger, ICalificacionesService calificacionesService, IMapper mapper, IMateriaService materiaService, IEstudianteService estudianteService)
        {
            _logger = logger;
            _calificacionesService = calificacionesService;
            _mapper = mapper;
            _materiaService = materiaService;
            _estudianteService = estudianteService;
        }
        public async Task<IActionResult> Index()
        {
            var _calificaciones = await _calificacionesService.GetAllCalificacionesAsync();

            return View(_calificaciones);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                TempData["MateriaError"] = "El identificador no es válido.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _calificacionesService.DeleteCalificacionesAsync(id);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError(string.Empty, "Username o password no son válidos.");
                TempData["MateriaError"] = "El identificador no es válido.";
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, "Error {Username}", ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
                TempData["MateriaError"] = "El identificador no es válido.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al Eliminar Registro {id}", id.ToString());

                ModelState.AddModelError("_addError", ex.Message);
                TempData["MateriaError"] = "El identificador no es válido.";
                return RedirectToAction(nameof(Index));
            }
            //SetSuccessToast("Deleted successfully", "bg-danger");
            //TempData["DisplayToast"] = true;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
         
            var _materias = await _materiaService.GetAllMateriaAsync();
            var _estudiantes = await _estudianteService.GetAllEstudianteAsync();

            ViewData["Materias"] = new SelectList(await _materiaService.GetAllMateriaAsync(), "Id", "Nombre");
            ViewData["Estudiantes"] = new SelectList(await _estudianteService.GetAllEstudianteAsync(), "Id", "Nombre");
            ViewData["Estudiantes"] = new SelectList(
                _estudiantes.Select(m => new {
                    Value = m.Id,
                    Text = $"{m.Nombre} {m.Apellido} - {m.Matricula}"
                }),
                "Value",
                "Text"
            );


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCalificacionesDto createCalificacionesDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Add", createCalificacionesDto);
                }

                var estaAgregado = await _calificacionesService.AddCalificacionesAsync(createCalificacionesDto);
                if (estaAgregado is not null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("Add", createCalificacionesDto);

            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Error");
                ModelState.AddModelError("_addError", "Username o password no son válidos.");
                return View("Add", createCalificacionesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar la calificacion para el estudiante {Estudiante}", createCalificacionesDto?.EstudianteId);

                ModelState.AddModelError("_addError", ex.Message);
                return View("Add", createCalificacionesDto);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {          
            var _calificaciones = await _calificacionesService.GetCalificacionesByIdAsync(id);
            var updateCalificaciones = _mapper.Map<UpdateCalificacionesDto>(_calificaciones);

            var _materias = await _materiaService.GetAllMateriaAsync();
            var _estudiantes = await _estudianteService.GetAllEstudianteAsync();

            ViewData["Materias"]    = new SelectList( await _materiaService.GetAllMateriaAsync(), "Id" , "Nombre");
            ViewData["Estudiantes"] = new SelectList(await _estudianteService.GetAllEstudianteAsync(), "Id", "Nombre");
            ViewData["Estudiantes"] = new SelectList(
                _estudiantes.Select(m => new {
                        Value = m.Id,
                        Text = $"{m.Nombre} {m.Apellido} - {m.Matricula}"
                    }),
                "Value",
                "Text"
            );

            return View(updateCalificaciones);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateCalificacionesDto updateCalificacionesDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", updateCalificacionesDto);
            }

            await _calificacionesService.UpdateCalificacionesAsync(id, updateCalificacionesDto);

            return RedirectToAction(nameof(Index));
        }
    }
}
