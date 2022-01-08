
namespace Game
{
    public class Enemy : InteractableObject
    {
        //Attributes, every enemy must be alive or dead and have hitpoints
        protected bool alive;
        //short maxHealth;
       

        //Getter for the alive attribute
        public bool IsAlive { get => alive; }

        //constructor, every enemy must have coordinates
        public Enemy(int left, int top) : base(left, top)
        {
            //Enemy is alive by default
            alive = true;
        }
    }
}
