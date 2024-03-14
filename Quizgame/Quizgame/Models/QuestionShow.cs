namespace Quizgame.Models
{
    public class QuestionShow
    {
        public int ArticleId { get; set; }
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        public string SelectedAnswerId { get; set; }
        public List<AnswerShow> Answers { get; set; }
    }
}
