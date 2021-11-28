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
        //bool goleft, goright, goup, godown, gameover;
        //string facing = "up";
        static int level = 0;


        Render levelOne = new Render(0);

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

        private void Engine_Load(object sender, EventArgs e)
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
