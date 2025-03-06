namespace VanLife.Models.ViewModel;

public class PostViewModel
{
    public Post Post { get; set; }
    
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    public IEnumerable<Region> Regions { get; set; } = new List<Region>();
}