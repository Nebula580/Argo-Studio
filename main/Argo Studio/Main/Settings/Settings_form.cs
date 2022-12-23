using ArgoStudio.Main.BuildMachines;
using ArgoStudio.Main.BuildMachines.MachineProgrammer;
using ArgoStudio.Main.Classes;
using ArgoStudio.Main.RobotProgrammer;
using ArgoStudio.Main.Settings.Menus;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArgoStudio.Main.Settings
{
    public partial class Settings_form : Form
    {
        private readonly Form FormGeneral = new General_form();
        private readonly Form FormVisual = new Visual_form();
        private readonly Form FormSecurity = new Security_form();
        private readonly Form FormUpdates = new Updates_form();
        private readonly Form FormControls = new Controls_form();

        // Init.
        public static Settings_form instance;
        public Settings_form()
        {
            InitializeComponent();
            instance = this;

            UpdateTheme();

            // Add forms
            FormGeneral.TopLevel = false;
            FormGeneral.Dock = DockStyle.Fill;
            FormGeneral.Visible = true;
            FormBack_panel.Controls.Add(FormGeneral);

            FormVisual.TopLevel = false;
            FormVisual.Dock = DockStyle.Fill;
            FormVisual.Visible = true;
            FormBack_panel.Controls.Add(FormVisual);

            FormSecurity.TopLevel = false;
            FormSecurity.Dock = DockStyle.Fill;
            FormSecurity.Visible = true;
            FormBack_panel.Controls.Add(FormSecurity);

            FormUpdates.TopLevel = false;
            FormUpdates.Dock = DockStyle.Fill;
            FormUpdates.Visible = true;
            FormBack_panel.Controls.Add(FormUpdates);

            FormControls.TopLevel = false;
            FormControls.Dock = DockStyle.Fill;
            FormControls.Visible = true;
            FormBack_panel.Controls.Add(FormControls);

            General_btn.PerformClick();
        }
        private void UpdateTheme()
        {
            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }
            // Select button
            if (btnSelected != null)
            {
                btnSelected.FillColor = CustomColors.accent_blue;
                btnSelected.ForeColor = Color.White;
            }
        }


        // Left menu buttons
        private Guna2Button btnSelected;

        private void GeneralButton_Click(object sender, EventArgs e)
        {
            SwitchForm(FormGeneral, sender);
        }
        private void VisualButton_Click(object sender, EventArgs e)
        {
            SwitchForm(FormVisual, sender);
        }
        private void SecurityButton_Click(object sender, EventArgs e)
        {
            SwitchForm(FormSecurity, sender);
        }
        private void UpdatesButton_Click(object sender, EventArgs e)
        {
            SwitchForm(FormUpdates, sender);
        }
        private void ControlsButton_Click(object sender, EventArgs e)
        {
            SwitchForm(FormControls, sender);
        }


        // Bottom buttons
        private void ResetToDefault_btn_Click(object sender, EventArgs e)
        {
            CustomMessageBoxResult result = CustomMessageBox.Show("Argo Studio", "All user settings will be reset to default.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.OkCancel);
            if (result == CustomMessageBoxResult.Ok)
            {
                UserSettings.ResetAllSettingsToDefault();
            }
        }
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Close();
        }
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Apply_btn_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }
        private void ApplyChanges()
        {
            // Apply changes

            // Color theme
            if (Visual_form.instance.colorTheme_comboBox.Text != Properties.Settings.Default.ColorTheme)
            {
                Theme.theme = Visual_form.instance.colorTheme_comboBox.Text;
                CustomColors.SetColors();

                Controls_form.instance.UpdateTheme();
                General_form.instance.UpdateTheme();
                Security_form.instance.UpdateTheme();
                Updates_form.instance.UpdateTheme();
                Visual_form.instance.UpdateTheme();

                foreach (Form form in Application.OpenForms)
                {
                    switch (form.Name)
                    {
                        // Some forms such as "ConnectRobot_form" do not need to be changed here
                        case "MachineProgrammer_form":
                            MachineProgrammer_form.instance.UpdateTheme();
                            break;

                        case "BuildMachines_form":
                            BuildMachines_form.instance.UpdateTheme();
                            break;

                        case "MainMenu_form":
                            MainMenu_form.instance.UpdateTheme();
                            break;

                        case "MainControls_form":
                            MainControls_form.instance.UpdateTheme();
                            break;

                        case "IO_form":
                            IO_form.instance.UpdateTheme();
                            break;

                        case "SP_form":
                            SP_form.instance.UpdateTheme();
                            break;

                        case "Settings_form":
                            UpdateTheme();
                            break;
                    }
                }

                List<Guna2Panel> listOfMenus = new List<Guna2Panel> { UI.fileMenu, UI.viewMenu, UI.helpMenu, UI.profileMenu, UI.workspace_panel, UI.robotProgrammerWorkspace_panel };
                foreach (Guna2Panel guna2Panel in listOfMenus)
                {
                    guna2Panel.FillColor = CustomColors.panelBtn;
                    guna2Panel.BorderColor = CustomColors.controlPanelBorder;

                    FlowLayoutPanel flowPanel;
                    Control.ControlCollection list;
                    try
                    {
                        flowPanel = (FlowLayoutPanel)guna2Panel.Controls[0];
                        flowPanel.BackColor = CustomColors.panelBtn;
                        list = flowPanel.Controls;
                    }
                    catch
                    {
                        list = guna2Panel.Controls;
                    }

                    foreach (Control control in list)
                    {
                        switch (control)
                        {
                            case Guna2Separator guna2Separator:
                                guna2Separator.FillColor = CustomColors.controlPanelBorder;
                                break;

                            case Guna2Button guna2Button:
                                guna2Button.FillColor = CustomColors.panelBtn;
                                guna2Button.ForeColor = CustomColors.text;
                                guna2Button.BorderColor = CustomColors.controlBorder;
                                guna2Button.HoverState.BorderColor = CustomColors.controlBorder;
                                guna2Button.HoverState.FillColor = CustomColors.panelBtnHover;
                                guna2Button.PressedColor = CustomColors.panelBtnHover;

                                foreach (Label label in guna2Button.Controls)
                                {
                                    label.ForeColor = CustomColors.text;
                                }
                                break;
                        }
                    }
                }

                if (Theme.theme == "Dark")
                {
                    UI.rename_textBox.HoverState.BorderColor = Color.White;
                    UI.rename_textBox.FocusedState.BorderColor = Color.White;
                    UI.rename_textBox.BorderColor = Color.White;
                }
                else
                {
                    UI.rename_textBox.HoverState.BorderColor = Color.Black;
                    UI.rename_textBox.FocusedState.BorderColor = Color.Black;
                    UI.rename_textBox.BorderColor = Color.Black;
                }
                MachineProgrammer.rightClickFileDelete_btn.ForeColor = CustomColors.accent_red;
            }

            UserSettings.SaveUserSettings();
        }


        // Misc.
        private void SwitchForm(Form form, object btnSender)
        {
            UI.CloseAllPanels();
            Guna2Button btn = (Guna2Button)btnSender;

            // If btn is not already selected
            if (btn.FillColor != CustomColors.accent_blue)
            {
                // Unselect button
                if (btnSelected != null)
                {
                    btnSelected.FillColor = CustomColors.controlBack;
                    if (Theme.theme == "Dark")
                        btnSelected.ForeColor = Color.White;
                    else
                        btnSelected.ForeColor = Color.Black;
                }

                // Select new button
                btn.FillColor = CustomColors.accent_blue;
                btn.ForeColor = Color.White;
                form.BringToFront();

                // Save
                btnSelected = btn;
            }
        }
    }
}