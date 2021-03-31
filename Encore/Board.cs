using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    public class Board
    {
        public int BoardID { get; set; }
        public string BackgroundColor { get; set; }
        public Square[,] Squares { get; set; }

        public Board()
        {
            Squares = new Square[7, 15];
        }


        public List<Square> GetStarList()
        {
            List<Square> starSquares = new List<Square>();
            foreach (Square square in Squares)
            {
                if (square.Star)
                {
                    starSquares.Add(square);
                }
            }
            return starSquares;
        }
    }
}
