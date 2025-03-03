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
        public IQueryable<BlogPost> GetBlogPostsQuery()
        {
            return _context.BlogPosts.Include(blogPost => blogPost.Poster);
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
        public async Task AddBlogPostAsync(BlogPost model)
        {
            model.PostTime = DateTime.Now;
            _context.BlogPosts.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlogPostAsync(BlogPost model)
        {
            _context.BlogPosts.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBlogPostAsync(int id)
        {
            var targetBlogPost = await _context.BlogPosts.FindAsync(id);
            _context.BlogPosts.Remove(targetBlogPost);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region Comments
        public async Task<List<Comment>> GetCommentsAsync()
        {
            var commentList = await _context.Comments.Include(comment => comment.CommentID).ToListAsync();
            return commentList;
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

        public async Task UpdateCommentAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCommentAsync(int id)
        {
            var targetComment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(targetComment);
            return await _context.SaveChangesAsync();
        }
        #endregion
    }
}
