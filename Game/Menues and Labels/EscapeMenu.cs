using Game.Engine_Releated;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace Game
{
    public class EscapeMenu : GroupBox
    {
        Button exit = new Button();
        Button restart = new Button();
        Button sound = new Button();
        Button graphics = new Button();        

        public bool menueopen = false;
        bool _exitClicked = false;
        bool _restartClicked = false;
        bool _soundClicked = false;
        bool _graphicsClicked = false;

        public bool exitClicked { get => _exitClicked; private set => _exitClicked = value; }
        public bool restartClicked { get => _restartClicked; set => _restartClicked = value; }
        public bool soundClicked { get => _soundClicked; set => _soundClicked = value; }
        public bool graphicsClicked { get => _graphicsClicked; set => _graphicsClicked = value; }
        public void KeyIsUp(object sender, KeyEventArgs e)
        {


        }
        public void KeyIsDown(object sender, KeyEventArgs e)               
        {
            if (e.KeyCode == Keys.Escape && menueopen == true)                   //Closes the Menue
            {
                this.Hide();
                menueopen = false;
                this.Enabled = false;
            }
            else if (e.KeyCode == Keys.Escape && menueopen == false)             //"Opens" the Menue
            {
                this.BringToFront();
                this.Show();
                menueopen = true;
                this.Enabled = true;
            }
            else
            {


            }
        }
        public void exit_Click(object sender, EventArgs e)
        {
            exitClicked = true;
        }
        public void restart_Click(object sender, EventArgs e)
        {
            restartClicked = true;
            //menueopen = false;
            this.Dispose();
        }
        public void sound_Click(object sender, EventArgs e)
        {
            if (SFX.enabled == true)
            {
                SFX.enabled = false;

            }
            else
            {
                SFX.enabled = true;
            }
            soundClicked = true;

        }
        public void graphics_Click(object sender, EventArgs e)
        {          
            
            graphicsClicked = true;                     
            //MessageBox.Show("graphics lowered, please click the sound button to restore control of the menu! (bug)");

        }
       

        public void OpenMenue()
        {


        }

        public EscapeMenu()
        {
            // 
            // groupBox1
            // 
            this.Controls.Add(this.exit);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.sound);
            this.Controls.Add(this.graphics);
            this.Location = new System.Drawing.Point(111, 160);
            this.Name = "groupBox1";
            this.Size = new System.Drawing.Size(472, 294);
            this.TabIndex = 0;
            this.TabStop = false;
            this.Text = "";
            this.Hide();
            this.BackColor = Color.Black;
            this.ForeColor = Color.Green;
            this.BackgroundImage = Properties.Resources.matrix;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(195, 109);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 0;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.BackColor = Color.Black;
            this.exit.ForeColor = Color.Green;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(195, 128);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(75, 23);
            this.restart.TabIndex = 1;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            this.restart.BackColor = Color.Black;
            this.restart.ForeColor = Color.Green;
            // 
            // sound
            // 
            this.sound.Location = new System.Drawing.Point(195, 149);
            this.sound.Name = "sound";
            this.sound.Size = new System.Drawing.Size(75, 23);
            this.sound.TabIndex = 0;
            this.sound.Text = "Sound";
            this.sound.UseVisualStyleBackColor = true;
            this.sound.Click += new System.EventHandler(this.sound_Click);
            this.sound.BackColor = Color.Black;
            this.sound.ForeColor = Color.Green;
            // 
            // Low Quality Graphics
            // 
            this.graphics.Location = new System.Drawing.Point(195, 169);
            this.graphics.Name = "graphics";
            this.graphics.Size = new System.Drawing.Size(75, 23);
            this.graphics.TabIndex = 0;
            this.graphics.Text = "lower Graphics";
            this.graphics.UseVisualStyleBackColor = true;
            this.graphics.Click += new System.EventHandler(this.graphics_Click);
            this.graphics.BackColor = Color.Black;
            this.graphics.ForeColor = Color.Green;
        }
    }
}
