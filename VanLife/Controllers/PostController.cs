using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanLife.Constant;
using VanLife.Data;
using VanLife.Models;
using VanLife.Models.ViewModel;
using VanLife.Utility;

namespace VanLife.Controllers;

public class PostController(ILogger<PostController> logger, VanLifeContext context) : Controller
{
    [Authorize]
    public IActionResult SavePost()
    {
        logger.LogInformation("SavePost: go to PostForm");
        var postViewModel = new PostViewModel
        {
            Post = new Post(),
            Categories =  context.Categories.ToList(),
            Regions =  context.Regions.ToList(),
            SelectedPriceUnit = PriceUnit.Month,
            PriceUnits = new SelectList(Enum.GetValues(typeof(PriceUnit)))
        };
        return View("PostForm", postViewModel);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
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
        post.PriceUnit = postViewModel.SelectedPriceUnit;

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
            existingPost.PriceUnit = post.PriceUnit; 
        }

        context.SaveChanges();

        // deal with images
        UploadImages(post, images);

        context.SaveChanges();
        // commit transaction
        transaction.Commit();

        return RedirectToAction(nameof(Index), "Home");
    }
    
    private void UploadImages(Post post, List<IFormFile> images)
    {
        foreach (var image in images)
        {
            logger.LogInformation("Processing image: {ImageName}, Size: {ImageSize} bytes", image.FileName, image.Length);
            if (image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());

                    post.Images.Add(new Image
                    {
                        ImageString = base64String,
                        ContentType = image.ContentType,
                        PostId = post.PostId
                    });
                }
            }
        }
    }

    public IActionResult PostDetail(int id)
    {
        logger.LogInformation("Detail: go to detailed post");

        var post = context.Posts
            .Where(p => p.PostId == id)
            .Include(p => p.Images)
            .Include(p => p.Category)
            .Include(p => p.Region)
            .Include(p => p.Comments)
            .Include(p => p.User)
            .FirstOrDefault();

        if (post == null)
        {
            return NotFound();
        }

        return View("PostDetail", post);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int id)
    {
        logger.LogInformation("DeletePost: attempt to delete post {PostId}", id);

        var post = context.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isAdmin = User.IsInRole(RoleConstant.Admin);
        if (post.UserId != currentUserId && !isAdmin)
        {
            return Forbid();
        }

        context.Posts.Remove(post);
        context.SaveChanges();

        return RedirectToAction(nameof(Index), "Home");
    }

    [Authorize]
    public IActionResult EditPost(int id)
    {
        logger.LogInformation("EditPost: attempt to edit post {PostId}", id);

        var post = context.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isAdmin = User.IsInRole(RoleConstant.Admin);
        if (post.UserId != currentUserId && !isAdmin)
        {
            return Forbid();
        }

        PostViewModel model = new PostViewModel()
        {
            Post = post,
            Categories = context.Categories.ToList(),
            Regions = context.Regions.ToList(),
            SelectedPriceUnit = post.PriceUnit,
            PriceUnits = new SelectList(Enum.GetValues(typeof(PriceUnit)))
        };

        return View("PostForm", model);
    }
}