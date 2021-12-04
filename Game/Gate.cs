using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class Gate :StaticObject
    {
        public Gate(int l,int h, int i, int j) :base(l,h)
        {
            this.Tag = $"Gate{i}{j}";
            this.Image = Properties.Resources.gate;
            this.BackColor = Color.Transparent;
            this.Width = 40;
            this.Height = 40;
            this.Left = l;
            this.Top = h;
            this.BringToFront();

        }
            
    }
}
