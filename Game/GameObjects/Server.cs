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
    class Server : InteractableObject
    {
        //State
        bool hacked;
        bool hasBadUSB;        

        public Server(int xOffset, int yOffset) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"Server";

            //Picture
            this.Image = Properties.Resources.Server;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.BringToFront();

            //Properties
            bool hacked = false;

            //Listen to Flashdrive pickup event
            Flashdrive.OnPickup += OnFlashdrivePickup;
        }

        //Action to take on flashdrive pickup event
        private void OnFlashdrivePickup(object sender, EventArgs eArgs)
        {
            //Allow hacking
            hasBadUSB = true;
        }

        /// <summary>
        /// Hacks the server
        /// </summary>
        public async void Hack()
        {
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
            }
        }

    }
}
