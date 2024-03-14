using Microsoft.AspNetCore.Mvc;
using Quizgame.Models;
using Quizgame.Properties.Helper;

namespace Quizgame.Controllers.API
{
    [Route("api-Login")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {

        [HttpPost]
        [Route("Save-login")]
        public IActionResult SaveLogin(Login login)
        {
            if (login != null)
            {
                string name=login.Name;
                string password=login.Password;
                               
                DatabaseHelper databaseHelper = new DatabaseHelper();
                var user = databaseHelper.ValidUser(name, password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    return Ok(new { success = true });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Invalid username or password" });
                }
            }
            return BadRequest(new { success = false, message = "Invalid data" });

        }
    }

}
