using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class InteractableObject : GameObjects
    {
        public int maxHealth = 3;
        public int currentHealth = 3;        
        public InteractableObject(int left, int top)
            :base(left, top)
        {
            
        }
    }
}
