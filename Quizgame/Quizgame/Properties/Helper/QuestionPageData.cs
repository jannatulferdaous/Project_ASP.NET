using Microsoft.Data.SqlClient;
using Quizgame.Models;
using System.Data;

namespace Quizgame.Properties.Helper
{
    public class QuestionPageData
    {
        private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";

        public List<QuestionShow> ViewByArticleId(int ArticleId)
        {
            string SP_Questionshow = "Questionshow";

            List<QuestionShow> QList = new List<QuestionShow>();
            List<AnswerShow> answers = null;
            QuestionShow questionShow = null;
            AnswerShow answerShow = null;

            int previousQuestionId = -1;
            int currentQuestionId = -1;

            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_Questionshow, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ArticleId", SqlDbType.Int).Value = ArticleId;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            currentQuestionId = Convert.ToInt32(reader["QuestionId"]);
                            if (previousQuestionId == -1 || previousQuestionId != currentQuestionId)
                            {
                                // for first row
                                previousQuestionId = currentQuestionId;
                                questionShow = new QuestionShow();
                                questionShow.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                                questionShow.Question = Convert.ToString(reader["Question"]);
                                questionShow.QuestionId = currentQuestionId;
                                answers = new List<AnswerShow>();
                                answerShow = new AnswerShow();
                                answerShow.AnswerId = Convert.ToInt32(reader["AnswerId"]);
                                answerShow.Answer = Convert.ToString(reader["Answer"]);
                                answerShow.IsCorrect = Convert.ToBoolean(reader["IsCorrect"]);
                                answers.Add(answerShow);
                                questionShow.Answers = answers;
                                QList.Add(questionShow);
                            }
                            else if (previousQuestionId == currentQuestionId)
                            {
                                // row with same questionid as previouse one
                                answerShow = new AnswerShow();
                                answerShow.AnswerId = Convert.ToInt32(reader["AnswerId"]);
                                answerShow.Answer = Convert.ToString(reader["Answer"]);
                                answerShow.IsCorrect = Convert.ToBoolean(reader["IsCorrect"]);
                                questionShow.Answers.Add(answerShow);
                            }
                            //else
                            //{
                            //    previousQuestionId = currentQuestionId;
                            //    questionShow = new QuestionShow();
                            //    questionShow.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                            //    questionShow.Question = Convert.ToString(reader["Question"]);
                            //    questionShow.QuestionId = currentQuestionId;
                            //    answers = new List<AnswerShow>();
                            //    answerShow = new AnswerShow();
                            //    answerShow.AnswerId = Convert.ToInt32(reader["AnswerId"]);
                            //    answerShow.Answer = Convert.ToString(reader["Answer"]);
                            //    answerShow.IsCorrect = Convert.ToBoolean(reader["IsCorrect"]);
                            //    answers.Add(answerShow);
                            //    questionShow.Answers = answers;
                            //}
                        }
                    }
                    connection.Close();
                }
            }
            return QList;
        }

        public void UserAnswer(int userId, string questionAnswer)
        {
            string SP_CreateQuestion_answerMap = "CreateQuestion_answerMap";
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_CreateQuestion_answerMap, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@QuestionAnswer", SqlDbType.VarChar).Value = questionAnswer;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void NextArticle(int questionId, int userId)
        {
            string SP_NextArticle = "NextArticle";
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_NextArticle, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@QuestionId", SqlDbType.Int).Value = questionId;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
