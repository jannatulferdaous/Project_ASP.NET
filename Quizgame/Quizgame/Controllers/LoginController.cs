using Microsoft.AspNetCore.Mvc;
using Quizgame.Models;
using Quizgame.Properties.Helper;

namespace Quizgame.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Login login = new Login();
            return View(login);
        }

        //[HttpPost]
        //public IActionResult Index (Login login)
        //{
        //    if (login != null)
        //    {
        //        DatabaseHelper databaseHelper = new DatabaseHelper();
        //        var user = databaseHelper.ValidUser(login);
        //        if (user != null)
        //        {
        //            HttpContext.Session.SetInt32("UserId", user.UserId);
        //            return RedirectToAction("Index", "Tutorial");
        //        }
        //        else
        //        {
        //            return View(login);
        //        }
        //    }
        //    return View(login);
        //}
    }
}
