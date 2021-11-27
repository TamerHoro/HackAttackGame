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
    public class Player : PictureBox
    {
        public bool goLeft, goRight, goUp, goDown;
        int speed = 5;
        //public PictureBox picture = new PictureBox();       
        Image playerimage = Image.FromFile(@"..\..\Resources\player.png");
        public int health = 3;
        public Player()
        {
            this.Image = playerimage;
            this.Location = new Point(135, 135);
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            PlayerControl playercontrol = new PlayerControl();
            this.BringToFront();
        }

        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            goLeft = false;
            goDown = false;
            goUp = false;
            goRight = false;
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerleft.png");
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                this.Image = Image.FromFile(@"..\..\Resources\playeright.png");
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerup.png");
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerdown.png");
            }
        }

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        public void Move(object sender, EventArgs e)
        {
            if (goLeft == true)
            {
                this.Left -= speed;
            }
            if (goRight == true)
            {
                this.Left += speed;
            }
            if (goUp == true)
            {
                this.Top -= speed;
            }
            if (goDown == true)
            {
                this.Top += speed;
            }
        }
        
    }
}
