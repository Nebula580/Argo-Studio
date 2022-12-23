using ArgoStudio.Main.Classes;
using ArgoStudio.Main.Startup.Menus;
using System;
using System.IO;
using System.Windows.Forms;

namespace ArgoStudio.Main.BuildMachines
{
    public partial class BuildMachines_form : Form
    {
        // Init.
        public static BuildMachines_form instance;
        public BuildMachines_form()
        {
            InitializeComponent();
            instance = this;

            UpdateTheme();
        }
        public void UpdateTheme()
        {
            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }
        }

        public bool areAnyChangesMade = true;
        public void Save()
        {
            if (Directory.Exists(Directories.buildMachines_commands_temp_dir))
            {
                Directories.CopyDirectory(Directories.buildMachines_commands_temp_dir, Directories.buildMachines_commands_dir, true, true);
            }
        }
        public void SaveAs()
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
                // Save normally
                Save();

                string newDir = dialog.SelectedPath + @"\" + ConfigureProject_form.instance.projectName;

                // Copy the project to a new location
                Directories.CopyDirectory(Directories.main_dir, newDir, true, true);

                // Delete the temp dir in the new location
                Directories.CopyDirectory(newDir + @"\project\build machines\commands\temp", newDir + @"\project\build machines\commands", true, true);
                Directories.DeleteDirectory(newDir + @"\project\build machines\commands\temp", true);
            }
        }
        public void SaveAsLatest()
        {

        }


        // Misc.
        private void CloseAllPanels(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }
    }
}