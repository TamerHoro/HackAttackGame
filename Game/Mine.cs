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
        SoundPlayer SFXExplosion = new SoundPlayer(Properties.Resources.Explosion);
        public Mine(int l, int h, int i, int j) : base(l, h)
        {
            this.Tag = $"Mine{i}{j}";
            this.Image = Properties.Resources.MineIdle;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.Left = l;
            this.Top = h;
            this.BringToFront();
            SFXExplosion.Load();
        }

        public async void Explode()
        {
            if (alive)
            { 
                alive = false;
                SFXExplosion.Play();
                this.Image = Properties.Resources.MineExplode;
                await Task.Delay(1500);
                //this.alive = false;
                this.Dispose();
            }
        }
    }
}
