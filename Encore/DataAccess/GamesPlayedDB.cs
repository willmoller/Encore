using Encore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore.DataAccess
{
    public class GamesPlayedDB
    {
        public static bool InsertGamePlayed(int score, int userId, int boardId)
        {
            bool success = false;
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "INSERT INTO GamesPlayed(UserID, Date, GameScore, BoardID)" +
                "VALUES(@userID, @date, @score, @boardID)";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("@userID", userId);
            cmd.Parameters.AddWithValue("@date", DateTime.Today.ToString("d"));
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@boardID", boardId);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

                // for testing
                //Console.WriteLine("RowsAffected: {0}", rowsAffected);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        public static List<GamePlayed> GetAllGamesPlayed()
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string statement = "SELECT * " +
                "FROM GamesPlayed";

            SqlCommand selectCommand = new SqlCommand(statement, connection);

            try
            {
                connection.Open();
                List<GamePlayed> gpList = new List<GamePlayed>();
                SqlDataReader gamesReader = selectCommand.ExecuteReader();
                while (gamesReader.Read())
                {
                    GamePlayed gp = new GamePlayed();
                    gp.GameID = (int)gamesReader["GameID"];
                    gp.UserID = (int)gamesReader["UserID"];
                    gp.Date = (DateTime)gamesReader["Date"];
                    gp.Score = (int)gamesReader["GameScore"];
                    gp.BoardID = (int)gamesReader["BoardID"];

                    gpList.Add(gp);
                }
                return gpList;
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

        public static List<GamePlayed> GetGamesPlayedByUserID(int userID)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string statement = "SELECT * " +
                "FROM GamesPlayed " +
                "WHERE UserID = @userId";

            SqlCommand selectCommand = new SqlCommand(statement, connection);
            selectCommand.Parameters.AddWithValue("@userId", userID);

            try
            {
                connection.Open();
                List<GamePlayed> gpList = new List<GamePlayed>();
                SqlDataReader gamesReader = selectCommand.ExecuteReader();
                while (gamesReader.Read())
                {
                    GamePlayed gp = new GamePlayed();
                    gp.GameID = (int)gamesReader["GameID"];
                    gp.UserID = (int)gamesReader["UserID"];
                    gp.Date = (DateTime)gamesReader["Date"];
                    gp.Score = (int)gamesReader["GameScore"];
                    gp.BoardID = (int)gamesReader["BoardID"];

                    gpList.Add(gp);
                }
                return gpList;
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

        public static List<GamePlayed> GetGamesPlayedByBoardID(int boardID)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string statement = "SELECT * " +
                "FROM GamesPlayed " +
                "WHERE BoardID = @boardId";

            SqlCommand selectCommand = new SqlCommand(statement, connection);
            selectCommand.Parameters.AddWithValue("@boardId", boardID);

            try
            {
                connection.Open();
                List<GamePlayed> gpList = new List<GamePlayed>();
                SqlDataReader gamesReader = selectCommand.ExecuteReader();
                while (gamesReader.Read())
                {
                    GamePlayed gp = new GamePlayed();
                    gp.GameID = (int)gamesReader["GameID"];
                    gp.UserID = (int)gamesReader["UserID"];
                    gp.Date = (DateTime)gamesReader["Date"];
                    gp.Score = (int)gamesReader["GameScore"];
                    gp.BoardID = (int)gamesReader["BoardID"];

                    gpList.Add(gp);
                }
                return gpList;
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
