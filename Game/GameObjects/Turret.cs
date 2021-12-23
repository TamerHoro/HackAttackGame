using Game.Engine_Releated;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Turret : Enemy
    {
        public bool TestFireInProgress = false;        
        

        //Declare attributes for properties
        Direction direction;
        State state;

        //Getter and Setter for attributes
        /// <summary>
        /// Gets the current state of the turret
        /// </summary>
        public State CurrentState{ get => this.state; }

        /// <summary>
        /// Gets the direction in which the turret is currently facing
        /// </summary>
        public Direction CurrentDirection { get => this.direction; }

        

        /// <summary>
        ///Create a new turret with position, Tag, picture, direction, hp, state properties.
        /// </summary>
        /// <param name="xOffset">offset from left page border</param>
        /// <param name="yOffset">offset from top page border</param>
        /// <param name="i">First tag numbering for unique tags</param>
        /// <param name="j">Second tag numbering for unique tags</param>
        /// <param name="direction"></param>
        public Turret(int xOffset, int yOffset, int i = 0, int j = 0, Direction direction = Direction.North) : base(xOffset, yOffset)
        {
            //Position
            this.Left = xOffset;
            this.Top = yOffset;

            //Tag
            this.Tag = $"Turret{i}{j}";

            //Picture
            this.Image = Properties.Resources.TurretShootN;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Blue;
            this.BringToFront();

            //Properties
            this.direction = direction;
            this.maxHealth = 3;
            this.state = State.Idle;            
        }

        /// <summary>
        /// Turret destroys itself
        /// </summary>
        public async void SelfDestruct()
        {
            //Turrets can only explode if they're alive
            if (alive)
            {
                //Turrets die after self destruction
                this.alive = false;

                //Play SFX and animation
                SFX.Play(SFX.Sound.Explode);
                this.Image = Properties.Resources.MineExplode;

                //Wait until the animation has finished
                await Task.Delay(1500);
            }
            //Remove dead turret
            this.Dispose();

        }

        /// <summary>
        /// Turret starts firing 4 bullets in the current direction
        /// </summary>
        public void StartShooting()
        {
            //Turrets can start shooting only if they're alive and idle
            if (this.alive && this.state == State.Idle)
            {
                this.state = State.Shooting;
            }
        }

        /// <summary>
        /// Deal damage to the turret and explode if no hitpoints are left
        /// </summary>
        public void TakeDamage()
        {
            //If it has hitpoints left, reduce them
            currentHealth = currentHealth - 1;

            //if not, the turret dies
            if(currentHealth == 0)
            {
                Dispose();
            }
        }

        /// <summary>
        /// Internal method to spawn bullets in the right position and direction.
        /// </summary>
        private async void MakeBullets(Engine engine, GameObjects[] gameObjects) //Bullets need to be created in the engine class and added to the rendered object list
        {
            //Delay between spawned bullets
            int ShootDelay = 250;
            Player playerturret = engine.level.playerOne;
            
            //Try shooting 4 bullets in total
            for (short i = 1; i <= 4; i++)
			{
                //If not killed while shooting
                if (alive) 
                {
                    //Play SFX and spawn bullet
                    SFX.Play(SFX.Sound.Shoot);
                    SpawnBullet(i, playerturret).MakeBullet(engine);

                    //add lag adjusted delay
                    await Task.Delay(ShootDelay + i*100);
                } else { break; } //if killed while shooting, stop loop
			}

            //Auxiliary methods below
            //------------------------------------//

            ///Creates a bullet at the right barrel
            Bullet SpawnBullet(short barrel, Player player)
            {
                //Make a new bullet and add it to the rendered object list
                Bullet bullet = new Bullet(gameObjects, player);

                //Make the bullet fly in the right direction
                bullet.direction = this.DirectionString;

                //calculate the position of the barrel
                int left, top;
                GetBarrelPosition(barrel, out left, out top);
                
                //Set the position and return the bullet
                bullet.bulletLeft = left;
                bullet.bulletTop = top;
                return bullet;
            }

            ///Calculates the spawn location of the bullets
            void GetBarrelPosition(short barrel, out int left, out int top)
            {
                left = 0;
                top = 0;
                int offset = -20;
                switch (CurrentDirection)
                {
                    case Direction.North:
                        top = this.Top - (this.Height / 2) - offset;
                        left = this.Left + this.Width - (this.Width / 4) * barrel;
                        break;
                    case Direction.South:
                        top = this.Top + this.Height - offset;
                        left = this.Left + (this.Width / 4) * (barrel-1);
                        break;
                    case Direction.East:
                        left = this.Left + (this.Width / 2) - offset;
                        top = this.Top + (this.Height / 4) * (barrel-1);
                        break;
                    case Direction.West:
                        left = this.Left + (this.Width / 4) + offset;
                        top = this.Top + (this.Height / 4) * (barrel-1);
                        break;
                    case Direction.NorthEast:
                        left = this.Left + this.Width;
                        top = this.Top;
                        break;
                    case Direction.NorthWest:
                        left = this.Left;
                        top = this.Top;
                        break;
                    case Direction.SouthEast:
                        left = this.Left + this.Width;
                        top = this.Top + this.Height;
                        break;
                    case Direction.SouthWest:
                        left = this.Left;
                        top = this.Top + this.Height;
                        break;
                }
            }
            //------------------------------------//
        }

        /// <summary>
        /// Play the shooting animation and try to shoot 4 bullets in total
        /// </summary>
        /// <param name="engine">the current game engine where bullets will be rendered</param>
        /// <param name="gameObjects">the current game object list</param>
        public async void Shoot(Engine engine, GameObjects[] gameObjects) //Bullets need to be created in the engine class and added to the rendered object list
        {
            //Duration of the .gif shooting animation
            int AnimationTime = 2000;

            //If requirements are met (idle and alive)
            if (state == State.Shooting)
            {
                //Change to placeholder (busy) state to avoid spam
                state = State.Rotating;

                //Select the right image and animation for each direction
                Bitmap animation;
                Bitmap idle;
                GetAnimation(out animation, out idle);

                //Play shooting animation and spawn bullets
                this.Image = animation;
                MakeBullets(engine, gameObjects);
                await Task.Delay(AnimationTime);

                //If not killed while shooting, reset the image back to idle
                if (alive)
                    this.Image = idle;
                this.state = State.Idle;
            }

            //Auxiliary methods below
            //------------------------------------//
            //Returns the right image and animation for each direction

            void GetAnimation(out Bitmap animation, out Bitmap idle)
            {
                animation = null;
                idle = null;
                switch (CurrentDirection)
                {
                    case Direction.North:
                        animation = Properties.Resources.TurretShootN;
                        idle = Properties.Resources.TurretIdle;
                        break;
                    case Direction.NorthEast:
                        animation = Properties.Resources.TurretShootNE;
                        idle = Properties.Resources.TurretIdle45;
                        break;
                    case Direction.East:
                        animation = Properties.Resources.TurretShootE;
                        idle = Properties.Resources.TurretIdle;
                        idle.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case Direction.SouthEast:
                        animation = Properties.Resources.TurretShootSE;
                        idle = Properties.Resources.TurretIdle45;
                        idle.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case Direction.South:
                        animation = Properties.Resources.TurretShootS;
                        idle = Properties.Resources.TurretIdle;
                        idle.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SouthWest:
                        animation = Properties.Resources.TurretShootSW;
                        idle = Properties.Resources.TurretIdle45;
                        idle.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.West:
                        animation = Properties.Resources.TurretShootW;
                        idle = Properties.Resources.TurretIdle;
                        idle.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NorthWest:
                        animation = Properties.Resources.TurretShootNW;
                        idle = Properties.Resources.TurretIdle45;
                        idle.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    default:
                        animation = Properties.Resources.TurretShootN;
                        idle = Properties.Resources.TurretIdle;
                        break;
                }
            }
        }




        //Rotation
        //--------------------------------------------------------------------------//

        /// <summary>
        /// Rotate clockwise
        /// </summary>
        /// <param name="repeat">repeat rotation this many times</param>
        void Clockwise_Rotation(short repeat = 1)
        {
            Rotate(true, repeat);
        }

        /// <summary>
        /// Rotate counterclockwise
        /// </summary>
        /// <param name="repeat">repeat rotation this many times</param>
        void Counterclockwise_Rotation(short repeat = 1)
        {
            Rotate(false, repeat);
        }

        /// <summary>
        /// Rotate clockwise or counterclockwise
        /// </summary>
        /// <param name="clockwise">rotate clockwise?</param>
        /// <param name="repeat">repeat the rotation this many times</param>
        async void Rotate(bool clockwise, short repeat = 1)
        {
            int AnimationTime = 1500;
            if (this.state == State.Idle)
            {
                for (int i = 0; i < repeat; i++)
                {
                    if (alive)
                    {
                        //Select the right image and animation for each direction
                        Bitmap animation;
                        Bitmap idle;
                        Direction finalDirection;
                        GetAnimation(clockwise, out animation, out idle, out finalDirection);

                        //Change state
                        this.state = State.Rotating;

                        //Play SFX and animation
                        SFX.Play(SFX.Sound.Rotate);
                        this.Image = animation;
                        await Task.Delay(AnimationTime);

                        //If alive by then, change image back to idle
                        if (alive)
                            this.Image = idle;
                        this.state = State.Idle;
                        this.direction = finalDirection;
                    }
                }
            }

            
            //Auxiliary methods below
            //------------------------------------//

            /// <summary>
            /// Returns the correct rotation animation, idle picture and final direction of the turret
            /// </summary>
            /// <param name="clockwise">Rotate clockwise?</param>
            /// <param name="animation">Returns animation .gif file from resources</param>
            /// <param name="idle">Returns idle .png from resources</param>
            /// <param name="finalDirection">Returns direction after the rotation has completed</param>
            void GetAnimation(bool isClockwise, out Bitmap animation, out Bitmap idle, out Direction finalDirection)
            {
                animation = null;
                idle = null;
                finalDirection = Direction.North;
                if (isClockwise)
                {
                    switch (this.direction)
                    {
                        case Direction.North:
                            animation = Properties.Resources.CWTurretRotN;
                            idle = Properties.Resources.TurretIdle45;
                            finalDirection = Direction.NorthEast;
                            break;
                        case Direction.NorthEast:
                            animation = Properties.Resources.CWTurretRotNE;
                            idle = Properties.Resources.TurretIdle;
                            idle.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            finalDirection = Direction.East;
                            break;
                        case Direction.East:
                            animation = Properties.Resources.CWTurretRotE;
                            idle = Properties.Resources.TurretIdle45;
                            idle.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            finalDirection = Direction.SouthEast;
                            break;
                        case Direction.SouthEast:
                            animation = Properties.Resources.CWTurretRotSE;
                            idle = Properties.Resources.TurretIdle;
                            idle.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            finalDirection = Direction.South;
                            break;
                        case Direction.South:
                            animation = Properties.Resources.CWTurretRotS;
                            idle = Properties.Resources.TurretIdle45;
                            idle.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            finalDirection = Direction.SouthWest;
                            break;
                        case Direction.SouthWest:
                            animation = Properties.Resources.CWTurretRotSW;
                            idle = Properties.Resources.TurretIdle;
                            idle.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            finalDirection = Direction.West;
                            break;
                        case Direction.West:
                            animation = Properties.Resources.CWTurretRotW;
                            idle = Properties.Resources.TurretIdle45;
                            idle.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            finalDirection = Direction.NorthWest;
                            break;
                        case Direction.NorthWest:
                            animation = Properties.Resources.CWTurretRotNW;
                            idle = Properties.Resources.TurretIdle;
                            finalDirection = Direction.North;
                            break;
                        default:
                            animation = Properties.Resources.TurretShootN;
                            idle = Properties.Resources.TurretIdle;
                            finalDirection = Direction.North;
                            break;
                    }
                }
                else
                {
                    switch (this.direction)
                    {
                        case Direction.North:
                            animation = Properties.Resources.CCWTurretRotN;
                            idle = Properties.Resources.TurretIdle45;
                            idle.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            finalDirection = Direction.NorthWest;
                            break;
                        case Direction.NorthWest:
                            animation = Properties.Resources.CCWTurretRotNW;
                            idle = Properties.Resources.TurretIdle;
                            idle.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            finalDirection = Direction.West;
                            break;
                        case Direction.West:
                            animation = Properties.Resources.CCWTurretRotW;
                            idle = Properties.Resources.TurretIdle45;
                            idle.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            finalDirection = Direction.SouthWest;
                            break;
                        case Direction.SouthWest:
                            animation = Properties.Resources.CCWTurretRotSW;
                            idle = Properties.Resources.TurretIdle;
                            idle.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            finalDirection = Direction.South;
                            break;
                        case Direction.South:
                            animation = Properties.Resources.CCWTurretRotS;
                            idle = Properties.Resources.TurretIdle45;
                            idle.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            finalDirection = Direction.SouthEast;
                            break;
                        case Direction.SouthEast:
                            animation = Properties.Resources.CCWTurretRotSE;
                            idle = Properties.Resources.TurretIdle;
                            idle.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            finalDirection = Direction.East;
                            break;
                        case Direction.East:
                            animation = Properties.Resources.CCWTurretRotE;
                            idle = Properties.Resources.TurretIdle45;
                            finalDirection = Direction.NorthEast;
                            break;
                        case Direction.NorthEast:
                            animation = Properties.Resources.CCWTurretRotNE;
                            idle = Properties.Resources.TurretIdle;
                            finalDirection = Direction.North;
                            break;
                        default:
                            animation = Properties.Resources.CCWTurretRotN;
                            idle = Properties.Resources.TurretIdle;
                            finalDirection = Direction.North;
                            break;
                    }
                }
            //---------------------------------------------//
            }
        }
        public async void TestFire()
        {
            if (!TestFireInProgress)
            {
                TestFireInProgress = true;
                Rotate(Direction.South);
                await Task.Delay(7000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.West);
                await Task.Delay(4000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.SouthWest);
                await Task.Delay(2000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.NorthWest);
                await Task.Delay(4000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.SouthEast);
                await Task.Delay(7000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.East);
                await Task.Delay(2000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.NorthEast);
                await Task.Delay(2000);
                StartShooting();
                await Task.Delay(3000);

                Rotate(Direction.North);
                await Task.Delay(2000);
                StartShooting();
                await Task.Delay(4000);

                SelfDestruct();
            }
        }

        //Turrets can rotate in 8 different directions
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
        //Turrets can have 3 states
        public enum State
        {
            Idle = 0,
            Rotating = 1,
            Shooting = 2,
        }
        /// <summary>
        /// Gets the direction in which the turret is currently facing, as a string value
        /// </summary>
        public string DirectionString
        {
            get
            {
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
                    case Direction.NorthEast:
                        return "NorthEast";
                    case Direction.NorthWest:
                        return "NorthWest";
                    case Direction.SouthEast:
                        return "SouthEast";
                    case Direction.SouthWest:
                        return "SouthWest";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// Rotates the turret into the desired direction
        /// </summary>
        /// <param name="direction">desired final direction</param>
        public void Rotate(Direction direction)  //(implemented shortest path as hardcoded state machine)
        {
            if (CurrentDirection != direction)
            {
                if (CurrentDirection == Direction.North)
                {
                    switch (direction)
                    {
                        case Direction.NorthEast:
                            Clockwise_Rotation();
                            break;
                        case Direction.East:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.SouthEast:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.South:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.NorthWest:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.West:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.SouthWest:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.East)
                {
                    switch (direction)
                    {
                        case Direction.SouthEast:
                            Clockwise_Rotation();
                            break;
                        case Direction.South:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.SouthWest:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.West:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.NorthEast:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.North:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.NorthWest:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.South)
                {
                    switch (direction)
                    {
                        case Direction.SouthWest:
                            Clockwise_Rotation();
                            break;
                        case Direction.West:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.NorthWest:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.North:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.SouthEast:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.East:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.NorthEast:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.West)
                {
                    switch (direction)
                    {
                        case Direction.NorthWest:
                            Clockwise_Rotation();
                            break;
                        case Direction.North:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.NorthEast:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.East:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.SouthWest:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.South:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.SouthEast:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.NorthEast)
                {
                    switch (direction)
                    {
                        case Direction.East:
                            Clockwise_Rotation();
                            break;
                        case Direction.SouthEast:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.South:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.SouthWest:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.North:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.NorthWest:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.West:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.SouthEast)
                {
                    switch (direction)
                    {
                        case Direction.South:
                            Clockwise_Rotation();
                            break;
                        case Direction.SouthWest:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.West:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.NorthWest:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.East:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.NorthEast:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.North:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.SouthWest)
                {
                    switch (direction)
                    {
                        case Direction.West:
                            Clockwise_Rotation();
                            break;
                        case Direction.NorthWest:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.North:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.NorthEast:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.South:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.SouthEast:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.East:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

                if (CurrentDirection == Direction.NorthWest)
                {
                    switch (direction)
                    {
                        case Direction.North:
                            Clockwise_Rotation();
                            break;
                        case Direction.NorthEast:
                            Clockwise_Rotation(2);
                            break;
                        case Direction.East:
                            Clockwise_Rotation(3);
                            break;
                        case Direction.SouthEast:
                            Clockwise_Rotation(4);
                            break;
                        case Direction.West:
                            Counterclockwise_Rotation();
                            break;
                        case Direction.SouthWest:
                            Counterclockwise_Rotation(2);
                            break;
                        case Direction.South:
                            Counterclockwise_Rotation(3);
                            break;
                    }
                }

            }
        }

    }
}
