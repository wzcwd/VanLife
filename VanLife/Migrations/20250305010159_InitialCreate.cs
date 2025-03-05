using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VanLife.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentContent = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageString = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "job" },
                    { 2, "housing" },
                    { 3, "pet" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "IsAdmin", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 4, 17, 1, 59, 392, DateTimeKind.Local).AddTicks(1330), "admin@example.com", true, "Admin123", "admin" },
                    { 2, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4600), "user1@example.com", false, "User123", "user1" },
                    { 3, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610), "user2@example.com", false, "User123", "user2" },
                    { 4, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610), "user3@example.com", false, "User123", "user3" },
                    { 5, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610), "user4@example.com", false, "User123", "user4" },
                    { 6, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610), "user5@example.com", false, "User123", "user5" },
                    { 7, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620), "user6@example.com", false, "User123", "user6" },
                    { 8, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620), "user7@example.com", false, "User123", "user7" },
                    { 9, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620), "user8@example.com", false, "User123", "user8" },
                    { 10, new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620), "user9@example.com", false, "User123", "user9" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Content", "CreatedAt", "Price", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Join our team for an exciting part-time opportunity in Coquitlam! Embrace the freedom of van life while contributing to a dynamic, flexible work environment. This position is perfect for those looking to balance work and adventure. ", new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(8740), 25m, "A part time position in Coquitlam ", new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(8740), 2 },
                    { 2, 2, "Looking for a new place to call home? Rent a cozy room in a beautiful house, perfect for individuals seeking a quiet and peaceful environment. Enjoy the convenience of a fully furnished space, including essential amenities such as high-speed internet, heating, and laundry facilities. The house is situated in a great location close to shops, parks, and transportation. Don't miss out on this opportunity to make this your next home!", new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9770), 1000m, "A room for rent", new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9780), 3 },
                    { 3, 3, "“Meet the best dog in the world! A loyal companion, always by your side, ready for every adventure. Whether you’re hiking, camping, or simply lounging at home, this dog is the perfect friend for any occasion. With their playful spirit and loving nature, they’ll bring joy to your life. Join us in celebrating the best furry friend you could ever ask for!”", new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9780), null, "The best dog in the world!", new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9780), 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentContent", "CreatedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Is it still available? I need this job!", new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(810), 1, 2 },
                    { 2, "Is it still available? I like the house!", new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(1290), 2, 3 },
                    { 3, "Cute dog !", new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(1290), 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreatedAt", "ImageString", "PostId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(110), "image1.jpg", 1 },
                    { 2, new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(530), "image2.jpg", 2 },
                    { 3, new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(540), "image3.jpg", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PostId",
                table: "Images",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
