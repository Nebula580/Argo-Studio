using ArgoStudio.Main;
using ArgoStudio.Main.BuildMachines;
using ArgoStudio.Main.BuildMachines.MachineProgrammer;
using ArgoStudio.Main.Classes;
using ArgoStudio.Main.RobotProgrammer;
using ArgoStudio.Main.RobotProgrammer.MainControls;
using ArgoStudio.Main.RobotProgrammer.MainControls.Setup;
using ArgoStudio.Main.Startup.Menus;
using ArgoStudio.Properties;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ArgoStudio
{
    public partial class MainMenu_form : Form
    {
        // Init
        public static MainMenu_form instance;
        private Guna2Button selectedDesignMenu;
        public MainMenu_form()
        {
            InitializeComponent();
            instance = this;

            UI.ConstructControls();
            UpdateTheme();

            Log.Write(2, "Starting Argo Studio");
            selectedDesignMenu = ArgoParts_btn;

            UI.Design_btn.PerformClick();
            PartsBack_panel.Controls.Add(UI.argoParts_panel);
        }
        public void UpdateTheme()
        {
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {
                Connect_btn.Image = Resources.SpeedBlack;
                Program_btn.Image = Resources.ProgramBlack;
                RobotSpeed_btn.Image = Resources.SpeedBlack;
                Upload_btn.Image = Resources.UploadBlack;
                Backward_btn.Image = Resources.BackArrowBlack;
                Forward_btn.Image = Resources.ForwardArrowBlack;
            }
            else if (theme == "Dark")
            {
                Connect_btn.Image = Resources.SpeedWhite;
                Program_btn.Image = Resources.ProgramWhite;
                RobotSpeed_btn.Image = Resources.SpeedWhite;
                Upload_btn.Image = Resources.UploadWhite;
                Backward_btn.Image = Resources.BackArrowWhite;
                Forward_btn.Image = Resources.ForwardArrowWhite;
            }
            Play_btn.FillColor = CustomColors.playBtnGreen;
            Play_btn.ForeColor = Color.Black;

            PartsBack_panel.CustomBorderColor = CustomColors.controlBack;
            Refresh_btn.FillColor = CustomColors.mainBackground;
            ClosePartsBack_btn.FillColor = CustomColors.mainBackground;
            Back_btn.BackColor = CustomColors.mainBackground;

            Top_panel.BackColor = CustomColors.background3;
            MainTop_panel.FillColor = CustomColors.background4;
            Menu_btn.FillColor = CustomColors.background3;
            File_btn.FillColor = CustomColors.background3;
            Save_btn.FillColor = CustomColors.background3;
            Help_btn.FillColor = CustomColors.background3;
            Profile_btn.FillColor = CustomColors.background3;

            Connect_btn.FillColor = CustomColors.background4;
            Program_btn.FillColor = CustomColors.background4;
            RobotSpeed_btn.FillColor = CustomColors.background4;
            Upload_btn.FillColor = CustomColors.background4;
        }


        // Form
        public bool isFormOpen;
        private void MainMenu_form_Load(object sender, EventArgs e)
        {
            isFormOpen = true;
        }
        private void MainMenu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
        }
        private void MainMenu_form_Shown(object sender, EventArgs e)
        {
            Log.Write(2, "Argo Studio has finished starting");
        }
        private void MainMenu_form_Resize(object sender, EventArgs e)
        {
            if (Controls.Contains(messagePanel))
            {
                messagePanel.Location = new Point((Width - messagePanel.Width) / 2, Height - messagePanel.Height - 80);
            }
        }
        private void MainMenu_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainControls_form.instance.CloseSerial();

            // Save logs in file
            if (Directory.Exists(Directories.logs_dir))
            {
                DateTime time = DateTime.Now;  // Get time
                int count = 0;
                string directory;

                while (true)
                {
                    if (count == 0)
                        directory = Directories.logs_dir + @"\" + time.Year + "-" + time.Month + "-" + time.Day + "-" + time.Hour + "-" + time.Minute + ".txt";
                    else
                        directory = Directories.logs_dir + @"\" + time.Year + "-" + time.Month + "-" + time.Day + "-" + time.Hour + "-" + time.Minute + "-" + count + ".txt";

                    if (!Directory.Exists(directory))
                    {
                        File.WriteAllText(directory, Log.logText);
                        break;
                    }
                    count++;
                }
            }

            // Ask the user to save
            if (BuildMachines_form.instance.areAnyChangesMade)
            {
                CustomMessageBoxResult result = CustomMessageBox.Show("Argo Studio", "There are unsaved changes. Do you want to save '" + ConfigureProject_form.instance.projectName + "'?", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNoCancel);
                if (result == CustomMessageBoxResult.Yes)
                {
                    BuildMachines_form.instance.Save();
                }
                else if (result == CustomMessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                    return; // Return so the temp directory is not deleted
                }
            }

            // Delete the temp directory
            Directories.DeleteDirectory(Directories.buildMachines_commands_temp_dir, true);
        }
        private void MainMenu_form_ResizeBegin(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }

        // Keyboard shortcuts
        private void MainMenu_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:  // Save
                        if (e.Shift)
                        {
                            CustomMessageBox.Show("Argo Studio", "You pressed CTRL SHIFT S.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        }
                        else  // Save as
                        {
                            CustomMessageBox.Show("Argo Studio", "You pressed CTRL S.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        }
                        break;

                    case Keys.C:  // Copy
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL C.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.X:  // Cut
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL X.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.V:  // Paste
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL V.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.H:  // Help
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL H.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.Y:  // Redo
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL Y.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.Z:  // Undo
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL Z.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.B:  // Make local backup
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL B.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.D:  // Duplicate
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL D.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.Add:  // Zoom in
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL +.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.Subtract:  // Zoom out
                        CustomMessageBox.Show("Argo Studio", "You pressed CTRL -.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        break;

                    case Keys.L:  // Open logs
                        OpenLogs();
                        break;
                }
            }

            else if (e.KeyCode == Keys.Delete)  // Delete
            {
                // If the Program Machines form is open
                if (MachineProgrammer_btn.Visible)
                {
                    CustomMessageBox.Show("Argo Studio", "You pressed Delete.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                }
            }
            else if (e.KeyCode == Keys.F2)  // Take screenshot
            {
                CustomMessageBox.Show("Argo Studio", "You pressed F2.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
            }
            else if (e.Alt & e.KeyCode == Keys.F4)  // Close program
            {
                CustomMessageBoxResult result = CustomMessageBox.Show("Argo Studio", "Are you sure you want to close Argo Studio? Your work will be saved.", CustomMessageBoxIcon.Exclamation, CustomMessageBoxButtons.YesNo);

                // Cancel close
                if (result == CustomMessageBoxResult.No)
                {
                    e.Handled = true;
                }
            }
        }

        // Cascading menus
        Guna2Panel menuToHide;
        private void HideMenu_timer_Tick(object sender, EventArgs e)
        {
            if (menuToHide.Parent != null)
            {
                menuToHide.Parent.Controls.Remove(menuToHide);
            }
            HideMenu_timer.Enabled = false;
        }
        public void OpenMenu()
        {
            HideMenu_timer.Enabled = false;
        }
        public void CloseMenu(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            menuToHide = (Guna2Panel)btn.Tag;
            HideMenu_timer.Enabled = false;
            HideMenu_timer.Enabled = true;
        }
        public void KeepMenuOpen(object sender, EventArgs e)
        {
            HideMenu_timer.Enabled = false;
        }


        // TOP BAR
        public readonly Form formBuildMachines = new BuildMachines_form(),
                             formMainControls = new MainControls_form(),
                             formSP = new SP_form(),
                             formIO = new IO_form(),
                             formVision = new Vision_form();

        public void SwitchMainForm(Form form, object btnSender)
        {
            Guna2Button btn = (Guna2Button)btnSender;
            // If the form is not already selected
            if (btn.FillColor != Color.FromArgb(15, 13, 74) & btn.FillColor != Color.Gray)
            {
                Main_panel.Controls.Clear();
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                Main_panel.Controls.Add(form);
                form.Show();
            }
        }

        // Workspace
        private void Workspace_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            UI.workspace_panel.Location = new Point(Workspace_btn.Parent.Left + Workspace_btn.Left, 105);
            Controls.Add(UI.workspace_panel);
            UI.workspace_panel.BringToFront();
        }

        // Menu
        private void Menu_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            UI.shouldPartsBack_panelOpen = true;
            OpenPartsBack_panel();
        }
        private void Menu_btn_MouseDown(object sender, MouseEventArgs e)
        {
            Menu_btn.Image = Resources.MenuWhite;
        }
        private void Menu_btn_MouseUp(object sender, MouseEventArgs e)
        {
            Menu_btn.Image = Resources.MenuGray;
        }

        // File
        private void File_btn_Click(object sender, EventArgs e)
        {
            if (Controls.Contains(UI.fileMenu))
            {
                Controls.Remove(UI.fileMenu);
            }
            else
            {
                UI.CloseAllPanels();
                File_btn.Image = Resources.FileWhite;
                UI.fileMenu.Location = new Point(File_btn.Left + PartsBack_panel.Width, 30);
                Controls.Add(UI.fileMenu);
                UI.fileMenu.BringToFront();
            }
        }

        // Save btn
        private void Save_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            Guna2Button saveBtn = (Guna2Button)UI.fileMenu.Controls[0].Controls.Find("Save", false).FirstOrDefault();
            saveBtn.PerformClick();
        }
        private void Save_btn_MouseDown(object sender, MouseEventArgs e)
        {
            Save_btn.Image = Resources.SaveWhite;
        }
        private void Save_btn_MouseUp(object sender, MouseEventArgs e)
        {
            Save_btn.Image = Resources.SaveGray;
        }

        // Help
        private void Help_btn_Click(object sender, EventArgs e)
        {
            if (Controls.Contains(UI.helpMenu))
            {
                Controls.Remove(UI.helpMenu);
            }
            else
            {
                UI.CloseAllPanels();
                Help_btn.Image = Resources.HelpWhite;
                UI.helpMenu.Location = new Point(Help_btn.Left - UI.helpMenu.Width + Help_btn.Width + PartsBack_panel.Width, 30);
                Controls.Add(UI.helpMenu);
                UI.helpMenu.BringToFront();
            }
        }

        // Profile
        private void Profile_btn_Click(object sender, EventArgs e)
        {
            if (Controls.Contains(UI.profileMenu))
            {
                Controls.Remove(UI.profileMenu);
            }
            else
            {
                UI.CloseAllPanels();
                UI.profileMenu.Location = new Point(Profile_btn.Left - UI.profileMenu.Width + Profile_btn.Width + PartsBack_panel.Width, 30);
                Controls.Add(UI.profileMenu);
                UI.profileMenu.BringToFront();
            }
        }

        // Close
        private void Close_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            ClosePartsBack_panel();
            UI.shouldPartsBack_panelOpen = false;
        }
        private void Close_btn_MouseDown(object sender, MouseEventArgs e)
        {
            ClosePartsBack_btn.Image = Resources.CloseWhite;
        }
        private void Close_btn_MouseUp(object sender, MouseEventArgs e)
        {
            ClosePartsBack_btn.Image = Resources.CloseGrey;
        }
        public static bool isPartsBack_panelOpen = true;
        public void ClosePartsBack_panel()
        {
            if (isPartsBack_panelOpen)
            {
                PartsBack_panel.Width = 0;
                MainTop_panel.Left = 0;
                Top_panel.Left = 0;
                Main_panel.Left = 0;
                MainTop_panel.Width = Width - 16;
                Top_panel.Width = Width - 16;
                Main_panel.Width = Width - 16;
                Menu_btn.Visible = true;
                isPartsBack_panelOpen = false;
            }
        }
        public void OpenPartsBack_panel()
        {
            if (!isPartsBack_panelOpen)
            {
                PartsBack_panel.Width = 300;
                MainTop_panel.Left = 300;
                Top_panel.Left = 300;
                Main_panel.Left = 300;
                MainTop_panel.Width = Width - 300 - 16;
                Top_panel.Width = Width - 300 - 16;
                Main_panel.Width = Width - 300 - 16;
                Menu_btn.Visible = false;
                isPartsBack_panelOpen = true;
            }
        }

        // Refresh
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

        }
        private void Refresh_btn_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh_btn.Image = Resources.RefreshWhite;
        }
        private void Refresh_btn_MouseUp(object sender, MouseEventArgs e)
        {
            Refresh_btn.Image = Resources.RefreshGray;
        }





        // ROBOT PROGRAMMER CONTROLS IN HEADER
        public Guna2Button RobotWorkspace_btn, Forward_btn, Backward_btn, Play_btn, RobotSpeed_btn, Upload_btn, Program_btn, Connect_btn,
            Servo_btn, IO_btn, Variabels_btn, Tabs_btn, Delay_btn, Motion_btn;
        public void ContructRobotProgrammerControls()
        {
            RobotWorkspace_btn = new Guna2Button
            {
                Name = "RobotWorkspace_btn",
                BackColor = Color.Transparent,
                BorderRadius = 3,
                BorderThickness = 2,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                Image = Resources.DownArrowFull,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(8, 8),
                Location = new Point(170, 9),
                Size = new Size(150, 60),
                TabIndex = 13,
                Text = "Main Controls",
                TextOffset = new Point(-10, 0)
            };
            RobotWorkspace_btn.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
                UI.robotProgrammerWorkspace_panel.Location = new Point(RobotWorkspace_btn.Parent.Left + RobotWorkspace_btn.Left, 105);
                Controls.Add(UI.robotProgrammerWorkspace_panel);
                UI.robotProgrammerWorkspace_panel.BringToFront();
            };
            MainTop_panel.Controls.Add(RobotWorkspace_btn);

            Forward_btn = new Guna2Button
            {
                Name = "Forward_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 11),
                Location = new Point(1232, 7),
                Size = new Size(60, 30),
                TabIndex = 28,
                Enabled = false
            };
            if (Theme.theme == "Dark")
                Forward_btn.Image = Resources.ForwardArrowWhite;
            else
                Forward_btn.Image = Resources.ForwardArrowBlack;

            Forward_btn.Click += (sender, e) =>
            {
                MainControls_form.instance.Forward();
            };
            MainTop_panel.Controls.Add(Forward_btn);

            Backward_btn = new Guna2Button
            {
                Name = "Backward_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 11),
                Location = new Point(1232, 42),
                Size = new Size(60, 30),
                TabIndex = 27,
                Enabled = false
            };
            if (Theme.theme == "Dark")
                Backward_btn.Image = Resources.BackArrowWhite;
            else
                Backward_btn.Image = Resources.BackArrowBlack;

            Backward_btn.Click += (sender, e) =>
            {
                MainControls_form.instance.Backward();
            };
            MainTop_panel.Controls.Add(Backward_btn);

            Play_btn = new Guna2Button
            {
                Name = "Play_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                BorderRadius = 3,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                Location = new Point(1135, 7),
                Size = new Size(90, 65),
                Text = "Play",
            };
            Play_btn.Click += (sender, e) =>
            {
                MainControls_form.instance.Play();
            };
            MainTop_panel.Controls.Add(Play_btn);

            Connect_btn = new Guna2Button
            {
                Name = "Connect_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                FillColor = CustomColors.background4,
                BorderRadius = 2,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10),
                ImageSize = new Size(18, 18),
                Location = new Point(965, 22),
                Size = new Size(30, 30),
            };
            if (Theme.theme == "Dark")
                Connect_btn.Image = Resources.PlugInWhite;
            else
                Connect_btn.Image = Resources.PlugInBlack;

            Connect_btn.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
                new ConnectRobot_form().ShowDialog();
            };
            MainTop_panel.Controls.Add(Connect_btn);

            Program_btn = new Guna2Button
            {
                Name = "Program_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                FillColor = CustomColors.background4,
                BorderRadius = 2,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                ImageSize = new Size(18, 18),
                Location = new Point(1005, 22),
                Size = new Size(30, 30),
            };
            if (Theme.theme == "Dark")
                Program_btn.Image = Resources.ProgramWhite;
            else
                Program_btn.Image = Resources.ProgramBlack;

            Program_btn.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
                new Program_form().ShowDialog();
            };
            MainTop_panel.Controls.Add(Program_btn);

            RobotSpeed_btn = new Guna2Button
            {
                Name = "RobotSpeed_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                FillColor = CustomColors.background4,
                BorderRadius = 2,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                ImageSize = new Size(18, 18),
                Location = new Point(1045, 22),
                Size = new Size(30, 30),
            };
            if (Theme.theme == "Dark")
                RobotSpeed_btn.Image = Resources.SpeedWhite;
            else
                RobotSpeed_btn.Image = Resources.SpeedBlack;

            RobotSpeed_btn.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
                new Speed_form().ShowDialog();
            };
            MainTop_panel.Controls.Add(RobotSpeed_btn);

            Upload_btn = new Guna2Button
            {
                Name = "Upload_btn",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.Transparent,
                FillColor = CustomColors.background4,
                BorderRadius = 2,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                ImageSize = new Size(18, 18),
                Location = new Point(1085, 22),
                Size = new Size(30, 30),
            };
            if (Theme.theme == "Dark")
                Upload_btn.Image = Resources.UploadWhite;
            else
                Upload_btn.Image = Resources.UploadBlack;

            Upload_btn.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
            };
            MainTop_panel.Controls.Add(Upload_btn);

            Motion_btn = new Guna2Button
            {
                Name = "Motion_btn",
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                Image = Resources.DownArrowBlack,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(7, 7),
                Left = 350,
                Size = new Size(90, 38),
                Text = "Motion",
                TextAlign = HorizontalAlignment.Left
            };
            Motion_btn.Top = MainTop_panel.Height - Motion_btn.Height;
            Motion_btn.Click += (sender, e) =>
            {
                CommandButtonClicked(MainControls_form.instance.motionMenu);
            };
            Motion_btn.MouseEnter += (sender, e) =>
            {
                CommandButtonMouseEnter(MainControls_form.instance.motionMenu);
            };
            MainTop_panel.Controls.Add(Motion_btn);

            Delay_btn = new Guna2Button
            {
                Name = "Delay_btn",
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                Image = Resources.DownArrowBlack,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(7, 7),
                Left = 446,
                Size = new Size(90, 38),
                Text = "Delay",
                TextAlign = HorizontalAlignment.Left,
            };
            Delay_btn.Top = MainTop_panel.Height - Delay_btn.Height;
            Delay_btn.Click += (sender, e) =>
            {
                CommandButtonClicked(MainControls_form.instance.delayMenu);
            };
            Delay_btn.MouseEnter += (sender, e) =>
            {
                CommandButtonMouseEnter(MainControls_form.instance.delayMenu);
            };
            MainTop_panel.Controls.Add(Delay_btn);

            Tabs_btn = new Guna2Button
            {
                Name = "Tabs_btn",
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                Image = Resources.DownArrowBlack,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(7, 7),
                Left = 542,
                Size = new Size(90, 38),
                Text = "Tabs",
                TextAlign = HorizontalAlignment.Left,
            };
            Tabs_btn.Top = MainTop_panel.Height - Tabs_btn.Height;
            Tabs_btn.Click += (sender, e) =>
            {
                CommandButtonClicked(MainControls_form.instance.tabsMenu);
            };
            Tabs_btn.MouseEnter += (sender, e) =>
            {
                CommandButtonMouseEnter(MainControls_form.instance.tabsMenu);
            };
            MainTop_panel.Controls.Add(Tabs_btn);

            Variabels_btn = new Guna2Button
            {
                Name = "Variabels_btn",
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                Image = Resources.DownArrowBlack,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(7, 7),
                Left = 638,
                Size = new Size(90, 38),
                Text = "Variables",
                TextAlign = HorizontalAlignment.Left,
            };
            Variabels_btn.Top = MainTop_panel.Height - Variabels_btn.Height;
            Variabels_btn.Click += (sender, e) =>
            {
                CommandButtonClicked(MainControls_form.instance.variablesMenu);
            };
            Variabels_btn.MouseEnter += (sender, e) =>
            {
                CommandButtonMouseEnter(MainControls_form.instance.variablesMenu);
            };
            MainTop_panel.Controls.Add(Variabels_btn);

            IO_btn = new Guna2Button
            {
                Name = "IO_btn",
                BackColor = Color.Transparent,
                BorderColor = Color.Gray,
                BorderRadius = 2,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                Image = Resources.DownArrowBlack,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(7, 7),
                Left = 734,
                Size = new Size(90, 38),
                Text = "IO",
                TextAlign = HorizontalAlignment.Left,
            };
            IO_btn.Top = MainTop_panel.Height - IO_btn.Height;
            IO_btn.Click += (sender, e) =>
            {
                CommandButtonClicked(MainControls_form.instance.IOMenu);
            };
            IO_btn.MouseEnter += (sender, e) =>
            {
                CommandButtonMouseEnter(MainControls_form.instance.IOMenu);
            };
            MainTop_panel.Controls.Add(IO_btn);

            Servo_btn = new Guna2Button
            {
                Name = "Servo_btn",
                BackColor = Color.Transparent,
                BorderRadius = 2,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                Enabled = false,
                Font = new Font("Segoe UI", 10),
                Image = Resources.DownArrowBlack,
                ImageAlign = HorizontalAlignment.Right,
                ImageSize = new Size(7, 7),
                Left = 830,
                Size = new Size(90, 38),
                Text = "Servo",
                TextAlign = HorizontalAlignment.Left,
            };
            Servo_btn.Top = MainTop_panel.Height - Servo_btn.Height;
            Servo_btn.Click += (sender, e) =>
            {
                CommandButtonClicked(MainControls_form.instance.servoMenu);
            };
            Servo_btn.MouseEnter += (sender, e) =>
            {
                CommandButtonMouseEnter(MainControls_form.instance.servoMenu);
            };
            MainTop_panel.Controls.Add(Servo_btn);
        }

        // Drop down command menus
        public bool isCommandMenuDown;
        private void CommandButtonClicked(Guna2Panel menu)
        {
            UI.CloseAllPanels();

            if (!MainControls_form.instance.Controls.Contains(menu))
            {
                MainControls_form.instance.Controls.Add(menu);
                menu.BringToFront();
                isCommandMenuDown = true;
            }
            else
            {
                MainControls_form.instance.Controls.Remove(menu);
                isCommandMenuDown = false;
            }
        }
        private void CommandButtonMouseEnter(Guna2Panel menu)
        {
            if (isCommandMenuDown)
            {
                CloseAllCommandMenus();
                MainControls_form.instance.Controls.Add(menu);
                menu.BringToFront();
                isCommandMenuDown = true;
            }
        }
        public void CloseAllCommandMenus()
        {
            MainControls_form.instance.Controls.Remove(MainControls_form.instance.motionMenu);
            MainControls_form.instance.Controls.Remove(MainControls_form.instance.delayMenu);
            MainControls_form.instance.Controls.Remove(MainControls_form.instance.tabsMenu);
            MainControls_form.instance.Controls.Remove(MainControls_form.instance.variablesMenu);
            MainControls_form.instance.Controls.Remove(MainControls_form.instance.IOMenu);
            MainControls_form.instance.Controls.Remove(MainControls_form.instance.servoMenu);
        }



        // DESIGN CONTROLS IN HEADER
        private MachineProgrammer_form MachineProgrammer_form;
        public bool isMachineProgrammerOpen, isAddRobotsMenuOpen;
        public Guna2Button MachineProgrammer_btn;
        public void ConstructMachineProgrammerBtn()
        {
            MachineProgrammer_btn = new Guna2Button
            {
                Anchor = AnchorStyles.Top,
                BorderRadius = 3,
                BackColor = Color.Transparent,
                BorderColor = CustomColors.controlBorder,
                BorderThickness = 1,
                Text = "Machine Programmer",
                Size = new Size(173, 32),
                Location = new Point(629, 9),
            };
            MachineProgrammer_btn.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
                if (!isMachineProgrammerOpen)
                {
                    MachineProgrammer_form = new MachineProgrammer_form();
                    MachineProgrammer_form.Show();
                    isMachineProgrammerOpen = true;
                }
                else MachineProgrammer_form.BringToFront();
            };

            MainTop_panel.Controls.Add(MachineProgrammer_btn);
        }



        // Add parts
        private bool SwitchDesignMenuBtn(object sender)
        {
            UI.CloseAllPanels();
            Guna2Button btn = (Guna2Button)sender;

            if (btn.FillColor == CustomColors.controlBack) // If it's not already selected
            {
                selectedDesignMenu.FillColor = CustomColors.controlBack;
                btn.FillColor = CustomColors.fileHover;
                selectedDesignMenu = btn;

                Back_btn.Visible = false;
                RemovePartsPanels();

                return true;
            }
            return false;
        }
        public void RemovePartsPanels()
        {
            PartsBack_panel.Controls.Remove(UI.argoParts_panel);
            PartsBack_panel.Controls.Remove(UI.myParts_panel);
            PartsBack_panel.Controls.Remove(UI.publicParts_panel);
            PartsBack_panel.Controls.Remove(UI.backBtnSelectedPanel);
        }
        private void ArgoParts_btn_Click(object sender, EventArgs e)
        {
            if (SwitchDesignMenuBtn(sender))
                PartsBack_panel.Controls.Add(UI.argoParts_panel);
        }
        private void MyParts_btn_Click(object sender, EventArgs e)
        {
            if (SwitchDesignMenuBtn(sender))
                PartsBack_panel.Controls.Add(UI.myParts_panel);
        }
        private void PublicParts_btn_Click(object sender, EventArgs e)
        {
            if (SwitchDesignMenuBtn(sender))
                PartsBack_panel.Controls.Add(UI.publicParts_panel);
        }
        private void Back_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            PartsBack_panel.Controls.Remove(UI.backBtnSelectedPanel);
            PartsBack_panel.Controls.Add(UI.argoParts_panel);
            Back_btn.Visible = false;
        }


        // Settings
        public void OpenSettingsMenu()
        {
            UI.CloseAllPanels();

            Main.Settings.Settings_form settingsForm = new Main.Settings.Settings_form();
            settingsForm.ShowDialog();
        }


        // Message panel
        public Guna2Panel messagePanel;
        public void ConstructMessage_panel()
        {
            messagePanel = new Guna2Panel
            {
                Size = new Size(500, 150),
                FillColor = CustomColors.mainBackground,
                BackColor = Color.Transparent,
                BorderThickness = 1,
                BorderRadius = 5,
                BorderColor = CustomColors.controlPanelBorder
            };

            Label messageLabel = new Label
            {
                Font = new Font("Segoe UI", 11),
                Location = new Point(10, 10),
                Size = new Size(480, 85),
                Name = "label",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = CustomColors.text
            };
            messageLabel.TextChanged += (sender, e) =>
            {
                if (messageLabel.Text != "")
                {
                    messagePanel.Location = new Point((Width - messagePanel.Width) / 2, Height - messagePanel.Height - 80);
                    Controls.Add(messagePanel);
                    messagePanel.BringToFront();
                    // Restart timer
                    MessagePanel_timer.Enabled = false;
                    MessagePanel_timer.Enabled = true;
                }
            };
            messagePanel.Controls.Add(messageLabel);

            Guna2Button gBtn = new Guna2Button
            {
                Font = new Font("Segoe UI", 11),
                Text = "Ok",
                Size = new Size(120, 35),
                Location = new Point(190, 100),
                FillColor = Color.FromArgb(58, 153, 236),  // Blue
                ForeColor = Color.White
            };
            gBtn.Click += MessagePanelClose;
            messagePanel.Controls.Add(gBtn);

            PictureBox picture = new PictureBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(470, 10),
                Size = new Size(15, 15),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Image = Resources.CloseGrey,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            picture.Click += MessagePanelClose;
            messagePanel.Controls.Add(picture);
        }
        public void SetMessage(string text)
        {
            Label label = (Label)messagePanel.Controls.Find("label", false).FirstOrDefault();
            label.Text = text;
        }
        private void MessagePanelClose(object sender, EventArgs e)
        {
            Controls.Remove(messagePanel);
            MessagePanel_timer.Enabled = false;
            // Reset in case the next message is the same
            SetMessage("");
        }
        private void MessagePanelTimer_Tick(object sender, EventArgs e)
        {
            Controls.Remove(messagePanel);
            MessagePanel_timer.Enabled = false;
            // Reset in case the next message is the same
            SetMessage("");
        }


        private Log_form formLog;
        public void OpenLogs()
        {
            if (!Log.isLogFormOpen)
            {
                formLog = new Log_form();
                formLog.Show();
                Log.isLogFormOpen = true;
            }
            else formLog.BringToFront();
        }



        // Misc.
        private void CloseAllPanels(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }
    }
}