using Microsoft.AspNetCore.Mvc;

namespace Quizgame.Controllers
{
    public class FinalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
