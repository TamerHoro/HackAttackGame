using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Game.Engine_Releated;

namespace Game
{
    class Mine : Enemy
    {    
        //Initialize new mines with a position, Tag and picture.
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
                SFX.Play(SFX.Sound.Explode);
                this.Image = Properties.Resources.MineExplode;

                //Wait until animation is finished and remove the mine
                await Task.Delay(1500);
                this.Dispose();
            }
        }
    }
}
