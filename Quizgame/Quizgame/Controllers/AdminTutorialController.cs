using Microsoft.AspNetCore.Mvc;
using Quizgame.Models;
using Quizgame.Properties.Helper;

namespace Quizgame.Controllers
{
    public class AdminTutorialController : Controller
    {
        public IActionResult Index()
        {
            // var games = DataHelper.GetGames();
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            var tutorials = databaseDataHelper.GetTutorial();
            return View(tutorials);
        }

        public IActionResult Details(int Id)
        {
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            var tutorial = databaseDataHelper.ViewById(Id);
            return View(tutorial);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            var tutorial = databaseDataHelper.ViewById(Id);
            return View(tutorial);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Tutorial tutorial)
        {
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();

            databaseDataHelper.EditTutorial(tutorial);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Create()
        {
            Tutorial tutorial = new Tutorial();
            return View(tutorial);
        }

        [HttpPost]
        public IActionResult Create(Tutorial tutorial)
        {
            if (tutorial != null)
            {
                DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
                databaseDataHelper.CreateTutorial(tutorial);
                return RedirectToAction(nameof(Index));
            }
            return View(tutorial);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {

            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            var tutorial = databaseDataHelper.ViewById(Id);
            return View(tutorial);
        }

        [HttpPost]
        public IActionResult Delete(int ArticleId, Models.Tutorial tutorial)
        {
            DatabaseDataHelper databaseDataHelper = new DatabaseDataHelper();
            databaseDataHelper.DeleteTutorialById(ArticleId);
            return RedirectToAction(nameof(Index));
        }
    }
}
