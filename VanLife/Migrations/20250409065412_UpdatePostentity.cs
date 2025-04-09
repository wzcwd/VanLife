using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanLife.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Regions_RegionId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceUnit",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PriceUnit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PriceUnit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PriceUnit",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Regions_RegionId",
                table: "Posts",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Regions_RegionId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PriceUnit",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Posts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Regions_RegionId",
                table: "Posts",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId");
        }
    }
}
