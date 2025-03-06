using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VanLife.Migrations
{
    /// <inheritdoc />
    public partial class updatePostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "RegionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "RegionId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "Location" },
                values: new object[,]
                {
                    { 1, "Downtown" },
                    { 2, "West Vancouver" },
                    { 3, "North Vancouver" },
                    { 4, "East Vancouver" },
                    { 5, "Burnaby" },
                    { 6, "Coquitlam" },
                    { 7, "Richmond" },
                    { 8, "New Westminster" },
                    { 9, "Surrey" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RegionId",
                table: "Posts",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Regions_RegionId",
                table: "Posts",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Regions_RegionId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Posts_RegionId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Posts");
        }
    }
}
