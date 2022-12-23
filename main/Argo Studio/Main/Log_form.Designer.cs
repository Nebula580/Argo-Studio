
namespace ArgoStudio.Main
{
    partial class Log_form
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
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.AutoScroll_comboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.BtnClear = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // RichTextBox
            // 
            this.RichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox.Location = new System.Drawing.Point(10, 10);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ReadOnly = true;
            this.RichTextBox.Size = new System.Drawing.Size(764, 401);
            this.RichTextBox.TabIndex = 0;
            this.RichTextBox.Text = "";
            this.RichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // AutoScroll_comboBox
            // 
            this.AutoScroll_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoScroll_comboBox.BackColor = System.Drawing.Color.Transparent;
            this.AutoScroll_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AutoScroll_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutoScroll_comboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AutoScroll_comboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AutoScroll_comboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.AutoScroll_comboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.AutoScroll_comboBox.ItemHeight = 20;
            this.AutoScroll_comboBox.Items.AddRange(new object[] {
            "Enable autoscroll",
            "Disable autoscroll"});
            this.AutoScroll_comboBox.Location = new System.Drawing.Point(513, 426);
            this.AutoScroll_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.AutoScroll_comboBox.Name = "AutoScroll_comboBox";
            this.AutoScroll_comboBox.Size = new System.Drawing.Size(159, 26);
            this.AutoScroll_comboBox.TabIndex = 1;
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClear.BorderThickness = 1;
            this.BtnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnClear.FillColor = System.Drawing.Color.White;
            this.BtnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BtnClear.ForeColor = System.Drawing.Color.Black;
            this.BtnClear.Location = new System.Drawing.Point(676, 426);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(100, 26);
            this.BtnClear.TabIndex = 3;
            this.BtnClear.Text = "Clear";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // Log_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.AutoScroll_comboBox);
            this.Controls.Add(this.RichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Log_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Log_FormClosing);
            this.Load += new System.EventHandler(this.Log_form_Load);
            this.Shown += new System.EventHandler(this.Log_form_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.RichTextBox RichTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox AutoScroll_comboBox;
        private Guna.UI2.WinForms.Guna2Button BtnClear;
    }
}