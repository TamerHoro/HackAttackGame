using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class InteractableObject : GameObjects
    {
        public int Health;
        public InteractableObject(int left, int top, int health, Image image)
            :base(left, top)
        {
            Health = health;
            this.Image = image;
        }
    }
}
