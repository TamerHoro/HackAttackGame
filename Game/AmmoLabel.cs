using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    class AmmoLabel: Label
    {
        public AmmoLabel()
        {
            Size = new Size(new Point(50, 16));
            new Font("Arial", 16);
            Text = "Ammo: 5";
            Location = new Point(650, 3);
            ForeColor = Color.White;
            BackColor = Color.Black;
        }

        public void UpdateAmmo(Player player)
        {
            Text = $"Ammo: {player.ammo}";
            BringToFront();
        }
    }
}
