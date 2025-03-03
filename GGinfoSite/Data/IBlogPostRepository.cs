using GGinfoSite.Models;

namespace GGinfoSite.Data
{
    public interface IBlogPostRepository
    {
        //BlogPosts
        public IQueryable<BlogPost> GetBlogPostsQuery();
        public Task<BlogPost> GetBlogPostByIdAsync(int id);
        public Task AddBlogPostAsync(BlogPost model);
        public Task UpdateBlogPostAsync(BlogPost model);
        public Task<int> DeleteBlogPostAsync(int id);

        //Comments
        public Task<List<Comment>> GetCommentsAsync();
        public Task<Comment> GetCommentByIdAsync(int id);
        public int StoreComment(Comment model);
        public Task UpdateCommentAsync(Comment comment);
        public Task<int> DeleteCommentAsync(int id);
    }
}