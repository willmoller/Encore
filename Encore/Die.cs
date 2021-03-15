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
        protected Random r = new Random();
        protected Bitmap dieImage;

        public abstract int Roll();

        public abstract Bitmap getImage();

        public abstract void setImage(Bitmap newImage);
    }
}
