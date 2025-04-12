using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VanLife.Models;

namespace VanLife.Data;

public class VanLifeContext : IdentityDbContext<User>
{
    public VanLifeContext(DbContextOptions<VanLifeContext> options) : base(options)
    { }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Seeding initial Data
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Job" },
            new Category { CategoryId = 2, CategoryName = "Housing" },
            new Category { CategoryId = 3, CategoryName = "Pet" }
        );
        
        modelBuilder.Entity<Region>().HasData(
            new Region { RegionId = 1, Location = "Downtown" },
            new Region { RegionId = 2, Location = "West Vancouver" },
            new Region { RegionId = 3, Location = "North Vancouver" },
            new Region { RegionId = 4, Location = "East Vancouver" },
            new Region { RegionId = 5, Location = "Burnaby" },
            new Region { RegionId = 6, Location = "Coquitlam" },
            new Region { RegionId = 7, Location = "Richmond" },
            new Region { RegionId = 8, Location = "New Westminster" },
            new Region { RegionId = 9, Location = "Surrey" }
        );
        
        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                PostId = 1, UserId = "64117936-776e-4710-b9e5-f2888573773e", CategoryId = 1, Title = "A part time position in Coquitlam ", Price = 25,
                CreatedAt = new DateTime(2025, 3, 4), UpdatedAt = new DateTime(2025, 3, 4),
                RegionId = 6, Content =
                    "Join our team for an exciting part-time opportunity in Coquitlam! Embrace the freedom of " +
                    "van life while contributing to a dynamic, flexible work environment. This position is perfect " +
                    "for those looking to balance work and adventure. "
            },
            new Post
            {
                PostId = 2, UserId = "64117936-776e-4710-b9e5-f2888573773e", CategoryId = 2, Title = "A room for rent", Price = 1000,
                CreatedAt = new DateTime(2025, 3, 4), UpdatedAt = new DateTime(2025, 3, 4),
                RegionId = 1, Content =
                    "Looking for a new place to call home? Rent a cozy room in a beautiful house, perfect for " +
                    "individuals seeking a quiet and peaceful environment. Enjoy the convenience of a fully furnished " +
                    "space, including essential amenities such as high-speed internet, heating, and laundry facilities. " +
                    "The house is situated in a great location close to shops, parks, and transportation. " +
                    "Don't miss out on this opportunity to make this your next home!"
            },
            new Post
            {
                PostId = 3, UserId = "64117936-776e-4710-b9e5-f2888573773e", CategoryId = 3, Title = "The best dog in the world!",
                CreatedAt = new DateTime(2025, 3, 4), UpdatedAt = new DateTime(2025, 3, 4),
                RegionId = 2, Content = "“Meet the best dog in the world! A loyal companion, always by your side, ready for every " +
                          "adventure. Whether you’re hiking, camping, or simply lounging at home, this dog is the perfect" +
                          " friend for any occasion. With their playful spirit and loving nature, they’ll bring joy to your " +
                          "life. Join us in celebrating the best furry friend you could ever ask for!”"
            }
        );
        

        modelBuilder.Entity<Image>().HasData(
            new Image { ImageId = 1, PostId = 1, ImageString = "image1.jpg", ContentType = "png"},
            new Image { ImageId = 2, PostId = 2, ImageString = "image2.jpg", ContentType = "png"},
            new Image { ImageId = 3, PostId = 3, ImageString = "image3.jpg", ContentType = "png"}
        );

        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                CommentId = 1, PostId = 1, UserId ="64117936-776e-4710-b9e5-f2888573773e", CreatedAt = new DateTime(2025, 3, 4),
                CommentContent = "Is it still available? I need this job!"
            },
            new Comment
            {
                CommentId = 2, PostId = 2, UserId = "64117936-776e-4710-b9e5-f2888573773e", CreatedAt = new DateTime(2025, 3, 4),
                CommentContent = "Is it still available? I like the house!"
            },
            new Comment
            {
                CommentId = 3, PostId = 3, UserId = "64117936-776e-4710-b9e5-f2888573773e", CreatedAt = new DateTime(2025, 3, 4),
                CommentContent = "Cute dog !"
            }
        );
        
    }
    
    
    public static async Task CreateUser(IServiceProvider serviceProvider)
    {
        UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        String username = "admin";
        String password = "Aa123456";
        String rolename = "Admin";
        String email = "admin@example.com";

        if (await roleManager.FindByNameAsync(rolename) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(rolename));
        }

        if (await userManager.FindByNameAsync(username) == null)
        {
            User user = new User()
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true,
            };
            IdentityResult result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, rolename);
            }
        }
    }
    
    
    
    
}