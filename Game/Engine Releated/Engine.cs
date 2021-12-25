using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Game.Menues_and_Labels;
using Game.Engine_Releated;

namespace Game
{
    enum Level { one, two, three }

    public partial class Engine : Form
    {
        public Render level = new Render();
        bool winCondition = false;        
        public EscapeMenu escapeMenu = new EscapeMenu();
        public bool restart = false;
        int count = 5;
        int _stage = 1;
        public DeathScreen deathScreen = new DeathScreen();
        public WinningScreen winningScreen = new WinningScreen();
        public Ammo ammo = new Ammo();
        AmmoLabel ammoLabel = new AmmoLabel();
        SoundIcon soundIcon = new SoundIcon();
        public bool sound = true;
        public int stage
        {
            get { return _stage; }
            set { _stage = value; }
        }
        
        public Engine()                     //First initialization of the Game
        {            
            StartGame();
            InitializeComponent();          
            
        }
        
        private void MainTimerEvent(object sender, EventArgs e)                     //Game Loop 20ms Timing
        {
            
            count++;
            MainTimerEvent MainTimeEvent = new MainTimerEvent();
            Collision collision = new Collision(level.playerOne, level.objectArray,count, this, out winCondition);
            level.playerOne.Move();
            Watchdog.Turn(level.watchdogs, level.objectArray);
            Watchdog.Walk(level.watchdogs);
            level.PlayerHealthLabel.update(level.playerOne);
            if (level.playerOne.Health <= 0)
            {
                Hide();
                deathScreen.Visible = true;
                level.playerOne.Health = 3;
            }
            MenueManager.ManageMenues(this);                               //Put all menue managing into one single place
            if (level.playerOne.shoot == true && count > 10)               
            {
                this.ShootBullet(level.playerOne.direction);
                count = 0;
            }
            if (level.playerOne.ammo == 0)
            {
                    ammo.Spwan(level.objectArray);

                if (level.playerOne.Bounds.IntersectsWith(ammo.Bounds))
                {
                    level.playerOne.ammo = ammo.Bullets;
                    ammo.Visible = false;
                    ammo.intersects = true;
                }
            }
            HealthLabelEnemy.update(level.enemies, level.HealthLabelEnemies);
            ammoLabel.UpdateAmmo(level.playerOne);
            NextLevel(winCondition);
            soundIcon.Update();
        }
        public void LoadRequiredObjects()
        {
            this.Controls.AddRange(level.objectArray);
            this.Controls.Add(level.playerOne);
            this.Controls.Add(escapeMenu);
            this.Controls.Add(level.PlayerHealthLabel);
            this.Controls.Add(ammo);
            this.Controls.Add(ammoLabel);
            this.Controls.Add(soundIcon);
            ammoLabel.BringToFront();
            soundIcon.BringToFront();
        }

        public void StartGame()                                  //Initializing a Level of the Game
        {
            SFX.enabled = sound;
            LoadRequiredObjects();
            for (int i=0; i<level.enemies.Count; i++)
            {
                this.Controls.Add(level.HealthLabelEnemies[i]);
            }
        }       

        private void NextLevel(bool wincondition)               //Loading next level
        {
            if (WonGame.CheckWinCondition(wincondition, level.objectArray))
            {
                if (stage == 3)
                {
                    Hide();
                    winningScreen.Visible = true;
                    
                }
                stage++;
                level.playerOne.ammo = 5;
                ammo.intersects = true;
                ammo.Visible = false;
                level.Dispose();
                level.Controls.Clear();
                this.Controls.Clear();
                timer1.Dispose();
                escapeMenu.Dispose();
                level = LevelManager.CreateLevel(stage);
                escapeMenu = new EscapeMenu();
                InitializeComponent();
                LoadRequiredObjects();
                for (int i = 0; i < level.enemies.Count; i++)
                {
                    this.Controls.Add(level.HealthLabelEnemies[i]);
                }
            }
        }
        
        
        public void RestartLevel(int stage)                //Reloading the current Level
        {
            level.Dispose();
            level.Controls.Clear();
            this.Controls.Clear();
            level = LevelManager.CreateLevel(stage);
            escapeMenu = new EscapeMenu();
            InitializeComponent();
            ammo.Visible = false;
            LoadRequiredObjects();
            for (int i = 0; i < level.enemies.Count; i++)
            {
                this.Controls.Add(level.HealthLabelEnemies[i]);
            }
        }

        private void RestartGame()                      //Restart Game Method (Loading the whole Window from new)
        {
            restart = true;
            this.Close();
        }

        private void ShootBullet(string direction)                          //Shooting bullets as Player method
        {
            if (level.playerOne.ammo > 0)
            {
                Bullet shotBullet = new Bullet(level.objectArray, this.level.playerOne);
                shotBullet.direction = direction;
                if (direction == "up")                 //shooting bulltets in direction the player is facing
                {
                    shotBullet.bulletLeft = level.playerOne.Left + level.playerOne.Width/2;
                    shotBullet.bulletTop = level.playerOne.Top - level.playerOne.Height;
                }
                if (direction == "down")
                {
                    shotBullet.bulletLeft = level.playerOne.Left + level.playerOne.Width/2;
                    shotBullet.bulletTop = level.playerOne.Top + level.playerOne.Height;
                }
                if (direction == "left")
                {
                    shotBullet.bulletLeft = level.playerOne.Left - level.playerOne.Width;
                    shotBullet.bulletTop = level.playerOne.Top + level.playerOne.Height/2;
                }
                if (direction == "right")
                {
                    shotBullet.bulletLeft = level.playerOne.Left + level.playerOne.Width;
                    shotBullet.bulletTop = level.playerOne.Top + level.playerOne.Height/2;
                }                
                shotBullet.MakeBullet(this);
                level.playerOne.ammo--;
            }
            
        }
        private void Engine_Load(object sender, EventArgs e)
        {

        }
       
    }
}
