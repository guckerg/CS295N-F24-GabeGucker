using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace GGinfoSite.Data
{
    public interface IBlogPostRepository
    {
        //BlogPosts
        public IQueryable<BlogPost> GetBlogPostsQuery();
        public Task<BlogPost> GetBlogPostByIdAsync(int id);
        public Task AddBlogPostAsync(BlogPost model);
        public Task UpdateBlogPostAsync(BlogPost model);
        public int DeleteBlogPost(int blogPostID);

        //Comments
        public Task<List<Comment>> GetCommentsAsync();
        public Task<Comment> GetCommentByIdAsync(int id);
        public Task StoreCommentAsync(Comment model);
        public Task UpdateCommentAsync(Comment comment);
        public int DeleteComment(int commentID);
    }
}