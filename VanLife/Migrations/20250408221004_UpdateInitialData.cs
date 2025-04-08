using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VanLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Content", "CreatedAt", "Price", "RegionId", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Join our team for an exciting part-time opportunity in Coquitlam! Embrace the freedom of van life while contributing to a dynamic, flexible work environment. This position is perfect for those looking to balance work and adventure. ", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 6, "A part time position in Coquitlam ", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "64117936-776e-4710-b9e5-f2888573773e" },
                    { 2, 2, "Looking for a new place to call home? Rent a cozy room in a beautiful house, perfect for individuals seeking a quiet and peaceful environment. Enjoy the convenience of a fully furnished space, including essential amenities such as high-speed internet, heating, and laundry facilities. The house is situated in a great location close to shops, parks, and transportation. Don't miss out on this opportunity to make this your next home!", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m, 1, "A room for rent", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "64117936-776e-4710-b9e5-f2888573773e" },
                    { 3, 3, "“Meet the best dog in the world! A loyal companion, always by your side, ready for every adventure. Whether you’re hiking, camping, or simply lounging at home, this dog is the perfect friend for any occasion. With their playful spirit and loving nature, they’ll bring joy to your life. Join us in celebrating the best furry friend you could ever ask for!”", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "The best dog in the world!", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "64117936-776e-4710-b9e5-f2888573773e" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentContent", "CreatedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Is it still available? I need this job!", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "64117936-776e-4710-b9e5-f2888573773e" },
                    { 2, "Is it still available? I like the house!", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "64117936-776e-4710-b9e5-f2888573773e" },
                    { 3, "Cute dog !", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "64117936-776e-4710-b9e5-f2888573773e" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ContentType", "ImageString", "PostId" },
                values: new object[,]
                {
                    { 1, "png", "image1.jpg", 1 },
                    { 2, "png", "image2.jpg", 2 },
                    { 3, "png", "image3.jpg", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);
        }
    }
}
