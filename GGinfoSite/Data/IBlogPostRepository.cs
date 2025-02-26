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

        //Comments
        public Task<List<Comment>> GetCommentsAsync();
        public Task<Comment> GetCommentByIdAsync(int id);
        public int StoreComment(Comment model);

        //add UpdateComment
    }
}