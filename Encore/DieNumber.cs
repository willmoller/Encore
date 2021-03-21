using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    enum NumberFace
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Wild = 6
    }
    public class DieNumber : Die
    {
        private NumberFace numberFace;

        public DieNumber()
        {
            sides = 6;
            dieImage = new System.Drawing.Bitmap(
                "C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black1.png");
        }

        public override void Roll(int randomNumber)
        {
            switch (randomNumber)
            {
                case 1:
                    numberFace = NumberFace.One;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black1.png");
                    break;
                case 2:
                    numberFace = NumberFace.Two;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black2.png");
                    break;
                case 3:
                    numberFace = NumberFace.Three;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black3.png");
                    break;
                case 4:
                    numberFace = NumberFace.Four;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black4.png");
                    break;
                case 5:
                    numberFace = NumberFace.Five;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black5.png");
                    break;
                case 6:
                    numberFace = NumberFace.Wild;
                    dieImage = new Bitmap("C:\\Users\\Will\\Desktop\\Programming\\SCC\\INFO2644 - Capstone\\Encore_C#\\Encore\\Images\\black6.png");
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
    }
}
