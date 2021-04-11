using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    enum ColorFace
    {
        Green = 1,
        Blue = 2,
        Yellow = 3,
        Orange = 4,
        Pink = 5,
        Wild = 6
    }


    public class DieColor : Die
    {
        private ColorFace colorFace;

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
                    colorFace = ColorFace.Blue;
                    filename = "..\\..\\Images\\bluex.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 2:
                    colorFace = ColorFace.Green;
                    filename = "..\\..\\Images\\greenx.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 3:
                    colorFace = ColorFace.Orange;
                    filename = "..\\..\\Images\\orangex.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 4:
                    colorFace = ColorFace.Pink;
                    filename = "..\\..\\Images\\pinkx.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 5:
                    colorFace = ColorFace.Yellow;
                    filename = "..\\..\\Images\\yellowx.png";
                    path = Path.Combine(Environment.CurrentDirectory, filename);
                    dieImage = new Bitmap(path);
                    break;
                case 6:
                    colorFace = ColorFace.Wild;
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

        public Color GetColor()
        {
            switch (colorFace)
            {
                case ColorFace.Green:
                    return Color.Lime;
                case ColorFace.Yellow:
                    return Color.Yellow;
                case ColorFace.Blue:
                    return Color.DodgerBlue;
                case ColorFace.Pink:
                    return Color.HotPink;
                case ColorFace.Orange:
                    return Color.Orange;
                default:
                    return Color.Black;
            }
        }
    }
}
