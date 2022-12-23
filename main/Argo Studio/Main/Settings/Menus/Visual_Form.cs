using ArgoStudio.Main.Classes;
using System;
using System.Windows.Forms;

namespace ArgoStudio.Main.Settings.Menus
{
    public partial class Visual_form : Form
    {
        // Init.
        public static Visual_form instance;
        public Visual_form()
        {
            InitializeComponent();
            instance = this;

            UpdateControls();
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

        // Form
        private void Visual_form_Click(object sender, EventArgs e)
        {
            Visual_lbl.Focus();
        }

        private void TrackBarShadowIntensity_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownShadowIntensity.Value = trackBarShadowIntensity.Value;
        }
        private void NumericUpDownShadowIntensity_ValueChanged(object sender, EventArgs e)
        {
            trackBarShadowIntensity.Value = (int)numericUpDownShadowIntensity.Value;
        }


        public void UpdateControls()
        {
            colorTheme_comboBox.Text = Properties.Settings.Default.ColorTheme;
            checkBoxShowShadows.Checked = Properties.Settings.Default.ShowShadows;
            trackBarShadowIntensity.Value = Properties.Settings.Default.ShadowIntensity;
            numericUpDownShadowIntensity.Value = Properties.Settings.Default.ShadowIntensity;
            checkBoxShowGround.Checked = Properties.Settings.Default.ShowGround;
            checkBoxShowSilhouettes.Checked = Properties.Settings.Default.ShowSilhouettes;
        }
    }
}