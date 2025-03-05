using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanLife.Migrations
{
    /// <inheritdoc />
    public partial class updateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Images",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 399, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(8740), new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9770), new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9780), new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 392, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 4, 17, 1, 59, 398, DateTimeKind.Local).AddTicks(4620));
        }
    }
}
