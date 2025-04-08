using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VanLife.Models;

public class User:IdentityUser
{
    [NotMapped] // do not create role name in User table
    public IList<string>? RoleNames { get; set; } = new List<string>();
}