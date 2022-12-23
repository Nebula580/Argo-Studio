using ArgoStudio.Main.Classes;
using System;
using System.Windows.Forms;

namespace ArgoStudio.Main.Settings.Menus
{
    public partial class Controls_form : Form
    {
        public static Controls_form instance;
        public Controls_form()
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
        private void Controls_form_Click(object sender, EventArgs e)
        {
            Controls_lbl.Focus();
        }

        public void UpdateControls()
        {
            ReverseMouse_checkBox.Checked = Properties.Settings.Default.ReverseMouse;
            ReverseZoomDirection_checkBox.Checked = Properties.Settings.Default.ReverseZoomDirection;
            PanZoomOrbit_comboBox.Text = Properties.Settings.Default.PanZoomOrbit;
            MouseSensitivity_trackBar.Value = Properties.Settings.Default.MouseSensitivity;
            MouseSensitivity_numericUpDown.Value = Properties.Settings.Default.MouseSensitivity;
            ZoomSensitivity_trackBar.Value = Properties.Settings.Default.ZoomSensitivity;
            ZoomSensitivity_numericUpDown.Value = Properties.Settings.Default.ZoomSensitivity;
        }

        private void MouseSensitivity_trackBar_Scroll(object sender, ScrollEventArgs e)
        {
            MouseSensitivity_numericUpDown.Value = MouseSensitivity_trackBar.Value;
        }
        private void MouseSensitivity_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            MouseSensitivity_trackBar.Value = (int)MouseSensitivity_numericUpDown.Value;
        }

        private void ZoomSensitivity_trackBar_Scroll(object sender, ScrollEventArgs e)
        {
            ZoomSensitivity_numericUpDown.Value = ZoomSensitivity_trackBar.Value;
        }
        private void ZoomSensitivity_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ZoomSensitivity_trackBar.Value = (int)ZoomSensitivity_numericUpDown.Value;
        }
    }
}