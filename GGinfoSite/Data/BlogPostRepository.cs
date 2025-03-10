using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc;
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

        public int DeleteBlogPost(int blogPostID)
        {
            var targetBlogPost = _context.BlogPosts.Find(blogPostID);
            if(targetBlogPost.Comments != null && targetBlogPost.Comments.Count > 0)
            {
                foreach(var comment in targetBlogPost.Comments)
                {
                    _context.Comments.Remove(comment);
                }
            }
            _context.BlogPosts.Remove(targetBlogPost);
            return _context.SaveChanges();
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
        public async Task StoreCommentAsync(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public int DeleteComment(int commentID)
        {
            var targetComment = _context.Comments.Find(commentID);
            _context.Comments.Remove(targetComment);
            return _context.SaveChanges();
        }
        #endregion
    }
}
