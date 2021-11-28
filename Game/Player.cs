using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Player : InteractableObject
    {
        public bool goLeft, goRight, goUp, goDown;      
        Image playerimage = Image.FromFile(@"..\..\Resources\player.png");
        int speed = 5;

        public Player()
            :base(Image.FromFile(@"..\..\Resources\player.png"), 100, 100, 3)
        {

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
                Image = Image.FromFile(@"..\..\Resources\playerleft.png");
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                Image = Image.FromFile(@"..\..\Resources\playeright.png");
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                Image = Image.FromFile(@"..\..\Resources\playerup.png");
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                Image = Image.FromFile(@"..\..\Resources\playerdown.png");
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
