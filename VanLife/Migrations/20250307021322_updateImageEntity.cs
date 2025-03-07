using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanLife.Migrations
{
    /// <inheritdoc />
    public partial class updateImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Images",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "ContentType",
                value: "png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                column: "ContentType",
                value: "png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                column: "ContentType",
                value: "png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Images");
        }
    }
}
