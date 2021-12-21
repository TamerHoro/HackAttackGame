using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using Game.Engine_Releated;

namespace Game
{
    class Firewall : InteractableObject
    {
        //State
        static bool hasBucket;        

        public Firewall(int xOffset, int yOffset) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"Firewall";

            //Picture
            this.Image = Properties.Resources.Firewall;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.BringToFront();

            //Properties
            //bool hacked = false;

            //Listen to Flashdrive pickup event
            WaterBucket.OnPickup += OnBucketPickup;
        }
        
        //Action to take on flashdrive pickup event
        private void OnBucketPickup(object sender, EventArgs eArgs)
        {
            //Allow hacking
            hasBucket = true;
        }

        /// <summary>
        /// Hacks the server
        /// </summary>
        public async void Extinguish()
        {/*
            //Server can only be hacked once using the bad USB
            if (!hacked && hasBadUSB)
            {
                //Change image, state and play SFX
                hacked = true;
                this.Image = Properties.Resources.Hacked_Server;
                for (int i = 0; i < 3; i++)
                {
                    SFX.Play(SFX.Sound.Hack);
                    await Task.Delay(1000);
                }
            }*/
        }
    
    }
}
