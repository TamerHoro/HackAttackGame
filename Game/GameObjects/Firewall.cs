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
        static bool hasExtinguisher;        

        public Firewall(int xOffset, int yOffset) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"Firewall";

            //Picture
            this.Image = Properties.Resources.Firewallgif;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.BringToFront();

            //Properties
            //bool hacked = false;

            //Listen to Flashdrive pickup event
            FireExtinguisher.OnPickup += OnBucketPickup;
        }
        
        //Action to take on flashdrive pickup event
        private void OnBucketPickup(object sender, EventArgs eArgs)
        {
            //Allow removal
            hasExtinguisher = true;
        }

        /// <summary>
        /// Fights the fire(wall)
        /// </summary>
        /// <returns>true if successful, false if not</returns>
        public bool Fight()
        {
            //Fire can only be fought with the extinguisher
            if (hasExtinguisher)
            {
                //Change image, state and play SFX
                hasExtinguisher = true;
                SFX.Play(SFX.Sound.Extinguish);
                return true;
            }
            else return false;
        }
    
    }
}
