using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    public class UserDB
    {
        public static void AddUser(User user)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string statement = "INSERT INTO Users (Username, Password, Role, FirstName, LastName) " +
                "VALUES (@username, @pwd, @role, @fName, @lName)";

            SqlCommand selectCommand = new SqlCommand(statement, connection);

            selectCommand.Parameters.AddWithValue("@username", user.Username);
            selectCommand.Parameters.AddWithValue("@pwd", user.getPassword());
            selectCommand.Parameters.AddWithValue("@role", user.Role);
            selectCommand.Parameters.AddWithValue("@fName", user.FirstName);
            selectCommand.Parameters.AddWithValue("@lName", user.LastName);

            try
            {
                connection.Open();
                int result = selectCommand.ExecuteNonQuery();
                // Check Error
                if (result < 0)
                {
                    MessageBox.Show("Error inserting data into Database!", "Error");
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

        internal static List<string[]> GetUserPlaysByID(int userID)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "SELECT * " +
                "FROM GamesPlayed " +
                "WHERE UserID = @userId " +
                "ORDER BY GameScore DESC";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("@userId", userID);

            try
            {
                connection.Open();
                SqlDataReader userReader = cmd.ExecuteReader();
                List<string[]> userPlays = new List<string[]>();

                while (userReader.Read())
                {
                    string[] play = new string[3];
                    
                    switch (userReader["BoardID"].ToString())
                    {
                        case "1":
                            play[0] = "Black";
                            break;
                        case "2":
                            play[0] = "Orange";
                            break;
                        case "3":
                            play[0] = "Yellow";
                            break;
                        case "4":
                            play[0] = "Purple";
                            break;
                        case "5":
                            play[0] = "Pink";
                            break;
                        case "6":
                            play[0] = "Green";
                            break;
                        case "7":
                            play[0] = "Blue";
                            break;
                    }

                    DateTime dateTime = (DateTime)userReader["Date"];
                    play[1] = dateTime.ToShortDateString();
                    play[2] = userReader["GameScore"].ToString();
                    userPlays.Add(play);
                }
                return userPlays;
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

        internal static double[] GetUserStatsById(int userID)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "SELECT ROUND(AVG(CAST(GameScore AS FLOAT)), 1) AS Average, CAST(Count(GamesPlayed.UserID) AS FLOAT) AS Total " +
                "FROM GamesPlayed " +
                "WHERE UserID = @userId";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("@userId", userID);

            try
            {
                connection.Open();
                SqlDataReader userReader = cmd.ExecuteReader();
                double[] userStats = new double[2];

                if (userReader.Read())
                {
                    userStats[0] = (double)userReader["Average"];
                    userStats[1] = (double)userReader["Total"];
                    return userStats;
                } else
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

        internal static bool DoesUsernameExist(string username)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string statement = "SELECT Username " +
                "FROM Users " +
                "WHERE (Username = @username)";

            SqlCommand selectCommand = new SqlCommand(statement, connection);
            selectCommand.Parameters.AddWithValue("@username", username);

            try
            {
                connection.Open();
                SqlDataReader userReader = selectCommand.ExecuteReader();

                if (userReader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
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

        internal static List<string[]> GetAllUserStats()
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "SELECT MAX(Users.UserID) as userID, MAX(FirstName) as fName, MAX(LastName) as lName, ROUND(AVG(CAST(GameScore AS FLOAT)), 1) AS Average, CAST(Count(GamesPlayed.UserID) AS FLOAT) AS Total " +
                "FROM GamesPlayed " +
                "INNER JOIN Users " +
                "ON GamesPlayed.UserID = Users.UserID " +
                "GROUP BY GamesPlayed.UserID";

            SqlCommand cmd = new SqlCommand(sqlState, connection);

            try
            {
                connection.Open();
                SqlDataReader userReader = cmd.ExecuteReader();
                List<string[]> userStats = new List<string[]>();

                while (userReader.Read())
                {
                    string[] user = new string[4];
                    user[0] = userReader["userID"].ToString();
                    user[1] = userReader["fName"].ToString() + " " + userReader["lName"].ToString();
                    user[2] = userReader["Average"].ToString();
                    user[3] = userReader["Total"].ToString();
                    userStats.Add(user);
                }
                return userStats;
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
