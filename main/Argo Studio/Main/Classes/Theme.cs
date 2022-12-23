using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ArgoStudio.Main.Classes
{
    internal static class Theme
    {
        public static string theme = Properties.Settings.Default.ColorTheme;
        public static void SetThemeForControl(List<Control> list)
        {
            foreach (Control control in list)
            {
                bool pass = false;
                if (control.HasChildren)
                {
                    // Recursively loop through the child controls
                    List<Control> childList = new List<Control>();
                    foreach (Control item in control.Controls)
                    {
                        childList.Add(item);
                    }
                    SetThemeForControl(childList);
                    pass = true;
                }
                if (!control.HasChildren || pass)
                {
                    switch (control)
                    {
                        case Label label:
                            label.ForeColor = CustomColors.text;
                            break;

                        case PictureBox pictureBox:
                            pictureBox.BackColor = CustomColors.mainBackground;
                            break;

                        case RichTextBox richTextBox:
                            richTextBox.BackColor = CustomColors.mainBackground;
                            richTextBox.ForeColor = CustomColors.text;
                            break;

                        case FlowLayoutPanel flowLayoutPanel:
                            flowLayoutPanel.BackColor = CustomColors.mainBackground;
                            break;

                        case Guna2Button guna2Button:
                            guna2Button.FillColor = CustomColors.controlBack;
                            guna2Button.ForeColor = CustomColors.text;
                            guna2Button.BorderColor = CustomColors.controlBorder;
                            guna2Button.DisabledState.FillColor = CustomColors.controlDisabledBack;
                            break;

                        case Guna2TextBox guna2TextBox:
                            guna2TextBox.FillColor = CustomColors.controlBack;
                            guna2TextBox.HoverState.FillColor = CustomColors.controlBack;
                            guna2TextBox.DisabledState.FillColor = CustomColors.controlDisabledBack;
                            guna2TextBox.ForeColor = CustomColors.text;
                            guna2TextBox.BorderColor = CustomColors.controlBorder;
                            guna2TextBox.HoverState.BorderColor = CustomColors.accent_blue;
                            guna2TextBox.FocusedState.BorderColor = CustomColors.accent_blue;
                            guna2TextBox.FocusedState.FillColor = CustomColors.controlBack;
                            break;

                        case Guna2CheckBox guna2CheckBox:
                            guna2CheckBox.ForeColor = CustomColors.text;
                            guna2CheckBox.CheckedState.BorderColor = CustomColors.accent_blue;
                            guna2CheckBox.CheckedState.FillColor = CustomColors.accent_blue;
                            guna2CheckBox.UncheckedState.BorderColor = CustomColors.controlUncheckedBorder;
                            guna2CheckBox.UncheckedState.FillColor = CustomColors.controlBack;
                            break;

                        case Guna2RadioButton guna2RadioButton:
                            guna2RadioButton.ForeColor = CustomColors.text;
                            guna2RadioButton.CheckedState.BorderColor = CustomColors.accent_blue;
                            guna2RadioButton.CheckedState.FillColor = CustomColors.accent_blue;
                            guna2RadioButton.UncheckedState.BorderColor = CustomColors.controlUncheckedBorder;
                            guna2RadioButton.UncheckedState.FillColor = CustomColors.controlBack;
                            break;

                        case Guna2Panel guna2Panel:
                            guna2Panel.FillColor = CustomColors.mainBackground;
                            break;

                        case Panel panel:
                            panel.BackColor = CustomColors.mainBackground;
                            break;

                        case Guna2TrackBar guna2TrackBar:
                            guna2TrackBar.ThumbColor = CustomColors.accent_blue;
                            guna2TrackBar.BackColor = CustomColors.mainBackground;
                            break;

                        case Guna2NumericUpDown guna2NumericUpDown:
                            guna2NumericUpDown.FillColor = CustomColors.controlBack;
                            guna2NumericUpDown.ForeColor = CustomColors.text;
                            guna2NumericUpDown.BorderColor = CustomColors.accent_blue;
                            guna2NumericUpDown.UpDownButtonFillColor = CustomColors.accent_blue;
                            break;

                        case Guna2ComboBox guna2ComboBox:
                            guna2ComboBox.FillColor = CustomColors.controlBack;
                            guna2ComboBox.ForeColor = CustomColors.text;
                            guna2ComboBox.BorderColor = CustomColors.controlBorder;
                            guna2ComboBox.HoverState.BorderColor = CustomColors.accent_blue;
                            guna2ComboBox.FocusedState.BorderColor = CustomColors.accent_blue;
                            guna2ComboBox.ItemsAppearance.BackColor = CustomColors.controlBack;
                            break;

                        case Guna2DataGridView guna2DataGridView:
                            guna2DataGridView.Theme = CustomColors.dataGridViewTheme;
                            guna2DataGridView.BackgroundColor = CustomColors.controlBack;
                            break;
                    }
                }
            }
        }
        public static string SetThemeForForm(Form form)
        {
            form.BackColor = CustomColors.mainBackground;

            List<Control> list = new List<Control>();
            foreach (Control item in form.Controls)
            {
                list.Add(item);
            }

            SetThemeForControl(list);
            UseImmersiveDarkMode(form.Handle, true);
            return theme;
        }


        // Set the header to dark
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (theme == "Dark")
            {
                if (IsWindows10OrGreater(17763))
                {
                    int attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                    if (IsWindows10OrGreater(18985))
                    {
                        attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                    }

                    int useImmersiveDarkMode = enabled ? 1 : 0;
                    return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                }
            }

            return false;
        }
        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}