using System.ComponentModel.DataAnnotations;

namespace VanLife.Models;

public class Comment
{
    [Key]
    public int CommentId { get; set; }  
    
    [Required]
    public int PostId { get; set; }  // foreign key
    
    [Required]
    public int UserId { get; set; }  // foreign key
    
    [Required]  
    [StringLength(100, ErrorMessage = "Content cannot exceed 100 characters.")]
    public string CommentContent { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // one comment to one post
    public Post Post { get; set; }

    // one comment to one user
    public User User { get; set; }
}