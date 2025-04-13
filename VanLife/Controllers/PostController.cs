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
using X.PagedList.Extensions;

namespace VanLife.Controllers;

public class PostController(ILogger<PostController> logger, VanLifeContext context) : Controller
{
    public IActionResult ListAll(int categoryId, int page = 1, int pageSize = 10)
    {
        logger.LogInformation("List all Post :{page} of page size {pageSize}: ", page, pageSize);
        var posts = context.Posts
            .Where(p => p.CategoryId == categoryId)
            .OrderBy(p => p.UpdatedAt)
            .Include(p=> p.Images)
            .Include(p => p.User)
            .ToPagedList(page, pageSize);
        
        string viewKey = categoryId switch
        {
            CategoryConstant.HousingCategoryId => "Housing",
            CategoryConstant.JobCategoryId => "Job",
            CategoryConstant.PetCategoryId => "Pet",
            _ => categoryId.ToString()
        };
        
        ViewData["ActivePage"] = viewKey;
        ViewData["CategoryId"] = categoryId;
        return View("AllCategory", posts);
    }
    
    
    [Authorize]
    public IActionResult SavePost()
    {
        logger.LogInformation("SavePost: go to PostForm");
        var postViewModel = new PostViewModel
        {
            Post = new Post(),
            Categories = context.Categories.ToList(),
            Regions = context.Regions.ToList(),
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
            var existingPost = context.Posts
                .Include(p => p.Images)
                .FirstOrDefault(p => p.PostId == post.PostId);
            if (existingPost == null)
            {
                return NotFound();
            }
            
            int existingImageCount = existingPost.Images.Count;
            
            if (existingImageCount + images.Count > 3)
            {
                ModelState.AddModelError("Images", "Exceed the maximum number of images");
                postViewModel.Categories = context.Categories.ToList();
                postViewModel.Regions = context.Regions.ToList();
                return View("PostForm", postViewModel);
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Price = post.Price;
            existingPost.CategoryId = post.CategoryId;
            existingPost.RegionId = post.RegionId;
            existingPost.PriceUnit = post.PriceUnit;
            
            UploadImages(existingPost, images);
        }

        context.SaveChanges(); // it has to be saved to generate a post id for images to link

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
            logger.LogInformation("Processing image: {ImageName}, Size: {ImageSize} bytes", image.FileName,
                image.Length);
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

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteImage(int imageId, int postId)
    {
        // find the linked post
        var post = context.Posts.Find(postId);
        if (post == null)
        {
            return NotFound();
        }

        // only the owen and admin can delete the images
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var isAdmin = User.IsInRole(RoleConstant.Admin);
        if (post.UserId != currentUserId && !isAdmin)
        {
            return Forbid();
        }

        var image = context.Images.Find(imageId);
        if (image == null)
        {
            return NotFound();
        }
        // delete the image
        context.Images.Remove(image);
        context.SaveChanges();

        
        return RedirectToAction("EditPost", new { id = postId });
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

        var post = context.Posts
            .Include(p => p.Images)
            .FirstOrDefault(p => p.PostId == id);

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