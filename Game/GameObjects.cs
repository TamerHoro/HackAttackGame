using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class GameObjects: PictureBox
    {
        public GameObjects(int left, int top)
        {
            Left = left;
            Top = top;
        }
    }
}
