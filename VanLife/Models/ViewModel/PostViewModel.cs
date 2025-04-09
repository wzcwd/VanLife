using Microsoft.AspNetCore.Mvc.Rendering;
using VanLife.Utility;

namespace VanLife.Models.ViewModel;

public class PostViewModel
{
    public Post Post { get; set; }
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    public IEnumerable<Region> Regions { get; set; } = new List<Region>();
    
    public IEnumerable<SelectListItem> PriceUnits { get; set; } = new List<SelectListItem>();
    public PriceUnit SelectedPriceUnit { get; set; } = PriceUnit.Month;
}