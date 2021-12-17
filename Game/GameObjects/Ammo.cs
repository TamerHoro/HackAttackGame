using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class Ammo : StaticObject
    {
        public int Bullets;
        Random rnd = new Random();
        public bool changePosition = true;
        public bool intersects = true;
        public Ammo()
            : base(200, 200)
        {
            //BringToFront();
            Visible = false;
            Image = Image.FromFile(@"..\..\Resources\ammo.png");
            Bullets = 5;
            Size = new Size(new Point(5, 5));
            SizeMode = PictureBoxSizeMode.AutoSize;
            BackColor = Color.Transparent;
            Visible = false;
        }

        public void Spwan(GameObjects[] gameobjects)
        {
            
            while (intersects)
            {
                bool redo = false;
                Location = new Point(rnd.Next(100, 600), rnd.Next(100, 600));
                for (int i = 0; i < gameobjects.Length; i++)
                {
                    if (gameobjects[i] == null) { }
                    else
                    {
                        if (Bounds.IntersectsWith(gameobjects[i].Bounds))
                        {
                            intersects = true;
                            redo = true;
                            break;
                        }

                    }
                }
                if (redo)
                {
                    break;
                }
                intersects = false;
            }

            Visible = true;
        }
    }
}