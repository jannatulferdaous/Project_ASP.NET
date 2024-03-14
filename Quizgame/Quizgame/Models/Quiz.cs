namespace Quizgame.Models
{
    public class Quiz
    {
        public int QuestionId { get; set; }
        public string? Article { get; set; }
        public titlelist Title { get; set; }
        public string? Question { get; set; }
        public int ArticleId { get; set; }

        public string? ShortQuestion
        {
            get
            {
                if (Question == null)
                {
                    return null;
                }
                else {

                    String value = Question;
                    int startIndex = 0;
                    int length = 20;
                   String substring = value.Substring(startIndex, length);
                    // Console.WriteLine(substring);


                    return substring;  
                }
            
            }
        }
        public List<QuizAnswer> Answers { get; set; }


        public enum titlelist
        {
            Syntax,
            data_types, 
            Constrants ,  
            Opreators ,
            Decition_making 
        }
    }
}
