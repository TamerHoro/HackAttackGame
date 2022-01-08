
namespace Game
{
    class Wall : StaticObject
    {
        public Wall(int l, int h, int i, int j) : base(l,h)
        {
            this.Tag = $"wall{i}{j}";
            this.Image = Properties.Resources.wall;
            this.Width = 40;
            this.Height = 40;
            this.Left = l;
            this.Top = h;
            this.BringToFront();
        }
    }
}
