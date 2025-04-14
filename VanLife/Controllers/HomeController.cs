using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanLife.Constant;
using VanLife.Data;
using VanLife.Models;
using VanLife.Models.ViewModel;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

public class HomeController(ILogger<HomeController> logger, VanLifeContext context) : Controller
{
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Home";
        return View();
    }

    public IActionResult SearchAll(string searchString, int categoryId, int page = PagingConstant.DefaultPage,
        int pageSize = PagingConstant.DefaultPageSize)
    {
        var query = context.Posts
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Images)
            .Include(p => p.User);

        var posts = query
            .Where(p => string.IsNullOrEmpty(searchString)
                        || p.Title.ToLower().Contains(searchString.ToLower()))
            .OrderByDescending(p => p.UpdatedAt)
            .ToPagedList(page, pageSize);

        return View("SearchResult", posts);
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