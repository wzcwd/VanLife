using Microsoft.AspNetCore.Mvc;
using VanLife.Data;
using VanLife.Models;
using VanLife.Models.ViewModel;

namespace VanLife.Controllers;

public class PostController( ILogger<PostController> logger, VanLifeContext context): Controller
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
    public IActionResult SavePost(Post post)
    {
        if (!ModelState.IsValid)
        {
            // 如果模型验证失败，返回到表单视图，并携带现有数据
            return View("PostForm");
        }

        // 检查是否为新帖子（PostId 是否为 0）
        if (post.PostId == 0)
        {
            context.Posts.Add(post);
        }
        else
        {
            // 更新现有帖子
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
            existingPost.UpdatedAt = DateTime.Now;
        }

        context.SaveChanges(); // 保存更改
        return RedirectToAction("Index"); // 保存后重定向到帖子列表
    }







}