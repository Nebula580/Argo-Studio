namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    partial class Speed_form
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
            this.speed_textBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.acceleration_textBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deceleration_textBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ramp_textBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // speed_textBox
            // 
            this.speed_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.speed_textBox.DefaultText = "50";
            this.speed_textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.speed_textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.speed_textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.speed_textBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.speed_textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.speed_textBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.speed_textBox.ForeColor = System.Drawing.Color.Black;
            this.speed_textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.speed_textBox.Location = new System.Drawing.Point(170, 83);
            this.speed_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.speed_textBox.MaxLength = 3;
            this.speed_textBox.Name = "speed_textBox";
            this.speed_textBox.PasswordChar = '\0';
            this.speed_textBox.PlaceholderText = "";
            this.speed_textBox.SelectedText = "";
            this.speed_textBox.ShortcutsEnabled = false;
            this.speed_textBox.Size = new System.Drawing.Size(55, 30);
            this.speed_textBox.TabIndex = 0;
            this.speed_textBox.TextChanged += new System.EventHandler(this.Speed_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(116, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(228, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(228, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(75, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Acceleration";
            // 
            // acceleration_textBox
            // 
            this.acceleration_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.acceleration_textBox.DefaultText = "50";
            this.acceleration_textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.acceleration_textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.acceleration_textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.acceleration_textBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.acceleration_textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.acceleration_textBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.acceleration_textBox.ForeColor = System.Drawing.Color.Black;
            this.acceleration_textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.acceleration_textBox.Location = new System.Drawing.Point(170, 121);
            this.acceleration_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.acceleration_textBox.MaxLength = 3;
            this.acceleration_textBox.Name = "acceleration_textBox";
            this.acceleration_textBox.PasswordChar = '\0';
            this.acceleration_textBox.PlaceholderText = "";
            this.acceleration_textBox.SelectedText = "";
            this.acceleration_textBox.ShortcutsEnabled = false;
            this.acceleration_textBox.Size = new System.Drawing.Size(55, 30);
            this.acceleration_textBox.TabIndex = 3;
            this.acceleration_textBox.TextChanged += new System.EventHandler(this.Acceleration_textBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.Location = new System.Drawing.Point(228, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(73, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Deceleration";
            // 
            // deceleration_textBox
            // 
            this.deceleration_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deceleration_textBox.DefaultText = "50";
            this.deceleration_textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.deceleration_textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.deceleration_textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.deceleration_textBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.deceleration_textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.deceleration_textBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.deceleration_textBox.ForeColor = System.Drawing.Color.Black;
            this.deceleration_textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.deceleration_textBox.Location = new System.Drawing.Point(170, 159);
            this.deceleration_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deceleration_textBox.MaxLength = 3;
            this.deceleration_textBox.Name = "deceleration_textBox";
            this.deceleration_textBox.PasswordChar = '\0';
            this.deceleration_textBox.PlaceholderText = "";
            this.deceleration_textBox.SelectedText = "";
            this.deceleration_textBox.ShortcutsEnabled = false;
            this.deceleration_textBox.Size = new System.Drawing.Size(55, 30);
            this.deceleration_textBox.TabIndex = 6;
            this.deceleration_textBox.TextChanged += new System.EventHandler(this.Deceleration_textBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.Location = new System.Drawing.Point(228, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.Location = new System.Drawing.Point(119, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Ramp";
            // 
            // ramp_textBox
            // 
            this.ramp_textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ramp_textBox.DefaultText = "50";
            this.ramp_textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ramp_textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ramp_textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ramp_textBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ramp_textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ramp_textBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ramp_textBox.ForeColor = System.Drawing.Color.Black;
            this.ramp_textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ramp_textBox.Location = new System.Drawing.Point(170, 197);
            this.ramp_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ramp_textBox.MaxLength = 3;
            this.ramp_textBox.Name = "ramp_textBox";
            this.ramp_textBox.PasswordChar = '\0';
            this.ramp_textBox.PlaceholderText = "";
            this.ramp_textBox.SelectedText = "";
            this.ramp_textBox.ShortcutsEnabled = false;
            this.ramp_textBox.Size = new System.Drawing.Size(55, 30);
            this.ramp_textBox.TabIndex = 9;
            this.ramp_textBox.TextChanged += new System.EventHandler(this.Ramp_textBox_TextChanged);
            // 
            // Speed_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ramp_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deceleration_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.acceleration_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speed_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(400, 350);
            this.Name = "Speed_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox speed_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox acceleration_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox deceleration_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox ramp_textBox;
    }
}