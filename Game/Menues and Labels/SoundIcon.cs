using System.Windows.Forms;
using System.Drawing;
using Game.Engine_Releated;


namespace Game.Menues_and_Labels
{
    class SoundIcon : PictureBox
    {
        public SoundIcon()
        {
            this.Image = Properties.Resources.nosound;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Gray;
            Location = new Point(650, 23);
            this.Hide();
            //this.BringToFront();            
        }

        public void Update()
        {
            if(SFX.enabled == true)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }
          
    }
}
