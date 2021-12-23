using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DestructableWall : Wall
    {

        public DestructableWall(int l, int h, int i, int j) : base(l, h, i, j)
        {
            this.Tag = $"destructablewall{i}{j}";
            this.Image = Properties.Resources.walldest;
            this.Width = 40;
            this.Height = 40;
            this.Left = l;
            this.Top = h;
            this.BringToFront();
        }
    }
}
