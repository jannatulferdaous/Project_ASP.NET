using Microsoft.AspNetCore.Mvc;
using Quizgame.Properties.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quizgame.Controllers.API
{
    [Route("api/result")]
    [ApiController]
    public class ResultAPIController : ControllerBase
    {
        // GET: api/<ResultAPIController>
        [HttpGet]
        [Route("get-score")]
        public IActionResult GetScore()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            var Result = databaseHelper.GetResultcs();
            int score = Result.Score;
            return Ok(new { score = score });
        }
    }
}
