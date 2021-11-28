using System;
using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    class HealthLabel: Label
    {
        public InteractableObject interactable;
        public int fullHealth;
        public int health;

        public HealthLabel(InteractableObject interactable)
        {
            this.interactable = interactable;
            fullHealth = interactable.Health;
            health = interactable.Health;
            this.Text = $"{health}/{fullHealth}";
            this.ForeColor = Color.FromArgb(255, 255, 255);
            this.Location = new Point(interactable.Left + 20, interactable.Top + 100);
        }

        public void update()
        {
            health = interactable.Health;
            Text = $"{health}/{fullHealth}";
            Location = new Point(interactable.Left + 20, interactable.Top + 100);
        }
    }
}
