using Microsoft.AspNetCore.Mvc;
using VanLife.Data;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

public class HousingController(VanLifeContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 10)
    {
        var posts = context
            .Posts.OrderBy(p => p.UpdatedAt)
            .ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Housing";
            
        return View("AllHousing",posts);
    }
}