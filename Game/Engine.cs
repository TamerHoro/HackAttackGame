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
        
        Render levelOne = new Render(0);
        bool winCondition = false;
        public EscapeMenu escapeMenu = new EscapeMenu();     
        


        public Engine()
        {           
            InitializeComponent();
            this.Controls.AddRange(levelOne.walling);
            this.Controls.Add(levelOne.PlayerOne);
            this.Controls.Add(escapeMenu);
            //this.Controls.Add(levelOne.PlayerControl);
            
        }
        private void MainTimerEvent(object sender, EventArgs e)
        {
            MainTimerEvent MainTimeEvent = new MainTimerEvent();
            Collision collision = new Collision(levelOne.PlayerOne, levelOne.walling,out winCondition);
            levelOne.PlayerOne.Move();
            if (escapeMenu.exitClicked == true) 
            {
                this.Close(); 
            }
            if(escapeMenu.restartClicked == true) 
            {
                RestartGame();
                escapeMenu = new EscapeMenu();
            };
            if (levelOne.PlayerOne.shoot == true)
            {
                this.ShootBullet(levelOne.PlayerOne.direction);
            }
            NextLevel(winCondition);
            //MainTimeEvent.Update();
        }
       
        private void Engine_Load(object sender, EventArgs e)
        {

        }   
        
        private void NextLevel(bool wincondition)
        {
            if(wincondition == true)
            {
                levelOne.Dispose();
                levelOne.Controls.Clear();
                this.Controls.Clear();
                
                levelOne = new Render(1);
                InitializeComponent();
                this.Controls.AddRange(levelOne.walling);
                this.Controls.Add(levelOne.PlayerOne);
                this.Controls.Add(escapeMenu);
            }
            else
            {
                
            }

        }
        
        
        private void RestartGame()   //goes to MenueClass
        {
            levelOne.Controls.Clear();
            levelOne.Dispose();            
            this.Controls.Clear();
            levelOne = new Render(0);
            InitializeComponent();
            this.Controls.AddRange(levelOne.walling);
            this.Controls.Add(levelOne.PlayerOne);
            this.Controls.Add(escapeMenu);
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
            shotBullet.bulletLeft = levelOne.PlayerOne.Left + (levelOne.PlayerOne.Width / 2);
            shotBullet.bulletTop = levelOne.PlayerOne.Top + (levelOne.PlayerOne.Height / 2);
            shotBullet.MakeBullet(this);
        }

    }
}
