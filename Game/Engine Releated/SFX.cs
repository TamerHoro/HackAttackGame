using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game.Engine_Releated
{
    public static class SFX
    {
        //Sound effects enabled
        public static bool enabled = true;
       
        //Load sounds
        static SoundPlayer Explosion = new SoundPlayer(Properties.Resources.Explosion);
        static SoundPlayer Rotation = new SoundPlayer(Properties.Resources.Rotate);
        static SoundPlayer Shot = new SoundPlayer(Properties.Resources.Shot);
        static SoundPlayer Hit = new SoundPlayer(Properties.Resources.PlayerHit);
        static SystemSound Hack = SystemSounds.Beep;

        //Sound names
        public enum Sound { Explode = 1, Rotate = 2, Shoot = 3, Death = 4, Hack = 5  }


        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="sfx">Desired sound effect</param>
        public static void Play(Sound sfx)
        {
            SoundPlayer sound = new SoundPlayer();

            //Choose the right SFX from list
            switch (sfx)
            {
                case Sound.Explode:
                    sound = Explosion;
                    break;
                case Sound.Rotate:
                    sound = Rotation;
                    break;
                case Sound.Shoot:
                    sound = Shot;
                    break;
                case Sound.Death:
                    sound = Hit;
                    break;
                case Sound.Hack: //Play Hacksound directly
                    if (enabled)
                        Hack.Play();
                    break;
                default:
                    break;
            }

            //Play chosen SFX if they're enabled
            if (enabled)
            {
                sound.Play();
            }
        }

    }
}
