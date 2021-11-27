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
        public bool goLeft, goRight, goUp, goDown;
        int speed = 5;
        public PictureBox picture = new PictureBox();
        Image playerimage = Image.FromFile(@"C:\Users\henke\Downloads\mooict.com-zombie-shooter-assets\up.png");
        public int health = 3;
        public Player()
        {
            picture.Image = playerimage;
            picture.Location = new Point(100, 100);
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
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
                picture.Image = Image.FromFile(@"C:\Users\henke\Downloads\mooict.com-zombie-shooter-assets\left.png");
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                picture.Image = Image.FromFile(@"C:\Users\henke\Downloads\mooict.com-zombie-shooter-assets\right.png");
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                picture.Image = Image.FromFile(@"C:\Users\henke\Downloads\mooict.com-zombie-shooter-assets\up.png");
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                picture.Image = Image.FromFile(@"C:\Users\henke\Downloads\mooict.com-zombie-shooter-assets\down.png");
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
                picture.Left -= speed;
            }
            if (goRight == true)
            {
                picture.Left += speed;
            }
            if (goUp == true)
            {
                picture.Top -= speed;
            }
            if (goDown == true)
            {
                picture.Top += speed;
            }
        }
        
    }
}
