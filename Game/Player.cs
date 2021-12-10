using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Game
{
    class Player : InteractableObject
    {
        public bool goLeft, goRight, goUp, goDown, shoot;
        int speed = 5;
        //public PictureBox picture = new PictureBox();       
        SoundPlayer SFXHit = new SoundPlayer(Properties.Resources.PlayerHit);
        Image playerimage = Image.FromFile(@"..\..\Resources\playersmall.png");
        public int health = 3;
        public string direction;

        public Player()
            : base(100, 70, 3, Image.FromFile(@"..\..\Resources\playerupsmall.png"))
        {
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            PlayerControl playercontrol = new PlayerControl();
            this.BackColor = Color.Transparent;
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
            if (e.KeyCode == Keys.Space)
            {
                shoot = false;
            }
        }

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            goLeft = false;
            goDown = false;
            goUp = false;
            goRight = false;
            shoot = false;
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerleftsmall.png");
                this.direction = "left";
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerightsmall.png");
                this.direction = "right";
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerupsmall.png");
                this.direction = "up";
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                this.Image = Image.FromFile(@"..\..\Resources\playerdownsmall.png");
                this.direction = "down";
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot = true;
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

        public void Die()
        {
            SFXHit.Play();
            this.Location = new Point(100, 100);
        }
  
    }
}
