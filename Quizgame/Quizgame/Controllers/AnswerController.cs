
using Microsoft.AspNetCore.Mvc;
using Quizgame.Models;
using Quizgame.Properties.Helper;

namespace Quizgame.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            AnswerDataHelper answerDataHelper = new AnswerDataHelper();
            var Answers = answerDataHelper.GetAnswers();
            return View(Answers);
        }

        public IActionResult AnswerView(int Id)
        {
            AnswerDataHelper answerDataHelper = new AnswerDataHelper();
            var answer = answerDataHelper.AnswerView(Id);
            return View(answer);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            QuestionDataHelper quizDataHelper = new QuestionDataHelper();
            var Questions = quizDataHelper.GetQuestions();
            AnswerDataHelper answerDataHelper = new AnswerDataHelper();
            var answer = answerDataHelper.AnswerView(Id);
            ViewBag.Questions = Questions;
            return View(answer);
        }



        [HttpPost]
        public IActionResult Edit(int Id, QuizAnswer answers)
        {
            AnswerDataHelper answerDataHelper = new AnswerDataHelper();
            answers.Id = Id;
            answerDataHelper.EditAnswer(answers);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Create()
        {
            QuestionDataHelper quizDataHelper = new QuestionDataHelper();
            var Questions = quizDataHelper.GetQuestions();
            QuizAnswer answer = new QuizAnswer();
            ViewBag.questions = Questions;
            return View(answer);
        }

        [HttpPost]
        public IActionResult Create(QuizAnswer answers)
        {
            if (answers != null)
            {
                AnswerDataHelper answerDataHelper = new AnswerDataHelper();
                answerDataHelper.CreateAnswer(answers);
                return RedirectToAction(nameof(Index));
            }
            return View(answers);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {

            AnswerDataHelper answerDataHelper = new AnswerDataHelper();
            var answers = answerDataHelper.AnswerView(Id);
            return View(answers);
        }

        [HttpPost]
        public IActionResult Delete(int Id, QuizAnswer answers)
        {
            AnswerDataHelper answerDataHelper = new();
            answerDataHelper.DeleteAnswerById(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
