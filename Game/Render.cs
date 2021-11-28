﻿using System;
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
        int[,] maparray = ReadMapFile();
        //List<PictureBox> levelwalling = new List<PictureBox>();
        public GameObjects[] walling = new GameObjects[325];
        //List<PictureBox> enemies = new List<PictureBox>();
        PictureBox goal;
        public Player PlayerOne = new Player();
        static private int[,] ReadMapFile()
        {
            int[,] maparray = new int[18, 18];
            var lines = File.ReadAllText(@"..\..\map array.txt").Split(new string[] { "\n" }, StringSplitOptions.None);
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
        public void LevelBuilder()            //creates a lists with GameObjects
        {
            Player PlayerOne = new Player();
            int l = -10, h = -15, k = 0;
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (maparray[i, j] == 1)
                    {
                        //PictureBox wall = new Wall();
                        //wall.Tag = $"wall{i}{j}";
                        //wall.Image = Properties.Resources.wall;
                        //wall.Width = 40;
                        //wall.Height = 40;
                        //wall.Left = l;
                        //wall.Top = h;
                        //wall.BringToFront();
                        walling[k++] = new Wall(l,h,i,j);
                    }
                    l = l + 40;
                }
                l = -10;
                h = h + 40;
            }
        }

        public Render(int level)
        {

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
