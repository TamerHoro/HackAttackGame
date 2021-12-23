using Game.Engine_Releated;
using System;
using System.Windows.Forms;

namespace Game
{
    public partial class MainMenue : Form
    {
        bool _start = false;
        public bool sound=true;
        public bool start { get=> _start; private set => _start = value; }
        public MainMenue()
        {
            InitializeComponent();
            
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            this.Close();
            start = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void soundButton_Click(object sender, EventArgs e)
        {
            //Toggle SFX
            SFX.enabled = !SFX.enabled;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
