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
        public static Board GetBoardById(int boardId)
        {
            SqlConnection connection = EncoreDB.GetConnection();
            string sqlState = "Select BoardID, BackgroundColor " +
                "FROM Board " +
                "WHERE BoardID = @boardId";

            SqlCommand cmd = new SqlCommand(sqlState, connection);
            cmd.Parameters.AddWithValue("@boardId", boardId);

            try
            {
                connection.Open();
                SqlDataReader boardReader = cmd.ExecuteReader();

                if (boardReader.Read())
                {
                    Board board = new Board();
                    board.BoardID = boardId;
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
