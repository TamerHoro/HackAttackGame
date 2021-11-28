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
    

    
    public partial class Engine : Form
    {
        bool goleft, goright, goup, godown, gameover;
        string facing = "up";
       

        Render levelOne = new Render(1);

        public Engine()
        {           
            InitializeComponent();
            this.Controls.AddRange(levelOne.walling);
            this.Controls.Add(levelOne.PlayerOne);
            //this.Controls.Add(levelOne.PlayerControl);
            RestartGame();
        }


        
        private void MainTimerEvent(object sender, EventArgs e)
        {
            MainTimerEvent MainTimeEvent = new MainTimerEvent();
            Collision collision = new Collision(levelOne.PlayerOne, levelOne.walling);
            levelOne.PlayerOne.Move(sender,e);
            
            //MainTimeEvent.Update();





        } // Goes to EngineClass



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Engine_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }      
        
        private void ShootBullet(string direction)
        {

        }
        
        private void RestartGame()   //goes to MenueClass
        {
            //MakeLevel();
            //goup = false;
            //godown = false;
            //goleft = false;
            //goright = false;
            //playerhealth = 100;
            //GameTimer.Start();
        }
    }
}
