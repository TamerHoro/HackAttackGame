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
            Text = $"{health}/{fullHealth}";
            ForeColor = Color.FromArgb(255, 255, 255);
            Location = new Point(interactable.Left + 15, interactable.Top + 50);
        }

    }
}
