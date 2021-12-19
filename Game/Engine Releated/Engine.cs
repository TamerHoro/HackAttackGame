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
        int stage = 1;
        public DeathScreen deathScreen = new DeathScreen();
        public WinningScreen winningScreen = new WinningScreen();
        public Ammo ammo = new Ammo();
        AmmoLabel ammoLabel = new AmmoLabel();
        public bool sound = true;
        
        public Engine()
        {
            //this.sound = sound;
            //if (sound == false)
            //{
            //    level = new Render(stage, false);

            //} 
            //else { level = new Render(stage, true); }
            
            StartGame();
            InitializeComponent();
            //this.Controls.Add(levelOne.PlayerControl);
            
        }
        
        private void MainTimerEvent(object sender, EventArgs e)
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
            if (escapeMenu.exitClicked == true || deathScreen.exitClicked == true || winningScreen.exitClicked == true) 
            {
                this.Close(); 
            }
            if (deathScreen.restartClicked == true || winningScreen.restartClicked == true)
            {
                winningScreen.restartClicked = false;
                deathScreen.restartClicked = false;
                stage = 1;
                RestartLevel(stage);
                Show();
            }
            if (escapeMenu.restartClicked == true) 
            {
                RestartLevel(stage);
                escapeMenu.restartClicked = false;
            }
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
            ammoLabel.UpdateAmmo(level.playerOne);
            NextLevel(winCondition);       
        }
        public void StartGame()
        {
            SFX.enabled = sound;
            this.Controls.AddRange(level.objectArray);
            this.Controls.Add(level.playerOne);
            this.Controls.Add(escapeMenu);
            this.Controls.Add(level.PlayerHealthLabel);
            this.Controls.Add(ammo);
            this.Controls.Add(ammoLabel);
            ammoLabel.BringToFront();
        }
       
        private void Engine_Load(object sender, EventArgs e)
        {

        }

        private void NextLevel(bool wincondition)
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
                this.Controls.AddRange(level.objectArray);
                this.Controls.Add(level.playerOne);
                this.Controls.Add(escapeMenu);
                this.Controls.Add(level.PlayerHealthLabel);
                this.Controls.Add(ammo);
                this.Controls.Add(ammoLabel);
            }
        }
        
        
        private void RestartLevel(int stage)
        {
            level.Dispose();
            level.Controls.Clear();
            this.Controls.Clear();
            level = LevelManager.CreateLevel(stage);
            escapeMenu = new EscapeMenu();
            InitializeComponent();
            
            this.Controls.AddRange(level.objectArray);
            this.Controls.Add(level.playerOne);
            this.Controls.Add(escapeMenu);
            this.Controls.Add(level.PlayerHealthLabel);
            this.Controls.Add(ammo);
            this.Controls.Add(ammoLabel);
        }

        private void RestartGame()
        {
            restart = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ShootBullet(string direction)
        {
            if (level.playerOne.ammo > 0)
            {
                Bullet shotBullet = new Bullet(level.objectArray, this.level.playerOne);
                shotBullet.direction = direction;
                if (direction == "up")
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
