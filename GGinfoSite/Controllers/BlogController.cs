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
            var blogPosts = await repo.GetBlogPostsQuery()
                                      .Include(bp => bp.Comments)
                                      .ToListAsync();
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
        public async Task<IActionResult> Comment(CommentVM commentVM)
        {
            //extract comment from VM
            var comment = new Comment { CommentText = commentVM.CommentText };
            comment.Commenter = userManager.GetUserAsync(User).Result;
            comment.CommentDate = DateTime.Now;

            //grab parent blogpost
            var blogPost = await repo.GetBlogPostsQuery()
                         .Include(bp => bp.Comments)
                         .FirstOrDefaultAsync(bp => bp.BlogPostID == commentVM.BlogPostID);


            blogPost.Comments.Add(comment);
            await repo.UpdateBlogPostAsync(blogPost);

            return RedirectToAction("BlogPost");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPostAsync(BlogPost model)
        {
            model.Poster = await userManager.GetUserAsync(User);
            model.PostTime = DateTime.Now;

            await repo.AddBlogPostAsync(model);
            return View(model);
        }
    }
}
