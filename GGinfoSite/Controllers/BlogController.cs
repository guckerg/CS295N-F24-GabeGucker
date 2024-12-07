using GGinfoSite.Data;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace GGinfoSite.Controllers
{
    public class BlogController : Controller
    {
        //private instance variable
        IBlogPostRepository repo;

        //constructor
        public BlogController(IBlogPostRepository r)
        {
            repo = r;
        }
        
        public IActionResult Index()
        {
           var blogPosts = repo.GetBlogPosts();
            return View(blogPosts);
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
        public IActionResult BlogPost(BlogPost model)
        {
            model.PostTime = DateTime.Now;  // Add date and time to the model
            if (repo.StoreBlogPost(model) > 0)
            {
                return RedirectToAction("Index", new { blogPostID = model.BlogPostID });
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the Blog Post.";
                return View();
            }
        }
    }
}
