using System.ComponentModel.DataAnnotations;

namespace Quizgame.Models
{
    public class Login
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
