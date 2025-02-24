using GGinfoSite.Models;

namespace GGinfoSite.Data
{
    public interface IBlogPostRepository
    {
        //BlogPosts
        public Task<List<BlogPost>> GetBlogPostsAsync();
        public Task<BlogPost> GetBlogPostByIdAsync(int id);
        public int StoreBlogPost(BlogPost model);

        //Comments
        public Task<List<Comment>> GetCommentsAsync();
        public Task<Comment> GetCommentByIdAsync(int id);
        public int StoreComment(Comment model);
    }
}