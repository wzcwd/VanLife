using Microsoft.EntityFrameworkCore;
using VanLife.Models;

namespace VanLife.Data;

public class VanLifeContext : DbContext
{
    public VanLifeContext(DbContextOptions<VanLifeContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seeding initial Data
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1, UserName = "admin", Email = "admin@example.com", Password = "Admin123", IsAdmin = true,
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 2, UserName = "user1", Email = "user1@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 3, UserName = "user2", Email = "user2@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 4, UserName = "user3", Email = "user3@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 5, UserName = "user4", Email = "user4@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 6, UserName = "user5", Email = "user5@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 7, UserName = "user6", Email = "user6@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 8, UserName = "user7", Email = "user7@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 9, UserName = "user8", Email = "user8@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            },
            new User
            {
                UserId = 10, UserName = "user9", Email = "user9@example.com", Password = "User123",
                CreatedAt = new DateTime(2025, 3, 4)
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "job" },
            new Category { CategoryId = 2, CategoryName = "housing" },
            new Category { CategoryId = 3, CategoryName = "pet" }
        );

        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                PostId = 1, UserId = 2, CategoryId = 1, Title = "A part time position in Coquitlam ", Price = 25,
                CreatedAt = new DateTime(2025, 3, 4), UpdatedAt = new DateTime(2025, 3, 4),
                Content =
                    "Join our team for an exciting part-time opportunity in Coquitlam! Embrace the freedom of " +
                    "van life while contributing to a dynamic, flexible work environment. This position is perfect " +
                    "for those looking to balance work and adventure. "
            },
            new Post
            {
                PostId = 2, UserId = 3, CategoryId = 2, Title = "A room for rent", Price = 1000,
                CreatedAt = new DateTime(2025, 3, 4), UpdatedAt = new DateTime(2025, 3, 4),
                Content =
                    "Looking for a new place to call home? Rent a cozy room in a beautiful house, perfect for " +
                    "individuals seeking a quiet and peaceful environment. Enjoy the convenience of a fully furnished " +
                    "space, including essential amenities such as high-speed internet, heating, and laundry facilities. " +
                    "The house is situated in a great location close to shops, parks, and transportation. " +
                    "Don't miss out on this opportunity to make this your next home!"
            },
            new Post
            {
                PostId = 3, UserId = 4, CategoryId = 3, Title = "The best dog in the world!",
                CreatedAt = new DateTime(2025, 3, 4), UpdatedAt = new DateTime(2025, 3, 4),
                Content = "“Meet the best dog in the world! A loyal companion, always by your side, ready for every " +
                          "adventure. Whether you’re hiking, camping, or simply lounging at home, this dog is the perfect" +
                          " friend for any occasion. With their playful spirit and loving nature, they’ll bring joy to your " +
                          "life. Join us in celebrating the best furry friend you could ever ask for!”"
            }
        );

        modelBuilder.Entity<Image>().HasData(
            new Image { ImageId = 1, PostId = 1, ImageString = "image1.jpg" },
            new Image { ImageId = 2, PostId = 2, ImageString = "image2.jpg" },
            new Image { ImageId = 3, PostId = 3, ImageString = "image3.jpg" }
        );

        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                CommentId = 1, PostId = 1, UserId = 2, CreatedAt = new DateTime(2025, 3, 4),
                CommentContent = "Is it still available? I need this job!"
            },
            new Comment
            {
                CommentId = 2, PostId = 2, UserId = 3, CreatedAt = new DateTime(2025, 3, 4),
                CommentContent = "Is it still available? I like the house!"
            },
            new Comment
            {
                CommentId = 3, PostId = 3, UserId = 4, CreatedAt = new DateTime(2025, 3, 4),
                CommentContent = "Cute dog !"
            }
        );
    }
}