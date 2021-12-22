﻿using System;
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
        public Engine engine;
        bool win = false;
        int timepassed;
        
        public void CollsionCheck() 
        {            
            for (int i = 0; i < gameobjects.Length; i++)
            {
                if (gameobjects[i] == null) {  }
                else
                {
                    for(int j = 0; j < 4; j++)                              //Improved Collision check
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
                        if (gameobjects[i] is Mine || gameobjects[i] is Turret || gameobjects[i] is Watchdog)
                        {
                            if (player.Bounds.IntersectsWith(gameobjects[i].Bounds))
                            {
                                if (gameobjects[i] is Mine)
                                {
                                    var ActiveMine = gameobjects[i] as Mine;
                                    if (ActiveMine.IsAlive && gameobjects[i].col == false)
                                    {
                                        ActiveMine.Explode();
                                        player.Health--;
                                        gameobjects[i].col = true;
                                        //player.Die();
                                        gameobjects[i] = null;
                                    }
                                }
                                else if (gameobjects[i] is Watchdog&& gameobjects[i].col == false)
                                {
                                    gameobjects[i].col = true;
                                    //player.Health--;
                                    player.Die();
                                }
                                else
                                {
                                    gameobjects[i].col = true;
                                    player.Health--;
                                    //var ActiveTurret = gameobjects[i] as Turret;
                                    //if (ActiveTurret.IsAlive&& ActiveTurret!=null && gameobjects[i].col == false)
                                    //{
                                        
                                    //    //ActiveTurret.SelfDestruct();
                                    //    //player.Die();
                                    //    //gameobjects[i] = null;
                                    //    ActiveTurret.TestFire();
                                    //}

                                }
                            }
                            if (gameobjects[i] is Turret)
                            {
                                var TurretToCheck = gameobjects[i] as Turret;
                                if (TurretToCheck.CurrentState == Turret.State.Shooting)
                                {
                                    TurretToCheck.Shoot(engine, gameobjects);
                                }

                            }                            
                        }
                        if (gameobjects[i] is Flashdrive)
                        {
                            var badUSB = gameobjects[i] as Flashdrive;
                            if (!badUSB.Collected) badUSB.collect();
                            badUSB.Dispose();
                            badUSB = null;
                            gameobjects[i] = null;
                        }
                        if (gameobjects[i] is FireExtinguisher)
                        {
                            var extinguisher = gameobjects[i] as FireExtinguisher;
                            if (!extinguisher.Collected) extinguisher.collect();
                        }
                        if (gameobjects[i] is Server)
                        {
                            var server = gameobjects[i] as Server;
                            server.Hack();
                        }
                        if (gameobjects[i] is Firewall)
                        {
                            var fire = gameobjects[i] as Firewall;
                            if (fire.Fight())
                            {
                                fire.Dispose();
                                fire = null;
                                gameobjects[i] = null;
                            }
                            else player.Die();
                        }
                        if (gameobjects[i] is Checkpoint)
                        {
                            var Checkpoint = gameobjects[i] as Checkpoint;
                            Checkpoint.Trigger(engine, gameobjects);
                        }
                    }
                    if(timepassed%200==0) gameobjects[i].col = false;






                }
                
            }

        }
        public Collision(Player player, GameObjects[] gameobjects,int count, Engine engine, out bool winCondition)
        {            
            this.player = player;
            this.timepassed = count;
            this.gameobjects = gameobjects;
            this.engine = engine;
            CollsionCheck();
            winCondition = win;
        }
       
    }
}
