using System.ComponentModel.DataAnnotations;

namespace VanLife.Models;

public class Image
{
    [Key] 
    public int ImageId { get; set; }  
    
    [Required] 
    public int PostId { get; set; }  // foreign key 
    
    [Required] 
    public string ImageString { get; set; }  // Base64 encoded image string
    
    public string ContentType { get; set; } 

    // one image for one post
    public Post Post { get; set; }
}