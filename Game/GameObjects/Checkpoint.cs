using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Checkpoint : GameObjects
    {
        //Each checkpoint has a turret and a direction that the turret must have to face the checkpoint
        Turret turret;
        Turret.Direction shootingDirection;
        int xCoordinate, yCoordinate;
        int size;
        bool enabled = false;
        public Checkpoint(int xOffset, int yOffset, int Size = 40, bool levelDesignMode = false) : base(xOffset, yOffset)
        {
            this.Tag = $"Checkpoint";
            this.BackColor = System.Drawing.Color.DarkRed;
            this.Width = 40;
            this.Height = 40;
            this.Left = xOffset;
            this.Top = yOffset;
            this.size = Size;
            if (!levelDesignMode) this.Hide(); //Visualizes checkpoints as a dark red box in level design mode
        }

        /// <summary>
        /// Links a turret to the checkpoint
        /// </summary>
        /// <param name="turret">Turret to be linked</param>
        public void Link(Turret turret)
        {
            this.turret = turret;
        }

        /// <summary>
        /// Calculates the direction of the checkpoint relative to the linked turret
        /// </summary>
        /// <returns></returns>
        public Turret.Direction GetDirection(int xPosition, int yPosition)
        {
            //Same X coordinate
            if (turret.Left == xPosition)
            {
                if (yPosition > turret.Top) //higher Y? must be below!
                    return Turret.Direction.South; 
                else if (yPosition < turret.Top) //lower Y? must be above!
                    return Turret.Direction.North;
            }

            //Same Y coordinate
            else if (turret.Top == yPosition)
            {
                if (xCoordinate > turret.Left) //higher X? must be to the right!
                    return Turret.Direction.East;
                else if (xCoordinate < turret.Left) //lower X? must be to the left!
                    return Turret.Direction.West;
            }

            //Northwest
            else if (xPosition > turret.Left && yPosition > turret.Top)
            {
                return Turret.Direction.SouthEast;
            }

            //Southeast
            else if (xPosition < turret.Left && yPosition < turret.Top)
            {
                return Turret.Direction.NorthWest;
            }

            //Northeast
            else if (xPosition > turret.Left && yPosition < turret.Top)
            {
                return Turret.Direction.NorthEast;
            }

            //Soutwest
            else if (xPosition < turret.Left && yPosition > turret.Top)
            {
                return Turret.Direction.SouthWest;
            }

            throw new ArgumentException("Turret direction for checkpoint not found");
        }

        /// <summary>
        /// Triggers the checkpoint and it's linked turret
        /// </summary>
        /// <param name="engine">nessessary for turret control (bullet spawning)</param>
        /// <param name="gameObjects">nessessary for turret control (bullet spawning)</param>
        /// <param name="Resize">Resizes the checkpoint once triggered (default 100px)</param>
        public void Trigger(Engine engine, GameObjects[] gameObjects)
        {
            //Save current coordinates if triggered for the first time
            if (!enabled)
            {
                xCoordinate = this.Left;
                yCoordinate = this.Top;

                Width = size;
                Height = size;

                Left = xCoordinate - Width/2 + 20;
                Top = yCoordinate - Height / 2 + 20;

                enabled = true;
            }


            //If the turret is not facing at checkpoint, rotate it
            var shootingDirection = GetDirection(xCoordinate, yCoordinate);
            if (turret.CurrentDirection != shootingDirection)
                turret.Rotate(shootingDirection);
            else //start shooting otherwise
            {
                turret.StartShooting();
                turret.Shoot(engine, gameObjects);
            }
        }

        /// <summary>
        /// finds the closest turret relative to the checkpoint from a list
        /// </summary>
        /// <param name="turrets">turret list to search</param>
        /// <returns>instance of closest turret</returns>
        public Turret getNearestTurret(List<Turret> turrets)
        {
            //calculate distances using an array
            double[] distances = new double[turrets.Count];
            for (int i = 0; i < turrets.Count; i++) //iterate trough turrets
            {
                //Calculate x and y distance from checkpoint to turret
                int xDistance = turrets[i].Top - this.Top;
                int yDistance = turrets[i].Left - this.Left;

                //Calculate euclidean distance using the pythagorean theorem
                distances[i] = calculateEuclideanDistance(xDistance, yDistance);
            }

            //Auxiliary distance calculation function (pythagorean theorem)
            double calculateEuclideanDistance(int x, int y)
            {
                return Math.Sqrt(x * x + y * y);
            }

            //Find index of closest turret
            int indexClosestTurret = Array.IndexOf(distances, distances.Min());

            //Return closest turret
            return turrets[indexClosestTurret];
        }

    }
}
