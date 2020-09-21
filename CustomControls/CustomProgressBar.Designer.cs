namespace CustomControls
{
    partial class CustomProgressBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = new System.Windows.Forms.Label();
            this.VerticalBar1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Text
            // 
            this.Text.BackColor = System.Drawing.Color.Transparent;
            this.Text.ForeColor = System.Drawing.Color.White;
            this.Text.Location = new System.Drawing.Point(198, 0);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(60, 44);
            this.Text.TabIndex = 0;
            this.Text.Text = "0%";
            this.Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VerticalBar1
            // 
            this.VerticalBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VerticalBar1.BackColor = System.Drawing.SystemColors.Highlight;
            this.VerticalBar1.Location = new System.Drawing.Point(2, 3);
            this.VerticalBar1.Name = "VerticalBar1";
            this.VerticalBar1.Size = new System.Drawing.Size(10, 37);
            this.VerticalBar1.TabIndex = 0;
            this.VerticalBar1.Visible = false;
            // 
            // CustomProgressBar
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.VerticalBar1);
            this.Controls.Add(this.Text);
            this.Name = "CustomProgressBar";
            this.Size = new System.Drawing.Size(455, 44);
            this.Load += new System.EventHandler(this.CustomProgressBar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomProgressBar_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.Label VerticalBar1;
    }
}
