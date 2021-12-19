using System.Windows.Forms;
using System.Drawing;

namespace Game
{

    public class HealthLabel : Label
    {
        public InteractableObject interactable;
        public int maxHealth;
        public int currenthealth;

        public HealthLabel(InteractableObject interactable)
        {
            this.interactable = interactable;
            this.maxHealth = interactable.maxHealth;
            this.currenthealth = interactable.currentHealth;
            Text = $"{currenthealth}/{maxHealth}";
            ForeColor = Color.FromArgb(255, 255, 255);
            Location = new Point(interactable.Left + 4, interactable.Top + 15);
            BringToFront();
            Size = new Size(new Point(23, 12));
            this.BackColor = Color.Transparent;
        }

    }
}
