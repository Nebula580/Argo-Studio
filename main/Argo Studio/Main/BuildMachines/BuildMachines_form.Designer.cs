
namespace ArgoStudio.Main.BuildMachines
{
    partial class BuildMachines_form
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
            this.components = new System.ComponentModel.Container();
            this.Back_panel = new System.Windows.Forms.Panel();
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.MouseTimer = new System.Windows.Forms.Timer(this.components);
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Back_panel
            // 
            this.Back_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Back_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back_panel.Location = new System.Drawing.Point(0, 0);
            this.Back_panel.Name = "Back_panel";
            this.Back_panel.Size = new System.Drawing.Size(1620, 782);
            this.Back_panel.TabIndex = 311;
            this.Back_panel.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.Back_panel);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1620, 782);
            this.MainPanel.TabIndex = 370;
            // 
            // MouseTimer
            // 
            this.MouseTimer.Enabled = true;
            this.MouseTimer.Interval = 1;
            // 
            // BuildMachines_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 779);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuildMachines_form";
            this.Text = "BuildMachines";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer MouseTimer;
        private System.Windows.Forms.Panel Back_panel;
        internal Guna.UI2.WinForms.Guna2Panel MainPanel;
    }
}