using Microsoft.CodeAnalysis.CSharp.Syntax;
using Milestone350.Models;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Milestone350.Services
{
    public class SecurityDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CST350;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

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

        public bool addUserToDatabase(UserModel user)
        {
            //check to see if connection/sql  works
            bool success = true;

            //prepared statements to defend injections
            string sqlStatement = "INSERT INTO users (USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONENUMBER) VALUES(@Username, @Password, @FirstName, @LastName, @Email, @PhoneNumber);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Define the values of the placeholders in the string
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 50).Value = user.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 50).Value = user.LastName;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = user.Email;
                command.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.VarChar,50).Value = user.PhoneNumber;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                };
                return success;
            }
        }
    }
}
