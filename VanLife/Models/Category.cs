using System.ComponentModel.DataAnnotations;

namespace VanLife.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }  
    
    [MaxLength(20)]  
    [Required]  
    public string CategoryName { get; set; }  

    // one category for many posts
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}