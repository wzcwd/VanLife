using System.ComponentModel.DataAnnotations;

namespace VanLife.Models;

public class User
{
    [Key]
    public int UserId { get; set; } 
    
    [Required(ErrorMessage = "User name is required")]
    [StringLength(20, ErrorMessage = "Exceed the maximum length")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")] 
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)] 
    [MinLength(6)] 
    public string Password { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Set the user to be Admin
    public bool IsAdmin { get; set; } = false;  

    // one user for many posts 
    public ICollection<Post> Posts { get; set; }  = new List<Post>();

    // one user for many comments
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}