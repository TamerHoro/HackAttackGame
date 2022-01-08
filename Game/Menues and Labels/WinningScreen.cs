using System;
using System.Windows.Forms;
using System.Drawing;


namespace Game
{
    public class WinningScreen : Form
    {
        public Label WinLabel = new Label();
        public Button Exit = new Button();
        public Button Restart = new Button();
        public bool exitClicked = false;
        public bool restartClicked = false;

        public WinningScreen()
        {
            Initalize();
            BackColor = Color.Black;
            Show();
            Size = new Size(new Point(720, 720));
            Controls.Add(WinLabel);
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
            Visible = false;
            restartClicked = true;
        }

        public void Initalize()
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            WinLabel.Text = "You Won!";
            WinLabel.Size = new Size(new Point(700, 200));
            WinLabel.ForeColor = Color.LimeGreen;
            WinLabel.Font = new Font("Rockwell Extra Bold", 70);
            WinLabel.BackColor = Color.Transparent;
            WinLabel.Location = new Point(60, 100);
            WinLabel.BringToFront();

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
            // WinningScreen
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "WinningScreen";
            this.Load += new System.EventHandler(this.WinningScreen_Load);
            this.ResumeLayout(false);

        }

        private void WinningScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
