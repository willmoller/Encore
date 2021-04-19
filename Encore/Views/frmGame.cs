using Encore.DataAccess;
using System;
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
    // don't allow two wilds to be selected if there's only 1 wild selection left to pick.
    // allow game to end if last turn has no valid moves.
    // add Buttons:
        // Return to Home
        // Cancel Game
        // Play Again
    // add legal moves validation? or, allow create visual to indicate to user to skip this turn (in case of no valid moves).
    // put up score message based on final score.
    // save score to database.
    // create login (DONE)
    // create admin view to see stats by user or board
    // create user homepage - select board to play and view stats

    public partial class frmGame : Form
    {
        public Board Board { get; set; }
        private int starPoints, columnPoints, colorPoints, wildPoints, totalPoints;
        private List<PictureBox> Boxes, wilds;
        private Dice dice;
        private List<String> diceKeys;
        private PictureBox[] columnScoring = new PictureBox[15];
        private DieNumber numberDieSelected;
        private DieColor colorDieSelected;
        private bool numberSelected = false;
        private bool colorSelected = false;
        private int turnsLeft, clicksLeft, boardID;
        private List<string> boxGroupNames;
        private User user;

        public frmGame(int boardID, User user)
        {
            this.boardID = boardID;
            this.user = user;
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            starPoints = -30;
            txtStarPoints.Text = starPoints.ToString();
            columnPoints = 0;
            txtColumnPoints.Text = columnPoints.ToString();
            colorPoints = 0;
            txtColorPoints.Text = colorPoints.ToString();
            wildPoints = 8;
            txtUnusedWilds.Text = wildPoints.ToString();
            totalPoints = 0;
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
            Board = BoardDB.GetBoardById(boardID);
            CreatePictureBoxes(Board.BlueSquares, Color.DodgerBlue);
            CreatePictureBoxes(Board.GreenSquares, Color.Lime);
            CreatePictureBoxes(Board.OrangeSquares, Color.Orange);
            CreatePictureBoxes(Board.PinkSquares, Color.HotPink);
            CreatePictureBoxes(Board.YellowSquares, Color.Yellow);
            BackColor = Board.BackgroundColor;

            SetHColumn();
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
            columnScoring[0].Name = "5";
            columnScoring[1].Name = "3";
            columnScoring[2].Name = "3";
            columnScoring[3].Name = "3";
            columnScoring[4].Name = "2";
            columnScoring[5].Name = "2";
            columnScoring[6].Name = "2";
            columnScoring[7].Name = "1";
            columnScoring[8].Name = "2";
            columnScoring[9].Name = "2";
            columnScoring[10].Name = "2";
            columnScoring[11].Name = "3";
            columnScoring[12].Name = "3";
            columnScoring[13].Name = "3";
            columnScoring[14].Name = "5";
        }

        private void SetWilds()
        {
            wilds = new List<PictureBox>()
            {
                pboWild8,
                pboWild7,
                pboWild6,
                pboWild5,
                pboWild4,
                pboWild3,
                pboWild2,
                pboWild1
            };

            foreach (PictureBox p in wilds)
            {
                string filename = "..\\..\\Images\\WildUsed.png";
                string path = Path.Combine(Environment.CurrentDirectory, filename);
                Bitmap wild = new Bitmap(path);
                wild.MakeTransparent(Color.White);
                p.Image = wild;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.BackColor = Color.White;
            }
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
            btnRoll.Enabled = false;
            btnRoll.BackColor = Color.DarkGray;
            clickedBox.Enabled = false;
            clickedBox.BorderStyle = BorderStyle.FixedSingle;   
            clicksLeft--;

            // use clickedBox's name to get all boxes with same Group into a List<>.
            // determine boxes in the List<> that are adjacent to it to make them "CanClick" and Enabled
            boxGroupNames = Board.GetGroup(clickedBox);
            Board.updateGroupSize(clickedBox.Tag.ToString());
            List<PictureBox> boxGroup = new List<PictureBox>();
            foreach (PictureBox pb in Boxes)
            {
                if (boxGroupNames.Contains(pb.Name))
                {
                    boxGroup.Add(pb);
                } else
                {
                    pb.Enabled = false;
                    pb.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            string[] coordinateStrings = clickedBox.Name.Split(',');
            int xCoordinate = Int32.Parse(coordinateStrings[0]);
            int yCoordinate = Int32.Parse(coordinateStrings[1]);
            int xPlus1 = xCoordinate + 1;
            int xMinus1 = xCoordinate - 1;
            int yPlus1 = yCoordinate + 1;
            int yMinus1 = yCoordinate - 1;
            string newCoordinate1 = xPlus1.ToString() + "," + yCoordinate.ToString();
            string newCoordinate2 = xMinus1.ToString() + "," + yCoordinate.ToString();
            string newCoordinate3 = xCoordinate.ToString() + "," + yPlus1.ToString();
            string newCoordinate4 = xCoordinate.ToString() + "," + yMinus1.ToString();

            if (clicksLeft > 0 && Board.getGroupSize(clickedBox.Name) > 0)
            {
                foreach (PictureBox pbo in boxGroup)
                {
                    
                    if (!Board.CheckIfClicked(pbo.Name) && 
                        (pbo.Name.Equals(newCoordinate1) ||
                        pbo.Name.Equals(newCoordinate2) ||
                        pbo.Name.Equals(newCoordinate3) ||
                        pbo.Name.Equals(newCoordinate4)))
                    {
                        Board.SetCanClickTrue(pbo.Name);
                        pbo.Enabled = true;
                        btnRoll.BackColor = SystemColors.Control;
                        pbo.BorderStyle = BorderStyle.Fixed3D;
                    }
                }
            } else
            {
                btnRoll.Enabled = true;
                btnRoll.BackColor = SystemColors.Control;
                foreach (PictureBox pb in Boxes)
                {
                    pb.Enabled = false;
                    pb.BorderStyle = BorderStyle.FixedSingle;
                }
            }




            //clickedBox.Clicked = true;
            //if (StarList.Contains(clickedBox))
            //{
            //    clickedBox.Star = false;
            //    StarList.Remove(clickedBox);
            //}

            // score column if all boxes in column are filled in
            if (Board.ColumnFilled(clickedBox.Name))
            {
                columnPoints += Int32.Parse(columnScoring[Board.GetYCoordinate(clickedBox.Name)].Name);
                txtColumnPoints.Text = columnPoints.ToString();
                columnScoring[Board.GetYCoordinate(clickedBox.Name)].BackColor = Color.Green;
            }

            // score color bonus if all squares of color are filled in
            if (Board.ColorFilled(clickedBox.Tag.ToString()))
            {
                colorPoints += 5;
                txtColorPoints.Text = colorPoints.ToString();
                string filename2 = "..\\..\\Images\\x.png";
                string path2 = Path.Combine(Environment.CurrentDirectory, filename2);
                Bitmap x = new Bitmap(path2);
                x.MakeTransparent(Color.White);
                switch (clickedBox.Tag.ToString().Substring(0, 1))
                {
                    case "b":
                        pboBonusBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                        pboBonusBlue.Image = x;
                        break;
                    case "g":
                        pboBonusGreen.SizeMode = PictureBoxSizeMode.StretchImage;
                        pboBonusGreen.Image = x;
                        break;
                    case "o":
                        pboBonusOrange.SizeMode = PictureBoxSizeMode.StretchImage;
                        pboBonusOrange.Image = x;
                        break;
                    case "p":
                        pboBonusPink.SizeMode = PictureBoxSizeMode.StretchImage;
                        pboBonusPink.Image = x;
                        break;
                    case "y":
                        pboBonusYellow.SizeMode = PictureBoxSizeMode.StretchImage;
                        pboBonusYellow.Image = x;
                        break;
                }
            }

            if (Board.ContainsStar(clickedBox.Name))
            {
                starPoints += 2;
                txtStarPoints.Text = starPoints.ToString();
            }

            if (clicksLeft == 0)
            {
                if (numberDieSelected.getValue() == -1)
                {
                    MarkWild();
                }

                if (colorDieSelected.getValue() == -1)
                {
                    MarkWild();
                }

                if (turnsLeft == 0)
                {
                    btnRoll.Enabled = false;
                    btnRoll.BackColor = Color.DarkGray;
                    FinishGame();
                }
            }
        }

        private void FinishGame()
        {
            totalPoints += colorPoints;
            totalPoints += columnPoints;
            totalPoints += starPoints;
            totalPoints += wildPoints;
            txtUnusedWilds.Text = wildPoints.ToString();
            txtStarPoints.Text = starPoints.ToString();
            txtTotalScore.Text = totalPoints.ToString();
            GamesPlayedDB.InsertGamePlayed(totalPoints, user.UserID, boardID);

            string message = "";
            switch (totalPoints)
            {
                case int n when n < 0:
                    message = "You should be ashamed. We will be alerting your friends.";
                    break;
                case 0:
                    message = "Checkers. Do you like checkers?";
                    break;
                case int n when n > 0 && n <= 4:
                    message = "Maybe there's something else you could practice?";
                    break;
                case int n when n > 4 && n <= 8:
                    message = "Not very good at all.";
                    break;
                case int n when n > 8 && n <= 12:
                    message = "Was that your first try?";
                    break;
                case int n when n > 12 && n <= 16:
                    message = "Ok, but I bet you do better on your next try.";
                    break;
                case int n when n > 16 && n <= 20:
                    message = "That was probably not your first time.";
                    break;
                case int n when n > 20 && n <= 24:
                    message = "that went well.";
                    break;
                case int n when n > 24 && n <= 28:
                    message = "Hopefully done without cheating.";
                    break;
                case int n when n > 28 && n <= 32:
                    message = "Excellent! A great result!";
                    break;
                case int n when n > 32 && n <= 36:
                    message = "You could be a professional ENCORE! player!";
                    break;
                case int n when n > 36 && n <= 40:
                    message = "Do your friends call you The Brain?";
                    break;
                case int n when n > 40:
                    message = "So there are super heroes!";
                    break;
            }

            MessageBox.Show("Your score was " + totalPoints + ".\n\n" + message, "Game Over");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // reset the board... or open a new board?
            this.Hide();
            frmGame gameForm = new frmGame(boardID, user);
            gameForm.ShowDialog();
        }

        private void MarkWild()
        {
            wildPoints--;
            txtUnusedWilds.Text = wildPoints.ToString();
            wilds[wildPoints].BackColor = Color.Red;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (turnsLeft == 0)
            {
                FinishGame();
            }
            else
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

                if (wildPoints == 0)
                {
                    if (dice.DiceList["color1"].getValue() == -1)
                    {
                        pboColorDie1.Enabled = false;
                        pboColorDie1.BackColor = Color.Red;
                    }

                    if (dice.DiceList["color2"].getValue() == -1)
                    {
                        pboColorDie2.Enabled = false;
                        pboColorDie2.BackColor = Color.Red;
                    }

                    if (dice.DiceList["number1"].getValue() == -1)
                    {
                        pboNumberDie1.Enabled = false;
                        pboNumberDie1.BackColor = Color.Red;
                    }

                    if (dice.DiceList["number2"].getValue() == -1)
                    {
                        pboNumberDie2.Enabled = false;
                        pboNumberDie2.BackColor = Color.Red;
                    }
                }
            }
        }

        private void pboNumberDie1_Click(object sender, EventArgs e)
        {
            foreach(PictureBox box in Boxes)
            {
                box.Enabled = false;
                box.BorderStyle = BorderStyle.FixedSingle;
            }

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
            foreach (PictureBox box in Boxes)
            {
                box.Enabled = false;
                box.BorderStyle = BorderStyle.FixedSingle;
            }

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
            foreach (PictureBox box in Boxes)
            {
                box.Enabled = false;
                box.BorderStyle = BorderStyle.FixedSingle;
            }

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
            foreach (PictureBox box in Boxes)
            {
                box.Enabled = false;
                box.BorderStyle = BorderStyle.FixedSingle;
            }

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

            string dieColor = colorDieSelected.getColor().Substring(0, 1);
            int dieNumber = numberDieSelected.getNumberFace();
            clicksLeft = dieNumber;

            if (dieColor == "w" && dieNumber == -1)
            {
                // any color/number combination
                //dieNumber = 5;
                clicksLeft = 5;
                foreach (PictureBox box in Boxes)
                {
                    if (Board.CheckIfClickable(box.Name)) {
                        box.BorderStyle = BorderStyle.Fixed3D;
                        box.Enabled = true;
                        btnRoll.Enabled = true;
                        btnRoll.BackColor = SystemColors.Control;
                    }

                }

            } else if (dieColor == "w")
            {
                // any color possible with specific number
                foreach (PictureBox box in Boxes)
                {
                    if (Board.CheckIfClickable(dieNumber, box.Name))
                    {
                        box.BorderStyle = BorderStyle.Fixed3D;
                        box.Enabled = true;
                    }
                }

            } else if (dieNumber == -1)
            {
                // any number possible with specific color
                //dieNumber = 5;
                clicksLeft = 5;
                foreach (PictureBox box in Boxes)
                {
                    if (Board.CheckIfClickable(dieColor, box.Name))
                    {
                        box.BorderStyle = BorderStyle.Fixed3D;
                        box.Enabled = true;
                        btnRoll.Enabled = true;
                        btnRoll.BackColor = SystemColors.Control;
                    }
                }

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
