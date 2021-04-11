﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    public partial class frmGame : Form
    {
        public Board Board { get; set; }
        //private Square[,] squares = new Square[7, 15];
        private int starsRemaining = 15;
        //private List<Square> StarList = new List<Square>();
        //private List<Square> CanClickList;
        private List<PictureBox> Boxes;
        private Dice dice;
        private List<String> diceKeys;
        private PictureBox[] columnScoring = new PictureBox[15];
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

            pboColorDie1.Enabled = false;
            pboColorDie2.Enabled = false;
            pboNumberDie1.Enabled = false;
            pboNumberDie2.Enabled = false;

            turnsLeft = 30;
            lblTurnsLeft.Text = turnsLeft.ToString();

            Boxes = new List<PictureBox>();
            Board = BoardDB.GetBoardById(1);
            CreatePictureBoxes(Board.BlueSquares, Color.DodgerBlue);
            CreatePictureBoxes(Board.GreenSquares, Color.Lime);
            CreatePictureBoxes(Board.OrangeSquares, Color.Orange);
            CreatePictureBoxes(Board.PinkSquares, Color.HotPink);
            CreatePictureBoxes(Board.YellowSquares, Color.Yellow);

            

            SetHColumn();
            //SetColors();
            //SetStars();
            SetDice();
            SetColumnPoints();
            SetWilds();
            SetScoringBoxes();
        }

        private void CreatePictureBoxes(Square[] squares, Color color)
        {
            foreach (Square square in squares)
            {
                PictureBox box = new PictureBox();
                if (square.Star)
                {
                    string filename = "..\\..\\Images\\star.png";
                    string path = Path.Combine(Environment.CurrentDirectory, filename);
                    box.Image = new Bitmap(path);
                }
                box.BorderStyle = BorderStyle.FixedSingle;
                box.Location = new Point(200 + (square.YCoordinate * 50), 100 + (square.XCoordinate * 50));
                box.Size = new Size(50, 50);
                box.Name = square.GetSquareName();
                box.Tag = square.Group;
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.MouseClick += new MouseEventHandler(EncoreBox_Click);
                box.BackColor = color;
                box.Enabled = false;
                Boxes.Add(box);
                //Board.AllSquares.Add(box.Name, square);
                Controls.Add(box);
            }
        }

        private void SetColumnPoints()
        {
            for (int i = 0; i < columnScoring.Length; i++)
            {
                columnScoring[i] = new PictureBox();
                columnScoring[i].BorderStyle = BorderStyle.FixedSingle;
                columnScoring[i].Location = new Point(200 + i * 50, 475);
                columnScoring[i].Size = new Size(50, 50);
                columnScoring[i].SizeMode = PictureBoxSizeMode.StretchImage;
                columnScoring[i].BackColor = Color.AntiqueWhite;
                Controls.Add(columnScoring[i]);
            }

            string filename = "..\\..\\Images\\number5.png";
            string path = Path.Combine(Environment.CurrentDirectory, filename);
            Bitmap five = new Bitmap(path);
            five.MakeTransparent(Color.White);

            filename = "..\\..\\Images\\number3.png";
            path = Path.Combine(Environment.CurrentDirectory, filename);
            Bitmap three = new Bitmap(path);
            three.MakeTransparent(Color.White);

            filename = "..\\..\\Images\\number2.png";
            path = Path.Combine(Environment.CurrentDirectory, filename);
            Bitmap two = new Bitmap(path);
            two.MakeTransparent(Color.White);

            filename = "..\\..\\Images\\number1.png";
            path = Path.Combine(Environment.CurrentDirectory, filename);
            Bitmap one = new Bitmap(path);
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
            Board.SetCanClickTrue("0,7");
            Board.SetCanClickTrue("1,7");
            Board.SetCanClickTrue("2,7");
            Board.SetCanClickTrue("3,7");
            Board.SetCanClickTrue("4,7");
            Board.SetCanClickTrue("5,7");
            Board.SetCanClickTrue("6,7");
        }

        private void EncoreBox_Click (Object sender, EventArgs e)
        {
            pboColorDie1.Enabled = false;
            pboColorDie2.Enabled = false;
            pboNumberDie1.Enabled = false;
            pboNumberDie2.Enabled = false;

            PictureBox clickedBox = (PictureBox)sender;
            string filename = "..\\..\\Images\\x.png";
            string path = Path.Combine(Environment.CurrentDirectory, filename);
            Bitmap b = new Bitmap(path);
            b.MakeTransparent(Color.White);
            clickedBox.Image = b;
            Board.SetClickedBox(clickedBox.BackColor.ToString(), clickedBox);
            

            //clickedBox.Clicked = true;
            //if (StarList.Contains(clickedBox))
            //{
            //    clickedBox.Star = false;
            //    StarList.Remove(clickedBox);
            //}
            CheckColumnScore();
            CheckColorScore();
            CheckEndOfGame();
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
            pboColorDie1.Enabled = true;
            pboColorDie2.Enabled = true;
            pboNumberDie1.Enabled = true;
            pboNumberDie2.Enabled = true;
            colorSelected = false;
            numberSelected = false;


            turnsLeft--;
            lblTurnsLeft.Text = turnsLeft.ToString();

            pboNumberDie1.BorderStyle = BorderStyle.None;
            pboNumberDie1.BackColor = Color.Empty;
            pboNumberDie2.BorderStyle = BorderStyle.None;
            pboNumberDie2.BackColor = Color.Empty;
            pboColorDie1.BorderStyle = BorderStyle.None;
            pboColorDie1.BackColor = Color.Empty;
            pboColorDie2.BorderStyle = BorderStyle.None;
            pboColorDie2.BackColor = Color.Empty;

            dice.RollDice();
            pboColorDie1.Image = dice.DiceList["color1"].getImage();
            pboColorDie2.Image = dice.DiceList["color2"].getImage();
            pboNumberDie1.Image = dice.DiceList["number1"].getImage();
            pboNumberDie2.Image = dice.DiceList["number2"].getImage();

            foreach (PictureBox box in Boxes)
            {
                box.Enabled = false;
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

            string dieColor = colorDieSelected.GetColor().Substring(0, 1);
            int dieNumber = numberDieSelected.getNumberFace();

            if (dieColor == "w" && dieNumber == -1)
            {
                // any color/number combination
                foreach (PictureBox box in Boxes)
                {
                    if (true)
                    box.Enabled = true;
                }

            } else if (dieColor == "w")
            {
                // any color possible with specific number


            } else if (dieNumber == -1)
            {
                // any number possible with specific color


            } else
            {
                // specific number and color only
                foreach (PictureBox box in Boxes)
                {
                    box.Enabled = false;

                    if (box.Tag.ToString().Substring(0, 1).Equals(dieColor) && Board.CheckIfClickable(dieColor, dieNumber, box.Name))
                    {
                        box.BorderStyle = BorderStyle.Fixed3D;
                        box.Enabled = true;
                    }
                }
            }
        }
    }
}
