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
    class Flashdrive : StaticObject
    {
        bool collected;
        public bool Collected { get => collected; }

        //Static pickup event 
        public static event EventHandler OnPickup;

        public Flashdrive(int xOffset, int yOffset) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"Flashdrive";

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

                //Trigger static flashdrive pickup event!
                OnPickup?.Invoke(this, EventArgs.Empty);
            }
        }


    }
}
