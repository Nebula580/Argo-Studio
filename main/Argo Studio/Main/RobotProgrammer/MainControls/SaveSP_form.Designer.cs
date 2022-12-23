namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    partial class SaveSP_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.SP_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save the current position of the robot arm to an SP";
            // 
            // SP_ComboBox
            // 
            this.SP_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.SP_ComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SP_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SP_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SP_ComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SP_ComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SP_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SP_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.SP_ComboBox.ItemHeight = 30;
            this.SP_ComboBox.Items.AddRange(new object[] {
            "SP 1",
            "SP 2",
            "SP 3",
            "SP 4",
            "SP 5",
            "SP 6",
            "SP 7",
            "SP 8",
            "SP 9",
            "SP 10",
            "SP 11",
            "SP 12",
            "SP 13",
            "SP 14",
            "SP 15",
            "SP 16"});
            this.SP_ComboBox.Location = new System.Drawing.Point(165, 81);
            this.SP_ComboBox.Name = "SP_ComboBox";
            this.SP_ComboBox.Size = new System.Drawing.Size(180, 36);
            this.SP_ComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "SP";
            // 
            // Save_btn
            // 
            this.Save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Save_btn.Location = new System.Drawing.Point(352, 84);
            this.Save_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(89, 30);
            this.Save_btn.TabIndex = 2;
            this.Save_btn.Text = "Save";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // SaveSP_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(564, 161);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SP_ComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(580, 200);
            this.Name = "SaveSP_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save SP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox SP_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save_btn;
    }
}