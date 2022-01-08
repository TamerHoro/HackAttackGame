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
        static SoundPlayer Taunt = new SoundPlayer(Properties.Resources.USBCollect);
        static SoundPlayer EmergencyGlassBreaking = new SoundPlayer(Properties.Resources.EmergencyGlassBreaking);
        static SoundPlayer Extinguish = new SoundPlayer(Properties.Resources.Extinguish);
        static SystemSound Hack = SystemSounds.Beep;

        //Sound names
        public enum Sound { Explode = 1, Rotate = 2, Shoot = 3, Death = 4, Hack = 5, Extinguish = 6, GlassBreak = 7, Taunt = 8  }


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
                case Sound.Extinguish:
                    sound = Extinguish;
                    break;
                case Sound.GlassBreak:
                    sound = EmergencyGlassBreaking;
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
                case Sound.Taunt:
                    sound = Taunt;
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
