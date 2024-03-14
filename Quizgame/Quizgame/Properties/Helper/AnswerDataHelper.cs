 
using Microsoft.Data.SqlClient;
using Quizgame.Models;
using System.Data;

namespace Quizgame.Properties.Helper
{
    public class AnswerDataHelper
    {
        // private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";
        private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";
        private const string SP_GetAnswers = "GetAnswers";
        private const string SP_CreateAnswer = "CreateAnswer";
        private const string SP_EditAnswer = "EditAnswer";
        private const string SP_AnswerView = "AnswerView";
        private const string SP_DeleteAnswerById = "DeleteAnswerById";
       

        public List<QuizAnswer> GetAnswers()
        {
            List<QuizAnswer> Answers = new List<QuizAnswer>();
            QuizAnswer quizAnswer = null;
            // Prepare for SQL server connectivity
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                // Prepare the command that need to be executed into SQL server
                using (SqlCommand command = new SqlCommand(SP_GetAnswers, connection))
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
                            quizAnswer = new QuizAnswer();

                            quizAnswer.Id = Convert.ToInt32(reader["Id"]);
                            quizAnswer.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                            quizAnswer.Answer = Convert.ToString(reader["Answer"]);
                            quizAnswer.IsCorrect = Convert.ToBoolean(reader["IsCorrect"]);

                            // add the Game object into the Collection that will be returned from this method
                            Answers.Add(quizAnswer);
                        }
                    }
                    // close the SQL server connection
                    connection.Close();
                }
            }
            // return the Game collection that we got from database.
            return Answers;
        }

        public QuizAnswer AnswerView(int Id)
        {
            QuizAnswer answer = null;
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_AnswerView, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            answer = new QuizAnswer();

                            answer.Id = Convert.ToInt32(reader["Id"]);
                            answer.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                            answer.Answer = Convert.ToString(reader["Answer"]);
                            answer.IsCorrect = Convert.ToBoolean(reader["IsCorrect"]);
                            //database theke data newa
                        }
                    }
                    connection.Close();
                }
            }
            return answer; 
        }




        public void CreateAnswer(QuizAnswer answer)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_CreateAnswer, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@QuestionId", SqlDbType.VarChar).Value = answer.QuestionId;
                    command.Parameters.Add("@Answer", SqlDbType.Text).Value = answer.Answer;
                    command.Parameters.Add("@IsCorrect", SqlDbType.Int).Value = answer.IsCorrect;


                    connection.Open();
                     command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void EditAnswer(QuizAnswer answer)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_EditAnswer, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = answer.Id;
                    command.Parameters.Add("@QuestionId", SqlDbType.Int).Value = answer.QuestionId;
                    command.Parameters.Add("@Answer", SqlDbType.Text).Value = answer.Answer;

                    command.Parameters.Add("@IsCorrect", SqlDbType.Bit).Value = answer.IsCorrect;
                   

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteAnswerById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_DeleteAnswerById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

         
    }
}