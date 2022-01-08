namespace Game
{
    static class LevelManager
    {
        public static Render CreateLevel(int stage)
        {
            switch (stage)
            {
                case 1: return new Render(1);
                case 2: return new Render(2);
                case 3: return new Render(3);
                default: return new Render(0);
            } 
        }
    }
}
