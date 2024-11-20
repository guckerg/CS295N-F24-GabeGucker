using GGinfoSite.Models;

namespace GGinfoSite.Data
{
    public interface IBlogPostRepository
    {
        public List<BlogPost> GetBlogPosts();
        public BlogPost GetBlogPostById(int id); // Returns a model object
        public int StoreBlogPost(BlogPost model);  // Saves a model object to the db
    }
}