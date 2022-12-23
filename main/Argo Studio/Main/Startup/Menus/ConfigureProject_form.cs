using ArgoStudio.Main.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ArgoStudio.Main.Startup.Menus
{
    public partial class ConfigureProject_form : Form
    {
        // Init.
        public static ConfigureProject_form instance;
        public ConfigureProject_form()
        {
            InitializeComponent();
            instance = this;

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }

            // Set default file location
            if (Properties.Settings.Default.isProjectDirectoryDesktop)
                Directory_textBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                Directory_textBox.Text = Properties.Settings.Default.ProjectDirectory;

            ProjectName_textBox.Focus();
        }

        // Form
        private void ConfigureProject_form_Load(object sender, EventArgs e)
        {
            // Set default name. Choose a name that doesn't already exist in the directory
            if (!Directory.Exists(Properties.Settings.Default.ProjectDirectory + @"\ArgoProject"))
            {
                ProjectName_textBox.Text = "ArgoProject";
            }
            else
            {
                int count = 2;
                while (true)
                {
                    if (!Directory.Exists(Properties.Settings.Default.ProjectDirectory + @"\ArgoProject (" + count + ")"))
                    {
                        ProjectName_textBox.Text = "ArgoProject (" + count + ")";
                        break;
                    }
                    count++;
                }
            }
        }
        private void ConfigureProject_form_Click(object sender, EventArgs e)
        {
            label1.Focus();
        }


        // Back btn
        private void Back_btn_Click(object sender, EventArgs e)
        {
            Startup_form.instance.SwitchMainForm(Startup_form.instance.formGetStarted);
        }
        // Create btn
        public string selectedDirectory, projectName;
        private readonly Form FormMainMenu = new MainMenu_form();
        private void Create_btn_Click(object sender, EventArgs e)
        {
            if (Directory_textBox.Text != "")
            {
                // Set main directory
                selectedDirectory = Directory_textBox.Text + @"\";

                bool wasDirectoryCreated = false;
                if (CreateDirectory_checkBox.Checked)
                {
                    projectName = ProjectName_textBox.Text;
                    selectedDirectory += projectName;
                    wasDirectoryCreated = Directories.CreateDirectory(selectedDirectory);
                }
                if (wasDirectoryCreated || !CreateDirectory_checkBox.Checked)
                {
                    // Hide current form. Don't close it or both forms will close
                    Parent.Hide();

                    Directories.SetDirectoriesFor(selectedDirectory);

                    // Create directories and files
                    if (!Directories.CreateDirectory(Directories.buildMachines_commands_temp_dir))
                    {
                        ProjectName_textBox.Select();
                        return;
                    }
                    Directories.CreateFile(Directories.buildMachines_commands_temp_data_file);
                    Directories.CreateDirectory(Directories.buildMachines_python_program_dir);
                    Directories.CreateDirectory(Directories.robotArms_program_dir);
                    Directories.CreateDirectory(Directories.backups_dir);
                    Directories.CreateDirectory(Directories.logs_dir);

                    // Init app data
                    AppData.CreateAppDataDirectoryAndFile();
                    AppData.InitAppDataVariables();

                    // Add event to close FormStartup when FormMainMenu is closed
                    FormMainMenu.FormClosed += (s, args) => Startup_form.instance.Close();

                    FormMainMenu.Show();
                }
            }
            else
            {
                Directory_textBox.Focus();
                CustomMessageBox.Show("Argo Studio", "Select a directory to create the project.", CustomMessageBoxIcon.Error, CustomMessageBoxButtons.Ok);
            }
        }
        private void ThreeDots_btn_Click(object sender, EventArgs e)
        {
            // Select folder
            Ookii.Dialogs.WinForms.VistaFolderBrowserDialog dialog = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();

            string DesktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (Properties.Settings.Default.isProjectDirectoryDesktop)
            {
                dialog.SelectedPath = DesktopDirectory;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Directory_textBox.Text = dialog.SelectedPath + @"\";
                selectedDirectory = Directory_textBox.Text;
                if (dialog.SelectedPath == DesktopDirectory)
                {
                    Properties.Settings.Default.isProjectDirectoryDesktop = true;
                }
                else { Properties.Settings.Default.isProjectDirectoryDesktop = false; }
            }
            // Save
            Properties.Settings.Default.ProjectDirectory = selectedDirectory;
            Properties.Settings.Default.Save();
        }
        private void CreateDirHelp_btn_Click(object sender, EventArgs e)
        {

        }
        private void SaveHelp_btn_Click(object sender, EventArgs e)
        {

        }


        private void TextBoxProjectName_TextChanged(object sender, EventArgs e)
        {
            if (@"/\#%&*|;".Any(ProjectName_textBox.Text.Contains) || ProjectName_textBox.Text == "")
            {
                Create_btn.Enabled = false;
                ProjectName_textBox.BorderColor = Color.Red;
                ProjectName_textBox.FocusedState.BorderColor = Color.Red;
                pictureBoxWarning1.Visible = true;
                lblWarning1.Visible = true;
            }
            else
            {
                Create_btn.Enabled = true;
                ProjectName_textBox.BorderColor = CustomColors.controlBorder;
                ProjectName_textBox.FocusedState.BorderColor = CustomColors.accent_blue;
                pictureBoxWarning1.Visible = false;
                lblWarning1.Visible = false;
            }
        }
        private void Directory_textBox_TextChanged(object sender, EventArgs e)
        {
            if ("/#%&*|;".Any(Directory_textBox.Text.Contains) || Directory_textBox.Text == "" || !Directory_textBox.Text.Contains(@"\"))
            {
                Create_btn.Enabled = false;
                Directory_textBox.BorderColor = Color.Red;
                Directory_textBox.FocusedState.BorderColor = Color.Red;
                pictureBoxWarning2.Visible = true;
                lblWarning2.Visible = true;
            }
            else
            {
                Create_btn.Enabled = true;
                Directory_textBox.BorderColor = CustomColors.controlBorder;
                Directory_textBox.FocusedState.BorderColor = CustomColors.controlBorder;
                pictureBoxWarning2.Visible = false;
                lblWarning2.Visible = false;
            }
            // Save
            if (Directory_textBox.Text == Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
            {
                Properties.Settings.Default.isProjectDirectoryDesktop = true;
            }
            else
            {
                Properties.Settings.Default.isProjectDirectoryDesktop = false;
            }
            Properties.Settings.Default.ProjectDirectory = Directory_textBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}