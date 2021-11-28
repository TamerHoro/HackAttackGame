using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class InteractableObject : GameObjects
    {
        public int Health;
        public InteractableObject(Image image, int left, int top, int health)
            :base(image, left, top)
        {
            Health = health;
        }
    }
}
