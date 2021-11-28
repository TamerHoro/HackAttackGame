using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Collision
    {
        public Player player;
        public GameObjects[] gameobjects;
        public void CollsionCheck()
        {            
            for (int i = 0; i < gameobjects.Length; i++)
            {
                if (gameobjects[i] == null) { break; }
                else
                {
                    if (player.Bounds.IntersectsWith(gameobjects[i].Bounds))
                        if (gameobjects is Wall[])
                        {
                            if (player.Location.X > gameobjects[i].Location.X) //Object is leftside of player
                            {
                                player.goLeft = false;
                            }
                            if (player.Location.X < gameobjects[i].Location.X) //Object is rightside of player
                            {
                                player.goRight = false;
                            }
                            if (player.Location.Y > gameobjects[i].Location.X) //Object is below player
                            {
                                player.goDown = false;
                            }
                            if (player.Location.X < gameobjects[i].Location.X) //Object is over player
                            {
                                player.goUp = false;
                            }
                        }
                }
                
            }
            
        }
        public Collision(Player player, GameObjects[] gameobjects)
        {
            this.player = player;
            this.gameobjects = gameobjects;
            CollsionCheck();
        }
    }
}
