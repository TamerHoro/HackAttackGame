using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class Ammo : StaticObject
    {
        // New ammo always contains 5 bullets
        public int Bullets = 5;
        public bool changePosition = true;
        public bool intersects = true;
        Random rnd = new Random();
        public Ammo()
            : base(200, 200)
        {
            Image = Image.FromFile(@"..\..\Resources\ammo.png");
            Size = new Size(new Point(5, 5));
            SizeMode = PictureBoxSizeMode.AutoSize;
            BackColor = Color.Transparent;
            Visible = false;
        }

        // New Ammo spawns if the player is out of bullets
        public void Spwan(GameObjects[] gameobjects)
        {
            //Checks if the Ammo intersects with a gameobject
            while (intersects)
            {
                bool redo = false;
                Location = new Point(rnd.Next(100, 600), rnd.Next(100, 600));
                for (int i = 0; i < gameobjects.Length; i++)
                {
                    if (gameobjects[i] is Wall || gameobjects[i] is InteractableObject)
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
            // After finding a good location without intersections the ammo is visble for the player
            Visible = true; 
        }
    }
}