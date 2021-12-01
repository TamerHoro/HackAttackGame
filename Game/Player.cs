using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Player : InteractableObject
    {
        public bool goLeft, goRight, goUp, goDown;
        int speed = 5;
        //public PictureBox picture = new PictureBox();       
        Image playerimage = Image.FromFile(@"..\..\Resources\playersmall.png");
        public int health = 3;

        public Player()
            :base(Image.FromFile(@"..\..\Resources\player.png"), 100, 100, 3)
        {
            this.Image = playerimage;
            this.Location = new Point(135, 155);
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            PlayerControl playercontrol = new PlayerControl();            
            this.BringToFront();

        }
        public void KeyIsUp(object sender, KeyEventArgs e)
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

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            goLeft = false;
            goDown = false;
            goUp = false;
            goRight = false;
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerleftsmall.png");
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerightsmall.png");
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerupsmall.png");
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerdownsmall.png");
            }
        }

       
        public void Move()
        {
            if (goLeft == true)
            {
                Left -= speed;
            }
            if (goRight == true)
            {
                Left += speed;
            }
            if (goUp == true)
            {
                Top -= speed;
            }
            if (goDown == true)
            {
                Top += speed;
            }
        }
        
    }
}
