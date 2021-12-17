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
    partial class MainMenue : Form
    {
        Label goal = new Label();
        Label lvl1 = new Label();
        Label lvl2 = new Label();
        Label lvl3 = new Label();
        Label warning = new Label();
        Label title = new Label();
        Button startGame = new Button();
        Button exitButton = new Button();

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.startGame = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(320, 560);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(75, 23);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // Gametitle
            // 
            this.title.Font = new Font("Rockwell Extra Bold", 60);
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(10, 10);
            this.title.Name = "label1";
            this.title.Size = new System.Drawing.Size(140, 10);
            this.title.TabIndex = 1;
            this.title.Text = "HACKATTACK";
            this.title.BackColor = Color.Transparent;
            this.title.ForeColor = Color.White;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(320, 610);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            //
            // Goal
            //
            this.goal.Text = "Goal: Hack your university servers to get all the solutions for the upcoming exams";
            this.goal.Font = new Font("Arial", 20);
            this.goal.Location = new Point(60, 150);
            this.goal.Size = new System.Drawing.Size(590, 70);
            this.goal.BackColor = Color.LightGray;
            //
            // Level1
            //
            this.lvl1.Text = "Level 1: Find the hidden flash drive and sneak into your university";
            this.lvl1.Font = new Font("Arial", 20);
            this.lvl1.Location = new Point(60, 220);
            this.lvl1.Size = new System.Drawing.Size(590, 70);
            this.lvl1.BackColor = Color.LightGray;
            //
            // Level2
            //
            this.lvl2.Text = "Level 2: Hack the servers with your flash drive";
            this.lvl2.Font = new Font("Arial", 20);
            this.lvl2.Location = new Point(60, 290);
            this.lvl2.Size = new System.Drawing.Size(590, 50);
            this.lvl2.BackColor = Color.LightGray;
            //
            // Level3
            //
            this.lvl3.Text = "Level 3: Take down the firewall and get your solutions";
            this.lvl3.Font = new Font("Arial", 20);
            this.lvl3.Location = new Point(60, 340);
            this.lvl3.Size = new System.Drawing.Size(590, 70);
            this.lvl3.BackColor = Color.LightGray;
            //
            // Level3
            //
            this.warning.Text = "Warning: Be aware of the guards and other obstacles";
            this.warning.Font = new Font("Arial", 20);
            this.warning.Location = new Point(60, 410);
            this.warning.Size = new System.Drawing.Size(590, 60);
            this.warning.BackColor = Color.LightGray;
            this.warning.ForeColor = Color.Red;
            // 
            // MainMenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 681);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.goal);
            this.Controls.Add(this.lvl1);
            this.Controls.Add(this.lvl2);
            this.Controls.Add(this.lvl3);
            this.Controls.Add(this.warning);
            this.Name = "MainMenue";
            this.Text = "MainMenue";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.BackgroundImage = Image.FromFile(@"C:\Users\henke\Downloads\matrix.png");
            
        }
    }
}