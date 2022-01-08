using System.Windows.Forms;
using System.Drawing;

namespace Game.Engine_Releated
{
    static class RenderSettings
    {
        public static bool ultraHighQuality = true;
        public static bool lowered = false;        

        public static void LowerGraphics(Engine engine)
        {
            foreach (var item in engine.level.objectArray)
            {
                if (item is PictureBox)
                    item.BackColor = Color.Gray;

                if (item is Firewall)
                    item.Image = Properties.Resources.FirewallStatic;
            }
            RenderSettings.ultraHighQuality = false;
            RenderSettings.lowered = true;
        }
        public static void UpGraphics(Engine engine)
        {
            foreach (var item in engine.level.objectArray)
            {
                if (item is PictureBox)
                    item.BackColor = Color.Transparent;

                if (item is Firewall)
                    item.Image = Properties.Resources.Firewallgif;
            }
            RenderSettings.ultraHighQuality = true;
            RenderSettings.lowered = false;
        }
    }
}
