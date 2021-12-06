using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Mine : Enemy
    {
        public Mine(int l, int h, int i, int j) : base(l, h)
        {
            this.Tag = $"Mine{i}{j}";
            this.Image = Properties.Resources.MineIdle;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.Left = l;
            this.Top = h;
            this.BringToFront();
        }

        public void Explode()
        {
            this.Image = Properties.Resources.MineExplode;
        }
    }
}
