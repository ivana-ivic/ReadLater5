using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddUserToCategoriesAndBookmarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_AspNetUserId",
                table: "Categories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
                );

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Bookmarks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AspNetUserId",
                table: "Bookmarks",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AspNetUserId",
                table: "Bookmarks"
                );

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Bookmarks"
                );
        }
    }
}
