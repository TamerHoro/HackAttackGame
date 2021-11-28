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
        bool win = false;
        public void CollsionCheck()
        {            
            for (int i = 0; i < gameobjects.Length; i++)
            {
                if (gameobjects[i] == null) {  }
                else
                {
                    if (player.Bounds.IntersectsWith(gameobjects[i].Bounds))
                        if (gameobjects[i] is Wall)
                        {
                            if (player.Location.X > gameobjects[i].Location.X) //Object is leftside of player
                            {
                                player.goLeft = false;
                                player.Left = player.Left + 5;
                            }
                            if (player.Location.X < gameobjects[i].Location.X) //Object is rightside of player
                            {
                                player.goRight = false;
                                player.Left = player.Left - 5;
                            }
                            if (player.Location.Y > gameobjects[i].Location.Y) //Object is below player
                            {
                                player.goDown = false;
                                player.Top = player.Top + 5;
                            }
                            if (player.Location.Y < gameobjects[i].Location.Y) //Object is over player
                            {
                                player.goUp = false;
                                player.Top = player.Top - 5;
                            }
                        }
                        if (gameobjects[i] is Gate)
                        {
                            if (player.Bounds.IntersectsWith(gameobjects[i].Bounds))
                            {
                                win = true;
                            }
                            
                        }
                }
                
            }
            
        }
        public Collision(Player player, GameObjects[] gameobjects, out bool winCondition)
        {            
            this.player = player;
            this.gameobjects = gameobjects;
            CollsionCheck();
            winCondition = win;
        }
    }
}
