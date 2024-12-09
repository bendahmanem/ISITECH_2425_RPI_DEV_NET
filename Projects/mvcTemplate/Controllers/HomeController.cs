using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// une directive qui permet d'importer les classes du namespace mvc.Models
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly TestModel _testModel;
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        Console.WriteLine("Error");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
