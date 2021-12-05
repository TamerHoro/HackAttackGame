using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainMenue start = new MainMenue();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Engine game = new Engine();
            Application.Run(start);
            if(start.start == true)
            {
                Application.Exit();
                Application.Run(game);
                if (game.restart == true)
                {                    
                    Application.Exit();
                    game = new Engine();
                    Application.Run(game);
                }
            }
            

        }
    }
}
