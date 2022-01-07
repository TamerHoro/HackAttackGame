using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class WonGame
    {        
        public static bool CheckWinCondition(bool win, GameObjects[] objectArray)
        {
            bool enemyAlive = false;
            for (int i = 0; i < objectArray.Length; i++)
            {
                if (objectArray[i] is Enemy )
                {
                    if (objectArray[i].IsDisposed)
                    {
                        objectArray[i] = null;
                        enemyAlive = false;
                    }
                    else
                    {
                        enemyAlive = true;
                    }
                    
                }

            }
            //  Add "&& enemyAlive == false" to get to the next level only when all enemies are dead
            if (win == true)           
            {
                return true;
            }
            return false;
        }
    }
}
