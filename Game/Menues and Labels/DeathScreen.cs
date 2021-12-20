using System;
using System.Windows.Forms;
using System.Drawing;


namespace Game
{
    public class DeathScreen: Form
    {
        public Label DeathLabel = new Label();
        public Button Exit = new Button();
        public Button Restart = new Button();
        public bool exitClicked = false;
        public bool restartClicked = false;

        public DeathScreen()
        {
            Initalize();
            BackColor = Color.Black;
            Show();
            Size = new Size(new Point(720, 720));
            Controls.Add(DeathLabel);
            Controls.Add(Restart);
            Controls.Add(Exit);
            Visible = false;
        }

        public void exitClick(object sender, EventArgs e)
        {
            exitClicked = true;
            Close();
        }
        public void restartClick(object sender, EventArgs e)
        {
            Visible =  false;
            restartClicked = true;
        }

        public void Initalize()
        {
            DeathLabel.Text = "You Died!";
            DeathLabel.Size = new Size(new Point(500, 200));
            DeathLabel.ForeColor = Color.FromArgb(138, 3, 3);
            DeathLabel.Font = new Font("Chiller", 100);
            DeathLabel.BackColor = Color.Transparent;
            DeathLabel.Location = new Point(150, 100);
            DeathLabel.BringToFront();

            Restart.Text = "Restart";
            Restart.Location = new Point(310, 500);
            Restart.BringToFront();
            Restart.BackColor = Color.White;
            Restart.Click += new EventHandler(restartClick);


            Exit.Text = "Exit";
            Exit.Location = new Point(310, 600);
            Exit.BringToFront();
            Exit.BackColor = Color.White;
            Exit.Click += new EventHandler(exitClick);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DeathScreen
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "DeathScreen";
            this.Load += new System.EventHandler(this.DeathScreen_Load);
            this.ResumeLayout(false);

        }

        private void DeathScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
