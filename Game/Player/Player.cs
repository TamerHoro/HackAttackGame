using System.Drawing;
using System.Windows.Forms;
using Game.Engine_Releated;

namespace Game
{
    public class Player : InteractableObject
    {
        public bool goLeft, goRight, goUp, goDown, shoot;
        public int speed = 5;
        public int ammo = 5;        
        public string direction;

        public int Health
        {
            get { return this.currentHealth; }
            set{ this.currentHealth = value;}
        }

        public Player()
            : base(100, 70)
        {
            this.maxHealth = 3;
            this.currentHealth = maxHealth;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            //PlayerControl playercontrol = new PlayerControl();
            this.BringToFront();
            this.Image = Properties.Resources.playersmall;            
        }

        //Contols
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
                this.Image = Properties.Resources.playerleftsmall;
                this.direction = "left";
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                this.Image = Properties.Resources.playerightsmall;
                this.direction = "right";
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                this.Image = Properties.Resources.playerupsmall;
                this.direction = "up";
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                this.Image = Properties.Resources.playerdownsmall;
                this.direction = "down";
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot = true;
            }

        }

        new public void Move()
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

        // Player loses a life
        public void Die()
        {
            this.currentHealth--;
            SFX.Play(SFX.Sound.Death);
            this.Location = new Point(100, 100);
        }
  
    }
}
