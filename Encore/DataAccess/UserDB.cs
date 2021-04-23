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

        internal static User UserLogin(string username, string pwd)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string statement = "SELECT UserID, FirstName, LastName, Role " +
                "FROM Users " +
                "WHERE (Username = @username) AND (Password = @pwd)";

            SqlCommand selectCommand = new SqlCommand(statement, connection);

            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@pwd", pwd);

            try
            {
                connection.Open();
                SqlDataReader userReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                if (userReader.HasRows)
                {
                    if (userReader.Read())
                    {
                        User user = new User();
                        user.UserID = (int)userReader["UserId"];
                        user.FirstName = userReader["FirstName"].ToString();
                        user.LastName = userReader["LastName"].ToString();
                        user.Role = userReader["Role"].ToString();

                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
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

        internal static List<double> GetStatsByUser(int userId)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "SELECT ROUND(AVG(CAST(GameScore AS FLOAT)), 1) AS Average, CAST(Count(UserID) AS FLOAT) AS Total " +
                "FROM GamesPlayed " +
                "WHERE UserID = @userId";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("@userId", userId);

            try
            {
                connection.Open();
                SqlDataReader userReader = cmd.ExecuteReader();
                List<double> stats = new List<double>();

                if (userReader.Read())
                {
                    stats.Add((double)userReader["Average"]);
                    stats.Add((double)userReader["Total"]);
                    return stats;
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

        public static List<User> GetAllUsers()
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "Select * From Users";

            SqlCommand cmd = new SqlCommand(sqlState, connection);

            try
            {
                connection.Open();
                List<User> users = new List<User>();
                SqlDataReader userReader = cmd.ExecuteReader();

                while (userReader.Read())
                {
                    User user = new User();
                    user.UserID = (int)userReader["UserID"];
                    user.Username = userReader["Username"].ToString();
                    user.FirstName = userReader["FirstName"].ToString();
                    user.LastName = userReader["LastName"].ToString();
                    users.Add(user);
                }
                return users;
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
