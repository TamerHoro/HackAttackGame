using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Wall : StaticObject
    {


        public Wall(int l, int h, int i, int j)
        {
            this.Tag = $"wall{i}{j}";
            this.Image = Properties.Resources.wall;
            this.Width = 40;
            this.Height = 40;
            this.Left = l;
            this.Top = h;
            this.BringToFront();
        }
    }
}
