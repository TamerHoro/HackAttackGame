using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class Watchdog : Enemy
    {
        public int speed = 5;
        public bool goLeft, goRight, goUp, goDown;

        public Watchdog(int xOffset, int yOffset, int i = 0, int j = 0, int k = 0)
            : base(xOffset, yOffset)
        {
            BackColor = Color.DimGray;
            SizeMode = PictureBoxSizeMode.AutoSize;
            if (k == 0)
            {
                goLeft = true;
                Image = Properties.Resources.watchdogleft;
            }
            else
            {
                goUp = true;
                Image = Properties.Resources.watchdogup;
            }
        }

        public static void Walk(List<Watchdog> watchdogs)
        {
            for (int i = 0; i < watchdogs.Count; i++)
            {
                if (watchdogs[i].goLeft)
                {
                    watchdogs[i].Left -= watchdogs[i].speed;
                }
                else if (watchdogs[i].goRight)
                {
                    watchdogs[i].Left += watchdogs[i].speed;
                }
                else if (watchdogs[i].goUp)
                {
                    watchdogs[i].Top -= watchdogs[i].speed;
                }
                else if (watchdogs[i].goDown)
                {
                    watchdogs[i].Top += watchdogs[i].speed;
                }
            }
        }

        public static void Turn(List<Watchdog> watchdogs, GameObjects[] gameobjects)
        {
            for (int i = 0; i < watchdogs.Count; i++)
            {
                for (int k = 0; k < gameobjects.Length; k++)
                {
                    if (gameobjects[k] is Wall)
                    {
                        if (watchdogs[i].Bounds.IntersectsWith(gameobjects[k].Bounds))
                        {
                            if (watchdogs[i].goUp)
                            {
                                watchdogs[i].goUp = false;
                                watchdogs[i].goDown = true;
                                watchdogs[i].Image = Properties.Resources.watchdogdown;
                            }
                            else if (watchdogs[i].goDown)
                            {
                                watchdogs[i].goDown = false;
                                watchdogs[i].goUp = true;
                                watchdogs[i].Image = Properties.Resources.watchdogup;
                            }
                            else if (watchdogs[i].goLeft)
                            {
                                watchdogs[i].goLeft = false;
                                watchdogs[i].goRight = true;
                                watchdogs[i].Image = Properties.Resources.watchdogright;
                            }
                            else if (watchdogs[i].goRight)
                            {
                                watchdogs[i].goRight = false;
                                watchdogs[i].goLeft = true;
                                watchdogs[i].Image = Properties.Resources.watchdogleft;
                            }
                        }
                    }
                }
            }
        }
    }
}
