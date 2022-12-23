using ArgoStudio.Main.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    public partial class Setup_form : Form
    {
        static public Setup_form instance;
        public readonly Form FormConnect = new ConnectRobot_form();
        public readonly Form FormProgram = new Program_form();
        public readonly Form FormTutorial = new Tutorial_form();

        public Setup_form()
        {
            InitializeComponent();
            instance = this;

            if (!AppData.RPTutorial)
            {
                Size = new Size(740, 470);
            }

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }

            // Add forms
            FormConnect.TopLevel = false;
            FormConnect.Dock = DockStyle.Fill;
            FormConnect.FormBorderStyle = FormBorderStyle.None;
            FormConnect.Visible = true;
            FormBack_panel.Controls.Add(FormConnect);

            FormProgram.TopLevel = false;
            FormProgram.Dock = DockStyle.Fill;
            FormProgram.FormBorderStyle = FormBorderStyle.None;
            FormProgram.Visible = true;
            FormBack_panel.Controls.Add(FormProgram);

            FormTutorial.TopLevel = false;
            FormTutorial.Dock = DockStyle.Fill;
            FormTutorial.FormBorderStyle = FormBorderStyle.None;
            FormTutorial.Visible = true;
            FormBack_panel.Controls.Add(FormTutorial);

            FormConnect.BringToFront();
        }


        // FORM
        private void Setup_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close threads
            if (ConnectRobot_form.instance.timerThread != null)
            {
                // Do not use "Thread.Abort()" because it is slow
                ConnectRobot_form.ThreadClass.TerminateAllThreads();
            }
        }
    }
}