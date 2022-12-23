
namespace ArgoStudio
{
    partial class MainMenu_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu_form));
            this.MainTop_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Workspace_btn = new Guna.UI2.WinForms.Guna2Button();
            this.MessagePanel_timer = new System.Windows.Forms.Timer(this.components);
            this.PartsBack_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Refresh_btn = new Guna.UI2.WinForms.Guna2Button();
            this.ClosePartsBack_btn = new Guna.UI2.WinForms.Guna2Button();
            this.PublicParts_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Back_btn = new Guna.UI2.WinForms.Guna2Button();
            this.IMGPreview_pictureBox = new System.Windows.Forms.PictureBox();
            this.MyParts_btn = new Guna.UI2.WinForms.Guna2Button();
            this.ArgoParts_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Top_panel = new System.Windows.Forms.Panel();
            this.Help_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Profile_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Save_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Menu_btn = new Guna.UI2.WinForms.Guna2Button();
            this.File_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Main_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.HideMenu_timer = new System.Windows.Forms.Timer(this.components);
            this.MainTop_panel.SuspendLayout();
            this.PartsBack_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IMGPreview_pictureBox)).BeginInit();
            this.Top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTop_panel
            // 
            this.MainTop_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTop_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.MainTop_panel.Controls.Add(this.Workspace_btn);
            this.MainTop_panel.Location = new System.Drawing.Point(300, 30);
            this.MainTop_panel.Name = "MainTop_panel";
            this.MainTop_panel.Size = new System.Drawing.Size(1304, 80);
            this.MainTop_panel.TabIndex = 6;
            this.MainTop_panel.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // Workspace_btn
            // 
            this.Workspace_btn.BackColor = System.Drawing.Color.Transparent;
            this.Workspace_btn.BorderColor = System.Drawing.Color.LightGray;
            this.Workspace_btn.BorderRadius = 3;
            this.Workspace_btn.BorderThickness = 2;
            this.Workspace_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Workspace_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Workspace_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Workspace_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Workspace_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Workspace_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Workspace_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Workspace_btn.ForeColor = System.Drawing.Color.Black;
            this.Workspace_btn.Image = global::ArgoStudio.Properties.Resources.DownArrowFull;
            this.Workspace_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Workspace_btn.ImageOffset = new System.Drawing.Point(40, 0);
            this.Workspace_btn.ImageSize = new System.Drawing.Size(8, 8);
            this.Workspace_btn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Workspace_btn.Location = new System.Drawing.Point(9, 9);
            this.Workspace_btn.Name = "Workspace_btn";
            this.Workspace_btn.Size = new System.Drawing.Size(155, 60);
            this.Workspace_btn.TabIndex = 1;
            this.Workspace_btn.Text = "DESIGN";
            this.Workspace_btn.TextOffset = new System.Drawing.Point(-10, 0);
            this.Workspace_btn.Click += new System.EventHandler(this.Workspace_btn_Click);
            // 
            // MessagePanel_timer
            // 
            this.MessagePanel_timer.Interval = 4500;
            this.MessagePanel_timer.Tick += new System.EventHandler(this.MessagePanelTimer_Tick);
            // 
            // PartsBack_panel
            // 
            this.PartsBack_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PartsBack_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.PartsBack_panel.Controls.Add(this.Refresh_btn);
            this.PartsBack_panel.Controls.Add(this.ClosePartsBack_btn);
            this.PartsBack_panel.Controls.Add(this.PublicParts_btn);
            this.PartsBack_panel.Controls.Add(this.Back_btn);
            this.PartsBack_panel.Controls.Add(this.IMGPreview_pictureBox);
            this.PartsBack_panel.Controls.Add(this.MyParts_btn);
            this.PartsBack_panel.Controls.Add(this.ArgoParts_btn);
            this.PartsBack_panel.CustomBorderColor = System.Drawing.Color.LightGray;
            this.PartsBack_panel.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.PartsBack_panel.Location = new System.Drawing.Point(0, 0);
            this.PartsBack_panel.Name = "PartsBack_panel";
            this.PartsBack_panel.Size = new System.Drawing.Size(300, 1040);
            this.PartsBack_panel.TabIndex = 365;
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Refresh_btn.BorderColor = System.Drawing.Color.Empty;
            this.Refresh_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Refresh_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Refresh_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Refresh_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Refresh_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Refresh_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Refresh_btn.ForeColor = System.Drawing.Color.White;
            this.Refresh_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.Refresh_btn.Image = global::ArgoStudio.Properties.Resources.RefreshGray;
            this.Refresh_btn.ImageSize = new System.Drawing.Size(18, 18);
            this.Refresh_btn.Location = new System.Drawing.Point(240, 0);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(30, 30);
            this.Refresh_btn.TabIndex = 7;
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            this.Refresh_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Refresh_btn_MouseDown);
            this.Refresh_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Refresh_btn_MouseUp);
            // 
            // ClosePartsBack_btn
            // 
            this.ClosePartsBack_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ClosePartsBack_btn.BorderColor = System.Drawing.Color.Empty;
            this.ClosePartsBack_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClosePartsBack_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ClosePartsBack_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ClosePartsBack_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ClosePartsBack_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ClosePartsBack_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.ClosePartsBack_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClosePartsBack_btn.ForeColor = System.Drawing.Color.White;
            this.ClosePartsBack_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.ClosePartsBack_btn.Image = global::ArgoStudio.Properties.Resources.CloseGrey;
            this.ClosePartsBack_btn.ImageSize = new System.Drawing.Size(18, 18);
            this.ClosePartsBack_btn.Location = new System.Drawing.Point(270, 0);
            this.ClosePartsBack_btn.Name = "ClosePartsBack_btn";
            this.ClosePartsBack_btn.Size = new System.Drawing.Size(30, 30);
            this.ClosePartsBack_btn.TabIndex = 8;
            this.ClosePartsBack_btn.Click += new System.EventHandler(this.Close_btn_Click);
            this.ClosePartsBack_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Close_btn_MouseDown);
            this.ClosePartsBack_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Close_btn_MouseUp);
            // 
            // PublicParts_btn
            // 
            this.PublicParts_btn.BackColor = System.Drawing.Color.Transparent;
            this.PublicParts_btn.BorderColor = System.Drawing.Color.Empty;
            this.PublicParts_btn.BorderRadius = 3;
            this.PublicParts_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PublicParts_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.PublicParts_btn.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.PublicParts_btn.ForeColor = System.Drawing.Color.Black;
            this.PublicParts_btn.Location = new System.Drawing.Point(201, 34);
            this.PublicParts_btn.Name = "PublicParts_btn";
            this.PublicParts_btn.Size = new System.Drawing.Size(90, 44);
            this.PublicParts_btn.TabIndex = 11;
            this.PublicParts_btn.Text = "Public Parts";
            this.PublicParts_btn.Click += new System.EventHandler(this.PublicParts_btn_Click);
            // 
            // Back_btn
            // 
            this.Back_btn.BorderColor = System.Drawing.Color.Empty;
            this.Back_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back_btn.FillColor = System.Drawing.Color.Empty;
            this.Back_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.Back_btn.ForeColor = System.Drawing.Color.Black;
            this.Back_btn.Image = global::ArgoStudio.Properties.Resources.LongBackArrow;
            this.Back_btn.ImageSize = new System.Drawing.Size(16, 16);
            this.Back_btn.Location = new System.Drawing.Point(12, 240);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(76, 33);
            this.Back_btn.TabIndex = 12;
            this.Back_btn.Text = "Back";
            this.Back_btn.Visible = false;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // IMGPreview_pictureBox
            // 
            this.IMGPreview_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.IMGPreview_pictureBox.Location = new System.Drawing.Point(12, 84);
            this.IMGPreview_pictureBox.Name = "IMGPreview_pictureBox";
            this.IMGPreview_pictureBox.Size = new System.Drawing.Size(279, 150);
            this.IMGPreview_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IMGPreview_pictureBox.TabIndex = 312;
            this.IMGPreview_pictureBox.TabStop = false;
            // 
            // MyParts_btn
            // 
            this.MyParts_btn.BackColor = System.Drawing.Color.Transparent;
            this.MyParts_btn.BorderColor = System.Drawing.Color.Empty;
            this.MyParts_btn.BorderRadius = 3;
            this.MyParts_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MyParts_btn.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.MyParts_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.MyParts_btn.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.MyParts_btn.ForeColor = System.Drawing.Color.Black;
            this.MyParts_btn.Location = new System.Drawing.Point(105, 34);
            this.MyParts_btn.Name = "MyParts_btn";
            this.MyParts_btn.Size = new System.Drawing.Size(90, 44);
            this.MyParts_btn.TabIndex = 10;
            this.MyParts_btn.Text = "My Parts";
            this.MyParts_btn.Click += new System.EventHandler(this.MyParts_btn_Click);
            // 
            // ArgoParts_btn
            // 
            this.ArgoParts_btn.BackColor = System.Drawing.Color.Transparent;
            this.ArgoParts_btn.BorderColor = System.Drawing.Color.Empty;
            this.ArgoParts_btn.BorderRadius = 3;
            this.ArgoParts_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArgoParts_btn.FillColor = System.Drawing.Color.White;
            this.ArgoParts_btn.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.ArgoParts_btn.ForeColor = System.Drawing.Color.Black;
            this.ArgoParts_btn.Location = new System.Drawing.Point(9, 34);
            this.ArgoParts_btn.Name = "ArgoParts_btn";
            this.ArgoParts_btn.Size = new System.Drawing.Size(90, 44);
            this.ArgoParts_btn.TabIndex = 9;
            this.ArgoParts_btn.Text = "Argo Parts";
            this.ArgoParts_btn.Click += new System.EventHandler(this.ArgoParts_btn_Click);
            // 
            // Top_panel
            // 
            this.Top_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Top_panel.Controls.Add(this.Help_btn);
            this.Top_panel.Controls.Add(this.Profile_btn);
            this.Top_panel.Controls.Add(this.Save_btn);
            this.Top_panel.Controls.Add(this.Menu_btn);
            this.Top_panel.Controls.Add(this.File_btn);
            this.Top_panel.Location = new System.Drawing.Point(300, 0);
            this.Top_panel.Name = "Top_panel";
            this.Top_panel.Size = new System.Drawing.Size(1304, 30);
            this.Top_panel.TabIndex = 0;
            this.Top_panel.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // Help_btn
            // 
            this.Help_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Help_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Help_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Help_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Help_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Help_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Help_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Help_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Help_btn.ForeColor = System.Drawing.Color.White;
            this.Help_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.Help_btn.Image = global::ArgoStudio.Properties.Resources.HelpGray;
            this.Help_btn.Location = new System.Drawing.Point(1223, 0);
            this.Help_btn.Name = "Help_btn";
            this.Help_btn.PressedColor = System.Drawing.Color.Empty;
            this.Help_btn.Size = new System.Drawing.Size(30, 30);
            this.Help_btn.TabIndex = 5;
            this.Help_btn.Click += new System.EventHandler(this.Help_btn_Click);
            // 
            // Profile_btn
            // 
            this.Profile_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Profile_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Profile_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Profile_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Profile_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Profile_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Profile_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Profile_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Profile_btn.ForeColor = System.Drawing.Color.White;
            this.Profile_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.Profile_btn.Image = global::ArgoStudio.Properties.Resources.Account;
            this.Profile_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.Profile_btn.Location = new System.Drawing.Point(1253, 0);
            this.Profile_btn.Name = "Profile_btn";
            this.Profile_btn.PressedColor = System.Drawing.Color.Empty;
            this.Profile_btn.Size = new System.Drawing.Size(51, 30);
            this.Profile_btn.TabIndex = 6;
            this.Profile_btn.Click += new System.EventHandler(this.Profile_btn_Click);
            // 
            // Save_btn
            // 
            this.Save_btn.BorderColor = System.Drawing.Color.Empty;
            this.Save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Save_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Save_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Save_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Save_btn.FillColor = System.Drawing.Color.Empty;
            this.Save_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Save_btn.ForeColor = System.Drawing.Color.White;
            this.Save_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.Save_btn.Image = global::ArgoStudio.Properties.Resources.SaveGray;
            this.Save_btn.ImageSize = new System.Drawing.Size(18, 18);
            this.Save_btn.Location = new System.Drawing.Point(72, 0);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(30, 30);
            this.Save_btn.TabIndex = 4;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            this.Save_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Save_btn_MouseDown);
            this.Save_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Save_btn_MouseUp);
            // 
            // Menu_btn
            // 
            this.Menu_btn.BorderColor = System.Drawing.Color.Empty;
            this.Menu_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Menu_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Menu_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Menu_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Menu_btn.FillColor = System.Drawing.Color.Empty;
            this.Menu_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Menu_btn.ForeColor = System.Drawing.Color.White;
            this.Menu_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.Menu_btn.Image = global::ArgoStudio.Properties.Resources.MenuGray;
            this.Menu_btn.ImageSize = new System.Drawing.Size(18, 18);
            this.Menu_btn.Location = new System.Drawing.Point(0, 0);
            this.Menu_btn.Name = "Menu_btn";
            this.Menu_btn.Size = new System.Drawing.Size(30, 30);
            this.Menu_btn.TabIndex = 2;
            this.Menu_btn.Visible = false;
            this.Menu_btn.Click += new System.EventHandler(this.Menu_btn_Click);
            this.Menu_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_btn_MouseDown);
            this.Menu_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_btn_MouseUp);
            // 
            // File_btn
            // 
            this.File_btn.BorderColor = System.Drawing.Color.Empty;
            this.File_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.File_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.File_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.File_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.File_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.File_btn.FillColor = System.Drawing.Color.Empty;
            this.File_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.File_btn.ForeColor = System.Drawing.Color.White;
            this.File_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.File_btn.Image = global::ArgoStudio.Properties.Resources.FileGray;
            this.File_btn.ImageSize = new System.Drawing.Size(35, 25);
            this.File_btn.Location = new System.Drawing.Point(30, 0);
            this.File_btn.Name = "File_btn";
            this.File_btn.Size = new System.Drawing.Size(42, 30);
            this.File_btn.TabIndex = 3;
            this.File_btn.Click += new System.EventHandler(this.File_btn_Click);
            // 
            // Main_panel
            // 
            this.Main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Main_panel.Location = new System.Drawing.Point(300, 110);
            this.Main_panel.Name = "Main_panel";
            this.Main_panel.Size = new System.Drawing.Size(1304, 930);
            this.Main_panel.TabIndex = 8;
            this.Main_panel.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // HideMenu_timer
            // 
            this.HideMenu_timer.Interval = 800;
            this.HideMenu_timer.Tick += new System.EventHandler(this.HideMenu_timer_Tick);
            // 
            // MainMenu_form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1604, 1041);
            this.Controls.Add(this.Top_panel);
            this.Controls.Add(this.PartsBack_panel);
            this.Controls.Add(this.MainTop_panel);
            this.Controls.Add(this.Main_panel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 670);
            this.Name = "MainMenu_form";
            this.Text = "Argo Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_form_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_form_Load);
            this.Shown += new System.EventHandler(this.MainMenu_form_Shown);
            this.ResizeBegin += new System.EventHandler(this.MainMenu_form_ResizeBegin);
            this.Click += new System.EventHandler(this.CloseAllPanels);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenu_form_KeyDown);
            this.Resize += new System.EventHandler(this.MainMenu_form_Resize);
            this.MainTop_panel.ResumeLayout(false);
            this.PartsBack_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IMGPreview_pictureBox)).EndInit();
            this.Top_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MessagePanel_timer;
        public Guna.UI2.WinForms.Guna2Button Workspace_btn;
        public Guna.UI2.WinForms.Guna2Panel PartsBack_panel;
        private Guna.UI2.WinForms.Guna2Button PublicParts_btn;
        public Guna.UI2.WinForms.Guna2Button Back_btn;
        private System.Windows.Forms.PictureBox IMGPreview_pictureBox;
        private Guna.UI2.WinForms.Guna2Button MyParts_btn;
        private Guna.UI2.WinForms.Guna2Button ArgoParts_btn;
        public Guna.UI2.WinForms.Guna2Panel MainTop_panel;
        public System.Windows.Forms.Panel Top_panel;
        public Guna.UI2.WinForms.Guna2Button File_btn;
        public Guna.UI2.WinForms.Guna2Button ClosePartsBack_btn;
        public Guna.UI2.WinForms.Guna2Button Menu_btn;
        public Guna.UI2.WinForms.Guna2Button Save_btn;
        public Guna.UI2.WinForms.Guna2Button Profile_btn;
        public Guna.UI2.WinForms.Guna2Button Refresh_btn;
        public Guna.UI2.WinForms.Guna2Button Help_btn;
        public Guna.UI2.WinForms.Guna2Panel Main_panel;
        public System.Windows.Forms.Timer HideMenu_timer;
    }
}
