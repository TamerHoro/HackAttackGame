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
        Render levelOne = new Render(0);
        bool winCondition = false;
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
            Collision collision = new Collision(levelOne.PlayerOne, levelOne.walling,out winCondition);
            levelOne.PlayerOne.Move(sender,e);
            NextLevel(winCondition);
            //MainTimeEvent.Update();
        }
        private void Engine_Load(object sender, EventArgs e)
        {

        }   
        
        private void NextLevel(bool windcondition)
        {
            if(windcondition == true)
            {
                levelOne.Close();
                levelOne = new Render(1);
                InitializeComponent();
                this.Controls.AddRange(levelOne.walling);
                this.Controls.Add(levelOne.PlayerOne);
            }
            else
            {
                
            }

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
