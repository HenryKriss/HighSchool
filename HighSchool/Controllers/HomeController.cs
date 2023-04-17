using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HighSchool.Models;
using HighSchool.Services;

namespace HighSchool.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHighSchoolService _galerinhaService;

    public HomeController(ILogger<HomeController> logger, IHighSchoolService galerinhaService)
    {
        _logger = logger;
        _galerinhaService = galerinhaService;
    }

    public IActionResult Index(string tipo)
    {
        var galera = _galerinhaService.GetHighSchoolDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(galera);
    }

    public IActionResult Details(int Numero)
    {
        var personagem = _galerinhaService.GetDetailedPersonagem(Numero);
        return View(personagem);
    }

    public IActionResult Privacy ()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
