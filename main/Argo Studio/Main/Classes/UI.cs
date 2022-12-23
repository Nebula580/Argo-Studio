using ArgoStudio.Main.BuildMachines;
using ArgoStudio.Main.BuildMachines.MachineProgrammer;
using ArgoStudio.Main.RobotProgrammer;
using ArgoStudio.Properties;
using Guna.UI2.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ArgoStudio.Main.Classes
{
    class UI
    {
        public static void ConstructControls()
        {
            // Main menu controls
            ConstructFileMenu();
            ConstructViewMenu();
            ConstructHelpMenu();
            ConstructProfileMenu();
            ConstructArgoParts_panels();
            ConstructMyParts_panel();
            ConstructPublicParts_panel();
            ConstructWorkspaceMenu();
            ConstructRobotProgrammerWorkspaceMenu();
            ConstructRightClickRename();
            MainMenu_form.instance.ConstructMessage_panel();

            // Machine Programmer controls
            MachineProgrammer.ConstructRightClickFilePanel();
            MachineProgrammer.ConstructRightClickFileBackPanel();
            MachineProgrammer.ConstructRightClickCommandPanel();
            MachineProgrammer.ConstructVariableBox();

            // Design controls
            MainMenu_form.instance.ConstructMachineProgrammerBtn();

            // Robot Programmer controls
            MainMenu_form.instance.ContructRobotProgrammerControls();
            MainControls_form.instance.ConstructRightClickTabMenu();
            MainControls_form.instance.ConstructRightClickTabBackMenu();
            MainControls_form.instance.ConstructRightClickDataGridViewRowMenu();
            MainControls_form.instance.ConstructRightClickRename_textbox();
            MainControls_form.instance.ConstructMotionMenu();
            MainControls_form.instance.ConstructDelayMenu();
            MainControls_form.instance.ConstructTabsMenu();
            MainControls_form.instance.ConstructVariablesMenu();
            MainControls_form.instance.ConstructIOMenu();
            MainControls_form.instance.ConstructServoMenu();
        }

        // Construct controls (mostly for commands in MachineProgrammer)
        public static Guna2Button ConstructCommand(Size size, int top, Control control)
        {
            Guna2Button command = new Guna2Button
            {
                Size = size,
                Location = new Point(13, top),
                BorderRadius = 3,
                BorderThickness = 1,
                BorderColor = CustomColors.controlBorder,
                FillColor = CustomColors.controlBack,
                PressedColor = CustomColors.controlBack,
                BackColor = Color.Transparent
            };
            command.HoverState.FillColor = CustomColors.controlBack;
            command.HoverState.BorderColor = CustomColors.controlBorder;
            command.CheckedState.FillColor = CustomColors.controlBack;
            command.DisabledState.FillColor = CustomColors.controlBack;

            control.Controls.Add(command);
            return command;
        }
        public static Guna2Button ConstructGBtn(Image image, string Text, int borderRadius, Size size, Point location, Control control)
        {
            Guna2Button gBtn = new Guna2Button
            {
                Location = location,
                Cursor = Cursors.Hand,
                BackColor = CustomColors.controlBack,
                FillColor = CustomColors.controlBack
            };

            if (image != null) { gBtn.Image = image; }

            if (Text != null) { gBtn.Font = new Font("Segoe UI", 10); gBtn.Text = Text; }

            if (size != new Size(0, 0)) { gBtn.Size = size; }
            else { gBtn.AutoSize = true; }

            if (borderRadius > 0) { gBtn.BorderRadius = borderRadius; }

            gBtn.Click += CloseAllPanels;
            control.Controls.Add(gBtn);
            return gBtn;
        }
        public static Guna2ComboBox ConstructGComboBox(Size size, Point location, Control control)
        {
            Guna2ComboBox gComboBox = new Guna2ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = location,
                Size = size,
                BorderRadius = 3,
                Cursor = Cursors.Hand,
                FillColor = CustomColors.controlBack,
                BorderColor = CustomColors.controlBorder,
                ForeColor = CustomColors.text
            };
            gComboBox.HoverState.BorderColor = CustomColors.accent_blue;
            gComboBox.FocusedState.BorderColor = CustomColors.accent_blue;
            gComboBox.Click += CloseAllPanels;
            gComboBox.MouseWheel += Combobox_MouseWheel;
            control.Controls.Add(gComboBox);
            return gComboBox;
        }
        public static void Combobox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Scroll selectedCommandBack up
                if (MachineProgrammer.selectedCommandBack.VerticalScroll.Value - e.Delta > 0)
                    MachineProgrammer.selectedCommandBack.VerticalScroll.Value -= e.Delta;
                else
                    MachineProgrammer.selectedCommandBack.VerticalScroll.Value = 0;
            }
            else
            {
                // Scroll selectedCommandBack down
                if (MachineProgrammer.selectedCommandBack.VerticalScroll.Value + e.Delta < MachineProgrammer.selectedCommandBack.VerticalScroll.Maximum)
                    MachineProgrammer.selectedCommandBack.VerticalScroll.Value -= e.Delta;
                else
                    MachineProgrammer.selectedCommandBack.VerticalScroll.Value = 0;
            }

            // Update the scroll bar location
            MachineProgrammer.selectedCommandBack.PerformLayout();

            // Disable scroll on ComboBox
            ((HandledMouseEventArgs)e).Handled = true;
        }
        /// </summary>
        public static Guna2TextBox ConstructGTextBox(bool numbersAndLettersOnly, Size size, Point location, Control control)
        {
            // https://stackoverflow.com/questions/16684406/how-to-disable-the-right-click-context-menu-on-textboxes-in-windows-using-c

            Guna2TextBox gTextBox = new Guna2TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = location,
                MaxLength = 16,
                FillColor = CustomColors.controlBack,
                ForeColor = CustomColors.text,
                Size = size,
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3,
                Cursor = Cursors.Hand,
                ContextMenu = new ContextMenu()  // This disables the right click menu, but still allows keyboard shortcuts
            };
            gTextBox.FocusedState.FillColor = CustomColors.controlBack;
            gTextBox.HoverState.BorderColor = CustomColors.accent_blue;
            gTextBox.FocusedState.BorderColor = CustomColors.accent_blue;
            gTextBox.Click += CloseAllPanels;
            gTextBox.Enter += (sender, e) =>
            {
                Guna2TextBox senderTextBox = (Guna2TextBox)sender;
                senderTextBox.SelectionStart = senderTextBox.Text.Length;
                senderTextBox.SelectionLength = 0;
            };
            // Only allow numbers and letters
            if (numbersAndLettersOnly)
            {
                gTextBox.KeyPress += (sender, e) =>
                {
                    bool pass = false;
                    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        pass = true;
                    }

                    e.Handled = pass;
                };
            }
            gTextBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Remove Windows "ding" noise when user presses enter
                    e.SuppressKeyPress = true;

                    // Unselect the textBox
                    if (MainMenu_form.instance.isMachineProgrammerOpen)
                    {
                        MachineProgrammer_form.instance.Back_panel.Focus();
                    }
                }
            };

            control.Controls.Add(gTextBox);
            return gTextBox;
        }
        public static Guna2CircleButton ConstructGCircleBtn(Image image, Size size, Point location, Control control)
        {
            Guna2CircleButton gCircleBtn = new Guna2CircleButton
            {
                BackColor = CustomColors.controlBack,
                FillColor = CustomColors.controlBack,
                Font = new Font("Segoe UI", 10),
                Location = location,
                Size = size,
                Image = image,
                ImageSize = new Size(22, 22),
                ImageOffset = new Point(1, 0),
                Cursor = Cursors.Hand
            };
            gCircleBtn.Click += CloseAllPanels;
            control.Controls.Add(gCircleBtn);
            return gCircleBtn;
        }
        public static Label ConstructLabel(string text, short fontSize, bool bold, Point location, string name, Control control)
        {
            Label label = new Label
            {
                BackColor = Color.Transparent,
                ForeColor = CustomColors.text,
                Cursor = Cursors.Arrow,
                Location = location,
                Text = text
            };
            if (name != "")
            {
                label.Name = name;
            }
            label.Click += CloseAllPanels;
            control.Controls.Add(label);

            if (bold) { label.Font = new Font("Segoe UI", fontSize, FontStyle.Bold); }
            else { label.Font = new Font("Segoe UI", fontSize); }
            return label;
        }
        public static Label ConstructNumberLabel(string text, string tag, Control control)
        {
            Label label = new Label
            {
                Font = new Font("Segoe UI", 12),
                BackColor = CustomColors.controlBack,
                ForeColor = CustomColors.text,
                Cursor = Cursors.Arrow,
                Location = new Point(5, 5),
                TextAlign = ContentAlignment.MiddleLeft,
                Name = "numberLabel",
                Tag = tag,
                Text = text,
                AutoSize = true
            };
            label.Click += CloseAllPanels;
            control.Controls.Add(label);
            return label;
        }
        public static PictureBox ConstructPicture(Image image, Size size, Point location, Control control)
        {
            PictureBox picture = new PictureBox
            {
                Location = location,
                BackColor = CustomColors.controlBack,
                Size = size,
                BorderStyle = BorderStyle.None,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            picture.Click += CloseAllPanels;
            control.Controls.Add(picture);
            return picture;
        }
        public static FlowLayoutPanel ConstructFlowPanel(Size size, Point location, Control control)
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Location = location,
                Size = size,
                BackColor = CustomColors.mainBackground,
                Padding = new Padding(0),
            };
            flowPanel.Click += CloseAllPanels;
            control.Controls.Add(flowPanel);
            return flowPanel;
        }
        private static Guna2CircleButton ConstructHelpButton(Point location, Control control)
        {
            Guna2CircleButton circleButton = new Guna2CircleButton
            {
                Location = location,
                Size = new Size(20, 20),
                Image = Resources.HelpBlue,
                BackColor = Color.Transparent,
                Padding = new Padding(0),
            };
            control.Controls.Add(circleButton);
            return circleButton;
        }


        // Conatruct controls for MainControls_form
        public static Guna2Panel ConstructGPanelMainControls(Size size, int left, Control control)
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                Left = left,
                Size = size,
                BackColor = CustomColors.controlBack,
                Padding = new Padding(0),
                BorderColor = CustomColors.text,
                BorderRadius = 3,
                BorderThickness = 1
            };
            control.Controls.Add(gPanel);
            return gPanel;
        }
        public static Guna2Button ConstructGButtonForMainControls(string text, int top, Control control)
        {
            Guna2Button gBtn = new Guna2Button
            {
                Location = new Point(10, top),
                Height = 30,
                Text = text,
                Font = new Font("Segoe UI", 11),
                FillColor = CustomColors.controlBack,
                ForeColor = CustomColors.text,
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3,
                BorderThickness = 1,
                Width = 160,
                Cursor = Cursors.Hand
            };
            control.Controls.Add(gBtn);
            return gBtn;
        }
        public static Guna2ComboBox ConstructGComboBoxForMainControls(Point location, string name, Control control)
        {
            Guna2ComboBox gComboBox = new Guna2ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = location,
                Width = 152,
                ForeColor = CustomColors.text,
                BorderColor = CustomColors.controlBorder,
                BorderThickness = 1,
                Name = name,
                Cursor = Cursors.Hand,
                FillColor = CustomColors.controlBack,
            };
            gComboBox.HoverState.BorderColor = CustomColors.accent_blue;
            gComboBox.FocusedState.BorderColor = CustomColors.accent_blue;

            control.Controls.Add(gComboBox);
            return gComboBox;
        }
        public static Guna2TextBox ConstructGTextBoxForMainControls(Point location, byte maxLength, string name, Control control)
        {
            Guna2TextBox gTextBox = new Guna2TextBox
            {
                Font = new Font("Segoe UI", 11),
                Location = location,
                Size = new Size(55, 30),
                BorderColor = CustomColors.controlBorder,
                ForeColor = CustomColors.text,
                BorderThickness = 1,
                MaxLength = maxLength,
                Name = name,
                Cursor = Cursors.Hand,
                FillColor = CustomColors.controlBack,
                ShortcutsEnabled = false,
            };
            gTextBox.HoverState.BorderColor = CustomColors.accent_blue;
            gTextBox.FocusedState.BorderColor = CustomColors.accent_blue;

            control.Controls.Add(gTextBox);
            return gTextBox;
        }
        public static void ConstructLabelForMainControls(int width, Point location, string text, Control control)
        {
            Label label = new Label
            {
                Location = location,
                Text = text,
                Width = width,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = CustomColors.text,
                BackColor = Color.Transparent
            };
            control.Controls.Add(label);
        }



        // Construct things for menus
        public static Guna2Panel ConstructPanelForMenu(Size size)
        {
            Guna2Panel panel = new Guna2Panel
            {
                BorderStyle = DashStyle.Solid,
                BorderColor = CustomColors.controlPanelBorder,
                BorderThickness = 1,
                BorderRadius = 4,
                FillColor = CustomColors.panelBtn,
                Size = size
            };
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                BackColor = CustomColors.panelBtn,
                Size = new Size(size.Width - 10, size.Height - 10),
                Location = new Point(5, 5)
            };
            panel.Controls.Add(flowLayoutPanel);
            return panel;
        }
        private static Guna2Separator CosntructSeperator(int width, Control control)
        {
            Guna2Separator seperator = new Guna2Separator
            {
                FillColor = CustomColors.controlBorder,
                BackColor = Color.Transparent,
                Size = new Size(width, 1),
                Margin = new Padding(0, 5, 0, 5)
            };
            control.Controls.Add(seperator);
            return seperator;
        }
        public static Guna2Button ConstructBtnForMenu(string text, int width, bool closeAllPanels, Control control)
        {
            Guna2Button menuBtn = new Guna2Button
            {
                Size = new Size(width, 22),
                FillColor = CustomColors.panelBtn,
                ForeColor = CustomColors.text,
                TextAlign = HorizontalAlignment.Left,
                Font = new Font("Segoe UI", 10),
                Text = text,
                Cursor = Cursors.Hand,
                Margin = new Padding(0),
                BorderColor = CustomColors.controlBorder
            };
            menuBtn.HoverState.BorderColor = CustomColors.controlBorder;
            menuBtn.HoverState.FillColor = CustomColors.panelBtnHover;
            menuBtn.PressedColor = CustomColors.panelBtnHover;
            if (closeAllPanels)
            {
                menuBtn.Click += CloseAllPanels;
            }

            menuBtn.MouseEnter += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                Label label = (Label)btn.Controls.Find("label", false).FirstOrDefault();
                if (label != null)
                {
                    label.BackColor = CustomColors.panelBtnHover;
                }
                btn.BorderThickness = 1;
            };
            menuBtn.MouseLeave += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                Label label = (Label)btn.Controls.Find("label", false).FirstOrDefault();
                if (label != null)
                {
                    label.BackColor = CustomColors.panelBtn;
                }
                btn.BorderThickness = 0;
            };

            control.Controls.Add(menuBtn);
            return menuBtn;
        }

        private static void ConstructKeyShortcut(string text, int width, Control control)
        {
            Label KeyShortcut = new Label
            {
                ForeColor = CustomColors.text,
                BackColor = CustomColors.controlBack,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleRight,
                Height = 20,
                Top = 1,
                Name = "label",
                Text = text
            };
            if (width == 0)
            {
                KeyShortcut.Width = 60;
            }
            else { KeyShortcut.Width = width; }
            KeyShortcut.Left = control.Width - KeyShortcut.Width - 15;

            KeyShortcut.MouseEnter += (sender, e) =>
            {
                Label label = (Label)sender;
                label.BackColor = CustomColors.panelBtnHover;
                Guna2Button btn = (Guna2Button)label.Parent;
                btn.FillColor = CustomColors.panelBtnHover;
                btn.BorderThickness = 1;
            };
            KeyShortcut.MouseLeave += (sender, e) =>
            {
                Label label = (Label)sender;
                label.BackColor = CustomColors.panelBtn;
                Guna2Button btn = (Guna2Button)label.Parent;
                btn.FillColor = CustomColors.panelBtn;
                btn.BorderThickness = 0;
            };
            KeyShortcut.MouseUp += (sender, e) =>
            {
                Label label = (Label)sender;
                Guna2Button btn = (Guna2Button)label.Parent;
                btn.PerformClick();
            };
            control.Controls.Add(KeyShortcut);
        }

        // fileMenu
        public static Guna2Panel fileMenu, viewMenu;
        private static void ConstructFileMenu()
        {
            fileMenu = ConstructPanelForMenu(new Size(250, 9 * 22 + 10 + 20));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)fileMenu.Controls[0];

            Guna2Button menuBtn = ConstructBtnForMenu("New design", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };

            menuBtn = ConstructBtnForMenu("Open", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };

            menuBtn = ConstructBtnForMenu("Upload", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };

            CosntructSeperator(240, flowPanel);

            menuBtn = ConstructBtnForMenu("Save", 240, true, flowPanel);
            menuBtn.Name = "Save";
            menuBtn.Click += (sender, e) =>
            {
                BuildMachines_form.instance.Save();
            };
            ConstructKeyShortcut("Ctrl+S", 0, menuBtn);

            menuBtn = ConstructBtnForMenu("Save as", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                BuildMachines_form.instance.SaveAs();
            };
            ConstructKeyShortcut("Ctrl+Shift+S", 80, menuBtn);

            menuBtn = ConstructBtnForMenu("Save as latest", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                BuildMachines_form.instance.SaveAsLatest();
            };

            menuBtn = ConstructBtnForMenu("Make local backup", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+B", 0, menuBtn);

            CosntructSeperator(240, flowPanel);

            menuBtn = ConstructBtnForMenu("Capture image", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("F2", 0, menuBtn);

            menuBtn = ConstructBtnForMenu("View", 240, false, flowPanel);
            menuBtn.Image = Resources.RightArrowGray;
            menuBtn.ImageSize = new Size(11, 11);
            menuBtn.ImageOffset = new Point(103, 0);
            menuBtn.Click += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                SetViewMenu();
                btn.Tag = viewMenu;
                MainMenu_form.instance.OpenMenu();
            };
            menuBtn.MouseEnter += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                SetViewMenu();
                btn.Tag = viewMenu;
            };
            menuBtn.MouseLeave += MainMenu_form.instance.CloseMenu;
        }
        private static void ConstructViewMenu()
        {
            viewMenu = ConstructPanelForMenu(new Size(280, 6 * 22 + 10 + 10));
            viewMenu.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)viewMenu.Controls[0];

            Guna2Button menuBtn = ConstructBtnForMenu("Hide ViewCube", 270, true, flowPanel);
            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+V+C", 0, menuBtn);

            menuBtn = ConstructBtnForMenu("Hide ", 270, true, flowPanel);
            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+V+", 0, menuBtn);

            menuBtn = ConstructBtnForMenu("Hide ", 270, true, flowPanel);
            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+V+", 0, menuBtn);

            menuBtn = ConstructBtnForMenu("Show logs", 270, true, flowPanel);
            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+V+", 0, menuBtn);

            menuBtn = ConstructBtnForMenu("Hide", 270, true, flowPanel);
            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+V+", 0, menuBtn);

            CosntructSeperator(240, flowPanel);

            menuBtn = ConstructBtnForMenu("Reset to default layout", 270, true, flowPanel);
            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
            menuBtn.Click += (sender, e) =>
            {

            };
            ConstructKeyShortcut("Ctrl+V+R", 0, menuBtn);
        }
        private static void SetViewMenu()
        {
            if (!MainMenu_form.instance.Controls.Contains(viewMenu))
            {
                viewMenu.Location = new Point(fileMenu.Left + fileMenu.Width, fileMenu.Top + fileMenu.Height - 22 - 5);
                MainMenu_form.instance.Controls.Add(viewMenu);
                viewMenu.BringToFront();
            }
        }

        // helpMenu
        public static Guna2Panel helpMenu;
        private static void ConstructHelpMenu()
        {
            helpMenu = ConstructPanelForMenu(new Size(250, 6 * 22 + 10 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)helpMenu.Controls[0];

            Guna2Button menuBtn = ConstructBtnForMenu("Support", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                Process.Start("https://www.support.argorobots.ca");
            };
            menuBtn = ConstructBtnForMenu("Forums", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                Process.Start("https://www.support.argorobots.ca");
            };
            menuBtn = ConstructBtnForMenu("Troubleshooting", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                Process.Start("https://www.support.argorobots.ca");
            };
            menuBtn = ConstructBtnForMenu("Show logs", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.OpenLogs();
            };

            CosntructSeperator(240, flowPanel);

            menuBtn = ConstructBtnForMenu("What's new", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                Process.Start("https://www.argorobots.ca/software/argo-studio/whats-new/index.html");
            };
            menuBtn = ConstructBtnForMenu("About", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                Process.Start("https://www.argorobots.ca/about-us/index.html");
            };
        }

        // profileMenu
        public static Guna2Panel profileMenu;
        private static void ConstructProfileMenu()
        {
            profileMenu = ConstructPanelForMenu(new Size(250, 4 * 22 + 10 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)profileMenu.Controls[0];

            Guna2Button menuBtn = ConstructBtnForMenu("Argo account", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                Process.Start("https://www.argorobots.ca/my-account/profile/index.html");
            };

            menuBtn = ConstructBtnForMenu("Settings", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.OpenSettingsMenu();
            };

            menuBtn = ConstructBtnForMenu("Share feedback", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };

            CosntructSeperator(240, flowPanel);

            menuBtn = ConstructBtnForMenu("Sign out", 240, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };
        }



        // Construct things for other menus
        public static void ConstructLabelForMenus(Point location, string text, Control control)
        {
            Label label = new Label
            {
                Location = location,
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI", 11),
                BackColor = CustomColors.controlBack,
                ForeColor = CustomColors.text
            };
            control.Controls.Add(label);
        }
        public static Guna2TextBox ConstructGTextBoxForMenus(Point location, string text, Control control)
        {
            Guna2TextBox gTextBox = new Guna2TextBox
            {
                Font = new Font("Segoe UI", 11),
                Location = location,
                Size = new Size(55, 30),
                BorderColor = CustomColors.controlBorder,
                ForeColor = CustomColors.text,
                BorderThickness = 1,
                MaxLength = 3,
                Text = text,
                Cursor = Cursors.Hand,
                FillColor = CustomColors.controlBack,
                ShortcutsEnabled = false,
            };
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.HoverState.BorderColor = CustomColors.accent_blue;
            gTextBox.FocusedState.BorderColor = CustomColors.accent_blue;

            control.Controls.Add(gTextBox);
            return gTextBox;
        }



        // Workspace button
        public static Guna2Panel workspace_panel;
        public static Guna2Button Design_btn;
        public static bool shouldPartsBack_panelOpen = true;
        private static void ConstructWorkspaceMenu()
        {
            workspace_panel = ConstructPanelForMenu(new Size(200, 2 * 35 + 13 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)workspace_panel.Controls[0];

            Guna2Button menuBtn = ConstructBtnForMenu("DESIGN", 0, true, flowPanel);
            menuBtn.Size = new Size(190, 35);
            menuBtn.Click += (sender, e) =>
            {
                CloseAllPanels();
                if (shouldPartsBack_panelOpen)
                    MainMenu_form.instance.OpenPartsBack_panel();
                else
                    MainMenu_form.instance.Menu_btn.Visible = true;

                MainMenu_form.instance.RobotWorkspace_btn.Visible = false;
                MainMenu_form.instance.MachineProgrammer_btn.Visible = true;
                MainMenu_form.instance.Motion_btn.Visible = false;
                MainMenu_form.instance.Delay_btn.Visible = false;
                MainMenu_form.instance.Tabs_btn.Visible = false;
                MainMenu_form.instance.Variabels_btn.Visible = false;
                MainMenu_form.instance.IO_btn.Visible = false;
                MainMenu_form.instance.Servo_btn.Visible = false;
                MainMenu_form.instance.Connect_btn.Visible = false;
                MainMenu_form.instance.Program_btn.Visible = false;
                MainMenu_form.instance.RobotSpeed_btn.Visible = false;
                MainMenu_form.instance.Upload_btn.Visible = false;

                MainMenu_form.instance.Play_btn.Visible = false;
                MainMenu_form.instance.Forward_btn.Visible = false;
                MainMenu_form.instance.Backward_btn.Visible = false;

                MainMenu_form.instance.Workspace_btn.Text = "Design";
                MainMenu_form.instance.Workspace_btn.ImageOffset = new Point(40, 0);

                MainMenu_form.instance.SwitchMainForm(MainMenu_form.instance.formBuildMachines, sender);
            };
            Design_btn = menuBtn;

            CosntructSeperator(190, flowPanel);

            menuBtn = ConstructBtnForMenu("ROBOT PROGRAMMER", 0, true, flowPanel);
            menuBtn.Size = new Size(190, 35);
            menuBtn.Click += (sender, e) =>
            {
                CloseAllPanels();
                MainMenu_form.instance.ClosePartsBack_panel();
                MainMenu_form.instance.RobotWorkspace_btn.Visible = true;
                MainMenu_form.instance.MachineProgrammer_btn.Visible = false;
                MainMenu_form.instance.Motion_btn.Visible = true;
                MainMenu_form.instance.Delay_btn.Visible = true;
                MainMenu_form.instance.Tabs_btn.Visible = true;
                MainMenu_form.instance.Variabels_btn.Visible = true;
                MainMenu_form.instance.IO_btn.Visible = true;
                MainMenu_form.instance.Servo_btn.Visible = true;
                MainMenu_form.instance.Play_btn.Visible = true;
                MainMenu_form.instance.Forward_btn.Visible = true;
                MainMenu_form.instance.Backward_btn.Visible = true;
                MainMenu_form.instance.Connect_btn.Visible = true;
                MainMenu_form.instance.Program_btn.Visible = true;
                MainMenu_form.instance.RobotSpeed_btn.Visible = true;
                MainMenu_form.instance.Upload_btn.Visible = true;

                MainMenu_form.instance.Workspace_btn.Text = "Robot Programmer";
                MainMenu_form.instance.Workspace_btn.ImageOffset = new Point(7, 0);
                MainMenu_form.instance.Menu_btn.Visible = false;

                MainMenu_form.instance.SwitchMainForm(MainMenu_form.instance.formMainControls, sender);
            };
        }

        // Robot Programmer workspace
        public static Guna2Panel robotProgrammerWorkspace_panel;
        public static Guna2Button mainControls_btn;
        private static void ConstructRobotProgrammerWorkspaceMenu()
        {
            robotProgrammerWorkspace_panel = ConstructPanelForMenu(new Size(200, 4 * 35 + 15 + 30));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)robotProgrammerWorkspace_panel.Controls[0];

            Guna2Button menuBtn = ConstructBtnForMenu("Main Controls", 0, true, flowPanel);
            menuBtn.Size = new Size(190, 35);
            menuBtn.Click += (sender, e) =>
            {
                CloseAllPanels();
                MainMenu_form.instance.RobotWorkspace_btn.Text = "Main Controls";
                MainMenu_form.instance.SwitchMainForm(MainMenu_form.instance.formMainControls, sender);
            };
            mainControls_btn = menuBtn;

            CosntructSeperator(190, flowPanel);

            menuBtn = ConstructBtnForMenu("Stored Positions", 0, true, flowPanel);
            menuBtn.Size = new Size(190, 35);
            menuBtn.Click += (sender, e) =>
            {
                CloseAllPanels();
                MainMenu_form.instance.RobotWorkspace_btn.Text = "Stored Positions";
                MainMenu_form.instance.SwitchMainForm(MainMenu_form.instance.formSP, sender);
            };

            CosntructSeperator(190, flowPanel);

            menuBtn = ConstructBtnForMenu("Inputs Outputs", 0, true, flowPanel);
            menuBtn.Size = new Size(190, 35);
            menuBtn.Click += (sender, e) =>
            {
                CloseAllPanels();
                MainMenu_form.instance.RobotWorkspace_btn.Text = "Inputs Outputs";
                MainMenu_form.instance.SwitchMainForm(MainMenu_form.instance.formIO, sender);
            };

            CosntructSeperator(190, flowPanel);

            menuBtn = ConstructBtnForMenu("Vision", 0, true, flowPanel);
            menuBtn.Size = new Size(190, 35);
            menuBtn.Click += (sender, e) =>
            {
                CloseAllPanels();
                MainMenu_form.instance.RobotWorkspace_btn.Text = "Vision";
                MainMenu_form.instance.SwitchMainForm(MainMenu_form.instance.formVision, sender);
            };
        }



        // Parts
        public static FlowLayoutPanel argoParts_panel, myParts_panel, publicParts_panel,  // Main panels
           machineController_panel, aluminumExtrusion_panel, aluminumExtrusionConnectors_panel, aluminumExtrusionAccessories_panel,
           stepperMotors_panel, motorDrivers_panel, motorAccessories_panel, gearBoxes_panel, panels_panel,  // Argo parts panels
           backBtnSelectedPanel;
        private static void ConstructPartTitle(string text, Control control)
        {
            Label label = new Label
            {
                ForeColor = CustomColors.text,
                Cursor = Cursors.Arrow,
                Text = text,
                Top = 70,
                Size = new Size(275, 40),
                Font = new Font("Segoe UI", 13)
            };
            label.Click += CloseAllPanels;
            control.Controls.Add(label);
        }
        private static Guna2Button ConstructArgoPartsItem(Control control, string text)
        {
            Panel argoPartsPanelItem = new Panel
            {
                Size = new Size(80, 130),
                Margin = new Padding(4),
                Cursor = Cursors.Hand
            };
            control.Controls.Add(argoPartsPanelItem);

            Guna2Button gBtn = new Guna2Button
            {
                FillColor = CustomColors.controlBack,
                Size = new Size(70, 70),
                BorderRadius = 2,
                Left = 5
            };
            gBtn.Click += CloseAllPanels;
            argoPartsPanelItem.Controls.Add(gBtn);

            Label label = new Label
            {
                ForeColor = CustomColors.text,
                Cursor = Cursors.Arrow,
                Text = text,
                Top = 70,
                Size = new Size(80, 60),
                TextAlign = ContentAlignment.TopCenter,
                Font = new Font("Segoe UI", 10)
            };
            label.Click += CloseAllPanels;
            argoPartsPanelItem.Controls.Add(label);
            return gBtn;
        }
        private static FlowLayoutPanel ConstructFlowPanelForParts()
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Location = new Point(11, 270),
                Size = new Size(275, 630),
                Padding = new Padding(5),
                BackColor = CustomColors.mainBackground
            };
            return flowPanel;
        }
        private static void ConstructArgoParts_panels()
        {
            Guna2Button gBtn;
            argoParts_panel = ConstructFlowPanelForParts();

            // Label
            ConstructPartTitle("Argo parts", argoParts_panel);


            // Machine controller            
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Machine\r\ncontrollers");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = machineController_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            machineController_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Machine controllers", machineController_panel);
            gBtn = ConstructArgoPartsItem(machineController_panel, "Small machine\r\ncontroller");


            // Aluminum extrusion
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Aluminum\r\nextrusion");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = aluminumExtrusion_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            aluminumExtrusion_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Aluminum extrusion", aluminumExtrusion_panel);
            gBtn = ConstructArgoPartsItem(aluminumExtrusion_panel, "2020\r\nT-Slot");
            gBtn = ConstructArgoPartsItem(aluminumExtrusion_panel, "2040\r\nT-Slot");
            gBtn = ConstructArgoPartsItem(aluminumExtrusion_panel, "2060\r\nT-Slot");
            gBtn = ConstructArgoPartsItem(aluminumExtrusion_panel, "3030\r\nT-Slot");
            gBtn = ConstructArgoPartsItem(aluminumExtrusion_panel, "4040\r\nT-Slot");
            gBtn = ConstructArgoPartsItem(aluminumExtrusion_panel, "4080\r\nT-Slot");


            // Aluminum extrusion connectors
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Aluminum\r\nextrusion\r\nconnectors");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = aluminumExtrusionConnectors_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            aluminumExtrusionConnectors_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Aluminum extrusion connectors", aluminumExtrusionConnectors_panel);
            gBtn = ConstructArgoPartsItem(aluminumExtrusionConnectors_panel, "2020\r\ncorner\r\nbracket");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionConnectors_panel, "2020\r\n90 degree\r\ncorner");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionConnectors_panel, "3030\r\nCorner\r\nbracket");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionConnectors_panel, "3030\r\n90 degree\r\ncorner");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionConnectors_panel, "4040\r\ncorner\r\nbracket");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionConnectors_panel, "4080\r\n90 degree\r\ncorner");


            // Aluminum extrusion accessories
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Aluminum\r\nextrusion\r\nccessories");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = aluminumExtrusionAccessories_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            aluminumExtrusionAccessories_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Aluminum extrusion accessories", aluminumExtrusionAccessories_panel);
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "Handle");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "2020 end cap");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "2040 end cap");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "3030 end cap");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "4040 end cap");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "4080 end cap");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "Hinge");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "Door hinge");
            gBtn = ConstructArgoPartsItem(aluminumExtrusionAccessories_panel, "Small door\r\nhinge");


            // Stepper motors
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Stepper\r\nmotors");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = stepperMotors_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            stepperMotors_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Stepper motors", stepperMotors_panel);
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 17\r\ntype 1");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 17\r\ntype 2");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 17\r\ntype 3");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 23\r\ntype 1");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 23\r\ntype 2");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 34\r\ntype 1");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 34\r\ntype 2");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 34\r\ntype 3");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 42\r\ntype 1");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 42\r\ntype 2");
            gBtn = ConstructArgoPartsItem(stepperMotors_panel, "Nema 42\r\ntype 3");


            // Motor drivers
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Motor\r\ndrivers");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = motorDrivers_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            motorDrivers_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Motor drivers", motorDrivers_panel);
            gBtn = ConstructArgoPartsItem(motorDrivers_panel, "DM320T");
            gBtn = ConstructArgoPartsItem(motorDrivers_panel, "DM542T");
            gBtn = ConstructArgoPartsItem(motorDrivers_panel, "DM860T");


            // Motor accessories            
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Motor\r\naccessories");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = motorAccessories_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            motorAccessories_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Motor accessories", motorAccessories_panel);
            gBtn = ConstructArgoPartsItem(motorAccessories_panel, "Nema 17\r\nbracket");
            gBtn = ConstructArgoPartsItem(motorAccessories_panel, "Nema 23\r\nbracket");
            gBtn = ConstructArgoPartsItem(motorAccessories_panel, "Nema 34\r\nbracket");
            gBtn = ConstructArgoPartsItem(motorAccessories_panel, "Nema 42\r\nbracket");

            // Gearboxes            
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Gearboxes");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = gearBoxes_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            gearBoxes_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Gearboxes", gearBoxes_panel);
            gBtn = ConstructArgoPartsItem(gearBoxes_panel, "Nema 17\r\ngearbox");
            gBtn = ConstructArgoPartsItem(gearBoxes_panel, "Nema 23\r\ngearbox");
            gBtn = ConstructArgoPartsItem(gearBoxes_panel, "Nema 34\r\ngearbox");
            gBtn = ConstructArgoPartsItem(gearBoxes_panel, "Nema 42\r\ngearbox");


            // Panels
            gBtn = ConstructArgoPartsItem(argoParts_panel, "Panels");
            gBtn.Click += (sender, e) =>
            {
                MainMenu_form.instance.RemovePartsPanels();
                MainMenu_form.instance.Back_btn.Visible = true;
                backBtnSelectedPanel = panels_panel;
                MainMenu_form.instance.PartsBack_panel.Controls.Add(backBtnSelectedPanel);
            };
            panels_panel = ConstructFlowPanelForParts();
            ConstructPartTitle("Panels", panels_panel);
            gBtn = ConstructArgoPartsItem(panels_panel, "HDPE\r\nPanels");
            gBtn = ConstructArgoPartsItem(panels_panel, "Acrylic 23\r\nPanels");
            gBtn = ConstructArgoPartsItem(panels_panel, "Aluminum 34\r\nPanels");
            gBtn = ConstructArgoPartsItem(panels_panel, "Steel\r\nPanels");
        }
        private static void ConstructMyParts_panel()
        {
            // New panel
            myParts_panel = ConstructFlowPanelForParts();

            // Label
            ConstructPartTitle("My parts", myParts_panel);
        }
        private static void ConstructPublicParts_panel()
        {
            // New panel
            publicParts_panel = ConstructFlowPanelForParts();

            // Label
            ConstructPartTitle("Public parts", publicParts_panel);
        }


        // Rename
        public static Guna2TextBox rename_textBox;
        public static void ConstructRightClickRename()
        {
            rename_textBox = new Guna2TextBox
            {
                Font = new Font("Segoe UI", 10),
                Height = 23,
                Top = 1,
                MaxLength = 30,
                ForeColor = CustomColors.text,
                FillColor = CustomColors.controlBack,
                BorderStyle = DashStyle.Solid,
                TextOffset = new Point(-3, 0),
                BorderThickness = 1,
                ShortcutsEnabled = false
            };
            if (Theme.theme == "Dark")
            {
                rename_textBox.BorderColor = Color.White;
                rename_textBox.HoverState.BorderColor = Color.White;
                rename_textBox.FocusedState.BorderColor = Color.White;
            }
            else
            {
                rename_textBox.BorderColor = Color.Black;
                rename_textBox.HoverState.BorderColor = Color.Black;
                rename_textBox.FocusedState.BorderColor = Color.Black;
            }

            rename_textBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;  // Remove Windows "ding" noise when user presses enter
                    MachineProgrammer.RenameAppSequenceOrFunction();
                }
            };
        }


        // Close all panels
        private static void CloseAllPanels(object sender, EventArgs e)
        {
            CloseAllPanels();
        }
        public static void CloseAllPanels()
        {
            // Robot Programmer
            // Main Controls
            if (MainControls_form.instance.isFormOpen)
            {
                MainControls_form.instance.ResetTabButtons();
                MainControls_form.instance.CloseRightClickPanels();
                MainControls_form.instance.SetDataGridViewColorToFileSelected();
                MainControls_form.instance.ClearSelection();
            }

            // Main Menu
            if (MainMenu_form.instance.isFormOpen)
            {
                if (MainMenu_form.instance.Controls.Contains(workspace_panel)) { MainMenu_form.instance.Controls.Remove(workspace_panel); }
                if (MainMenu_form.instance.Controls.Contains(robotProgrammerWorkspace_panel)) { MainMenu_form.instance.Controls.Remove(robotProgrammerWorkspace_panel); }
                if (MainMenu_form.instance.Controls.Contains(fileMenu)) { MainMenu_form.instance.Controls.Remove(fileMenu); }
                if (MainMenu_form.instance.Controls.Contains(viewMenu)) { MainMenu_form.instance.Controls.Remove(viewMenu); }
                if (MainMenu_form.instance.Controls.Contains(helpMenu)) { MainMenu_form.instance.Controls.Remove(helpMenu); }
                if (MainMenu_form.instance.Controls.Contains(profileMenu)) { MainMenu_form.instance.Controls.Remove(profileMenu); }
                MainMenu_form.instance.File_btn.Image = Resources.FileGray;
                MainMenu_form.instance.Help_btn.Image = Resources.HelpGray;
                MainMenu_form.instance.CloseAllCommandMenus();
                MainMenu_form.instance.isCommandMenuDown = false;
                MainMenu_form.instance.HideMenu_timer.Enabled = false;
            }

            // Machine Programmer
            if (MainMenu_form.instance.isMachineProgrammerOpen)
            {
                MachineProgrammer_form.instance.AddCommand_flowPanel.Visible = false;
                MachineProgrammer_form.instance.AddCommand_btn.CustomizableEdges.TopLeft = true;
                MachineProgrammer_form.instance.AddCommand_btn.CustomizableEdges.TopRight = true;
                MachineProgrammer.UnselectAllCommands(false);
                MachineProgrammer.CloseRightClickPanels();
                MachineProgrammer.RenameEvent();
                MachineProgrammer.RenameAppSequenceOrFunction();
                MachineProgrammer.SetRedCommandsToWhite();
            }
        }
    }
}