using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanLife.Constant;
using VanLife.Data;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

public class HousingController(ILogger<HousingController> logger, VanLifeContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 10)
    {
        logger.LogInformation("ListAll Housing Post page:{page} of page size {pageSize}: ", page, pageSize);
        var posts = context.Posts
            .Where(p => p.CategoryId == CategoryConstant.HousingCategoryId)
            .OrderBy(p => p.UpdatedAt)
            .Include(p=> p.Images)
            .ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Housing";
        
        return View("AllHousing", posts);
    }
}