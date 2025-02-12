using Microsoft.AspNetCore.Mvc;
using GGinfoSite.Models;
using GGinfoSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GGinfoSite.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        IBlogPostRepository repo;
        ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public CommentController(IBlogPostRepository r, ApplicationDbContext context, 
            UserManager<AppUser> userMnger)
        {
            repo = r;
            _context = context;
            _userManager = userMnger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return View(); //make this go somewhere
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentByIdAsync()
        {
            //add definition
            return View();
        }
    }
}
