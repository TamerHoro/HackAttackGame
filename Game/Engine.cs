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
        //int playerhealth = 100;
        //int speed = 10;

        //private void KeyIsDown(object sender, KeyEventArgs e)
        //{
            
        //}


        //private void KeyIsDownAlt(object sender, KeyEventArgs e)
        //{
        //    if (gameover) return; // if game over is true then do nothing in this event

        //    // if the left key is pressed then do the following
        //    if (e.KeyCode == Keys.Left)
        //    {
        //        goleft = true; // change go left to true                                    Goes to PlayerClass
        //        facing = "left"; //change facing to left                                    Goes to PlayerClass
        //        player.Image = Properties.Resources.playerleft; // change the player image to LEFT image
        //    }

        //    // end of left key selection

        //    // if the right key is pressed then do the following
        //    if (e.KeyCode == Keys.Right)
        //    {
        //        goright = true; // change go right to true                                   Goes to PlayerClass
        //        facing = "right"; // change facing to right                                   Goes to PlayerClass
        //        player.Image = Properties.Resources.playeright; // change the player image to right
        //    }
        //    // end of right key selection

        //    // if the up key is pressed then do the following
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        facing = "up"; // change facing to up                                   Goes to PlayerClass
        //        goup = true; // change go up to true                                   Goes to PlayerClass
        //        player.Image = Properties.Resources.playerup; // change the player image to up
        //    }

        //    // end of up key selection

        //    // if the down key is pressed then do the following
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        facing = "down"; // change facing to down                                   Goes to PlayerClass
        //        godown = true; // change go down to true                                   Goes to PlayerClass
        //        player.Image = Properties.Resources.playerdown; //change the player image to down
        //    }
        //}//Goes to Engine

        //private void KeyIsUp(object sender, KeyEventArgs e) // Goes to PlayerClass or Engine
        //{
        //    if (e.KeyCode == Keys.Left)     
        //    {
        //        goleft = false;
        //    }
        //    if (e.KeyCode == Keys.Right)
        //    {
        //        goright = false;
        //    }
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        goup = false;
        //    }
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        godown = false;
        //    }

        //}//Goes to Engine

        Render levelOne = new Render(1);

        public Engine()
        {           
            InitializeComponent();
            this.Controls.AddRange(levelOne.walling);
            this.Controls.Add(levelOne.PlayerOne);
            //this.Controls.Add(level.PlayerControl);
            RestartGame();
        }

        
        private void MainTimerEvent(object sender, EventArgs e)
        {
            MainTimerEvent MainTimeEvent = new MainTimerEvent();
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
