using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaCalificacion.Presentation.Models;

namespace SistemaCalificacion.Presentation.Controllers;

public class Page2 : Controller
{
  public IActionResult Index() => View();
}
