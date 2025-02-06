using GGinfoSite.Data;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var blogPosts = await repo.GetBlogPostsAsync();
            return View(blogPosts);
        }

        public async Task<IActionResult> Filter(string poster, string date)
        {
            var blogPosts = await repo.GetBlogPostsAsync();
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

        [HttpPost]
        public async Task<IActionResult> BlogPostAsync(BlogPost model)
        {
            model.Poster = await userManager.GetUserAsync(User);
            model.PostTime = DateTime.Now;

            repo.StoreBlogPost(model);
            return View(model);
        }
    }
}
