using GGinfoSite.CafeQuiz;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GGinfoSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult References()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Quiz()
        {
            Quiz model = new Quiz();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Quiz(string[] answers)
        {
            Quiz model = new Quiz();
            for (int i = 0; i < answers.Length; i++)
            {
                string answer = answers[i];
                if (answer != null)
                {
                    Question q1 = model.Questions[i];
                    q1.UserA = answer;
                    q1.isRight = model.CheckAnswer(q1);
                }
            }

            return View(model);
        }
    }
}
