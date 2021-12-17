using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Game
{
    class Mine : Enemy
    {
        //Attributes for SFX
        SoundPlayer SFXExplosion = new SoundPlayer(Properties.Resources.Explosion);

        //Initialize new mines with a position, Tag and picture.
        //Also load SFX into memory.
        public Mine(int l, int h, int i, int j) : base(l, h)
        {
            //Position
            this.Left = l;
            this.Top = h;

            //Tag
            this.Tag = $"Mine{i}{j}";

            //Picture
            this.Image = Properties.Resources.MineIdle;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.BringToFront();

            //load SFX
            SFXExplosion.Load();
        }

        //Mine detonation animation
        public async void Explode()
        {
            //Mines can only detonate if they're alive
            if (alive)
            { 
                //Mines die after detonation
                alive = false;

                //Play SFX and animation
                SFXExplosion.Play();
                this.Image = Properties.Resources.MineExplode;

                //Wait until animation is finished and remove the mine
                await Task.Delay(1500);
                this.Dispose();
            }
        }
    }
}
