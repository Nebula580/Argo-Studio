
namespace ArgoStudio.Main.Startup.Menus
{
    partial class GetStarted_form
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
            this.FlowPanelOpenRecnt = new System.Windows.Forms.FlowLayoutPanel();
            this.BlankProject_btn = new Guna.UI2.WinForms.Guna2Button();
            this.LblOpenRecent = new System.Windows.Forms.Label();
            this.OpenProject_panel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 41);
            this.label1.TabIndex = 15;
            this.label1.Text = "Argo Studio";
            // 
            // FlowPanelOpenRecnt
            // 
            this.FlowPanelOpenRecnt.AutoSize = true;
            this.FlowPanelOpenRecnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowPanelOpenRecnt.Location = new System.Drawing.Point(29, 101);
            this.FlowPanelOpenRecnt.Name = "FlowPanelOpenRecnt";
            this.FlowPanelOpenRecnt.Size = new System.Drawing.Size(264, 349);
            this.FlowPanelOpenRecnt.TabIndex = 1;
            // 
            // BlankProject_btn
            // 
            this.BlankProject_btn.BorderThickness = 1;
            this.BlankProject_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BlankProject_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BlankProject_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankProject_btn.ForeColor = System.Drawing.Color.Black;
            this.BlankProject_btn.Image = global::ArgoStudio.Properties.Resources.CreateFile;
            this.BlankProject_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BlankProject_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.BlankProject_btn.ImageSize = new System.Drawing.Size(30, 30);
            this.BlankProject_btn.Location = new System.Drawing.Point(305, 101);
            this.BlankProject_btn.Margin = new System.Windows.Forms.Padding(10);
            this.BlankProject_btn.Name = "BlankProject_btn";
            this.BlankProject_btn.Size = new System.Drawing.Size(279, 69);
            this.BlankProject_btn.TabIndex = 2;
            this.BlankProject_btn.Text = "Create a new project";
            this.BlankProject_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BlankProject_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.BlankProject_btn.Click += new System.EventHandler(this.CreateNewProject_Click);
            // 
            // LblOpenRecent
            // 
            this.LblOpenRecent.AutoSize = true;
            this.LblOpenRecent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblOpenRecent.Location = new System.Drawing.Point(25, 73);
            this.LblOpenRecent.Name = "LblOpenRecent";
            this.LblOpenRecent.Size = new System.Drawing.Size(95, 21);
            this.LblOpenRecent.TabIndex = 17;
            this.LblOpenRecent.Text = "Open recent";
            // 
            // OpenProject_panel
            // 
            this.OpenProject_panel.BorderThickness = 1;
            this.OpenProject_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenProject_panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.OpenProject_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenProject_panel.ForeColor = System.Drawing.Color.Black;
            this.OpenProject_panel.Image = global::ArgoStudio.Properties.Resources.OpenFolder;
            this.OpenProject_panel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OpenProject_panel.ImageOffset = new System.Drawing.Point(5, 0);
            this.OpenProject_panel.ImageSize = new System.Drawing.Size(30, 30);
            this.OpenProject_panel.Location = new System.Drawing.Point(305, 185);
            this.OpenProject_panel.Margin = new System.Windows.Forms.Padding(10);
            this.OpenProject_panel.Name = "OpenProject_panel";
            this.OpenProject_panel.Size = new System.Drawing.Size(279, 69);
            this.OpenProject_panel.TabIndex = 3;
            this.OpenProject_panel.Text = "Open a project";
            this.OpenProject_panel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OpenProject_panel.TextOffset = new System.Drawing.Point(10, 0);
            this.OpenProject_panel.Click += new System.EventHandler(this.OpenProject_panel_Click);
            // 
            // GetStarted_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(880, 550);
            this.Controls.Add(this.OpenProject_panel);
            this.Controls.Add(this.BlankProject_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FlowPanelOpenRecnt);
            this.Controls.Add(this.LblOpenRecent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GetStarted_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelOpenRecnt;
        private System.Windows.Forms.Label LblOpenRecent;
        private Guna.UI2.WinForms.Guna2Button BlankProject_btn;
        private Guna.UI2.WinForms.Guna2Button OpenProject_panel;
    }
}