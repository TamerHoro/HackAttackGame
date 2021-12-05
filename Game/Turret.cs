using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Turret : Enemy
    {
        public Turret(int l, int h, int i, int j) : base(l, h)
        {
            this.Tag = $"Turret{i}{j}";
            this.Image = Properties.Resources.TurretShootSmallN;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.Left = l;
            this.Top = h;
            this.BringToFront();

        }

    }
}
