using ArgoStudio.Main.Classes;
using System.Windows.Forms;

namespace ArgoStudio.Main.Settings.Menus
{
    public partial class Security_form : Form
    {
        public static Security_form instance;
        public Security_form()
        {
            InitializeComponent();
            instance = this;

            UpdateControls();

            UpdateTheme();
        }
        public void UpdateTheme()
        {
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }
        }

        // Form
        private void Security_form_Click(object sender, System.EventArgs e)
        {
            Security_lbl.Focus();
        }

        public void UpdateControls()
        {
            AutofillUsername_checkBox.Checked = Properties.Settings.Default.AutofillUsername;
            AlwaysKeepMeSignedIn_checkBox.Checked = Properties.Settings.Default.AlwaysKeepMeSignedIn;
        }
    }
}
