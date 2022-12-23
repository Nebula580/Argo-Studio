namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    partial class Setup_form
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
            this.FormBack_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // FormBack_panel
            // 
            this.FormBack_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.FormBack_panel.BorderColor = System.Drawing.Color.Black;
            this.FormBack_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBack_panel.Location = new System.Drawing.Point(0, 0);
            this.FormBack_panel.Margin = new System.Windows.Forms.Padding(0);
            this.FormBack_panel.Name = "FormBack_panel";
            this.FormBack_panel.Size = new System.Drawing.Size(854, 541);
            this.FormBack_panel.TabIndex = 177;
            // 
            // Setup_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 541);
            this.Controls.Add(this.FormBack_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Setup_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setup_form_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel FormBack_panel;
    }
}