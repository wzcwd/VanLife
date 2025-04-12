using System.ComponentModel.DataAnnotations;
using VanLife.Utility;

namespace VanLife.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }  
    
    [Required]  
    public string UserId { get; set; }  // foreign key to Identity User
    
    [Required(ErrorMessage = "Category is required")]  
    public int CategoryId { get; set; }  // foreign key
    
    [Required(ErrorMessage = "Location is required")]  
    public int? RegionId { get; set; }  // foreign key
    
    [Required(ErrorMessage = "Title is required")]  
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Content is required")] 
    [StringLength(2000, ErrorMessage = "Content cannot exceed 2000 characters.")]
    public string Content { get; set; }

    public decimal Price { get; set; } = 0;

    public PriceUnit PriceUnit { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    // one post for many comments
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    // one post to many images
    public ICollection<Image> Images { get; set; } = new List<Image>();
    // one post for one user
    public User? User { get; set; }
    // one post for one region
    public Region? Region { get; set; }  
    
    // one post for one category
    public Category? Category { get; set; }
}