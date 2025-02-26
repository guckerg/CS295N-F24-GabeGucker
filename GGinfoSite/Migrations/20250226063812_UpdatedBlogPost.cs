using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GGinfoSite.Migrations
{
    public partial class UpdatedBlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostID",
                table: "Comments",
                column: "BlogPostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostID",
                table: "Comments",
                column: "BlogPostID",
                principalTable: "BlogPosts",
                principalColumn: "BlogPostID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogPostID",
                table: "Comments");
        }
    }
}
