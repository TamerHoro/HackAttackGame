using System.Drawing;

namespace Game
{
    class HealthLabelPlayer: HealthLabel
    {
        public HealthLabelPlayer(Player player)
            : base(player)
        {

        }

        public void update(Player player)
        {
            if (player.goDown)
            {
                Location = new Point(player.Left + 15, player.Top - 15);
            }
            else if(player.goUp)
            {
                Location = new Point(player.Left + 15, player.Top + 50);
            }
            else if (player.goLeft)
            {
                Location = new Point(player.Left + 60, player.Top + 20);
            }
            else if (player.goRight)
            {
                Location = new Point(player.Left - 20, player.Top + 20);
            }
        }

    }
}
