using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VanLife.Constant;
using VanLife.Models;
using VanLife.Models.ViewModel;
using X.PagedList.Extensions;

namespace VanLife.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;

        _logger = logger;
    }

    public async Task<IActionResult> ListUsers(int page = PagingConstant.DefaultPage,
        int pageSize = PagingConstant.DefaultPageSize)
    {
        var users = _userManager.Users.ToList();

        var model = new List<UserRolesViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            model.Add(new UserRolesViewModel
            {
                User = user,
                RoleNames = roles.ToList()
            });
        }

        var pagedModel = model.ToPagedList(page, pageSize);
        return View("ListUsers", pagedModel);
    }

    public async Task<IActionResult> SearchUser(string email, int page = PagingConstant.DefaultPage,
        int pageSize = PagingConstant.DefaultPageSize)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            ViewData["ErrorMessage"] = "Please enter an email address.";
            return View("ListUsers", new List<UserRolesViewModel>().ToPagedList(page, pageSize));
        }
        
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            ViewData["ErrorMessage"] = "No user is found.";
            return View("ListUsers", new List<UserRolesViewModel>().ToPagedList(page, pageSize));
        }

        var model = new List<UserRolesViewModel>();

        var roles = await _userManager.GetRolesAsync(user);
        model.Add(new UserRolesViewModel
        {
            User = user,
            RoleNames = roles.ToList()
        });

        var pagedModel = model.ToPagedList(page, pageSize);
        return View("ListUsers", pagedModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest("Failed to delete user.");
        }

        return RedirectToAction(nameof(ListUsers));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            throw new InvalidOperationException("Admin role does not exist.");
        }

        if (await _userManager.IsInRoleAsync(user, "Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
        }

        return RedirectToAction(nameof(ListUsers));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            throw new InvalidOperationException("Admin role does not exist.");
        }

        if (!await _userManager.IsInRoleAsync(user, "Admin"))
        {
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        return RedirectToAction(nameof(ListUsers));
    }
}