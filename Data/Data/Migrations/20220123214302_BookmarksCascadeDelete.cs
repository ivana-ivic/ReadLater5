using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BookmarksCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks"
                );

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AspNetUserId",
                table: "Bookmarks"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AspNetUserId",
                table: "Bookmarks",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks"
                );

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AspNetUserId",
                table: "Bookmarks"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_AspNetUserId",
                table: "Bookmarks",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
                );
        }
    }
}
