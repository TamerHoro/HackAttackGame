using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class InteractableObject : GameObjects
    {
        protected short hitpoints;
        protected bool sound= true;
        public InteractableObject(int left, int top)
            :base(left, top)
        {
            
        }
    }
}
