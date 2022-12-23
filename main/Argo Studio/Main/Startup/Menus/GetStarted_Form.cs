using ArgoStudio.Main.Classes;
using System;
using System.Windows.Forms;

namespace ArgoStudio.Main.Startup.Menus
{
    public partial class GetStarted_form : Form
    {
        // Init.
        public static GetStarted_form instance;
        public GetStarted_form()
        {
            InitializeComponent();
            instance = this;

            CustomColors.SetColors();

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }
        }

        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            Startup_form.instance.SwitchMainForm(Startup_form.instance.FormConfigureProject);
        }


        // Open project
        private void OpenProject_panel_Click(object sender, EventArgs e)
        {
            // Set ProjectDirectory
            if (Properties.Settings.Default.ProjectDirectory == "")
            {
                Properties.Settings.Default.ProjectDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Properties.Settings.Default.Save();
            }

            // Select file
            string DesktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog dialog = new OpenFileDialog();
            if (Properties.Settings.Default.isProjectDirectoryDesktop)
            {
                dialog.InitialDirectory = DesktopDirectory;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Save new ProjectDirectory
                Properties.Settings.Default.ProjectDirectory = dialog.FileName;
                Properties.Settings.Default.Save();
                if (dialog.FileName == DesktopDirectory)
                {
                    Properties.Settings.Default.isProjectDirectoryDesktop = true;
                }
                else { Properties.Settings.Default.isProjectDirectoryDesktop = false; }
            }
        }
    }
}