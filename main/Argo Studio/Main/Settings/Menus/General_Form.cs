using ArgoStudio.Main.Classes;
using System.Windows.Forms;

namespace ArgoStudio.Main.Settings.Menus
{
    public partial class General_form : Form
    {
        public static General_form instance;
        public General_form()
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
        private void General_form_Shown(object sender, System.EventArgs e)
        {
            General_lbl.Focus();
        }
        private void General_form_Click(object sender, System.EventArgs e)
        {
            General_lbl.Focus();
        }


        public void UpdateControls()
        {
            Language_comboBox.SelectedItem = Properties.Settings.Default.Language;
            Currency_comboBox.Text = Properties.Settings.Default.Currency;
            UnitOfMeasuremnt_comboBox.Text = Properties.Settings.Default.UnitOfMeasurement;
            ShowToolTips_checkBox.Checked = Properties.Settings.Default.ShowToolTips;
            SendAnonymousInformation_checkBox.Checked = Properties.Settings.Default.SendAnonymousInformation;
        }
    }
}
