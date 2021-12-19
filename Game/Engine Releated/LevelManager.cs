using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class LevelManager
    {
        public static Render CreateLevel(int stage,bool sound)
        {
            if(sound== false)
            {
                switch (stage)
                {
                    case 1: return new Render(1,false);
                    case 2: return new Render(2,false);
                    case 3: return new Render(3,false);
                    default: return new Render(0,false);
                }
            }
            else
            {
                switch (stage)
                {
                    case 1: return new Render(1, true);
                    case 2: return new Render(2, true);
                    case 3: return new Render(3, true);
                    default: return new Render(0, true);
                }
            }
            
        }
        
        

    }
}
