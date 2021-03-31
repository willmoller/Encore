using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    public partial class frmGame : Form
    {
        public Board GameBoard { get; set; }
        private Square[,] squares = new Square[7, 15];
        private List<Square> StarList = new List<Square>();
        private List<Square> CanClickList;
        private Dice dice;
        private List<String> diceKeys;
        private Square[] columnScoring = new Square[15];
        private DieNumber numberDieSelected;
        private DieColor colorDieSelected;
        private bool numberSelected = false;
        private bool colorSelected = false;
        private int turnsLeft;

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            DieColor colorDie1 = new DieColor();
            DieColor colorDie2 = new DieColor();
            DieNumber numberDie1 = new DieNumber();
            DieNumber numberDie2 = new DieNumber();
            diceKeys = new List<String>()
            {
                "color1",
                "color2",
                "number1",
                "number2"
            };
            dice = new Dice(diceKeys);
            dice.DiceList.Add(diceKeys[0], colorDie1);
            dice.DiceList.Add(diceKeys[1], colorDie2);
            dice.DiceList.Add(diceKeys[2], numberDie1);
            dice.DiceList.Add(diceKeys[3], numberDie2);

            turnsLeft = 30;
            lblTurnsLeft.Text = turnsLeft.ToString();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    GameBoard.Squares[i, j] = new Square();
                    GameBoard.Squares[i, j].BorderStyle = BorderStyle.FixedSingle;
                    GameBoard.Squares[i, j].Location = new Point(200 + j * 50, 100 + i * 50);
                    //squares[i, j].Name = $"encoreBox{i}{j}";
                    GameBoard.Squares[i, j].Size = new Size(50, 50);
                    GameBoard.Squares[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    GameBoard.Squares[i, j].TabStop = true;

                    GameBoard.Squares[i, j].MouseClick += new MouseEventHandler(EncoreBox_Click);
                    GameBoard.Squares[i, j].CanClick = false;
                    Controls.Add(GameBoard.Squares[i, j]);
                }
            }
            SetHColumn();
            SetColors();
            SetStars();
            SetDice();
            SetColumnPoints();
            SetWilds();
            SetScoringBoxes();
        }

        private void SetColumnPoints()
        {
            for (int i = 0; i < columnScoring.Length; i++)
            {
                columnScoring[i] = new Square();
                columnScoring[i].BorderStyle = BorderStyle.FixedSingle;
                columnScoring[i].Location = new Point(200 + i * 50, 475);
                columnScoring[i].Size = new Size(50, 50);
                columnScoring[i].SizeMode = PictureBoxSizeMode.StretchImage;
                columnScoring[i].BackColor = Color.AntiqueWhite;
                Controls.Add(columnScoring[i]);
            }

            Bitmap five = new Bitmap(
                "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\number5.png");
            five.MakeTransparent(Color.White);
            Bitmap three = new Bitmap(
                "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\number3.png");
            three.MakeTransparent(Color.White);
            Bitmap two = new Bitmap(
                "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\number2.png");
            two.MakeTransparent(Color.White);
            Bitmap one = new Bitmap(
                "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\number1.png");
            one.MakeTransparent(Color.White);

            columnScoring[0].Image = five;
            columnScoring[1].Image = three;
            columnScoring[2].Image = three;
            columnScoring[3].Image = three;
            columnScoring[4].Image = two;
            columnScoring[5].Image = two;
            columnScoring[6].Image = two;
            columnScoring[7].Image = one;
            columnScoring[8].Image = two;
            columnScoring[9].Image = two;
            columnScoring[10].Image = two;
            columnScoring[11].Image = three;
            columnScoring[12].Image = three;
            columnScoring[13].Image = three;
            columnScoring[14].Image = five;
        }

        private void SetWilds()
        {
            
        }

        private void SetScoringBoxes()
        {
            pboBonusGreen.BackColor = Color.Lime;
            pboBonusYellow.BackColor = Color.Yellow;
            pboBonusBlue.BackColor = Color.DodgerBlue;
            pboBonusPink.BackColor = Color.HotPink;
            pboBonusOrange.BackColor = Color.Orange;
        }

        private void SetDice()
        {
            pboNumberDie1.SizeMode = PictureBoxSizeMode.StretchImage;
            pboNumberDie1.BorderStyle = BorderStyle.FixedSingle;
            pboNumberDie1.Image = dice.DiceList["number1"].getImage();
            pboNumberDie2.SizeMode = PictureBoxSizeMode.StretchImage;
            pboNumberDie2.BorderStyle = BorderStyle.FixedSingle;
            pboNumberDie2.Image = dice.DiceList["number2"].getImage();

            pboColorDie1.SizeMode = PictureBoxSizeMode.StretchImage;
            pboColorDie1.Image = dice.DiceList["color1"].getImage();
            pboColorDie2.SizeMode = PictureBoxSizeMode.StretchImage;
            pboColorDie2.Image = dice.DiceList["color2"].getImage();
        }

        private void SetHColumn()
        {
            CanClickList = new List<Square>()
            {
                GameBoard.Squares[0, 7],
                GameBoard.Squares[1, 7],
                GameBoard.Squares[2, 7],
                GameBoard.Squares[3, 7],
                GameBoard.Squares[4, 7],
                GameBoard.Squares[5, 7],
                GameBoard.Squares[6, 7]
            };
            foreach (Square square in GameBoard.Squares)
            {
                square.BorderStyle = BorderStyle.Fixed3D;
                square.CanClick = true;
            }
        }

        private void EncoreBox_Click (Object sender, EventArgs e)
        {
            Square clickedBox = (Square)sender;
            if (clickedBox.CanClick)
            {
                Bitmap b = new Bitmap(
                    "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\x.png");
                b.MakeTransparent(Color.White);
                clickedBox.Image = b;

                clickedBox.Clicked = true;
                if (StarList.Contains(clickedBox))
                {
                    clickedBox.Star = false;
                    StarList.Remove(clickedBox);
                }
                CheckColumnScore();
                CheckColorScore();
                CheckEndOfGame();
            }
        }

        private void SetStars()
        {
            StarList = GameBoard.GetStarList();

            foreach (Square square in StarList)
            {
                square.Image = Image.FromFile(
                        "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\star.png");
            }
        }

        private void SetColors()
        {
            List<string> greens = new List<string>()
            {
                "0,0", "0,1", "0,2", "0,7",
                "1,1", "1,3", "1,13", "1,14",
                "2,1", "2,3", "2,4", "2,5", "2,6", "2,13", "2,14",
                "3,3", "3,8", "3,9",
                "6,10", "6,11", "6,12"
            };
            foreach (string green in greens)
            {
                string[] coordinates = green.Split(',');
                squares[int.Parse(coordinates[0]), int.Parse(coordinates[1])].BackColor = Color.Lime;
            }

            List<string> blues = new List<string>()
            {
                "0,8", "0,9", "0,10",
                "1,9", "1,10",
                "2,0",
                "3,0", "3,6", "3,7","3,14",
                "4,6", "4,7",
                "5,1", "5,2", "5,11", "5,12", "5,13",
                "6,2", "6,3", "6,4", "6,5"
            };
            foreach (string blue in blues)
            {
                string[] coordinates = blue.Split(',');
                squares[int.Parse(coordinates[0]), int.Parse(coordinates[1])].BackColor = Color.DodgerBlue;
            }

            List<string> oranges = new List<string>()
            {
                "0,11",
                "1,0", "1,6", "1,7", "1,11", "1,12",
                "2,12",
                "3,4", "3,5", "3,12",
                "4,1", "4,2", "4,3", "4,4", "4,8", "4,9", "4,10",
                "5,9", "5,14",
                "6,13", "6,14"
            };
            foreach (string orange in oranges)
            {
                string[] coordinates = orange.Split(',');
                squares[int.Parse(coordinates[0]), int.Parse(coordinates[1])].BackColor = Color.Orange;
            }

            List<string> pinks = new List<string>()
            {
                "1,8",
                "2,2", "2,7", "2,8", "2,9",
                "3,1", "3,2", "3,13",
                "4,0", "4,5", "4,11", "4,12", "4,13", "4,14",
                "5,0", "5,3", "5,4", "5,5", "5,6", "5,10",
                "6,6"
            };
            foreach (string pink in pinks)
            {
                string[] coordinates = pink.Split(',');
                squares[int.Parse(coordinates[0]), int.Parse(coordinates[1])].BackColor = Color.HotPink;
            }

            List<string> yellows = new List<string>()
            {
                "0,3", "0,4", "0,5", "0,6", "0,12", "0,13", "0,14",
                "1,2", "1,4", "1,5",
                "2,10", "2,11",
                "3,10", "3,11",
                "5,7", "5,8",
                "6,0", "6,1", "6,7", "6,8", "6,9"
            };
            foreach (string yellow in yellows)
            {
                string[] coordinates = yellow.Split(',');
                squares[int.Parse(coordinates[0]), int.Parse(coordinates[1])].BackColor = Color.Yellow;
            }
        }
        private void CheckColumnScore()
        {
            
        }

        private void CheckColorScore()
        {
            
        }

        private void CheckEndOfGame()
        {
            
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            turnsLeft--;
            lblTurnsLeft.Text = turnsLeft.ToString();

            foreach (Square square in squares)
            {
                square.CanClick = false;
                square.BorderStyle = BorderStyle.FixedSingle;
            }

            pboNumberDie1.BorderStyle = BorderStyle.None;
            pboNumberDie2.BorderStyle = BorderStyle.None;
            pboColorDie1.BorderStyle = BorderStyle.None;
            pboColorDie2.BorderStyle = BorderStyle.None;

            dice.RollDice();
            pboColorDie1.Image = dice.DiceList["color1"].getImage();
            pboColorDie2.Image = dice.DiceList["color2"].getImage();
            pboNumberDie1.Image = dice.DiceList["number1"].getImage();
            pboNumberDie2.Image = dice.DiceList["number2"].getImage();





            foreach (Square square in CanClickList)
            {
                square.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void pboNumberDie1_Click(object sender, EventArgs e)
        {
            numberDieSelected = (DieNumber)dice.DiceList["number1"];
            pboNumberDie1.BackColor = Color.Red;
            pboNumberDie2.BackColor = Color.Transparent;

            pboNumberDie1.BorderStyle = BorderStyle.Fixed3D;
            if (pboNumberDie2.BorderStyle == BorderStyle.Fixed3D)
            {
                pboNumberDie2.BorderStyle = BorderStyle.None;
            }

            numberSelected = true;
            if (colorSelected)
            {
                ShowAvailableSquares(numberDieSelected, colorDieSelected);
            }

        }

        private void pboNumberDie2_Click(object sender, EventArgs e)
        {
            numberDieSelected = (DieNumber)dice.DiceList["number2"];
            pboNumberDie2.BackColor = Color.Red;
            pboNumberDie1.BackColor = Color.Transparent;

            pboNumberDie2.BorderStyle = BorderStyle.Fixed3D;
            if (pboNumberDie1.BorderStyle == BorderStyle.Fixed3D)
            {
                pboNumberDie1.BorderStyle = BorderStyle.None;
            }

            numberSelected = true;
            if (colorSelected)
            {
                ShowAvailableSquares(numberDieSelected, colorDieSelected);
            }
        }

        private void pboColorDie1_Click(object sender, EventArgs e)
        {
            colorDieSelected = (DieColor)dice.DiceList["color1"];
            pboColorDie1.BackColor = Color.Red;
            pboColorDie2.BackColor = Color.Transparent;

            pboColorDie1.BorderStyle = BorderStyle.Fixed3D;
            if (pboColorDie2.BorderStyle == BorderStyle.Fixed3D)
            {
                pboColorDie2.BorderStyle = BorderStyle.None;
            }

            colorSelected = true;
            if (numberSelected)
            {
                ShowAvailableSquares(numberDieSelected, colorDieSelected);
            }
        }

        private void pboColorDie2_Click(object sender, EventArgs e)
        {
            colorDieSelected = (DieColor)dice.DiceList["color2"];
            pboColorDie2.BackColor = Color.Red;
            pboColorDie1.BackColor = Color.Transparent;

            pboColorDie2.BorderStyle = BorderStyle.Fixed3D;
            if (pboColorDie1.BorderStyle == BorderStyle.Fixed3D)
            {
                pboColorDie1.BorderStyle = BorderStyle.None;
            }

            colorSelected = true;
            if (numberSelected)
            {
                ShowAvailableSquares(numberDieSelected, colorDieSelected);
            }
        }

        private void ShowAvailableSquares(DieNumber numberDieSelected, DieColor colorDieSelected)
        {
            foreach (Square square in squares)
            {
                if (square.BackColor == colorDieSelected.GetColor())
                {
                    square.BorderStyle = BorderStyle.Fixed3D;
                    square.CanClick = true;
                }
            }
        }
    }
}
