using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game
{
    class Player 
    {
        public PictureBox player = new PictureBox();
        public ProgressBar healthbar = new ProgressBar();
        private int hp = 3;
        private int speed = 10;
        //healthbar.Location = player.Location;
        //    healthbar.Location = new Point(player.Location.X, player.Location.Y + -20);
        public int HP
        {
            get { return hp; }
            set { }
        }

        public void DamageTaken()
        {

        }

        Player()
        {

        }
        
    }
}
