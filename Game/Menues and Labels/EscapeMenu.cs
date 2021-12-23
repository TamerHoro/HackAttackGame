using Game.Engine_Releated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class EscapeMenu : GroupBox
    {
        new Button exit = new Button();
        new Button restart = new Button();
        new Button sound = new Button();
        new Button graphics = new Button();
        public bool menueopen = false;
        bool soundIsOn = true;
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
            if (e.KeyCode == Keys.Escape && menueopen == true)
            {
                this.Hide();
                menueopen = false;
            }
            else if (e.KeyCode == Keys.Escape && menueopen == false)
            {
                this.BringToFront();
                this.Show();
                menueopen = true;
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
            menueopen = false;
            this.Dispose();
        }
        public void sound_Click(object sender, EventArgs e)
        {
            soundClicked = true;
            //Toggle SFX
            SFX.enabled = !SFX.enabled;
            menueopen = true;
        }
        public void graphics_Click(object sender, EventArgs e)
        {
            graphicsClicked = true;
            RenderSettings.ultraHighQuality = false;
            menueopen=true;
            MessageBox.Show("graphics lowered, please click the sound button to restore control of the menu! (bug)");

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
            //this.Enter += new System.EventHandler(this_Enter);
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
            // 
            // Low Quality Graphics
            // 
            this.graphics.Location = new System.Drawing.Point(195, 169);
            this.graphics.Name = "graphics";
            this.graphics.Size = new System.Drawing.Size(75, 23);
            this.graphics.TabIndex = 0;
            this.graphics.Text = "low quality";
            this.graphics.UseVisualStyleBackColor = true;
            this.graphics.Click += new System.EventHandler(this.graphics_Click);
        }
    }
}
