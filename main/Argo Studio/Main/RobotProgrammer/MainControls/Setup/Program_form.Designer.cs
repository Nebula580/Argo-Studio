namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    partial class Program_form
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
            this.Warning_lbl = new System.Windows.Forms.Label();
            this.LoadProgram_gComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateProgram_btn = new Guna.UI2.WinForms.Guna2Button();
            this.LoadProgram_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Loaded_label = new System.Windows.Forms.Label();
            this.Next_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Delete_btn = new System.Windows.Forms.PictureBox();
            this.Import_btn = new System.Windows.Forms.PictureBox();
            this.Export_btn = new System.Windows.Forms.PictureBox();
            this.Checkmark_pictureBox = new System.Windows.Forms.PictureBox();
            this.Warning_pictureBox = new System.Windows.Forms.PictureBox();
            this.CreateProgram_gTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Import_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Export_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checkmark_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warning_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Warning_lbl
            // 
            this.Warning_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Warning_lbl.AutoSize = true;
            this.Warning_lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Warning_lbl.ForeColor = System.Drawing.Color.Red;
            this.Warning_lbl.Location = new System.Drawing.Point(199, 113);
            this.Warning_lbl.Name = "Warning_lbl";
            this.Warning_lbl.Size = new System.Drawing.Size(133, 19);
            this.Warning_lbl.TabIndex = 0;
            this.Warning_lbl.Text = "Invalid project name";
            this.Warning_lbl.Visible = false;
            // 
            // LoadProgram_gComboBox
            // 
            this.LoadProgram_gComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoadProgram_gComboBox.BackColor = System.Drawing.Color.Transparent;
            this.LoadProgram_gComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadProgram_gComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LoadProgram_gComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoadProgram_gComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LoadProgram_gComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LoadProgram_gComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LoadProgram_gComboBox.ForeColor = System.Drawing.Color.Black;
            this.LoadProgram_gComboBox.ItemHeight = 30;
            this.LoadProgram_gComboBox.Location = new System.Drawing.Point(182, 202);
            this.LoadProgram_gComboBox.Name = "LoadProgram_gComboBox";
            this.LoadProgram_gComboBox.Size = new System.Drawing.Size(215, 36);
            this.LoadProgram_gComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(185, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.TabIndex = 541;
            this.label1.Text = "Manage programs";
            // 
            // CreateProgram_btn
            // 
            this.CreateProgram_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CreateProgram_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.CreateProgram_btn.BorderRadius = 3;
            this.CreateProgram_btn.BorderThickness = 1;
            this.CreateProgram_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CreateProgram_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CreateProgram_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CreateProgram_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CreateProgram_btn.FillColor = System.Drawing.Color.White;
            this.CreateProgram_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CreateProgram_btn.ForeColor = System.Drawing.Color.Black;
            this.CreateProgram_btn.Location = new System.Drawing.Point(403, 76);
            this.CreateProgram_btn.Name = "CreateProgram_btn";
            this.CreateProgram_btn.Size = new System.Drawing.Size(140, 30);
            this.CreateProgram_btn.TabIndex = 2;
            this.CreateProgram_btn.Text = "Create program";
            // 
            // LoadProgram_btn
            // 
            this.LoadProgram_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoadProgram_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.LoadProgram_btn.BorderRadius = 3;
            this.LoadProgram_btn.BorderThickness = 1;
            this.LoadProgram_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LoadProgram_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LoadProgram_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoadProgram_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LoadProgram_btn.FillColor = System.Drawing.Color.White;
            this.LoadProgram_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LoadProgram_btn.ForeColor = System.Drawing.Color.Black;
            this.LoadProgram_btn.Location = new System.Drawing.Point(403, 205);
            this.LoadProgram_btn.Name = "LoadProgram_btn";
            this.LoadProgram_btn.Size = new System.Drawing.Size(140, 30);
            this.LoadProgram_btn.TabIndex = 4;
            this.LoadProgram_btn.Text = "Load program";
            // 
            // Loaded_label
            // 
            this.Loaded_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Loaded_label.AutoSize = true;
            this.Loaded_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loaded_label.ForeColor = System.Drawing.Color.Black;
            this.Loaded_label.Location = new System.Drawing.Point(270, 241);
            this.Loaded_label.Name = "Loaded_label";
            this.Loaded_label.Size = new System.Drawing.Size(62, 17);
            this.Loaded_label.TabIndex = 0;
            this.Loaded_label.Text = "is loaded";
            this.Loaded_label.Visible = false;
            this.Loaded_label.TextChanged += new System.EventHandler(this.Loaded_label_TextChanged);
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
            this.Next_btn.TabIndex = 556;
            this.Next_btn.Text = "Next";
            this.Next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Delete_btn.BackgroundImage = global::ArgoStudio.Properties.Resources.TrashBlack;
            this.Delete_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Delete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_btn.Enabled = false;
            this.Delete_btn.Location = new System.Drawing.Point(307, 291);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(24, 24);
            this.Delete_btn.TabIndex = 555;
            this.Delete_btn.TabStop = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Import_btn
            // 
            this.Import_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Import_btn.BackgroundImage = global::ArgoStudio.Properties.Resources.ImportBlack;
            this.Import_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Import_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Import_btn.Enabled = false;
            this.Import_btn.Location = new System.Drawing.Point(276, 291);
            this.Import_btn.Name = "Import_btn";
            this.Import_btn.Size = new System.Drawing.Size(24, 24);
            this.Import_btn.TabIndex = 554;
            this.Import_btn.TabStop = false;
            this.Import_btn.Click += new System.EventHandler(this.Import_btn_Click);
            // 
            // Export_btn
            // 
            this.Export_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Export_btn.BackgroundImage = global::ArgoStudio.Properties.Resources.ExportBlack;
            this.Export_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Export_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Export_btn.Enabled = false;
            this.Export_btn.Location = new System.Drawing.Point(245, 291);
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.Size = new System.Drawing.Size(24, 24);
            this.Export_btn.TabIndex = 553;
            this.Export_btn.TabStop = false;
            this.Export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // Checkmark_pictureBox
            // 
            this.Checkmark_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Checkmark_pictureBox.Image = global::ArgoStudio.Properties.Resources.CheckMark;
            this.Checkmark_pictureBox.Location = new System.Drawing.Point(347, 241);
            this.Checkmark_pictureBox.Name = "Checkmark_pictureBox";
            this.Checkmark_pictureBox.Size = new System.Drawing.Size(20, 20);
            this.Checkmark_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Checkmark_pictureBox.TabIndex = 551;
            this.Checkmark_pictureBox.TabStop = false;
            this.Checkmark_pictureBox.Visible = false;
            // 
            // Warning_pictureBox
            // 
            this.Warning_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Warning_pictureBox.Image = global::ArgoStudio.Properties.Resources.Warning;
            this.Warning_pictureBox.Location = new System.Drawing.Point(182, 115);
            this.Warning_pictureBox.Name = "Warning_pictureBox";
            this.Warning_pictureBox.Size = new System.Drawing.Size(15, 15);
            this.Warning_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Warning_pictureBox.TabIndex = 2;
            this.Warning_pictureBox.TabStop = false;
            this.Warning_pictureBox.Visible = false;
            // 
            // CreateProgram_gTextBox
            // 
            this.CreateProgram_gTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CreateProgram_gTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CreateProgram_gTextBox.DefaultText = "";
            this.CreateProgram_gTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CreateProgram_gTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CreateProgram_gTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CreateProgram_gTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CreateProgram_gTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CreateProgram_gTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CreateProgram_gTextBox.ForeColor = System.Drawing.Color.Black;
            this.CreateProgram_gTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CreateProgram_gTextBox.Location = new System.Drawing.Point(182, 73);
            this.CreateProgram_gTextBox.Name = "CreateProgram_gTextBox";
            this.CreateProgram_gTextBox.PasswordChar = '\0';
            this.CreateProgram_gTextBox.PlaceholderText = "Program name";
            this.CreateProgram_gTextBox.SelectedText = "";
            this.CreateProgram_gTextBox.Size = new System.Drawing.Size(215, 36);
            this.CreateProgram_gTextBox.TabIndex = 1;
            this.CreateProgram_gTextBox.TextChanged += new System.EventHandler(this.OnlyAllowNumbersAndLettersInCreateProgramTextBox);
            this.CreateProgram_gTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateProgram_gTextBox_KeyDown);
            // 
            // Program_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(724, 431);
            this.Controls.Add(this.CreateProgram_gTextBox);
            this.Controls.Add(this.Next_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Import_btn);
            this.Controls.Add(this.Export_btn);
            this.Controls.Add(this.Checkmark_pictureBox);
            this.Controls.Add(this.Loaded_label);
            this.Controls.Add(this.LoadProgram_btn);
            this.Controls.Add(this.CreateProgram_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadProgram_gComboBox);
            this.Controls.Add(this.Warning_lbl);
            this.Controls.Add(this.Warning_pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Program_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage programs";
            ((System.ComponentModel.ISupportInitialize)(this.Delete_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Import_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Export_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checkmark_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warning_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Warning_pictureBox;
        public System.Windows.Forms.Label Warning_lbl;
        public Guna.UI2.WinForms.Guna2ComboBox LoadProgram_gComboBox;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button CreateProgram_btn;
        private Guna.UI2.WinForms.Guna2Button LoadProgram_btn;
        public System.Windows.Forms.Label Loaded_label;
        private System.Windows.Forms.PictureBox Checkmark_pictureBox;
        private System.Windows.Forms.PictureBox Delete_btn;
        public Guna.UI2.WinForms.Guna2Button Next_btn;
        public System.Windows.Forms.PictureBox Export_btn;
        public System.Windows.Forms.PictureBox Import_btn;
        public Guna.UI2.WinForms.Guna2TextBox CreateProgram_gTextBox;
    }
}