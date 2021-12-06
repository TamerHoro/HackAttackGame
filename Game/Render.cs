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
    class Render : Form
    {
        int stage = 0;
        int[,] maparray;
        //List<PictureBox> levelwalling = new List<PictureBox>();
        public GameObjects[] objectArray = new GameObjects[325];
        //List<PictureBox> enemies = new List<PictureBox>();        
        public Player playerOne = new Player();
        private int[,] ReadMapFile()
        {
            string[] lines= new string[0];
            int[,] maparray = new int[18, 18];
            if (stage == 0||stage == 1)
            {
                 lines = File.ReadAllText(@"..\..\Level1.txt").Split(new string[] { "\n" }, StringSplitOptions.None);                
            }
            if(stage == 2)
            {
                lines = File.ReadAllText(@"..\..\Level2.txt").Split(new string[] { "\n" }, StringSplitOptions.None);                
            }
            else
            {
                lines = File.ReadAllText(@"..\..\Level1.txt").Split(new string[] { "\n" }, StringSplitOptions.None);
            }
            for (int i = 0; i < 18; i++)
            {
                var fields = lines[i].Split(' ');
                for (int j = 0; j < 18; j++)
                {
                    maparray[i, j] = int.Parse(fields[j]);
                }
            }
            return maparray;
        }

        enum Objects
        {
            Wall = 1,
            Mine = 2,
            Turret = 3,
            Gate = 9
        }

        public void LevelBuilder()            //creates a lists with GameObjects
        {

            Player PlayerOne = new Player();
            int l = -10, h = -15, k = 0;
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (maparray[i, j] == (int)Objects.Wall)
                    {
                        objectArray[k++] = new Wall(l, h, i, j);
                    }
                    else if (maparray[i, j] == (int)Objects.Turret)
                    {
                        objectArray[k++] = new Turret(l, h, i, j);
                    }
                    else if (maparray[i, j] == (int)Objects.Mine)
                    {
                        objectArray[k++] = new Mine(l, h, i, j);
                        
                    }
                    else if (maparray[i, j] == (int)Objects.Gate)
                    {
                        objectArray[k++] = new Gate(l, h, i, j);
                    }
                    l = l + 40;
                }
                l = -10;
                h = h + 40;
            }
        }

        public Render(int stage)
        {

            this.stage = stage;
            maparray = ReadMapFile();
            LevelBuilder();
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Render
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Render";
            this.Load += new System.EventHandler(this.Render_Load);
            this.ResumeLayout(false);

        }

        private void Render_Load(object sender, EventArgs e)
        {

        }
    }
}
