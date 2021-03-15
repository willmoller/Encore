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

        public override int Roll()
        {
            return r.Next(1, sides + 1);
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
