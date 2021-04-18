using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public class UserDB
    {
        public static bool AddUser(string sql)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.CommandText += sql;
                    cmd.Connection = EncoreDB.GetConnection();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static User GetUserByUserId(string userId)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "Select LastName, FirstName, UserRole from Users where UserId = @userId";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("UserId", userId);

            try
            {
                connection.Open();
                SqlDataReader userReader = cmd.ExecuteReader();

                if (userReader.Read())
                {
                    User user = new User();
                    user.FirstName = userReader["FirstName"].ToString();
                    user.LastName = userReader["LastName"].ToString();
                    user.Role = userReader["UserRole"].ToString();
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
