namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    partial class ModifyCommand_form
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
            this.Save_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Cancel_btn = new Guna.UI2.WinForms.Guna2Button();
            this.panel = new System.Windows.Forms.Panel();
            this.Old_label = new System.Windows.Forms.Label();
            this.New_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save_btn
            // 
            this.Save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_btn.BackColor = System.Drawing.Color.White;
            this.Save_btn.BorderThickness = 1;
            this.Save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_btn.FillColor = System.Drawing.Color.White;
            this.Save_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_btn.ForeColor = System.Drawing.Color.Black;
            this.Save_btn.Location = new System.Drawing.Point(844, 182);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(98, 27);
            this.Save_btn.TabIndex = 2;
            this.Save_btn.Text = "Save";
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_btn.BackColor = System.Drawing.Color.White;
            this.Cancel_btn.BorderThickness = 1;
            this.Cancel_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel_btn.FillColor = System.Drawing.Color.White;
            this.Cancel_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_btn.ForeColor = System.Drawing.Color.Black;
            this.Cancel_btn.Location = new System.Drawing.Point(740, 182);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(98, 27);
            this.Cancel_btn.TabIndex = 1;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel.Location = new System.Drawing.Point(20, 41);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(932, 87);
            this.panel.TabIndex = 183;
            // 
            // Old_label
            // 
            this.Old_label.AutoSize = true;
            this.Old_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Old_label.Location = new System.Drawing.Point(89, 13);
            this.Old_label.Name = "Old_label";
            this.Old_label.Size = new System.Drawing.Size(52, 21);
            this.Old_label.TabIndex = 184;
            this.Old_label.Text = "label1";
            // 
            // New_label
            // 
            this.New_label.AutoSize = true;
            this.New_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.New_label.Location = new System.Drawing.Point(89, 141);
            this.New_label.Name = "New_label";
            this.New_label.Size = new System.Drawing.Size(52, 21);
            this.New_label.TabIndex = 185;
            this.New_label.Text = "label1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 186;
            this.label1.Text = "Current:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 187;
            this.label2.Text = "New:";
            // 
            // ModifyCommand_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(954, 221);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.New_label);
            this.Controls.Add(this.Old_label);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Save_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(970, 260);
            this.Name = "ModifyCommand_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify command";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button Save_btn;
        private Guna.UI2.WinForms.Guna2Button Cancel_btn;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label Old_label;
        private System.Windows.Forms.Label New_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}