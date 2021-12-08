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
            Rotating = 1,
            Shooting = 2,
        }

        Direction direction;
        State state;

        public State CurrentState{ get => this.state; }
        public Direction CurrentDirection { get => this.direction; }
        public string DirectionString
        {
            get { 
                switch (direction)
                {
                    case Direction.North:
                        return "up";
                    case Direction.South:
                        return "down";
                    case Direction.West:
                        return "left";
                    case Direction.East:
                        return "right";
                    default: 
                        return "";
                }
            }
        }

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
            this.hitpoints = 3;
        }

        public async void SelfDestruct()
        {
            this.Image = Properties.Resources.MineExplode;
            await Task.Delay(1500);
            this.alive = false;
            this.Dispose();
        }
        public void StartShooting()
        {
            if (this.alive && this.state == State.Idle)
            {
                this.state = State.Shooting;
            }
        }

        public void TakeDamage()
        {
            if (this.hitpoints > 0)
                this.hitpoints--;
            else { SelfDestruct(); }
        }
        public async void MakeBullets(Engine engine, GameObjects[] gameObjects)
        {
            int ShootDelay = 250;
            Bullet SpawnBullet(short count)
            {
                if (count < 3) {
                    Bullet bullet = new Bullet(gameObjects);
                    bullet.direction = this.DirectionString;
                    bullet.bulletLeft = this.Left + this.Width / 2 - 30 + 10 * count;
                    bullet.bulletTop = this.Top + (this.Height / 2) + 10;
                    return bullet;
                } else
                {
                    Bullet bullet = new Bullet(gameObjects);
                    bullet.direction = this.DirectionString;
                    bullet.bulletLeft = this.Left + this.Width / 2 - 25 + 10 * count;
                    bullet.bulletTop = this.Top + (this.Height / 2) + 10;
                    return bullet;
                }
            }
            if (alive)
            { SpawnBullet(1).MakeBullet(engine); }
            await Task.Delay(ShootDelay);
            if (alive)
            { SpawnBullet(2).MakeBullet(engine); }
            await Task.Delay(ShootDelay + 100);
            if (alive)
            { SpawnBullet(3).MakeBullet(engine); }
            await Task.Delay(ShootDelay + 200);
            if (alive)
            { SpawnBullet(4).MakeBullet(engine); }
            await Task.Delay(ShootDelay + 400);
        }

        public async void Shoot(Engine engine, GameObjects[] gameObjects)
        {
            int AnimationTime = 2000;
            if (state == State.Shooting)
            {
                state = State.Rotating;
                switch (this.direction)
                {
                    case Direction.North:
                        this.Image = Properties.Resources.TurretShootN;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle;
                        this.state = State.Idle;
                        break;
                    case Direction.NorthEast:
                        this.Image = Properties.Resources.TurretShootNE;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle45;
                        this.state = State.Idle;
                        break;
                    case Direction.East:
                        this.Image = Properties.Resources.TurretShootE;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle;
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.state = State.Idle;
                        break;
                    case Direction.SouthEast:
                        this.Image = Properties.Resources.TurretShootSE;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle45;
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.state = State.Idle;
                        break;
                    case Direction.South:
                        this.Image = Properties.Resources.TurretShootS;
                        MakeBullets(engine, gameObjects);
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle;
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        this.state = State.Idle;
                        break;
                    case Direction.SouthWest:
                        this.Image = Properties.Resources.TurretShootSW;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle45;
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        this.state = State.Idle;
                        break;
                    case Direction.West:
                        this.Image = Properties.Resources.TurretShootW;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle;
                        this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        this.state = State.Idle;
                        break;
                    case Direction.NorthWest:
                        this.Image = Properties.Resources.TurretShootNW;
                        await Task.Delay(AnimationTime);
                        this.Image = Properties.Resources.TurretIdle45;
                        this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        this.state = State.Idle;
                        break;
                }
            }

        }

        //Hardcoded rotation
        async void RotateCW(short repeat = 1)
        {
            int AnimationTime = 1500;
            if (state == State.Idle) 
            {
                for (int i = 0; i < repeat; i++)
                {
                    switch (this.direction)
                    {
                        case Direction.North:
                            this.Image = Properties.Resources.CWTurretRotN;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.state = State.Idle;
                            this.direction = Direction.NorthEast;
                            break;
                        case Direction.NorthEast:
                            this.Image = Properties.Resources.CWTurretRotNE;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.East;
                            break;
                        case Direction.East:
                            this.Image = Properties.Resources.CWTurretRotE;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.SouthEast;
                            break;
                        case Direction.SouthEast:
                            this.Image = Properties.Resources.CWTurretRotSE;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.South;
                            break;
                        case Direction.South:
                            this.Image = Properties.Resources.CWTurretRotS;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.SouthWest;
                            break;
                        case Direction.SouthWest:
                            this.Image = Properties.Resources.CWTurretRotSW;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.West;
                            break;
                        case Direction.West:
                            this.Image = Properties.Resources.CWTurretRotW;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.NorthWest;
                            break;
                        case Direction.NorthWest:
                            this.Image = Properties.Resources.CWTurretRotNW;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.state = State.Idle;
                            this.direction = Direction.North;
                            break;
                    }
                }
            }
        }

        async void RotateCCW(short repeat = 1)
        {
            int AnimationTime = 1500;
            if (this.state == State.Idle)
            {
                for (int i = 0; i < repeat; i++)
                {
                    switch (this.direction)
                    {
                        case Direction.North:
                            this.Image = Properties.Resources.CCWTurretRotN;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.NorthWest;
                            break;
                        case Direction.NorthWest:
                            this.Image = Properties.Resources.CCWTurretRotNW;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.West;
                            break;
                        case Direction.West:
                            this.Image = Properties.Resources.CCWTurretRotW;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.SouthWest;
                            break;
                        case Direction.SouthWest:
                            this.Image = Properties.Resources.CCWTurretRotSW;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.South;
                            break;
                        case Direction.South:
                            this.Image = Properties.Resources.CCWTurretRotS;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.SouthEast;
                            break;
                        case Direction.SouthEast:
                            this.Image = Properties.Resources.CCWTurretRotSE;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            this.state = State.Idle;
                            this.direction = Direction.East;
                            break;
                        case Direction.East:
                            this.Image = Properties.Resources.CCWTurretRotE;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle45;
                            this.state = State.Idle;
                            this.direction = Direction.NorthEast;
                            break;
                        case Direction.NorthEast:
                            this.Image = Properties.Resources.CCWTurretRotNE;
                            this.state = State.Rotating;
                            await Task.Delay(AnimationTime);
                            this.Image = Properties.Resources.TurretIdle;
                            this.state = State.Idle;
                            this.direction = Direction.North;
                            break;
                    }
                }
            }
        }

        public async void Rotate(Direction direction)
        {
            int AnimationTime = 1500;
            if (this.state == State.Idle && this.direction != direction)
            {
                if (this.direction == Direction.North)
                {
                    switch (direction)
                    {
                        case Direction.NorthEast:
                            RotateCW();
                            break;
                        case Direction.East:
                            RotateCW(2);
                            break;
                        case Direction.SouthEast:
                            RotateCW(3);
                            break;
                        case Direction.South:
                            RotateCW(4);
                            break;
                        case Direction.NorthWest:
                            RotateCCW();
                            break;
                        case Direction.West:
                            RotateCCW(2);
                            break;
                        case Direction.SouthWest:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.East)
                {
                    switch (direction)
                    {
                        case Direction.SouthEast:
                            RotateCW();
                            break;
                        case Direction.South:
                            RotateCW(2);
                            break;
                        case Direction.SouthWest:
                            RotateCW(3);
                            break;
                        case Direction.West:
                            RotateCW(4);
                            break;
                        case Direction.NorthEast:
                            RotateCCW();
                            break;
                        case Direction.North:
                            RotateCCW(2);
                            break;
                        case Direction.NorthWest:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.South)
                {
                    switch (direction)
                    {
                        case Direction.SouthWest:
                            RotateCW();
                            break;
                        case Direction.West:
                            RotateCW(2);
                            break;
                        case Direction.NorthWest:
                            RotateCW(3);
                            break;
                        case Direction.North:
                            RotateCW(4);
                            break;
                        case Direction.SouthEast:
                            RotateCCW();
                            break;
                        case Direction.East:
                            RotateCCW(2);
                            break;
                        case Direction.NorthEast:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.West)
                {
                    switch (direction)
                    {
                        case Direction.NorthWest:
                            RotateCW();
                            break;
                        case Direction.North:
                            RotateCW(2);
                            break;
                        case Direction.NorthEast:
                            RotateCW(3);
                            break;
                        case Direction.East:
                            RotateCW(4);
                            break;
                        case Direction.SouthWest:
                            RotateCCW();
                            break;
                        case Direction.South:
                            RotateCCW(2);
                            break;
                        case Direction.SouthEast:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.NorthEast)
                {
                    switch (direction)
                    {
                        case Direction.East:
                            RotateCW();
                            break;
                        case Direction.SouthEast:
                            RotateCW(2);
                            break;
                        case Direction.South:
                            RotateCW(3);
                            break;
                        case Direction.SouthWest:
                            RotateCW(4);
                            break;
                        case Direction.North:
                            RotateCCW();
                            break;
                        case Direction.NorthWest:
                            RotateCCW(2);
                            break;
                        case Direction.West:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.SouthEast)
                {
                    switch (direction)
                    {
                        case Direction.South:
                            RotateCW();
                            break;
                        case Direction.SouthWest:
                            RotateCW(2);
                            break;
                        case Direction.West:
                            RotateCW(3);
                            break;
                        case Direction.NorthWest:
                            RotateCW(4);
                            break;
                        case Direction.East:
                            RotateCCW();
                            break;
                        case Direction.NorthEast:
                            RotateCCW(2);
                            break;
                        case Direction.North:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.SouthWest)
                {
                    switch (direction)
                    {
                        case Direction.West:
                            RotateCW();
                            break;
                        case Direction.NorthWest:
                            RotateCW(2);
                            break;
                        case Direction.North:
                            RotateCW(3);
                            break;
                        case Direction.NorthEast:
                            RotateCW(4);
                            break;
                        case Direction.South:
                            RotateCCW();
                            break;
                        case Direction.SouthEast:
                            RotateCCW(2);
                            break;
                        case Direction.East:
                            RotateCCW(3);
                            break;
                    }
                }

                if (this.direction == Direction.NorthWest)
                {
                    switch (direction)
                    {
                        case Direction.North:
                            RotateCW();
                            break;
                        case Direction.NorthEast:
                            RotateCW(2);
                            break;
                        case Direction.East:
                            RotateCW(3);
                            break;
                        case Direction.SouthEast:
                            RotateCW(4);
                            break;
                        case Direction.West:
                            RotateCCW();
                            break;
                        case Direction.SouthWest:
                            RotateCCW(2);
                            break;
                        case Direction.South:
                            RotateCCW(3);
                            break;
                    }
                }

            }
        }

    }
}
