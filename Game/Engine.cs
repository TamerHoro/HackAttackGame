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


namespace Game
{
    enum Level { one, two, three }

    public partial class Engine : Form
    {
        
        Render level = new Render(0);
        bool winCondition = false;
        public EscapeMenu escapeMenu = new EscapeMenu();
        public bool restart = false;
        int stage = 1;


        public Engine()
        {           
            InitializeComponent();
            //this.Controls.Add(levelOne.PlayerControl);
            StartGame();
        }
        private void MainTimerEvent(object sender, EventArgs e)
        {
            MainTimerEvent MainTimeEvent = new MainTimerEvent();
            Collision collision = new Collision(level.playerOne, level.objectArray,out winCondition);
            level.playerOne.Move();
            if (escapeMenu.exitClicked == true) 
            {
                this.Close(); 
            }
            if(escapeMenu.restartClicked == true) 
            {
                RestartLevel();
                escapeMenu.restartClicked = false;
            };
            if (level.playerOne.shoot == true)
            {
                this.ShootBullet(level.playerOne.direction);
            }
            NextLevel(winCondition);
            //MainTimeEvent.Update();
        }
        public void StartGame()
        {
            this.Controls.AddRange(level.objectArray);
            this.Controls.Add(level.playerOne);
            this.Controls.Add(escapeMenu);
        }
       
        private void Engine_Load(object sender, EventArgs e)
        {

        }   
        
        private void NextLevel(bool wincondition)
        {
            if(wincondition == true)
            {
                stage++;
                level.Dispose();
                level.Controls.Clear();
                this.Controls.Clear();
                timer1.Dispose();
                escapeMenu.Dispose();
                //escapeMenu.Dispose();
                level = LevelManager.CreateLevel(stage);
                escapeMenu = new EscapeMenu();
                InitializeComponent();
                this.Controls.AddRange(level.objectArray);
                this.Controls.Add(level.playerOne);                
                this.Controls.Add(escapeMenu);
            }
            else
            {
                
            }

        }
        
        
        private void RestartLevel()
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
            Bullet shotBullet = new Bullet();
            shotBullet.direction = direction;
            shotBullet.bulletLeft = level.playerOne.Left + (level.playerOne.Width / 2);
            shotBullet.bulletTop = level.playerOne.Top + (level.playerOne.Height / 2);
            shotBullet.MakeBullet(this);
        }

    }
}
