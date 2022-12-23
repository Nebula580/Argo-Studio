using ArgoStudio.Main.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArgoStudio.Main.Settings.Menus
{
    public partial class Updates_form : Form
    {
        public static Updates_form instance;
        public Updates_form()
        {
            InitializeComponent();
            instance = this;

            UpdateTheme();
        }
        public void UpdateTheme()
        {
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {
                LastCheck_label.ForeColor = Color.DimGray;
            }
            else if (theme == "Dark")
            {

            }
            CheckForUpdates_btn.FillColor = CustomColors.accent_blue;
        }


        // Form
        private void Updates_form_Click(object sender, EventArgs e)
        {
            Updates_lbl.Focus();
        }

        private void CheckForUpdates_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
