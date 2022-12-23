namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    partial class ConnectRobot_form
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
            this.COMPort_comboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Label67 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Connect_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Connected_label = new System.Windows.Forms.Label();
            this.GetPorts_timer = new System.Windows.Forms.Timer(this.components);
            this.Next_btn = new Guna.UI2.WinForms.Guna2Button();
            this.TroubleConnecting_label = new System.Windows.Forms.Label();
            this.CheckMark_picture = new System.Windows.Forms.PictureBox();
            this.ConnectAutomatically_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CheckMark_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // COMPort_comboBox
            // 
            this.COMPort_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.COMPort_comboBox.BackColor = System.Drawing.Color.Transparent;
            this.COMPort_comboBox.BorderColor = System.Drawing.Color.Gray;
            this.COMPort_comboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.COMPort_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.COMPort_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMPort_comboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.COMPort_comboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.COMPort_comboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.COMPort_comboBox.ForeColor = System.Drawing.Color.Black;
            this.COMPort_comboBox.ItemHeight = 24;
            this.COMPort_comboBox.Location = new System.Drawing.Point(209, 129);
            this.COMPort_comboBox.MaxDropDownItems = 12;
            this.COMPort_comboBox.Name = "COMPort_comboBox";
            this.COMPort_comboBox.Size = new System.Drawing.Size(200, 30);
            this.COMPort_comboBox.TabIndex = 1;
            this.COMPort_comboBox.SelectedIndexChanged += new System.EventHandler(this.COMPort_ComboBox_SelectedIndexChanged);
            // 
            // Label67
            // 
            this.Label67.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label67.AutoSize = true;
            this.Label67.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Label67.Location = new System.Drawing.Point(208, 100);
            this.Label67.Name = "Label67";
            this.Label67.Size = new System.Drawing.Size(50, 20);
            this.Label67.TabIndex = 0;
            this.Label67.Text = "Robot";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 32);
            this.label1.TabIndex = 540;
            this.label1.Text = "Connect an Argo robot";
            // 
            // Connect_btn
            // 
            this.Connect_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Connect_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.Connect_btn.BorderRadius = 3;
            this.Connect_btn.BorderThickness = 1;
            this.Connect_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Connect_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Connect_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Connect_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Connect_btn.FillColor = System.Drawing.Color.White;
            this.Connect_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Connect_btn.ForeColor = System.Drawing.Color.Black;
            this.Connect_btn.Location = new System.Drawing.Point(415, 129);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(101, 30);
            this.Connect_btn.TabIndex = 2;
            this.Connect_btn.Text = "Connect";
            this.Connect_btn.Click += new System.EventHandler(this.Connect_btn_Click);
            // 
            // Connected_label
            // 
            this.Connected_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Connected_label.AutoSize = true;
            this.Connected_label.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Connected_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Connected_label.Location = new System.Drawing.Point(231, 162);
            this.Connected_label.Name = "Connected_label";
            this.Connected_label.Size = new System.Drawing.Size(92, 19);
            this.Connected_label.TabIndex = 0;
            this.Connected_label.Text = "Connected to";
            this.Connected_label.Visible = false;
            // 
            // GetPorts_timer
            // 
            this.GetPorts_timer.Enabled = true;
            this.GetPorts_timer.Interval = 1000;
            this.GetPorts_timer.Tick += new System.EventHandler(this.GetPorts_timer_Tick);
            // 
            // Next_btn
            // 
            this.Next_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Next_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.Next_btn.BorderRadius = 3;
            this.Next_btn.BorderThickness = 1;
            this.Next_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Next_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Next_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Next_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Next_btn.Enabled = false;
            this.Next_btn.FillColor = System.Drawing.Color.White;
            this.Next_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Next_btn.ForeColor = System.Drawing.Color.Black;
            this.Next_btn.Location = new System.Drawing.Point(611, 389);
            this.Next_btn.Name = "Next_btn";
            this.Next_btn.Size = new System.Drawing.Size(101, 30);
            this.Next_btn.TabIndex = 542;
            this.Next_btn.Text = "Next";
            this.Next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            // 
            // TroubleConnecting_label
            // 
            this.TroubleConnecting_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TroubleConnecting_label.AutoSize = true;
            this.TroubleConnecting_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TroubleConnecting_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.TroubleConnecting_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TroubleConnecting_label.Location = new System.Drawing.Point(266, 198);
            this.TroubleConnecting_label.Name = "TroubleConnecting_label";
            this.TroubleConnecting_label.Size = new System.Drawing.Size(131, 19);
            this.TroubleConnecting_label.TabIndex = 543;
            this.TroubleConnecting_label.Text = "Trouble connecting?";
            this.TroubleConnecting_label.Click += new System.EventHandler(this.TroubleConnecting_label_Click);
            // 
            // CheckMark_picture
            // 
            this.CheckMark_picture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CheckMark_picture.BackgroundImage = global::ArgoStudio.Properties.Resources.CheckMark;
            this.CheckMark_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckMark_picture.Location = new System.Drawing.Point(209, 161);
            this.CheckMark_picture.Name = "CheckMark_picture";
            this.CheckMark_picture.Size = new System.Drawing.Size(20, 20);
            this.CheckMark_picture.TabIndex = 541;
            this.CheckMark_picture.TabStop = false;
            this.CheckMark_picture.Visible = false;
            // 
            // ConnectAutomatically_timer
            // 
            this.ConnectAutomatically_timer.Enabled = true;
            this.ConnectAutomatically_timer.Interval = 500;
            this.ConnectAutomatically_timer.Tick += new System.EventHandler(this.ConnectAutomatically_timer_Tick);
            // 
            // ConnectRobot_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(724, 431);
            this.Controls.Add(this.TroubleConnecting_label);
            this.Controls.Add(this.Next_btn);
            this.Controls.Add(this.CheckMark_picture);
            this.Controls.Add(this.Connected_label);
            this.Controls.Add(this.Connect_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.COMPort_comboBox);
            this.Controls.Add(this.Label67);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(550, 350);
            this.Name = "ConnectRobot_form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.ConnectRobot_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CheckMark_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox COMPort_comboBox;
        private System.Windows.Forms.Label Label67;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label Connected_label;
        public System.Windows.Forms.PictureBox CheckMark_picture;
        public Guna.UI2.WinForms.Guna2Button Connect_btn;
        public Guna.UI2.WinForms.Guna2Button Next_btn;
        public System.Windows.Forms.Label TroubleConnecting_label;
        public System.Windows.Forms.Timer GetPorts_timer;
        private System.Windows.Forms.Timer ConnectAutomatically_timer;
    }
}