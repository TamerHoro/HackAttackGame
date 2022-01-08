using System.Windows.Forms;

namespace Game
{
    public class GameObjects: PictureBox
    {
        public bool col;
        public GameObjects(int left, int top)
        {
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            Left = left;
            Top = top;
        }
    }
}
