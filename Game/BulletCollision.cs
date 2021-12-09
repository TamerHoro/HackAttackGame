using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BulletCollision
    {
        public Bullet bullet; 
        public GameObjects[] gameobjects;
        bool col = false;
        public void BulletCollsionCheck()
        {
            for (int i = 0; i < gameobjects.Length; i++)
            {
                if (gameobjects[i] == null) { }
                else
                {
                    if (bullet.Bounds.IntersectsWith(gameobjects[i].Bounds))
                    {
                        if (gameobjects[i] is Wall)
                        {
                            col = true;
                        }
                        else if (gameobjects[i] is Turret)
                        {
                            col = true;
                            var HitTurret = gameobjects[i] as Turret;
                            HitTurret.TakeDamage();
                            if (!HitTurret.IsAlive)
                            {
                                gameobjects[i] = null;
                                HitTurret = null;
                            }
                        }
                        else if (gameobjects[i] is Mine)
                        {
                            col = true;
                            var HitMine = gameobjects[i] as Mine;
                            HitMine.Explode();
                            gameobjects[i] = null;
                            HitMine = null;
                        }
                        else if (gameobjects[i] is Player)
                        {
                            var activePlayer = gameobjects[i] as Player;
                            activePlayer.Die();
                        }
                    }
                }

            }

        }
        public BulletCollision(Bullet bullet, GameObjects[] gameobjects, out bool collided)
        {
            this.bullet = bullet;
            this.gameobjects = gameobjects;
            BulletCollsionCheck();
            collided = col;
            bullet = new Bullet(gameobjects);
        }
    }
}

