using Microsoft.AspNetCore.Mvc;
using Quizgame.Models;
using Quizgame.Properties.Helper;

namespace Quizgame.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            QuestionDataHelper quizDataHelper = new QuestionDataHelper();
            var Questions = quizDataHelper.GetQuestions();
            return View(Questions);
        }

        public IActionResult Questionview(int Id)
        {
            QuestionDataHelper databaseDataHelper = new QuestionDataHelper();
            var questions = databaseDataHelper.QuestionView(Id);
            return View(questions);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            var Tutorials = databaseDataHelper.GetTutorial();
            QuestionDataHelper databaseDataHelper1 = new QuestionDataHelper();
            var question = databaseDataHelper1.QuestionView(Id);
            ViewBag.Article = Tutorials;
            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Quiz ques)
        {
            QuestionDataHelper databaseDataHelper = new QuestionDataHelper();
            ques.QuestionId = Id;
            databaseDataHelper.EditQuestion(ques);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Create()
        {
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            var Tutorials = databaseDataHelper.GetTutorial();
            Quiz question = new Quiz();
            ViewBag.Article=Tutorials;
            return View(question);
        }

        [HttpPost]
        public IActionResult Create(Quiz questions)
        {
            if (questions != null)
            {
                QuestionDataHelper databaseDataHelper = new QuestionDataHelper();
                databaseDataHelper.CreateQuestion(questions);
                return RedirectToAction(nameof(Index));
            }
            return View(questions);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {

            QuestionDataHelper DataHelper = new QuestionDataHelper();
            var questions =  DataHelper.QuestionView(Id);
            return View(questions);
        }

        [HttpPost]
        public IActionResult Delete(int QuestionId, Models.Quiz questions)
        {
            QuestionDataHelper DataHelper = new QuestionDataHelper();
            questions.QuestionId = QuestionId;
            DataHelper.DeleteQuestionById(QuestionId);
            return RedirectToAction(nameof(Index));
        }
    }
}
