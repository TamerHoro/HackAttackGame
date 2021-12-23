using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    public class HealthLabelEnemy: HealthLabel
    {
        public HealthLabelEnemy(Enemy enemy)
            : base(enemy)
        {
            BringToFront();
            ForeColor = Color.White;
        }

        // Updates the Location if the enemies move 
        public static void update(List<Enemy> enemies, List<HealthLabelEnemy> healthLabels)
        {
            for (int i = 0; i<enemies.Count; i++)
            {
                //Delete the Healthlabel if the Enemy is dead
                if(enemies[i].currentHealth == 0)
                {
                    healthLabels[i].Dispose();
                }

                // Get current health update text
                healthLabels[i].Text = $"{enemies[i].currentHealth}/{enemies[i].maxHealth}";

                // set new location
                if (enemies[i] is Turret)
                {
                    var newEnemy = enemies[i] as Turret;
                    if (newEnemy.CurrentDirection == Turret.Direction.North || newEnemy.CurrentDirection == Turret.Direction.NorthWest || newEnemy.CurrentDirection == Turret.Direction.NorthEast)
                    {
                        healthLabels[i].Location = new Point(newEnemy.Left + 10, newEnemy.Top + 40);
                    }
                    else
                    {
                        healthLabels[i].Location = new Point(newEnemy.Left + 10, newEnemy.Top -40);
                    }
                }
                else
                {
                    var newEnemy = enemies[i] as Watchdog;
                    if (newEnemy.goUp)
                    {
                        healthLabels[i].Location = new Point(newEnemy.Left + 4, newEnemy.Top + 46);
                    }
                    else if (newEnemy.goDown)
                    {
                        healthLabels[i].Location = new Point(newEnemy.Left + 4, newEnemy.Top - 18);
                    }
                    else if (newEnemy.goLeft)
                    {
                        healthLabels[i].Location = new Point(newEnemy.Left + 46, newEnemy.Top + 5);
                    }
                    else
                    {
                        healthLabels[i].Location = new Point(newEnemy.Left - 24, newEnemy.Top + 5);
                    }
                }
            }
        }
    }
}
