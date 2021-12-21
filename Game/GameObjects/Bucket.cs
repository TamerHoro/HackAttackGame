using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Game
{
    class WaterBucket : StaticObject
    {
        bool collected;
        public bool Collected { get => collected; }

        //Static pickup event 
        public static event EventHandler OnPickup;

        public WaterBucket(int xOffset, int yOffset) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"WaterBucket";

            //Picture
            this.Image = Properties.Resources.flashdrive;
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

                //Trigger static waterbucket pickup event!
                OnPickup?.Invoke(this, EventArgs.Empty);
            }
        }


    }
}
