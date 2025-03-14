using GGinfoSite.Data;
using GGinfoSite.Models;
using GGinfoSite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GGinfoSite.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        IBlogPostRepository repo;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public BlogController(UserManager<AppUser> userMngr,
            SignInManager<AppUser> signInMngr, IBlogPostRepository r)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            repo = r;
        }

        public async Task<IActionResult> Index()
        {
            var blogPosts = await repo.GetBlogPostsQuery().Include(bp => bp.Comments)
                .ThenInclude(c => c.Commenter).ToListAsync();
            return View(blogPosts);
        }

        public async Task<IActionResult> Filter(string poster, string date)
        {
            var blogPostsQuery = repo.GetBlogPostsQuery().Include(bp => bp.Comments);
            var blogPosts = await blogPostsQuery.ToListAsync();
            var filteredBlogPosts = blogPosts.Where(b => b.Poster.UserName == poster || poster == null).ToList();

            return View("Index", filteredBlogPosts);
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult BlogPost()
        {
            return View();
        }

        public IActionResult Comment(int blogPostID)
        {
            var commentVM = new CommentVM { BlogPostID = blogPostID };
            return View(commentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(CommentVM commentVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Comment", commentVM);
            }

            //extract comment from VM
            var comment = new Comment { CommentText = commentVM.CommentText, BlogPostID = commentVM.BlogPostID }; 
            comment.Commenter = userManager.GetUserAsync(User).Result;
            comment.CommentDate = DateTime.Now;
            await repo.StoreCommentAsync(comment);

            //grab parent blogpost
            var blogPost = await repo.GetBlogPostByIdAsync(commentVM.BlogPostID);

            //assign comment to post
            blogPost.Comments.Add(comment);
            await repo.UpdateBlogPostAsync(blogPost);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlogPostAsync(BlogPost model)
        {
            if (!ModelState.IsValid)
            {
                return View("BlogPost", model);
            }

            model.Poster = await userManager.GetUserAsync(User);
            model.PostTime = DateTime.Now;

            await repo.AddBlogPostAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComment(int commentID)
        {
            repo.DeleteComment(commentID);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBlogPost(int blogPostID)
        {
            repo.DeleteBlogPost(blogPostID);
            return RedirectToAction("Index");
        }
    }
}
