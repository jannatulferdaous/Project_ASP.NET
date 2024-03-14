using Quizgame.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Quizgame.Properties.Helper
{
    public class DatabaseDataHelper
    {

        private const string DB_ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Quizgame";
        private const string SP_GetTutorial= "GetTutorial";
        private const string SP_ViewById = "ViewById";
        private const string SP_CreateTutorial = "CreateTutorial";
        private const string SP_EditTutorial = "EditTutorial";
        private const string SP_DeleteTutorialById = "DeleteTutorialById";
        

        public List<Tutorial>GetTutorial()
        {
            List<Tutorial> tutorials = new List<Tutorial>();
            Tutorial tutorial = null;
            // Prepare for SQL server connectivity
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                // Prepare the command that need to be executed into SQL server
                using (SqlCommand command = new SqlCommand(SP_GetTutorial, connection))
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
                            tutorial = new Tutorial();

                            tutorial.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                            tutorial.Language = Convert.ToString(reader["Language"]);
                            tutorial.Title = Convert.ToString(reader["Title"]);
                            tutorial.Article = Convert.ToString(reader["Article"]);
                             

                            // add the Game object into the Collection that will be returned from this method
                            tutorials.Add(tutorial);
                        }
                    }
                    // close the SQL server connection
                    connection.Close();
                }
            }
            // return the Game collection that we got from database.
            return tutorials;
        }

        public Tutorial ViewById(int ArticleId)
        {
            Tutorial tutorial = null;
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_ViewById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ArticleId", SqlDbType.Int).Value = ArticleId;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tutorial = new Tutorial();
                            tutorial.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                            tutorial.Language = Convert.ToString(reader["Language"]);
                            tutorial.Title = Convert.ToString(reader["Title"]);
                            tutorial.Article = Convert.ToString(reader["Article"]);
                        }
                    }
                    connection.Close();
                }
            }
            return tutorial;
        }

        public void CreateTutorial(Tutorial tutorial)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_CreateTutorial, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Language", SqlDbType.VarChar).Value = tutorial.Language;
                    command.Parameters.Add("@Title", SqlDbType.VarChar).Value = tutorial.Title;
                    command.Parameters.Add("@Article", SqlDbType.Text).Value = tutorial.Article;
                     

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void EditTutorial(Tutorial tutorial)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_EditTutorial, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                     
                    command.Parameters.Add("@ArticleId", SqlDbType.Int).Value = tutorial.ArticleId;
                    command.Parameters.Add("@Language", SqlDbType.VarChar).Value = tutorial.Language;
                    command.Parameters.Add("@Title", SqlDbType.VarChar).Value = tutorial.Title;
                    command.Parameters.Add("@Article", SqlDbType.Text).Value = tutorial.Article;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteTutorialById(int ArticleId)
        {
            using (SqlConnection connection = new SqlConnection(DB_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SP_DeleteTutorialById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ArticleId", SqlDbType.Int).Value = ArticleId;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }




}
    

