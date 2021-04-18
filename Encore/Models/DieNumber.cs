using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public class DieNumber : Die
    {
        private int numberFace;

        public DieNumber()
        {
            sides = 6;
            string filename = "..\\..\\Images\\black1.png";
            string path = Path.Combine(Environment.CurrentDirectory, filename);
            dieImage = new Bitmap(path);
        }

        public override void Roll(int randomNumber)
        {
            string filename;
            string path; 
            
            switch (randomNumber)
            {
                case 1:
                    numberFace = 1;
                    value = 1;
                    filename = "..\\..\\Images\\black1.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 2:
                    numberFace = 2;
                    value = 2;
                    filename = "..\\..\\Images\\black2.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 3:
                    numberFace = 3;
                    value = 3;
                    filename = "..\\..\\Images\\black3.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 4:
                    numberFace = 4;
                    value = 4;
                    filename = "..\\..\\Images\\black4.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 5:
                    numberFace = 5;
                    value = 5;
                    filename = "..\\..\\Images\\black5.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 6:
                    numberFace = -1;
                    value = -1;
                    filename = "..\\..\\Images\\black6.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
            }
        }

        public override Bitmap getImage()
        {
            return dieImage;
        }

        public override void setImage(Bitmap newImage)
        {
            dieImage = newImage;
        }

        public int getNumberFace()
        {
            return numberFace;
        }

        public override int getValue()
        {
            return value;
        }
    }
}
