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
    public class Render : Form
    {
        int stage = 0;
        int[,] maparray;

        //List<PictureBox> levelwalling = new List<PictureBox>();
        public GameObjects[] objectArray = new GameObjects[200];
        public List<Watchdog> watchdogs = new List<Watchdog>();
        public List<Enemy> enemies = new List<Enemy>();
        List<Turret> turrets = new List<Turret>();
        List<Checkpoint> checkpoints = new List<Checkpoint>();
        //List<PictureBox> enemies = new List<PictureBox>();        
        public Player playerOne= new Player();
        public HealthLabelPlayer PlayerHealthLabel;
        public List<HealthLabelEnemy> HealthLabelEnemies = new List<HealthLabelEnemy>();
        public Render(int stage=1)
        {
            PlayerHealthLabel = new HealthLabelPlayer(playerOne);
            this.stage = stage;    
            maparray = ReadMapFile();
            LevelBuilder();

        }
        private int[,] ReadMapFile()
        {
            //load level data from .txt files as strings
            string level1 = Properties.Resources.Level1;
            string level2 = Properties.Resources.Level2;
            string level3 = Properties.Resources.Level3;

            string[] lines= new string[0];
            int[,] maparray = new int[18, 18];
            if (stage == 0||stage == 1)
            {
                 lines = level1.Split(new string[] { "\n" }, StringSplitOptions.None);                
            }
            if(stage == 2)
            {
                lines = level2.Split(new string[] { "\n" }, StringSplitOptions.None);                
            }
            if (stage == 3)
            {
                lines = level3.Split(new string[] { "\n" }, StringSplitOptions.None);
            }
            if(stage >3)
            {
                lines = level1.Split(new string[] { "\n" }, StringSplitOptions.None);
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
            Turret.Direction facing = Turret.Direction.North;

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
                        HealthLabelEnemies.Add(new HealthLabelEnemy(objectArray[k - 1] as Enemy));
                        turrets.Add(objectArray[k - 1] as Turret);
                    }
                    else if (maparray[i, j] == (int)Objects.Mine)
                    {
                        objectArray[k++] = new Mine(l, h, i, j);
                    }
                    else if (maparray[i, j] == (int)Objects.Watchdog + 1)
                    {
                        objectArray[k++] = new Watchdog(l, h, i, j, 1);
                        watchdogs.Add(objectArray[k - 1] as Watchdog);
                        enemies.Add(objectArray[k - 1] as Enemy);
                        HealthLabelEnemies.Add(new HealthLabelEnemy(objectArray[k - 1] as Enemy));
                    }
                    else if (maparray[i, j] == (int)Objects.Watchdog)
                    {
                        objectArray[k++] = new Watchdog(l, h, i, j);
                        watchdogs.Add(objectArray[k - 1] as Watchdog);
                        enemies.Add(objectArray[k - 1] as Enemy);
                        HealthLabelEnemies.Add(new HealthLabelEnemy(objectArray[k - 1] as Enemy));
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
                    else if (checkTurret(i, j, out facing))
                    {
                        var current_turret = new Turret(l, h, i, j, facing);
                        turrets.Add(current_turret);
                        enemies.Add(current_turret as Enemy);
                        objectArray[k++] = current_turret;
                        HealthLabelEnemies.Add(new HealthLabelEnemy(current_turret as Enemy));
                    }
                    else if (maparray[i, j] == (int)Objects.CheckpointBig)
                    {
                        var checkpoint = new Checkpoint(l, h, 80);
                        checkpoints.Add(checkpoint);
                        objectArray[k++] = checkpoint;
                    }
                    else if (maparray[i, j] == (int)Objects.Checkpoint)
                    {
                        var checkpoint = new Checkpoint(l, h);
                        checkpoints.Add(checkpoint);
                        objectArray[k++] = checkpoint;
                    }
                    else if (maparray[i, j] == (int)Objects.DestructableWall)
                    {
                        objectArray[k++] = new DestructableWall(l, h, i, j);
                    }
                    l = l + 40;
                }
                l = -10;
                h = h + 40;
            }

            foreach (Checkpoint checkpoint in checkpoints) 
            {
                var nearest_turret = checkpoint.getNearestTurret(turrets);
                checkpoint.Link(nearest_turret); 
            }

            //Auxiliary method, checks if char is turret and returns the direction it is facing
            bool checkTurret(int i, int j, out Turret.Direction direction)
            {
                direction = Turret.Direction.North;
                switch (maparray[i,j])
                { 
                    case (int)Objects.TurretNorth:
                        direction = Turret.Direction.North;
                        return true;

                    case (int)Objects.TurretEast:
                        direction = Turret.Direction.East;
                        return true;

                    case (int)Objects.TurretSouth:
                        direction = Turret.Direction.South;
                        return true;

                    case (int)Objects.TurretWest:
                        direction = Turret.Direction.West;
                        return true;

                    case (int)Objects.TurretNorthEast:
                        direction = Turret.Direction.NorthEast;
                        return true;

                    case (int)Objects.TurretNorthWest:
                        direction = Turret.Direction.NorthWest;
                        return true;

                    case (int)Objects.TurretSouthEast:
                        direction = Turret.Direction.SouthEast;
                        return true;

                    case (int)Objects.TurretSouthWest:
                        direction = Turret.Direction.SouthWest;
                        return true;
                }
                return false;
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
            Mine = 'M',
            Watchdog = 4,
            DestructableWall = 6,

            Flashdrive = 7,
            Server = 8,
            Gate = 9,

            Firewall = 'F',
            Extinguisher = 'L',
            CheckpointBig = 'P',
            Checkpoint = 'p',

            Turret = 3,
            TurretNorth = 'w',
            TurretWest = 'a',
            TurretSouth = 'x',
            TurretEast = 'd',
            TurretNorthEast = 'e',
            TurretNorthWest = 'q',
            TurretSouthWest = 'y',
            TurretSouthEast = 'c',

        }
        private void Render_Load(object sender, EventArgs e)
        {

        }
    }
}
