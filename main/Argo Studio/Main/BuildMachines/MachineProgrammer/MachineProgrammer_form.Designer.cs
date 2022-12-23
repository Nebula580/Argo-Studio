
namespace ArgoStudio.Main.BuildMachines.MachineProgrammer
{
    partial class MachineProgrammer_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineProgrammer_form));
            this.Back_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.Connected_lbl = new System.Windows.Forms.Label();
            this.MachineController_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.MachineController_lbl = new System.Windows.Forms.Label();
            this.MoveForward_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Stop_btn = new Guna.UI2.WinForms.Guna2Button();
            this.MoveBackward_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Play_btn = new Guna.UI2.WinForms.Guna2Button();
            this.MainCommandBack_panel = new System.Windows.Forms.Panel();
            this.AddCommand_btn = new Guna.UI2.WinForms.Guna2Button();
            this.MoveCommand_timer = new System.Windows.Forms.Timer(this.components);
            this.FileBack_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.AddSequence_btn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.FileBack_flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddFunction_btn = new Guna.UI2.WinForms.Guna2Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SerialComTimeout_timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AddCommand_flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Motion_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Home_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Delay_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Run_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Loop_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SetVariable_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SetOutput_btn = new Guna.UI2.WinForms.Guna2Button();
            this.Back_panel.SuspendLayout();
            this.FileBack_panel.SuspendLayout();
            this.AddCommand_flowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Back_panel
            // 
            this.Back_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Back_panel.Controls.Add(this.Connected_lbl);
            this.Back_panel.Controls.Add(this.MachineController_ComboBox);
            this.Back_panel.Controls.Add(this.guna2Separator2);
            this.Back_panel.Controls.Add(this.MachineController_lbl);
            this.Back_panel.Controls.Add(this.MoveForward_btn);
            this.Back_panel.Controls.Add(this.Stop_btn);
            this.Back_panel.Controls.Add(this.MoveBackward_btn);
            this.Back_panel.Controls.Add(this.Play_btn);
            this.Back_panel.FillColor = System.Drawing.Color.White;
            this.Back_panel.Location = new System.Drawing.Point(256, 497);
            this.Back_panel.Name = "Back_panel";
            this.Back_panel.Size = new System.Drawing.Size(1028, 93);
            this.Back_panel.TabIndex = 419;
            this.Back_panel.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // Connected_lbl
            // 
            this.Connected_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Connected_lbl.AutoSize = true;
            this.Connected_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Connected_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connected_lbl.ForeColor = System.Drawing.Color.Black;
            this.Connected_lbl.Location = new System.Drawing.Point(15, 67);
            this.Connected_lbl.Name = "Connected_lbl";
            this.Connected_lbl.Size = new System.Drawing.Size(87, 15);
            this.Connected_lbl.TabIndex = 425;
            this.Connected_lbl.Text = "Not Connected";
            this.Connected_lbl.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // MachineController_ComboBox
            // 
            this.MachineController_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MachineController_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.MachineController_ComboBox.BorderRadius = 3;
            this.MachineController_ComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MachineController_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MachineController_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MachineController_ComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MachineController_ComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MachineController_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MachineController_ComboBox.ForeColor = System.Drawing.Color.Black;
            this.MachineController_ComboBox.ItemHeight = 25;
            this.MachineController_ComboBox.Location = new System.Drawing.Point(11, 31);
            this.MachineController_ComboBox.Name = "MachineController_ComboBox";
            this.MachineController_ComboBox.Size = new System.Drawing.Size(180, 31);
            this.MachineController_ComboBox.Sorted = true;
            this.MachineController_ComboBox.TabIndex = 4;
            this.MachineController_ComboBox.DropDown += new System.EventHandler(this.MachineController_ComboBox_DropDown);
            this.MachineController_ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMachineController_SelectedIndexChanged);
            this.MachineController_ComboBox.Click += new System.EventHandler(this.CloseAllPanels);
            this.MachineController_ComboBox.Enter += new System.EventHandler(this.MachineController_ComboBox_Enter);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Separator2.Location = new System.Drawing.Point(0, 0);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(1028, 1);
            this.guna2Separator2.TabIndex = 399;
            // 
            // MachineController_lbl
            // 
            this.MachineController_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MachineController_lbl.AutoSize = true;
            this.MachineController_lbl.BackColor = System.Drawing.Color.Transparent;
            this.MachineController_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MachineController_lbl.ForeColor = System.Drawing.Color.Black;
            this.MachineController_lbl.Location = new System.Drawing.Point(15, 12);
            this.MachineController_lbl.Name = "MachineController_lbl";
            this.MachineController_lbl.Size = new System.Drawing.Size(108, 15);
            this.MachineController_lbl.TabIndex = 416;
            this.MachineController_lbl.Text = "Machine Controller";
            this.MachineController_lbl.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // MoveForward_btn
            // 
            this.MoveForward_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveForward_btn.BorderRadius = 3;
            this.MoveForward_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveForward_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(117)))), ((int)(((byte)(197)))));
            this.MoveForward_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveForward_btn.ForeColor = System.Drawing.Color.White;
            this.MoveForward_btn.ImageSize = new System.Drawing.Size(22, 22);
            this.MoveForward_btn.Location = new System.Drawing.Point(634, 17);
            this.MoveForward_btn.Name = "MoveForward_btn";
            this.MoveForward_btn.Size = new System.Drawing.Size(90, 61);
            this.MoveForward_btn.TabIndex = 5;
            this.MoveForward_btn.Text = "Move Forward";
            this.MoveForward_btn.Click += new System.EventHandler(this.MoveForward_btn_Click);
            // 
            // Stop_btn
            // 
            this.Stop_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop_btn.BorderRadius = 3;
            this.Stop_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Stop_btn.Enabled = false;
            this.Stop_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(117)))), ((int)(((byte)(197)))));
            this.Stop_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Stop_btn.ForeColor = System.Drawing.Color.White;
            this.Stop_btn.Image = ((System.Drawing.Image)(resources.GetObject("Stop_btn.Image")));
            this.Stop_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.Stop_btn.Location = new System.Drawing.Point(922, 17);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(90, 61);
            this.Stop_btn.TabIndex = 8;
            this.Stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // MoveBackward_btn
            // 
            this.MoveBackward_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveBackward_btn.BorderRadius = 3;
            this.MoveBackward_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveBackward_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(117)))), ((int)(((byte)(197)))));
            this.MoveBackward_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveBackward_btn.ForeColor = System.Drawing.Color.White;
            this.MoveBackward_btn.ImageSize = new System.Drawing.Size(22, 22);
            this.MoveBackward_btn.Location = new System.Drawing.Point(730, 17);
            this.MoveBackward_btn.Name = "MoveBackward_btn";
            this.MoveBackward_btn.Size = new System.Drawing.Size(90, 61);
            this.MoveBackward_btn.TabIndex = 6;
            this.MoveBackward_btn.Text = "Move Backward";
            this.MoveBackward_btn.Click += new System.EventHandler(this.MoveBackward_btn_Click);
            // 
            // Play_btn
            // 
            this.Play_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Play_btn.BorderRadius = 3;
            this.Play_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Play_btn.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.Play_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Play_btn.ForeColor = System.Drawing.Color.White;
            this.Play_btn.Image = global::ArgoStudio.Properties.Resources.Play;
            this.Play_btn.ImageSize = new System.Drawing.Size(25, 25);
            this.Play_btn.Location = new System.Drawing.Point(826, 17);
            this.Play_btn.Name = "Play_btn";
            this.Play_btn.Size = new System.Drawing.Size(90, 61);
            this.Play_btn.TabIndex = 7;
            this.Play_btn.Tag = "";
            this.Play_btn.Click += new System.EventHandler(this.Play_btn_Click);
            // 
            // MainCommandBack_panel
            // 
            this.MainCommandBack_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainCommandBack_panel.BackColor = System.Drawing.Color.White;
            this.MainCommandBack_panel.Location = new System.Drawing.Point(256, 23);
            this.MainCommandBack_panel.Name = "MainCommandBack_panel";
            this.MainCommandBack_panel.Size = new System.Drawing.Size(1028, 475);
            this.MainCommandBack_panel.TabIndex = 0;
            // 
            // AddCommand_btn
            // 
            this.AddCommand_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddCommand_btn.BorderRadius = 3;
            this.AddCommand_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddCommand_btn.DisabledState.FillColor = System.Drawing.Color.LightGray;
            this.AddCommand_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(117)))), ((int)(((byte)(197)))));
            this.AddCommand_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCommand_btn.ForeColor = System.Drawing.Color.White;
            this.AddCommand_btn.Location = new System.Drawing.Point(165, 478);
            this.AddCommand_btn.Name = "AddCommand_btn";
            this.AddCommand_btn.Size = new System.Drawing.Size(76, 82);
            this.AddCommand_btn.TabIndex = 3;
            this.AddCommand_btn.Text = "Add Command";
            this.AddCommand_btn.TextOffset = new System.Drawing.Point(0, 20);
            this.AddCommand_btn.Click += new System.EventHandler(this.AddCommand_btn_Click);
            // 
            // MoveCommand_timer
            // 
            this.MoveCommand_timer.Interval = 10;
            this.MoveCommand_timer.Tick += new System.EventHandler(this.MoveCommandTimer_Tick);
            // 
            // FileBack_panel
            // 
            this.FileBack_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileBack_panel.Controls.Add(this.AddSequence_btn);
            this.FileBack_panel.Controls.Add(this.guna2Separator1);
            this.FileBack_panel.Controls.Add(this.FileBack_flowPanel);
            this.FileBack_panel.Controls.Add(this.AddFunction_btn);
            this.FileBack_panel.Controls.Add(this.AddCommand_btn);
            this.FileBack_panel.CustomBorderColor = System.Drawing.Color.LightGray;
            this.FileBack_panel.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.FileBack_panel.FillColor = System.Drawing.Color.White;
            this.FileBack_panel.Location = new System.Drawing.Point(6, 23);
            this.FileBack_panel.Name = "FileBack_panel";
            this.FileBack_panel.Size = new System.Drawing.Size(250, 567);
            this.FileBack_panel.TabIndex = 420;
            this.FileBack_panel.Click += new System.EventHandler(this.CloseAllPanels);
            // 
            // AddSequence_btn
            // 
            this.AddSequence_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddSequence_btn.BorderRadius = 3;
            this.AddSequence_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSequence_btn.DisabledState.FillColor = System.Drawing.Color.LightGray;
            this.AddSequence_btn.FillColor = System.Drawing.Color.WhiteSmoke;
            this.AddSequence_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSequence_btn.ForeColor = System.Drawing.Color.Black;
            this.AddSequence_btn.Location = new System.Drawing.Point(5, 478);
            this.AddSequence_btn.Name = "AddSequence_btn";
            this.AddSequence_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AddSequence_btn.Size = new System.Drawing.Size(76, 82);
            this.AddSequence_btn.TabIndex = 1;
            this.AddSequence_btn.Text = "Add Sequence";
            this.AddSequence_btn.TextOffset = new System.Drawing.Point(0, 20);
            this.AddSequence_btn.Click += new System.EventHandler(this.AddSequence_btn_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Separator1.Location = new System.Drawing.Point(1, 474);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(327, 1);
            this.guna2Separator1.TabIndex = 0;
            // 
            // FileBack_flowPanel
            // 
            this.FileBack_flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileBack_flowPanel.BackColor = System.Drawing.Color.White;
            this.FileBack_flowPanel.Location = new System.Drawing.Point(0, 0);
            this.FileBack_flowPanel.Name = "FileBack_flowPanel";
            this.FileBack_flowPanel.Size = new System.Drawing.Size(249, 474);
            this.FileBack_flowPanel.TabIndex = 0;
            this.FileBack_flowPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FileBack_flowPanel_MouseUp);
            // 
            // AddFunction_btn
            // 
            this.AddFunction_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddFunction_btn.BorderRadius = 3;
            this.AddFunction_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddFunction_btn.DisabledState.FillColor = System.Drawing.Color.LightGray;
            this.AddFunction_btn.FillColor = System.Drawing.Color.WhiteSmoke;
            this.AddFunction_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFunction_btn.ForeColor = System.Drawing.Color.Black;
            this.AddFunction_btn.Location = new System.Drawing.Point(85, 478);
            this.AddFunction_btn.Name = "AddFunction_btn";
            this.AddFunction_btn.Size = new System.Drawing.Size(76, 82);
            this.AddFunction_btn.TabIndex = 2;
            this.AddFunction_btn.Text = "Add Function";
            this.AddFunction_btn.TextOffset = new System.Drawing.Point(0, 20);
            this.AddFunction_btn.Click += new System.EventHandler(this.AddFuntion_btn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SerialPort1_ErrorReceived);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // SerialComTimeout_timer
            // 
            this.SerialComTimeout_timer.Interval = 1000;
            this.SerialComTimeout_timer.Tick += new System.EventHandler(this.SerialComTimeout_timer_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // AddCommand_flowPanel
            // 
            this.AddCommand_flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddCommand_flowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(117)))), ((int)(((byte)(197)))));
            this.AddCommand_flowPanel.Controls.Add(this.Motion_btn);
            this.AddCommand_flowPanel.Controls.Add(this.Home_btn);
            this.AddCommand_flowPanel.Controls.Add(this.Delay_btn);
            this.AddCommand_flowPanel.Controls.Add(this.Run_btn);
            this.AddCommand_flowPanel.Controls.Add(this.Loop_btn);
            this.AddCommand_flowPanel.Controls.Add(this.SetVariable_btn);
            this.AddCommand_flowPanel.Controls.Add(this.SetOutput_btn);
            this.AddCommand_flowPanel.Location = new System.Drawing.Point(171, 241);
            this.AddCommand_flowPanel.Name = "AddCommand_flowPanel";
            this.AddCommand_flowPanel.Size = new System.Drawing.Size(172, 261);
            this.AddCommand_flowPanel.TabIndex = 0;
            this.AddCommand_flowPanel.Visible = false;
            // 
            // Motion_btn
            // 
            this.Motion_btn.BackColor = System.Drawing.Color.Transparent;
            this.Motion_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Motion_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Motion_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Motion_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Motion_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Motion_btn.FillColor = System.Drawing.Color.Transparent;
            this.Motion_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Motion_btn.ForeColor = System.Drawing.Color.White;
            this.Motion_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.Motion_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Motion_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.Motion_btn.Location = new System.Drawing.Point(0, 0);
            this.Motion_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Motion_btn.Name = "Motion_btn";
            this.Motion_btn.Size = new System.Drawing.Size(172, 37);
            this.Motion_btn.TabIndex = 9;
            this.Motion_btn.Text = "Add Motion";
            this.Motion_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Motion_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.Motion_btn.Click += new System.EventHandler(this.Motion_btn_Click);
            // 
            // Home_btn
            // 
            this.Home_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Home_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Home_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Home_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Home_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Home_btn.FillColor = System.Drawing.Color.Transparent;
            this.Home_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home_btn.ForeColor = System.Drawing.Color.White;
            this.Home_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.Home_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Home_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.Home_btn.Location = new System.Drawing.Point(0, 37);
            this.Home_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Home_btn.Name = "Home_btn";
            this.Home_btn.Size = new System.Drawing.Size(172, 37);
            this.Home_btn.TabIndex = 10;
            this.Home_btn.Text = "Add Home";
            this.Home_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Home_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.Home_btn.Click += new System.EventHandler(this.Home_btn_Click);
            // 
            // Delay_btn
            // 
            this.Delay_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delay_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Delay_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Delay_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Delay_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Delay_btn.FillColor = System.Drawing.Color.Transparent;
            this.Delay_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delay_btn.ForeColor = System.Drawing.Color.White;
            this.Delay_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.Delay_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Delay_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.Delay_btn.Location = new System.Drawing.Point(0, 74);
            this.Delay_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Delay_btn.Name = "Delay_btn";
            this.Delay_btn.Size = new System.Drawing.Size(172, 37);
            this.Delay_btn.TabIndex = 11;
            this.Delay_btn.Text = "Add Delay";
            this.Delay_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Delay_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.Delay_btn.Click += new System.EventHandler(this.Delay_btn_Click);
            // 
            // Run_btn
            // 
            this.Run_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Run_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Run_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Run_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Run_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Run_btn.FillColor = System.Drawing.Color.Transparent;
            this.Run_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Run_btn.ForeColor = System.Drawing.Color.White;
            this.Run_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.Run_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Run_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.Run_btn.Location = new System.Drawing.Point(0, 111);
            this.Run_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Run_btn.Name = "Run_btn";
            this.Run_btn.Size = new System.Drawing.Size(172, 37);
            this.Run_btn.TabIndex = 12;
            this.Run_btn.Text = "Add Run";
            this.Run_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Run_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.Run_btn.Click += new System.EventHandler(this.Run_btn_Click);
            // 
            // Loop_btn
            // 
            this.Loop_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Loop_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Loop_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Loop_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Loop_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Loop_btn.FillColor = System.Drawing.Color.Transparent;
            this.Loop_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loop_btn.ForeColor = System.Drawing.Color.White;
            this.Loop_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.Loop_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Loop_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.Loop_btn.Location = new System.Drawing.Point(0, 148);
            this.Loop_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Loop_btn.Name = "Loop_btn";
            this.Loop_btn.Size = new System.Drawing.Size(172, 37);
            this.Loop_btn.TabIndex = 13;
            this.Loop_btn.Text = "Add Loop";
            this.Loop_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Loop_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.Loop_btn.Click += new System.EventHandler(this.Loop_btn_Click);
            // 
            // SetVariable_btn
            // 
            this.SetVariable_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetVariable_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SetVariable_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SetVariable_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SetVariable_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SetVariable_btn.FillColor = System.Drawing.Color.Transparent;
            this.SetVariable_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetVariable_btn.ForeColor = System.Drawing.Color.White;
            this.SetVariable_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.SetVariable_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SetVariable_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.SetVariable_btn.Location = new System.Drawing.Point(0, 185);
            this.SetVariable_btn.Margin = new System.Windows.Forms.Padding(0);
            this.SetVariable_btn.Name = "SetVariable_btn";
            this.SetVariable_btn.Size = new System.Drawing.Size(172, 37);
            this.SetVariable_btn.TabIndex = 14;
            this.SetVariable_btn.Text = "Add Set variable";
            this.SetVariable_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SetVariable_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.SetVariable_btn.Click += new System.EventHandler(this.SetVariable_btn_Click);
            // 
            // SetOutput_btn
            // 
            this.SetOutput_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetOutput_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SetOutput_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SetOutput_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SetOutput_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SetOutput_btn.FillColor = System.Drawing.Color.Transparent;
            this.SetOutput_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetOutput_btn.ForeColor = System.Drawing.Color.White;
            this.SetOutput_btn.Image = global::ArgoStudio.Properties.Resources.Temp;
            this.SetOutput_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SetOutput_btn.ImageOffset = new System.Drawing.Point(5, 0);
            this.SetOutput_btn.Location = new System.Drawing.Point(0, 222);
            this.SetOutput_btn.Margin = new System.Windows.Forms.Padding(0);
            this.SetOutput_btn.Name = "SetOutput_btn";
            this.SetOutput_btn.Size = new System.Drawing.Size(172, 37);
            this.SetOutput_btn.TabIndex = 15;
            this.SetOutput_btn.Text = "Add Set output";
            this.SetOutput_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SetOutput_btn.TextOffset = new System.Drawing.Point(10, 0);
            this.SetOutput_btn.Click += new System.EventHandler(this.SetOutput_btn_Click);
            // 
            // MachineProgrammer_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 595);
            this.Controls.Add(this.AddCommand_flowPanel);
            this.Controls.Add(this.Back_panel);
            this.Controls.Add(this.FileBack_panel);
            this.Controls.Add(this.MainCommandBack_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1300, 3064);
            this.MinimumSize = new System.Drawing.Size(1300, 397);
            this.Name = "MachineProgrammer_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machine Programmer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MachineProgrammer_form_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.MachineProgrammer_form_ResizeBegin);
            this.Click += new System.EventHandler(this.CloseAllPanels);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMachineProgrammer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMachineProgrammer_KeyUp);
            this.Back_panel.ResumeLayout(false);
            this.Back_panel.PerformLayout();
            this.FileBack_panel.ResumeLayout(false);
            this.AddCommand_flowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Timer MoveCommand_timer;
        private System.Windows.Forms.Label MachineController_lbl;
        public Guna.UI2.WinForms.Guna2Button Play_btn;
        public Guna.UI2.WinForms.Guna2Button Stop_btn;
        public Guna.UI2.WinForms.Guna2ComboBox MachineController_ComboBox;
        public Guna.UI2.WinForms.Guna2Panel Back_panel;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer SerialComTimeout_timer;
        private System.Windows.Forms.Label Connected_lbl;
        public Guna.UI2.WinForms.Guna2Button AddFunction_btn;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.FlowLayoutPanel FileBack_flowPanel;
        public System.Windows.Forms.Panel MainCommandBack_panel;
        public Guna.UI2.WinForms.Guna2Button Run_btn;
        public Guna.UI2.WinForms.Guna2Button SetVariable_btn;
        public Guna.UI2.WinForms.Guna2Button Loop_btn;
        public Guna.UI2.WinForms.Guna2Button SetOutput_btn;
        public Guna.UI2.WinForms.Guna2Button Home_btn;
        public Guna.UI2.WinForms.Guna2Button Motion_btn;
        public Guna.UI2.WinForms.Guna2Button Delay_btn;
        public Guna.UI2.WinForms.Guna2Button AddCommand_btn;
        public System.Windows.Forms.FlowLayoutPanel AddCommand_flowPanel;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public Guna.UI2.WinForms.Guna2Button AddSequence_btn;
        public Guna.UI2.WinForms.Guna2Button MoveForward_btn;
        public Guna.UI2.WinForms.Guna2Button MoveBackward_btn;
        public Guna.UI2.WinForms.Guna2Panel FileBack_panel;
    }
}