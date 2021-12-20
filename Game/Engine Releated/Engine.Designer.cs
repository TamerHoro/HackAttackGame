

namespace Game
{
    partial class Engine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DoubleBuffered = true;
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);           
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::Game.Properties.Resources.floor;
            this.ClientSize = new System.Drawing.Size(720, 720);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Engine";
            this.Text = "Engine";
            this.Load += new System.EventHandler(this.Engine_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(level.playerOne.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(level.playerOne.KeyIsUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(escapeMenu.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(escapeMenu.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(level.playerOne)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        
        //private System.Windows.Forms.PictureBox player;
        //private System.Windows.Forms.ProgressBar healthbar;

    }
}

