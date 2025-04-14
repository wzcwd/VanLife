using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VanLife.Constant;
using VanLife.Data;
using VanLife.Models.ViewModel;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

public class AdminController(ILogger<HomeController> logger, VanLifeContext context) : Controller
{
    [Authorize(Roles = "Admin")]
    public IActionResult ListUsers(int page = PagingConstant.DefaultPage, int pageSize = PagingConstant.DefaultPageSize)
    {
        var users = context.Users.ToList();

        var model = users.Select(u => new UserRolesViewModel
        {
            User = u,
            RoleNames = (from ur in context.UserRoles
                join r in context.Roles on ur.RoleId equals r.Id
                where ur.UserId == u.Id
                select r.Name).ToList()
        }).ToPagedList(page, pageSize);

        return View("AllUsers", model);
    }
}