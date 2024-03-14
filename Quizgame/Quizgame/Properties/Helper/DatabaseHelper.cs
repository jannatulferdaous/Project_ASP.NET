using Microsoft.Data.SqlClient;
using Quizgame.Models;
using System.Data;

namespace Quizgame.Properties.Helper
{
    public class DatabaseHelper
    {
        private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";

        public User ValidUser(string name,string password)
        {
            User returnValue = null;
            string SP_ValidUser = "ValidUser";

            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_ValidUser, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            returnValue = new User();
                            returnValue.UserId = Convert.ToInt32(reader["UserId"]);
                            returnValue.Name = Convert.ToString(reader["Name"]);
                            returnValue.Password = Convert.ToString(reader["Password"]);
                        }
                    }
                    connection.Close();
                }
            }
            return returnValue;
        }


        public Tutorial UserArticle(int userId)
        {
            Tutorial returnValue = null;
            string SP_UserArticle = "UserArticle";

            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_UserArticle, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;


                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            returnValue = new Tutorial();
                            returnValue.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                            returnValue.Language = Convert.ToString(reader["Language"]);
                            returnValue.Title = Convert.ToString(reader["Title"]);
                            returnValue.Article = Convert.ToString(reader["Article"]);
                        }
                    }
                    connection.Close();
                }
            }
            return returnValue;
        }
        public Tutorial lastArticle()
        {
            Tutorial returnValue = null;
            string SP_lastArticle = "lastArticle";

            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_lastArticle, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            returnValue = new Tutorial();
                            returnValue.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                            returnValue.Language = Convert.ToString(reader["Language"]);
                            returnValue.Title = Convert.ToString(reader["Title"]);
                            returnValue.Article = Convert.ToString(reader["Article"]);
                        }
                    }
                    connection.Close();
                }
            }
            return returnValue;
        }

        public Models.Results GetResultcs()
        {
            Models.Results result = null;
            string SP_Resultshow = "Resultshow";

            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_Resultshow, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;


                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new Models.Results();
                            result.Score = Convert.ToInt32(reader["RowCount"]);

                        }
                    }
                    connection.Close();
                }
            }
            return result;
        }
    }
}
