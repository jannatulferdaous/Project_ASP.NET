using System.Collections;
using System.Security.Policy;

namespace Quizgame.Models
{
    public class QuizAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? Answer { get; set; }
        public Boolean  IsCorrect { get; set; }
      //  public string UserAnswer { get; set; }
    }
}
