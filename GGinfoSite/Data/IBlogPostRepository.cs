using GGinfoSite.Models;

namespace GGinfoSite.Data
{
    public interface IBlogPostRepository
    {
        public Task<List<BlogPost>> GetBlogPostsAsync();
        public Task<BlogPost> GetBlogPostByIdAsync(int id); // Returns a model object
        public int StoreBlogPost(BlogPost model);  // Saves a model object to the db
    }
}