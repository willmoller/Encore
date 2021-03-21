using System;
using System.Collections.Generic;
using System.Drawing;
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
            dieImage = new System.Drawing.Bitmap(
                "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\bluex.png");
        }

        public override void Roll(int randomNumber)
        {
            switch(randomNumber)
            {
                case 1:
                    colorFace = ColorFace.Blue;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\bluex.png");
                    break;
                case 2:
                    colorFace = ColorFace.Green;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\greenx.png");
                    break;
                case 3:
                    colorFace = ColorFace.Orange;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\orangex.png");
                    break;
                case 4:
                    colorFace = ColorFace.Pink;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\pinkx.png");
                    break;
                case 5:
                    colorFace = ColorFace.Yellow;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\yellowx.png");
                    break;
                case 6:
                    colorFace = ColorFace.Wild;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\x.png");
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
