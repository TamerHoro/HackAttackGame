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
        public Player futurePlayer = new Player();
        public GameObjects[] gameobjects;
        bool win = false;
        
        public void CollsionCheck() 
        {            
            for (int i = 0; i < gameobjects.Length; i++)
            {
                if (gameobjects[i] == null) {  }
                else
                {
                    for(int j = 0; j < 4; j++)
                    {
                        futurePlayer.Bounds = player.Bounds;
                        if(j == 0)
                            futurePlayer.Left = futurePlayer.Left + 5;
                        if(j == 1)
                            futurePlayer.Left = futurePlayer.Left - 5;
                        if(j == 2)
                            futurePlayer.Top = futurePlayer.Top + 5;
                        if(j == 3)
                            futurePlayer.Top = futurePlayer.Top - 5;

                        if (futurePlayer.Bounds.IntersectsWith(gameobjects[i].Bounds))
                        {
                            if (gameobjects[i] is Wall)
                            {
                                if (j == 0)
                                    player.goRight = false;
                                if (j == 1)
                                    player.goLeft = false;
                                if (j == 2)
                                    player.goDown = false;
                                if (j == 3)
                                    player.goUp = false;
                            }
                        }
                        

                    }

                    if (player.Bounds.IntersectsWith(gameobjects[i].Bounds))
                    {
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
                            win = true;

                        }
                        if (gameobjects[i] is Mine || gameobjects[i] is Turret)
                        {
                            if (gameobjects[i] is Mine)
                            {
                                var ActiveMine = gameobjects[i] as Mine;
                                if (ActiveMine.IsAlive)
                                {
                                    ActiveMine.Explode();
                                    player.Die();
                                }
                            }
                            else
                            {
                                var ActiveTurret = gameobjects[i] as Turret;
                                if (ActiveTurret.IsAlive)
                                {
                                    ActiveTurret.SelfDestruct();
                                    player.Die();
                                }

                            }                            
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
