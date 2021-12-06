using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : GameObjects 
    {
        protected bool alive;
        public bool IsAlive { get => alive; }
        public Enemy(int left, int top) : base(left, top)
        {
            alive = true;
        }
    }
}
