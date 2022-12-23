
namespace ArgoStudio.Main.Settings.Menus
{
    partial class Updates_form
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
            this.label3 = new System.Windows.Forms.Label();
            this.Updates_lbl = new System.Windows.Forms.Label();
            this.LastCheck_label = new System.Windows.Forms.Label();
            this.CheckForUpdates_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label3.Location = new System.Drawing.Point(255, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 30);
            this.label3.TabIndex = 329;
            this.label3.Text = "Argo Studio is up to date";
            // 
            // Updates_lbl
            // 
            this.Updates_lbl.AutoSize = true;
            this.Updates_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.Updates_lbl.Location = new System.Drawing.Point(34, 19);
            this.Updates_lbl.Name = "Updates_lbl";
            this.Updates_lbl.Size = new System.Drawing.Size(82, 25);
            this.Updates_lbl.TabIndex = 330;
            this.Updates_lbl.Text = "Updates";
            // 
            // LastCheck_label
            // 
            this.LastCheck_label.AutoSize = true;
            this.LastCheck_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastCheck_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LastCheck_label.Location = new System.Drawing.Point(285, 145);
            this.LastCheck_label.Name = "LastCheck_label";
            this.LastCheck_label.Size = new System.Drawing.Size(185, 17);
            this.LastCheck_label.TabIndex = 331;
            this.LastCheck_label.Text = "Last checked: Today, 12:00 PM";
            // 
            // CheckForUpdates_btn
            // 
            this.CheckForUpdates_btn.BorderRadius = 3;
            this.CheckForUpdates_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckForUpdates_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CheckForUpdates_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CheckForUpdates_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CheckForUpdates_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.CheckForUpdates_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CheckForUpdates_btn.ForeColor = System.Drawing.Color.White;
            this.CheckForUpdates_btn.Location = new System.Drawing.Point(312, 197);
            this.CheckForUpdates_btn.Name = "CheckForUpdates_btn";
            this.CheckForUpdates_btn.Size = new System.Drawing.Size(130, 30);
            this.CheckForUpdates_btn.TabIndex = 332;
            this.CheckForUpdates_btn.Text = "Check for updates";
            this.CheckForUpdates_btn.Click += new System.EventHandler(this.CheckForUpdates_btn_Click);
            // 
            // Updates_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.CheckForUpdates_btn);
            this.Controls.Add(this.LastCheck_label);
            this.Controls.Add(this.Updates_lbl);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Updates_form";
            this.Click += new System.EventHandler(this.Updates_form_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Updates_lbl;
        private System.Windows.Forms.Label LastCheck_label;
        private Guna.UI2.WinForms.Guna2Button CheckForUpdates_btn;
    }
}