using Microsoft.AspNetCore.Mvc;
using Quizgame.Properties.Helper;

namespace Quizgame.Controllers
{
    public class TutorialController : Controller
    {
        public IActionResult Index()
        {
            var sessionUserId = HttpContext.Session.GetInt32("UserId");
            int userId = 0;
            if (sessionUserId != null && sessionUserId > 0)
            {
                userId = (int)sessionUserId;
            }
            if (userId > 0)
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();
                var tutorial = databaseHelper.UserArticle(userId);
                var last = databaseHelper.lastArticle();
                if (tutorial.ArticleId==last.ArticleId) 
                {
                    return RedirectToAction("Index", "Final");
                }
                else  
                {
                    return View(tutorial);
                }
                
                   
            }
            return Unauthorized();
        }
    }
}

