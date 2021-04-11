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
            string sqlState = "SELECT BackgroundColor, Blues, Greens, Oranges, Pinks, Yellows " +
                "FROM Board b INNER JOIN Squares s ON b.SquaresID = s.SquaresID " +
                "WHERE BoardID =@boardId";

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
                    string[] blues = boardReader["Blues"].ToString().Split('|');
                    string[] greens = boardReader["Greens"].ToString().Split('|');
                    string[] oranges = boardReader["Oranges"].ToString().Split('|');
                    string[] pinks = boardReader["Pinks"].ToString().Split('|');
                    string[] yellows = boardReader["Yellows"].ToString().Split('|');

                    for(int i = 0; i < blues.Length; i++)
                    {
                        string[] blueArray = blues[i].Split(',');
                        board.BlueSquares[i] = new Square();
                        board.BlueSquares[i].XCoordinate = Int32.Parse(blueArray[0]);
                        board.BlueSquares[i].YCoordinate = Int32.Parse(blueArray[1]);
                        if (Int32.Parse(blueArray[2]) == 0)
                        {
                            board.BlueSquares[i].Star = false;
                        }else
                        {
                            board.BlueSquares[i].Star = true;
                        }
                        board.BlueSquares[i].GroupSize = Int32.Parse(blueArray[3]);
                        board.BlueSquares[i].Group = "b" + blueArray[3];
                        board.BlueSquares[i].SetSquareName();
                        board.AllSquares.Add(board.BlueSquares[i].GetSquareName(), board.BlueSquares[i]);
                    }

                    for (int i = 0; i < greens.Length; i++)
                    {
                        string[] greenArray = greens[i].Split(',');
                        board.GreenSquares[i] = new Square();
                        board.GreenSquares[i].XCoordinate = Int32.Parse(greenArray[0]);
                        board.GreenSquares[i].YCoordinate = Int32.Parse(greenArray[1]);
                        if (Int32.Parse(greenArray[2]) == 0)
                        {
                            board.GreenSquares[i].Star = false;
                        }
                        else
                        {
                            board.GreenSquares[i].Star = true;
                        }
                        board.GreenSquares[i].GroupSize = Int32.Parse(greenArray[3]);
                        board.GreenSquares[i].Group = "g" + greenArray[3];
                        board.GreenSquares[i].SetSquareName();
                        board.AllSquares.Add(board.GreenSquares[i].GetSquareName(), board.GreenSquares[i]);
                    }

                    for (int i = 0; i < oranges.Length; i++)
                    {
                        string[] orangeArray = oranges[i].Split(',');
                        board.OrangeSquares[i] = new Square();
                        board.OrangeSquares[i].XCoordinate = Int32.Parse(orangeArray[0]);
                        board.OrangeSquares[i].YCoordinate = Int32.Parse(orangeArray[1]);
                        if (Int32.Parse(orangeArray[2]) == 0)
                        {
                            board.OrangeSquares[i].Star = false;
                        }
                        else
                        {
                            board.OrangeSquares[i].Star = true;
                        }
                        board.OrangeSquares[i].GroupSize = Int32.Parse(orangeArray[3]);
                        board.OrangeSquares[i].Group = "o" + orangeArray[3];
                        board.OrangeSquares[i].SetSquareName();
                        board.AllSquares.Add(board.OrangeSquares[i].GetSquareName(), board.OrangeSquares[i]);
                    }

                    for (int i = 0; i < pinks.Length; i++)
                    {
                        string[] pinkArray = pinks[i].Split(',');
                        board.PinkSquares[i] = new Square();
                        board.PinkSquares[i].XCoordinate = Int32.Parse(pinkArray[0]);
                        board.PinkSquares[i].YCoordinate = Int32.Parse(pinkArray[1]);
                        if (Int32.Parse(pinkArray[2]) == 0)
                        {
                            board.PinkSquares[i].Star = false;
                        }
                        else
                        {
                            board.PinkSquares[i].Star = true;
                        }
                        board.PinkSquares[i].GroupSize = Int32.Parse(pinkArray[3]);
                        board.PinkSquares[i].Group = "p" + pinkArray[3];
                        board.PinkSquares[i].SetSquareName();
                        board.AllSquares.Add(board.PinkSquares[i].GetSquareName(), board.PinkSquares[i]);
                    }

                    for (int i = 0; i < yellows.Length; i++)
                    {
                        string[] yellowArray = yellows[i].Split(',');
                        board.YellowSquares[i] = new Square();
                        board.YellowSquares[i].XCoordinate = Int32.Parse(yellowArray[0]);
                        board.YellowSquares[i].YCoordinate = Int32.Parse(yellowArray[1]);
                        if (Int32.Parse(yellowArray[2]) == 0)
                        {
                            board.YellowSquares[i].Star = false;
                        }
                        else
                        {
                            board.YellowSquares[i].Star = true;
                        }
                        board.YellowSquares[i].GroupSize = Int32.Parse(yellowArray[3]);
                        board.YellowSquares[i].Group = "y" + yellowArray[3];
                        board.YellowSquares[i].SetSquareName();
                        board.AllSquares.Add(board.YellowSquares[i].GetSquareName(), board.YellowSquares[i]);
                    }

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
