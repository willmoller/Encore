using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public class DieColor : Die
    {
        private string colorFace;

        public DieColor()
        {
            sides = 6;
            string filename = "..\\..\\Images\\bluex.png";
            string path = Path.Combine(Environment.CurrentDirectory, filename);
            dieImage = new Bitmap(path);
        }

        public override void Roll(int randomNumber)
        {
            string filename;
            string path;
            
            switch(randomNumber)
            {
                case 1:
                    colorFace = "blue";
                    value = 1;
                    filename = "..\\..\\Images\\bluex.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 2:
                    colorFace = "green";
                    value = 2;
                    filename = "..\\..\\Images\\greenx.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 3:
                    colorFace = "orange";
                    value = 3;
                    filename = "..\\..\\Images\\orangex.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 4:
                    colorFace = "pink";
                    value = 4;
                    filename = "..\\..\\Images\\pinkx.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 5:
                    colorFace = "yellow";
                    value = 5;
                    filename = "..\\..\\Images\\yellowx.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 6:
                    colorFace = "wild";
                    value = -1;
                    filename = "..\\..\\Images\\x.png";
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

        public string getColor()
        {
            return colorFace;
        }

        public override int getValue()
        {
            return value;
        }
    }
}
