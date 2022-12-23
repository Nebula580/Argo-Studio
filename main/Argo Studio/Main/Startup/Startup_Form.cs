using ArgoStudio.Main.Classes;
using System;
using System.Windows.Forms;

namespace ArgoStudio.Main.Startup.Menus
{
    public partial class Startup_form : Form
    {
        // Init
        public static Startup_form instance;
        public Startup_form()
        {
            InitializeComponent();
            instance = this;

            Theme.UseImmersiveDarkMode(Handle, true);
        }

        public readonly Form formGetStarted = new GetStarted_form();
        public readonly Form FormConfigureProject = new ConfigureProject_form();
        private void FormStartup_Load(object sender, EventArgs e)
        {
            SwitchMainForm(formGetStarted);
        }


        public void SwitchMainForm(Form mainForm)
        {
            Controls.Clear();
            mainForm.Dock = DockStyle.Fill;
            mainForm.TopLevel = false;
            Controls.Add(mainForm);
            mainForm.Show();
        }
    }
}