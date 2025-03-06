using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VanLife.Data;
using VanLife.Models;

namespace VanLife.Controllers;

public class HomeController(ILogger<HomeController> logger, VanLifeContext context) : Controller
{

    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Home";
        return View();
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}