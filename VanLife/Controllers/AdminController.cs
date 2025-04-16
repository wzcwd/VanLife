using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VanLife.Constant;
using VanLife.Data;
using VanLife.Models.ViewModel;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(ILogger<HomeController> logger, VanLifeContext context) : Controller
{
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

    [HttpPost]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ListUsers));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveAdmin(string userId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");
        if (adminRole != null)
        {
            var userRole = context.UserRoles.FirstOrDefault(ur => ur.UserId == user.Id && ur.RoleId == adminRole.Id);
            if (userRole != null)
            {
                context.UserRoles.Remove(userRole);
                await context.SaveChangesAsync();
            }
        }

        return RedirectToAction(nameof(ListUsers));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignAdmin(string userId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");
        if (adminRole != null)
        {
            var exists = context.UserRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == adminRole.Id);
            if (!exists)
            {
                context.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRole.Id });
                await context.SaveChangesAsync();
            }
        }

        return RedirectToAction(nameof(ListUsers));
    }
    
}