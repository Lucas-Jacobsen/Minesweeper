using AspNetCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Milestone350.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Milestone350.Services
{
    public class SecurityDAO
    {

        string connectionString = "server = localhost; port = 3306; user = root; password = root; database = CST350";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            //assume nothing is found
            bool success  = false;

            //prepared statements to defend injections
            string sqlStatement = "SELECT * FROM users WHERE Username = @Username and Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //define the values of the two placeholders in the statement string 
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.UserName;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            } return success;
        }
    }
}
