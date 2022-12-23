namespace ArgoStudio.Main
{
    partial class CustomMessageForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Ok_btn = new Guna.UI2.WinForms.Guna2Button();
            this.No_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Yes_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Cancel_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Message_label = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ArgoStudio.Properties.Resources.BackArrowBlack;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Ok_btn
            // 
            this.Ok_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_btn.BorderColor = System.Drawing.Color.LightGray;
            this.Ok_btn.BorderRadius = 4;
            this.Ok_btn.BorderThickness = 1;
            this.Ok_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Ok_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Ok_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Ok_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Ok_btn.FillColor = System.Drawing.SystemColors.Window;
            this.Ok_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ok_btn.ForeColor = System.Drawing.Color.Black;
            this.Ok_btn.Location = new System.Drawing.Point(225, 110);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(95, 30);
            this.Ok_btn.TabIndex = 3;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // No_btn
            // 
            this.No_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.No_btn.BorderColor = System.Drawing.Color.LightGray;
            this.No_btn.BorderRadius = 4;
            this.No_btn.BorderThickness = 1;
            this.No_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.No_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.No_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.No_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.No_btn.FillColor = System.Drawing.SystemColors.Window;
            this.No_btn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.No_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.No_btn.ForeColor = System.Drawing.Color.Black;
            this.No_btn.Location = new System.Drawing.Point(124, 110);
            this.No_btn.Name = "No_btn";
            this.No_btn.Size = new System.Drawing.Size(95, 30);
            this.No_btn.TabIndex = 2;
            this.No_btn.Text = "No";
            this.No_btn.Click += new System.EventHandler(this.No_btn_Click);
            // 
            // Yes_btn
            // 
            this.Yes_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Yes_btn.BorderColor = System.Drawing.Color.LightGray;
            this.Yes_btn.BorderRadius = 4;
            this.Yes_btn.BorderThickness = 1;
            this.Yes_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Yes_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Yes_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Yes_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Yes_btn.FillColor = System.Drawing.SystemColors.Window;
            this.Yes_btn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Yes_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Yes_btn.ForeColor = System.Drawing.Color.Black;
            this.Yes_btn.Location = new System.Drawing.Point(23, 110);
            this.Yes_btn.Name = "Yes_btn";
            this.Yes_btn.Size = new System.Drawing.Size(95, 30);
            this.Yes_btn.TabIndex = 1;
            this.Yes_btn.Text = "Yes";
            this.Yes_btn.Click += new System.EventHandler(this.Yes_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_btn.BorderColor = System.Drawing.Color.LightGray;
            this.Cancel_btn.BorderRadius = 4;
            this.Cancel_btn.BorderThickness = 1;
            this.Cancel_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Cancel_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Cancel_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Cancel_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Cancel_btn.FillColor = System.Drawing.SystemColors.Window;
            this.Cancel_btn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Cancel_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Cancel_btn.ForeColor = System.Drawing.Color.Black;
            this.Cancel_btn.Location = new System.Drawing.Point(326, 110);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(95, 30);
            this.Cancel_btn.TabIndex = 4;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.Message_label);
            this.Panel1.Controls.Add(this.pictureBox1);
            this.Panel1.Location = new System.Drawing.Point(0, 23);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(452, 81);
            this.Panel1.TabIndex = 4;
            // 
            // Message_label
            // 
            this.Message_label.AutoSize = true;
            this.Message_label.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Message_label.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.Message_label.Location = new System.Drawing.Point(65, 8);
            this.Message_label.Name = "Message_label";
            this.Message_label.Size = new System.Drawing.Size(67, 20);
            this.Message_label.TabIndex = 2;
            this.Message_label.Text = "message";
            this.Message_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Message_label_LinkClicked);
            // 
            // CustomMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(452, 152);
            this.Controls.Add(this.No_btn);
            this.Controls.Add(this.Yes_btn);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CustomMessageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Resize += new System.EventHandler(this.CustomMessageForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public Guna.UI2.WinForms.Guna2Button Ok_btn;
        public Guna.UI2.WinForms.Guna2Button No_btn;
        public Guna.UI2.WinForms.Guna2Button Yes_btn;
        public Guna.UI2.WinForms.Guna2Button Cancel_btn;
        private System.Windows.Forms.LinkLabel Message_label;
    }
}