using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public class BoardDB
    {
        //public List<string> GetBoard()
        //{
        //    List<string> results = new List<string>();

        //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    string command = 
        //        "SELECT ?" +
        //        "FROM [table]" +
        //        "WHERE ;";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand cmd = new SqlCommand(command, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    results.Add((string)reader[0]);
        //                }
        //            }
        //        }
        //    }
        //    return results;
        //}

        public static Board GetBoardById(string boardId)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "Select BoardID, BackgroundColor from Board where BoardID = @boardId";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("boardId", boardId);

            try
            {
                connection.Open();
                SqlDataReader boardReader = cmd.ExecuteReader();

                if (boardReader.Read())
                {
                    Board board = new Board();
                    board.BoardID = Int32.Parse(boardReader["BoardID"].ToString());
                    board.BackgroundColor = boardReader["BackgroundColor"].ToString();
                    return board;
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
