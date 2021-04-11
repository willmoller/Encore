using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    
    public class Square//:PictureBox
    {
        public bool Star { get; set; }
        public bool Clicked { get; set; }
        public int GroupSize { get; set; }
        public string Group { get; set; }
        public Color Color { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        private string squareName;
        private bool canClick;

        //private bool star;
        //private bool canClick;

        public Square()
        {
            canClick = false;
        }

        public void SetSquareName()
        {
            squareName = XCoordinate.ToString() + "," + YCoordinate.ToString();
        }

        public string GetSquareName()
        {
            return squareName;
        }

        public bool GetCanClick()
        {
            return canClick;
        }

        public void SetCanClickTrue()
        {
            canClick = true;
        }

        public void SetClickedTrue()
        {
            Clicked = true;
        }
    }
}
