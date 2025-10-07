using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using SistemaCalificacion.Presentation.Models;

namespace SistemaCalificacion.Presentation.Controllers
{
    public class MateriasController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMateriaService _materiaService;
        private readonly IMapper _mapper;

        public MateriasController(ILogger<AccountController> logger , IMateriaService materiaService, IMapper mapper) {
            _logger = logger;
            _materiaService = materiaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var _materias = await _materiaService.GetAllMateriaAsync();

            return View(_materias);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                TempData["MateriaError"] = "El identificador no es válido.";
                return RedirectToAction(nameof(Index));
            }

            await _materiaService.DeleteMateriaAsync(id);

            SetSuccessToast("Deleted successfully", "bg-danger");
            TempData["DisplayToast"] = true;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            //return PartialView("_Add");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, CreateMateriaDto createMateriaDto)
        {

            if (!ModelState.IsValid)
            {
                return View("Add", createMateriaDto);
            }

            var estaAgregado = await _materiaService.AddMateriaAsync(createMateriaDto);
            if (estaAgregado is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Add", createMateriaDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var _materia = await _materiaService.GetMateriaByIdAsync(id);
            var updateMateria = _mapper.Map<UpdateMateriaDto>(_materia);

            return View(updateMateria);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateMateriaDto updateMateriaDto)
        {

            if (!ModelState.IsValid)
            {

                return View("Update", updateMateriaDto);
            }

            await _materiaService.UpdateMateriaAsync(id, updateMateriaDto);

            return RedirectToAction(nameof(Index));
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
