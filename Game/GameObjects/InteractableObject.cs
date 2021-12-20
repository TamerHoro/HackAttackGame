using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class InteractableObject : GameObjects
    {
        public int maxHealth;
        public int currentHealth;        
        public InteractableObject(int left, int top)
            :base(left, top)
        {
            
        }
    }
}
