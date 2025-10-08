using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;

namespace SistemaCalificacion.Presentation.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ICalificacionesService _calificacionesService;
        private readonly IMapper _mapper;

        public CalificacionesController(ILogger<AccountController> logger, ICalificacionesService calificacionesService, IMapper mapper)
        {
            _logger = logger;
            _calificacionesService = calificacionesService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var _calificaciones = await _calificacionesService.GetAllCalificacionesAsync();

            return View(_calificaciones);
        }
    }
}
