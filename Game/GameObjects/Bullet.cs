using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Bullet : PictureBox
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;
        public bool collided = false;

        public GameObjects[] gameobjects;
        public Player player;

        private int speed = 5;
        private Timer bulletTimer = new Timer();
        public Bullet(GameObjects[] objects, Player playerin)
        {
            gameobjects = objects;
            player = playerin;
        }
        public void MakeBullet(Engine engine)
        {
            this.BackColor = Color.Black;
            this.Size = new Size(5, 5);
            this.Tag = "bullet";
            this.Left = bulletLeft;
            this.Top = bulletTop;          
            this.BringToFront();

            engine.Controls.Add(this);

            bulletTimer.Interval = 1;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
                this.Left -= speed;

            if (direction == "right")
                this.Left += speed;

            if (direction == "up")
                this.Top -= speed;

            if (direction == "down")
               this.Top += speed;

            if (direction == "NorthEast")
            {
                this.Left += speed;
                this.Top -= speed;
            }

            if (direction == "NorthWest")
            {
                this.Left -= speed;
                this.Top -= speed;
            }

            if (direction == "SouthEast")
            {
                this.Left += speed;
                this.Top += speed;
            }

            if (direction == "SouthWest")
            {
                this.Left -= speed;
                this.Top += speed;
            }

            BulletCollision bulCol = new BulletCollision(this, gameobjects, player, out collided);

            if(collided == true)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                this.Dispose();
                bulletTimer = null;         
            }
        }
    }
}
