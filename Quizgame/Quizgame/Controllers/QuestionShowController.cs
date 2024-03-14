using Microsoft.AspNetCore.Mvc;
using Quizgame.Models;
using Quizgame.Properties.Helper;
namespace Quizgame.Controllers
{
    public class QuestionShowController : Controller
    {
        [HttpGet]
        public IActionResult Index(int Id)
        {
            QuestionPageData questionPageData = new QuestionPageData();
            var Questions = questionPageData.ViewByArticleId(Id);
            return View(Questions);
        }
        [HttpPost]
        public IActionResult Index(List<QuestionShow> UserData)
        {
            var sessionUserId = HttpContext.Session.GetInt32("UserId");
            int userId = 0;
            int questionId = 0;
            List<string> questionAnswerIds = new List<string>();

            if (sessionUserId != null && sessionUserId > 0)
            {
                userId = (int)sessionUserId;
            }

            if (UserData != null)
            {
                foreach (var item in UserData)
                {
                    questionAnswerIds.Add($"{item.QuestionId}={item.SelectedAnswerId}");
                    if (questionId == 0)
                    {
                        questionId = item.QuestionId;
                    }
                }
            }

            if (questionAnswerIds.Count > 0)
            {
                QuestionPageData questionPageData = new QuestionPageData();
                // save the answers
                questionPageData.UserAnswer(userId, string.Join(",", questionAnswerIds));
                // set the next artical for the user
                questionPageData.NextArticle(questionId, userId);
                // return to result view
                return RedirectToAction("Index", "Results");
            }
            else
            {
                return View(UserData);
            }
        }
    }
}
