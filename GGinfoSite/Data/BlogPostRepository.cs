using GGinfoSite.Models;
using Microsoft.EntityFrameworkCore;

namespace GGinfoSite.Data
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<BlogPost> GetBlogPosts()
        {
            var blogPosts = _context.BlogPost
              .Include(blogPost => blogPost.Poster)
              .ToList<BlogPost>();
            return blogPosts;
        }

        public BlogPost GetBlogPostById(int id)
        {
            var blogPost = _context.BlogPost
              .Include(blogPost => blogPost.Poster)
              .Where(blogPost => blogPost.BlogPostID == id)
              .SingleOrDefault();
            return blogPost;
        }

        public int StoreBlogPost(BlogPost model)
        {
            model.PostTime = DateTime.Now;
            _context.BlogPost.Add(model);
            return _context.SaveChanges();
            // returns a positive value if succussful
        }
    }
}
