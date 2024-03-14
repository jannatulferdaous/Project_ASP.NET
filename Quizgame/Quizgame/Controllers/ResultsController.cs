using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quizgame.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ILogger<ResultsController> _logger;

        public ResultsController(ILogger<ResultsController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
 