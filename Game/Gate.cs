﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Gate :StaticObject
    {
        public Gate(int l,int h, int i, int j)
        {
            this.Tag = $"Gate{i}{j}";
            this.Image = Properties.Resources.gate;
            this.Width = 40;
            this.Height = 40;
            this.Left = l;
            this.Top = h-15;
            this.BringToFront();

        }
            
    }
}
