using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Game.Engine_Releated
{
    static class MenueManager
    {

        public static void ManageMenues(Engine engine)
        {
            if (engine.escapeMenu.exitClicked == true || engine.deathScreen.exitClicked == true || engine.winningScreen.exitClicked == true)
            {
                engine.Close();
            }
            if (engine.deathScreen.restartClicked == true || engine.winningScreen.restartClicked == true)
            {
                engine.winningScreen.restartClicked = false;
                engine.deathScreen.restartClicked = false;
                engine.stage = 1;
                engine.RestartLevel(engine.stage);
                engine.Show();
            }
            if (engine.escapeMenu.restartClicked == true)                           //Restart game
            {
                engine.RestartLevel(engine.stage);
                engine.escapeMenu.restartClicked = false;
            }
            if (engine.escapeMenu.soundClicked == true)                            //Switch sound on/off
            {
                engine.ActiveControl = default;
                engine.escapeMenu.soundClicked = false;
                
            }
            if (engine.escapeMenu.graphicsClicked == true) //Reduces graphics for less stutters
            {
                if (RenderSettings.ultraHighQuality == true)
                {
                    RenderSettings.LowerGraphics(engine);
                }
                else
                {
                    RenderSettings.UpGraphics(engine);
                }
                engine.ActiveControl = default;
                engine.escapeMenu.graphicsClicked = false;
            }
        }
        
    }
}
