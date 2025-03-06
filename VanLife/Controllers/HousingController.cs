using Microsoft.AspNetCore.Mvc;
using VanLife.Data;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

public class HousingController(ILogger<HousingController> logger, VanLifeContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 10)
    {
        logger.LogInformation("ListAll Housing Post {page} of {pageSize}: ", page, pageSize);
        var posts = context
            .Posts.OrderBy(p => p.UpdatedAt)
            .ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Housing";
            
        return View("AllHousing",posts);
    }
}