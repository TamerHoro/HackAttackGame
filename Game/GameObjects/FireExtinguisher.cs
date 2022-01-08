using System;
using System.Windows.Forms;
using System.Drawing;
using Game.Engine_Releated;

namespace Game
{
    class FireExtinguisher : StaticObject
    {
        static bool collected;
        public bool Collected { get => collected; }

        //Static pickup event 
        public static event EventHandler OnPickup;

        public FireExtinguisher(int xOffset, int yOffset) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"WaterBucket";

            //Picture
            this.Image = Properties.Resources.Extinguisher;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.BringToFront();

            //Properties
            bool collected = false;
        }

        public void collect()
        {
            if (!collected)
            {
                collected = true;

                //Trigger static fire extinguisher pickup event!
                OnPickup?.Invoke(this, EventArgs.Empty);
                //Play SFX and change image
                SFX.Play(SFX.Sound.GlassBreak);
                this.Image = Properties.Resources.Extinguisher_broken;
            }
        }


    }
}
