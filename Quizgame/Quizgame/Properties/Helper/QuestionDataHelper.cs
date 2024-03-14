using Microsoft.Data.SqlClient;
using Quizgame.Models;
using System.Data;
using static Quizgame.Models.Quiz;

namespace Quizgame.Properties.Helper
{
    public class QuestionDataHelper
    {
        // private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";
        private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";
        private const string SP_GetQuestions = "GetQuestions";
        private const string SP_QuestionView = "QuestionView";
        private const string SP_CreateQuestion = "CreateQuestion";
        private const string SP_EditQuestion = "EditQuestion";
        private const string SP_DeleteQuestionById = "DeleteQuestionById";

        public List<Quiz> GetQuestions()
        {
            List<Quiz> questions = new List<Quiz>();
            Quiz quiz = null;
            // Prepare for SQL server connectivity
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                // Prepare the command that need to be executed into SQL server
                using (SqlCommand command = new SqlCommand(SP_GetQuestions, connection))
                {
                    // define the command type as Stored Procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // open the sql server connection
                    connection.Open();
                    // get data from sql server by execting the command
                    // and initiate a reader to read sql server returned data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // loop through the reader until it can read values
                        while (reader.Read())
                        {
                            // populate the Game object with SQL server returned data
                            quiz = new Quiz();

                            quiz.QuestionId = Convert.ToInt32(reader["QuestionId"]);                           
                            string  titlevalue = Convert.ToString(reader["Title"]);                          
                            quiz.Title = (titlelist)Enum.Parse(typeof(titlelist),titlevalue);
                            quiz.Question = Convert.ToString(reader["Question"]);
                            quiz.ArticleId = Convert.ToInt32(reader["ArticleId"]);

                            // add the Game object into the Collection that will be returned from this method
                            questions.Add(quiz);
                        }
                    }
                    // close the SQL server connection
                    connection.Close();
                }
            }
            // return the Game collection that we got from database.
            return questions;
        }

        public Quiz QuestionView(int QuestionId)
        {
            Quiz question = null;
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_QuestionView, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@questionId", SqlDbType.Int).Value = QuestionId;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            question = new Quiz();
                            question.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                           // question.Article = Convert.ToString(reader["Article"]);
                            question.Question = Convert.ToString(reader["Question"]);
                            question.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                        }
                    }
                    connection.Close();
                }
            }
            return question;
        }

        public void CreateQuestion(Quiz question)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_CreateQuestion, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ArticleId", SqlDbType.Int).Value = question.ArticleId;
                    command.Parameters.Add("@Title", SqlDbType.VarChar).Value = question.Title;
                    command.Parameters.Add("@Question", SqlDbType.Text).Value = question.Question;
                    


                    connection.Open();
                    command.ExecuteNonQuery( );
                    connection.Close();
                }
            }
        }

        public void EditQuestion(Quiz questions)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_EditQuestion, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@QuestionId", SqlDbType.Int).Value = questions.QuestionId;
                    command.Parameters.Add("@Title", SqlDbType.VarChar).Value = questions.Title;
                    command.Parameters.Add("@Question", SqlDbType.Text).Value = questions.Question;
                    command.Parameters.Add("@ArticleId", SqlDbType.Int).Value = questions.ArticleId;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteQuestionById(int QuestionId)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_DeleteQuestionById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@QuestionId", SqlDbType.Int).Value = QuestionId;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
    }
}