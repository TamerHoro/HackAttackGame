using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Turret : Enemy
    {
        public enum Direction
        {
            North = 1,
            South = 2,
            West = 3,
            East = 4,
            NorthEast = 5,
            NorthWest = 6,
            SouthWest = 7,
            SouthEast = 8
        }
        public enum State
        {
            Idle = 0,
            Active = 1
        }

        Direction direction;
        State state;


        public Turret(int l, int h, int i, int j, Direction direction = Direction.North) : base(l, h)
        {
            this.Tag = $"Turret{i}{j}";
            this.Image = Properties.Resources.TurretIdle;
            this.state = State.Idle;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.Left = l;
            this.Top = h;
            this.BringToFront();
            this.direction = direction;
        }

        public void SelfDestruct()
        {
            this.Image = Properties.Resources.CWTurretRotN;
        }

        public void Rotate(Direction direction)
        {
            this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

    }
}
