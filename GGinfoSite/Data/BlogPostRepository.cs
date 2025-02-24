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

        #region Blogs
        public async Task<List<BlogPost>> GetBlogPostsAsync()
        {
            var blogList = await _context.BlogPosts.Include(blogPost => blogPost.Poster).ToListAsync();
            return blogList;
        }
        public async Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            var blogPost = await _context.BlogPosts.Include(blogPost => blogPost.Poster)
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
            _context.BlogPosts.Add(model);
            return _context.SaveChanges();
        }
        #endregion

        #region Comments
        public async Task<List<Comment>> GetCommentsAsync()
        {
            var commentList = await _context.Comments.Include(comment => comment.CommentID).ToListAsync();
            return commentList; //Maybe do this differently
        }
        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var comment = await _context.Comments.Include(comment => comment.CommentID)
                .Where(comment => comment.CommentID == id).SingleOrDefaultAsync();

            if (comment == null)
            {
                throw new Exception($"Comment with ID {id} not found");
            }

            return comment;
        }
        public int StoreComment(Comment model)
        {
            model.CommentDate = DateTime.Now;
            _context.Comments.Add(model);
            return _context.SaveChanges();
        }
        #endregion
    }
}
