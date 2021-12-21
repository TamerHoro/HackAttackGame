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
    public class Render : Form
    {
        int stage = 0;
        int[,] maparray;

        //List<PictureBox> levelwalling = new List<PictureBox>();
        public GameObjects[] objectArray = new GameObjects[200];
        public List<Watchdog> watchdogs = new List<Watchdog>();
        public List<Enemy> enemies = new List<Enemy>();
        //List<PictureBox> enemies = new List<PictureBox>();        
        public Player playerOne= new Player();
        public HealthLabelPlayer PlayerHealthLabel;        
        public Render(int stage=1)
        {
            PlayerHealthLabel = new HealthLabelPlayer(playerOne);
            this.stage = stage;    
            maparray = ReadMapFile();
            LevelBuilder();

        }
        private int[,] ReadMapFile()
        {
            string[] lines= new string[0];
            int[,] maparray = new int[18, 18];
            if (stage == 0||stage == 1)
            {
                 lines = File.ReadAllText(@"..\..\Levels\Level1.txt").Split(new string[] { "\n" }, StringSplitOptions.None);                
            }
            if(stage == 2)
            {
                lines = File.ReadAllText(@"..\..\Levels\Level2.txt").Split(new string[] { "\n" }, StringSplitOptions.None);                
            }
            if (stage == 3)
            {
                lines = File.ReadAllText(@"..\..\Levels\Level3.txt").Split(new string[] { "\n" }, StringSplitOptions.None);
            }
            if(stage >3)
            {
                lines = File.ReadAllText(@"..\..\Levels\Level1.txt").Split(new string[] { "\n" }, StringSplitOptions.None);
            }
            for (int i = 0; i < 18; i++)
            {
                var fields = lines[i].Split(' ');
                for (int j = 0; j < 18; j++)
                {
                    try
                    {
                        maparray[i, j] = int.Parse(fields[j]);
                    }
                    catch (System.FormatException)
                    {
                        maparray[i, j] = char.Parse(fields[j]);
                    }
                }
            }
            return maparray;
        }

        public void BackgroundColor(int stage)
        {

        }

        public void LevelBuilder()            //creates a lists with GameObjects
        {          
            
            int l = -10, h = -15, k = 0;
            
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (maparray[i, j] == (int)Objects.Wall)
                    {
                        objectArray[k++] = new Wall(l, h, i, j);
                        //objectArray[k-1].Image = ;
                    }
                    else if (maparray[i, j] == (int)Objects.Turret)
                    {
                        objectArray[k++] = new Turret(l, h, i, j);
                        objectArray[k - 1].BackColor = Color.Black;
                        enemies.Add(objectArray[k - 1] as Enemy);
                    }
                    else if (maparray[i, j] == (int)Objects.Mine)
                    {
                        objectArray[k++] = new Mine(l, h, i, j);
                    }
                    else if (maparray[i, j] == (int)Objects.Watchdog + 1)
                    {
                        objectArray[k++] = new Watchdog(l, h, i, j, 1);
                        watchdogs.Add(objectArray[k - 1] as Watchdog);
                    }
                    else if (maparray[i, j] == (int)Objects.Watchdog)
                    {
                        objectArray[k++] = new Watchdog(l, h, i, j);
                        watchdogs.Add(objectArray[k - 1] as Watchdog);
                    }
                    else if (maparray[i, j] == (int)Objects.Server)
                    {
                        objectArray[k++] = new Server(l, h);
                    }
                    else if (maparray[i, j] == (int)Objects.Firewall)
                    {
                        objectArray[k++] = new Firewall(l, h);
                    }
                    else if (maparray[i, j] == (int)Objects.Extinguisher)
                    {
                        objectArray[k++] = new FireExtinguisher(l, h);
                    }
                    else if (maparray[i, j] == (int)Objects.Flashdrive)
                    {
                        objectArray[k++] = new Flashdrive(l, h);
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
        enum Objects
        {
            Wall = 1,
            Mine = 2,
            Turret = 3,
            Watchdog = 4,

            Flashdrive = 7,
            Server = 8,
            Gate = 9,

            Firewall = 'F',
            Extinguisher = 'E',
        }
        private void Render_Load(object sender, EventArgs e)
        {

        }
    }
}
