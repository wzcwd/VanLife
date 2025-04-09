using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VanLife.Data;
using VanLife.Models;
using VanLife.Models.ViewModel;

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
        var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        var exceptionMessage = feature?.Error.Message;

        var model = new ErrorViewModel
        {
            RequestId = requestId,
            ExceptionMessage = exceptionMessage,
        };
        return View(model);
    }
    
    public IActionResult HandleStatusCode(int code)
    {
        var viewModel = new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier,
            StatusCode = code
        };
        return View("Error", viewModel); 
    }
}