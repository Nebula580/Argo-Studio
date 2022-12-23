using ArgoStudio.Main.Settings.Menus;

namespace ArgoStudio.Main.Classes
{
    class UserSettings
    {
        public static void SaveUserSettings()
        {
            Properties.Settings.Default.ReverseMouse = Controls_form.instance.ReverseMouse_checkBox.Checked;
            Properties.Settings.Default.ReverseZoomDirection = Controls_form.instance.ReverseZoomDirection_checkBox.Checked;
            Properties.Settings.Default.PanZoomOrbit = Controls_form.instance.PanZoomOrbit_comboBox.Text;
            Properties.Settings.Default.MouseSensitivity = Controls_form.instance.MouseSensitivity_trackBar.Value;
            Properties.Settings.Default.ZoomSensitivity = Controls_form.instance.ZoomSensitivity_trackBar.Value;
            Properties.Settings.Default.Language = General_form.instance.Language_comboBox.Text;
            Properties.Settings.Default.Currency = General_form.instance.Currency_comboBox.Text;
            Properties.Settings.Default.UnitOfMeasurement = General_form.instance.UnitOfMeasuremnt_comboBox.Text;
            Properties.Settings.Default.ShowToolTips = General_form.instance.ShowToolTips_checkBox.Checked;
            Properties.Settings.Default.SendAnonymousInformation = General_form.instance.SendAnonymousInformation_checkBox.Checked;
            Properties.Settings.Default.AutofillUsername = Security_form.instance.AutofillUsername_checkBox.Checked;
            Properties.Settings.Default.AlwaysKeepMeSignedIn = Security_form.instance.AlwaysKeepMeSignedIn_checkBox.Checked;
            Properties.Settings.Default.ColorTheme = Visual_form.instance.colorTheme_comboBox.Text;
            Properties.Settings.Default.ShowShadows = Visual_form.instance.checkBoxShowShadows.Checked;
            Properties.Settings.Default.ShadowIntensity = Visual_form.instance.trackBarShadowIntensity.Value;
            Properties.Settings.Default.ShowGround = Visual_form.instance.checkBoxShowGround.Checked;
            Properties.Settings.Default.ShowSilhouettes = Visual_form.instance.checkBoxShowSilhouettes.Checked;
            Properties.Settings.Default.Save();
        }

        public static void ResetAllSettingsToDefault()
        {
            Properties.Settings.Default.Reset();

            Controls_form.instance.UpdateControls();
            General_form.instance.UpdateControls();
            Security_form.instance.UpdateControls();
            Visual_form.instance.UpdateControls();

            Properties.Settings.Default.Save();
        }
    }
}