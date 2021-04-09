using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    
    public class Square:PictureBox
    {
        public bool Star { get; set; }
        public bool CanClick { get; set; }
        public bool Clicked { get; set; }
        public int GroupSize { get; set; }
        public int GroupId { get; set; }
        public Color Color { get; set; }


        //private bool star;
        //private bool canClick;

        public Square()
        {
            this.SetStyle(ControlStyles.Selectable, true);
        }
    }
}
