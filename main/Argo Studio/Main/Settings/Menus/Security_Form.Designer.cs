
namespace ArgoStudio.Main.Settings.Menus
{
    partial class Security_form
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
            this.Security_lbl = new System.Windows.Forms.Label();
            this.AutofillUsername_checkBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.AlwaysKeepMeSignedIn_checkBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SuspendLayout();
            // 
            // Security_lbl
            // 
            this.Security_lbl.AutoSize = true;
            this.Security_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.Security_lbl.Location = new System.Drawing.Point(34, 19);
            this.Security_lbl.Name = "Security_lbl";
            this.Security_lbl.Size = new System.Drawing.Size(81, 25);
            this.Security_lbl.TabIndex = 326;
            this.Security_lbl.Text = "Security";
            // 
            // AutofillUsername_checkBox
            // 
            this.AutofillUsername_checkBox.Animated = true;
            this.AutofillUsername_checkBox.AutoSize = true;
            this.AutofillUsername_checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(207)))));
            this.AutofillUsername_checkBox.CheckedState.BorderRadius = 0;
            this.AutofillUsername_checkBox.CheckedState.BorderThickness = 0;
            this.AutofillUsername_checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(207)))));
            this.AutofillUsername_checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutofillUsername_checkBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutofillUsername_checkBox.Location = new System.Drawing.Point(283, 80);
            this.AutofillUsername_checkBox.Name = "AutofillUsername_checkBox";
            this.AutofillUsername_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AutofillUsername_checkBox.Size = new System.Drawing.Size(128, 21);
            this.AutofillUsername_checkBox.TabIndex = 1;
            this.AutofillUsername_checkBox.Text = "Autofill username";
            this.AutofillUsername_checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AutofillUsername_checkBox.UncheckedState.BorderRadius = 0;
            this.AutofillUsername_checkBox.UncheckedState.BorderThickness = 0;
            this.AutofillUsername_checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // AlwaysKeepMeSignedIn_checkBox
            // 
            this.AlwaysKeepMeSignedIn_checkBox.Animated = true;
            this.AlwaysKeepMeSignedIn_checkBox.AutoSize = true;
            this.AlwaysKeepMeSignedIn_checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(207)))));
            this.AlwaysKeepMeSignedIn_checkBox.CheckedState.BorderRadius = 0;
            this.AlwaysKeepMeSignedIn_checkBox.CheckedState.BorderThickness = 0;
            this.AlwaysKeepMeSignedIn_checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(207)))));
            this.AlwaysKeepMeSignedIn_checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlwaysKeepMeSignedIn_checkBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlwaysKeepMeSignedIn_checkBox.Location = new System.Drawing.Point(234, 109);
            this.AlwaysKeepMeSignedIn_checkBox.Name = "AlwaysKeepMeSignedIn_checkBox";
            this.AlwaysKeepMeSignedIn_checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AlwaysKeepMeSignedIn_checkBox.Size = new System.Drawing.Size(177, 21);
            this.AlwaysKeepMeSignedIn_checkBox.TabIndex = 2;
            this.AlwaysKeepMeSignedIn_checkBox.Text = "Always keep me signed In";
            this.AlwaysKeepMeSignedIn_checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AlwaysKeepMeSignedIn_checkBox.UncheckedState.BorderRadius = 0;
            this.AlwaysKeepMeSignedIn_checkBox.UncheckedState.BorderThickness = 0;
            this.AlwaysKeepMeSignedIn_checkBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // Security_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.AlwaysKeepMeSignedIn_checkBox);
            this.Controls.Add(this.AutofillUsername_checkBox);
            this.Controls.Add(this.Security_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Security_form";
            this.Click += new System.EventHandler(this.Security_form_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Security_lbl;
        public Guna.UI2.WinForms.Guna2CheckBox AutofillUsername_checkBox;
        public Guna.UI2.WinForms.Guna2CheckBox AlwaysKeepMeSignedIn_checkBox;
    }
}