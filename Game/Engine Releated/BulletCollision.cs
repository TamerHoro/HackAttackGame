namespace Game
{
    class BulletCollision
    {
        public BulletCollision(Bullet bullet, GameObjects[] gameobjects, Player player, out bool collided)
        {
            this.bullet = bullet;
            this.gameobjects = gameobjects;
            this.player = player;
            BulletCollsionCheck();
            collided = col;
            bullet = new Bullet(gameobjects, player);
        }
        public Bullet bullet;
        public GameObjects[] gameobjects;
        public Player player;        
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
                        else if (gameobjects[i] is Watchdog)
                        {
                            col = true;
                            var HitWatchdog = gameobjects[i] as Watchdog;
                            HitWatchdog.TakeDamage();
                        }
                    }
                }

            }
            if (bullet.Bounds.IntersectsWith(player.Bounds)&& col==false)
            {
                col = true;
                player.Health--; 
            } 
        }
    }
}

