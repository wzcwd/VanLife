using Microsoft.AspNetCore.Mvc;
using VanLife.Data;
using VanLife.Models;
using VanLife.Models.ViewModel;

namespace VanLife.Controllers;

public class PostController(ILogger<PostController> logger, VanLifeContext context) : Controller
{
    public IActionResult SavePost()
    {
        logger.LogInformation("SavePost: go to PostForm");
        var categories = context.Categories.ToList();
        var regions = context.Regions.ToList();
        var postViewModel = new PostViewModel
        {
            Post = new Post(),
            Categories = categories,
            Regions = regions,
        };
        return View("PostForm", postViewModel);
    }

    [HttpPost]
    public IActionResult SavePost(PostViewModel postViewModel, List<IFormFile> images)
    {
        if (!ModelState.IsValid)
        {
            postViewModel.Categories = context.Categories.ToList();
            postViewModel.Regions = context.Regions.ToList();
            return View("PostForm", postViewModel);
        }
        
        // maximum number pf image is 3
        if (images.Count > 3)
        {
            ModelState.AddModelError("Images", "Exceed the maximum number of images");
            postViewModel.Categories = context.Categories.ToList();
            postViewModel.Regions = context.Regions.ToList();
            return View("PostForm", postViewModel);
        }
        
        var post = postViewModel.Post;
        // start transaction
        using var transaction = context.Database.BeginTransaction();
        
        if (post.PostId == 0) // new post
        {
            context.Posts.Add(post);
        }
        else
        {
            // edit post
            var existingPost = context.Posts.Find(post.PostId);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Price = post.Price;
            existingPost.CategoryId = post.CategoryId;
            existingPost.RegionId = post.RegionId;
        }
        context.SaveChanges(); 
        
        // deal with images
        foreach (var image in images)
        {
            logger.LogInformation("Processing image: {ImageName}, Size: {ImageSize} bytes", image.FileName, image.Length);
            if (image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);  
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());

                    // create image 
                    post.Images.Add(new Image 
                    { 
                        ImageString = base64String,
                        ContentType = image.ContentType,
                        PostId = post.PostId 
                    });
                }
            }
        }
        context.SaveChanges(); 
        // commit transaction
        transaction.Commit(); 
        
        return RedirectToAction("Index", "Home");
    }
}