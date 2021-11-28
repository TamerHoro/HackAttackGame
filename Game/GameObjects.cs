using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class GameObjects: PictureBox
    {
        public GameObjects(Image image, int left, int top)
        {
            Image = image;
            Left = left;
            Top = top;
        }
    }
}
