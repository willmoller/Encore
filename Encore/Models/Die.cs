using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    public abstract class Die
    {
        protected int sides;
        protected Bitmap dieImage;
        protected int value;

        public abstract void Roll(int randomNumber);

        public abstract Bitmap getImage();

        public abstract void setImage(Bitmap newImage);
        public abstract int getValue();
    }
}
