using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : GameObjects 
    {
        //Attributes, every enemy must be alive or dead and have hitpoints
        protected bool alive;
        protected short hitpoints;

        //Getter for the alive attribute
        public bool IsAlive { get => alive; }

        //constructor, every enemy must have coordinates
        public Enemy(int left, int top) : base(left, top)
        {
            //Enemy is alive by default
            alive = true;
        }
    }
}
