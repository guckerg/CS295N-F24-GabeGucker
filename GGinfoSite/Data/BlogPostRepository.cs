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

        public async Task<List<BlogPost>> GetBlogPostsAsync()
        {
            var blogList = await _context.BlogPost.Include(blogPost => blogPost.Poster).ToListAsync();
            return blogList;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _context.BlogPost.Include(blogPost => blogPost.Poster)
                .Where(blogPost => blogPost.BlogPostID == id).SingleOrDefaultAsync();

            if (blogPost == null)
            {
                throw new Exception($"Blogpost with ID {id} not found");
            }

            return blogPost;
        }

        public int StoreBlogPost(BlogPost model)
        {
            model.PostTime = DateTime.Now;
            _context.BlogPost.Add(model);
            return _context.SaveChanges();
        }
    }
}
