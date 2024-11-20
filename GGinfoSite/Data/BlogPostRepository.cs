using GGinfoSite.Models;
using Microsoft.EntityFrameworkCore;

namespace GGinfoSite.Data
{
    public interface BlogPostRepository : IBlogPostRepository
    {
        private ApplicationDbContext context;

        public BlogPostRepository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public List<BlogPost> GetAllBlogPosts()
        {
            var blogPost = context.BlogPost
              .Include(blogPost => blogPost.Poster) // returns BlogPost.AppUser object
              .ToList<BlogPost>();
            return blogPost;
        }

        public BlogPost GetBlogPostById(int id)
        {
            var blogPost = context.BlogPost
              .Include(blogPost => blogPost.Poster) // returns Reivew.AppUser object
              .Where(blogPost => blogPost.BlogPostID == id)
              .SingleOrDefault();
            return blogPost;
        }

        public int StoreBlogPost(BlogPost model)
        {
            model.PostTime = DateTime.Now;
            context.BlogPost.Add(model);
            return context.SaveChanges();
            // returns a positive value if succussful
        }
    }
}
