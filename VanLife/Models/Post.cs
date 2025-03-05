using System.ComponentModel.DataAnnotations;

namespace VanLife.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }  
    
    [Required]
    public int UserId { get; set; }  // foreign key
    
    [Required]  
    public int CategoryId { get; set; }  // foreign key
    
    public int? RegionId { get; set; }  // foreign key
    
    [Required]  
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }
    
    [Required] 
    [StringLength(2000, ErrorMessage = "Content cannot exceed 2000 characters.")]
    public string Content { get; set; }
    
    public decimal? Price { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    // one post for many comments
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    // one post to many images
    public ICollection<Image> Images { get; set; } = new List<Image>();
    // one post for one user
    public User User { get; set; }
    // one post for one region
    public Region Region { get; set; }  
}