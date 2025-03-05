using System.ComponentModel.DataAnnotations;

namespace VanLife.Models;

public class Region
{
    [Key]
    public int RegionId { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Location { get; set; }
}