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
        public Square[] BlueSquares { get; set; }
        public Square[] GreenSquares { get; set; }
        public Square[] OrangeSquares { get; set; }
        public Square[] PinkSquares { get; set; }
        public Square[] YellowSquares { get; set; }
        public Dictionary<string, Square> AllSquares { get; set; }

        //public Square[,] Squares { get; set; }

        public Board()
        {
            //Squares = new Square[7, 15];
            BlueSquares = new Square[21];
            GreenSquares = new Square[21];
            OrangeSquares = new Square[21];
            PinkSquares = new Square[21];
            YellowSquares = new Square[21];
            AllSquares = new Dictionary<string, Square>();
        }

        public int getGroupSize(string name)
        {

            return AllSquares[name].GroupSize;
        }

        public void updateGroupSize(string group)
        {
            switch (group.Substring(0, 1))
            {
                case "b":
                    foreach (Square square in BlueSquares)
                    {
                        if (square.Group == group)
                        {
                            square.GroupSize--;
                        }
                    }
                    break;
                case "g":
                    foreach (Square square in GreenSquares)
                    {
                        if (square.Group == group)
                        {
                            square.GroupSize--;
                        }
                    }
                    break;
                case "o":
                    foreach (Square square in OrangeSquares)
                    {
                        if (square.Group == group)
                        {
                            square.GroupSize--;
                        }
                    }
                    break;
                case "p":
                    foreach (Square square in PinkSquares)
                    {
                        if (square.Group == group)
                        {
                            square.GroupSize--;
                        }
                    }
                    break;
                case "y":
                    foreach (Square square in YellowSquares)
                    {
                        if (square.Group == group)
                        {
                            square.GroupSize--;
                        }
                    }
                    break;
            }
        }

        public bool CheckIfClickable(string color, int number, string name)
        {
            bool correctGroupSize = false;
            if (number <= AllSquares[name].GroupSize)
            {
                correctGroupSize = true;
            }

            bool correctColor = false;
            if (AllSquares[name].Group.Substring(0,1) == color)
            {
                correctColor = true;
            }

            return AllSquares[name].GetCanClick() && correctGroupSize && correctColor;
        }

        public bool CheckIfClickable(string name)
        {
            return AllSquares[name].GetCanClick();
        }

        public bool CheckIfClickable(int number, string name)
        {
            bool correctGroupSize = false;
            if (number <= AllSquares[name].GroupSize)
            {
                correctGroupSize = true;
            }

            return AllSquares[name].GetCanClick() && correctGroupSize;
        }

        public bool CheckIfClickable(string color, string name)
        {
            bool correctColor = false;
            if (AllSquares[name].Group.Substring(0, 1) == color)
            {
                correctColor = true;
            }

            return AllSquares[name].GetCanClick() && correctColor;
        }

        public bool CheckIfClicked(string name)
        {
            return AllSquares[name].Clicked;
        }

        public bool CheckIfStar(string color, PictureBox box)
        {
            return false;
        }

        public void SetClickedBox(string color, PictureBox box)
        {
            SetClickedTrue(box.Name);
            string[] coordinateStrings = box.Name.Split(',');
            int xCoordinate = Int32.Parse(coordinateStrings[0]);
            int yCoordinate = Int32.Parse(coordinateStrings[1]);
            int newX, newY;
            Square tempSquare;

            if (xCoordinate > 0)
            {
                newX = xCoordinate - 1;
                string tempName = newX.ToString() + "," + yCoordinate.ToString();
                AllSquares.TryGetValue(tempName, out tempSquare);
                if(!tempSquare.Clicked)
                    tempSquare.SetCanClickTrue();
            }

            if (xCoordinate < 6)
            {
                newX = xCoordinate + 1;
                string tempName = newX.ToString() + "," + yCoordinate.ToString();
                AllSquares.TryGetValue(tempName, out tempSquare);
                if (!tempSquare.Clicked)
                    tempSquare.SetCanClickTrue();
            }

            if (yCoordinate > 0)
            {
                newY = yCoordinate - 1;
                string tempName = xCoordinate.ToString() + "," + newY.ToString();
                AllSquares.TryGetValue(tempName, out tempSquare);
                if (!tempSquare.Clicked)
                    tempSquare.SetCanClickTrue();
            }

            if (yCoordinate < 14)
            {
                newY = yCoordinate + 1;
                string tempName = xCoordinate.ToString() + "," + newY.ToString();
                AllSquares.TryGetValue(tempName, out tempSquare);
                if (!tempSquare.Clicked)
                    tempSquare.SetCanClickTrue();
            }
        }

        internal void SetCanClickTrue(string name)
        {
            AllSquares[name].SetCanClickTrue();
        }

        internal void SetClickedTrue(string name)
        {
            AllSquares[name].SetClickedTrue();
        }

        public List<string> GetGroup(PictureBox box)
        {
            List<string> group = new List<string>();
            string groupId = AllSquares[box.Name].Group;
            switch (box.Tag.ToString().Substring(0, 1))
            {
                case "b":
                    foreach (Square s in BlueSquares)
                    {
                        if (s.Group == groupId)
                        {
                            group.Add(s.GetSquareName());
                        }
                    }
                    break;
                case "g":
                    foreach (Square s in GreenSquares)
                    {
                        if (s.Group == groupId)
                        {
                            group.Add(s.GetSquareName());
                        }
                    }
                    break;
                case "o":
                    foreach (Square s in OrangeSquares)
                    {
                        if (s.Group == groupId)
                        {
                            group.Add(s.GetSquareName());
                        }
                    }
                    break;
                case "p":
                    foreach (Square s in PinkSquares)
                    {
                        if (s.Group == groupId)
                        {
                            group.Add(s.GetSquareName());
                        }
                    }
                    break;
                case "y":
                    foreach (Square s in YellowSquares)
                    {
                        if (s.Group == groupId)
                        {
                            group.Add(s.GetSquareName());
                        }
                    }
                    break;
            }
            return group;
        }

        internal bool ColumnFilled(string name)
        {
            int column = AllSquares[name].YCoordinate;
            for (int i = 0; i < 7; i++)
            {
                if (!AllSquares[i + "," + column].Clicked)
                {
                    return false;
                }
            }
            return true;
        }

        internal int GetYCoordinate(string name)
        {
            return AllSquares[name].YCoordinate;
        }
    }
}
