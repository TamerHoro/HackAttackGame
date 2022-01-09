using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    class AmmoLabel: Label
    {
        public AmmoLabel()
        {
            Size = new Size(new Point(50, 26));
            new Font("Arial", 16);
            Location = new Point(660, 0);
            ForeColor = Color.White;
            BackColor = Color.Black;
        }

        // Label shows the remaining bullets and reloads
        public void UpdateAmmo(Player player)
        {
            Text = $"Ammo: {player.ammo}     Reload:{player.reload}";
            BringToFront();
        }
    }
}
