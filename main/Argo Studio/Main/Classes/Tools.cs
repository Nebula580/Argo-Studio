using Guna.UI2.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ArgoStudio.Main.Classes
{
    internal static class Tools
    {
        // Formatting
        // https://stackoverflow.com/questions/48453797/c-sharp-timespan-milliseconds-formated-to-2-digits
        /// <summary>
        /// Formats a TimeSpan into a readable format
        /// </summary>
        public static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format(@"{0:hh\:mm\:ss\.ff}", ts);
        }
        /// <summary>
        /// Formats a DateTime into a readable format
        /// </summary>
        public static string FormatDateTime(DateTime dt)
        {
            return string.Format(@"{0:hh\:mm\:ss\.ff}", dt);
        }


        // Only allow certain characters in a TextBox
        public static bool AreThereAnyNumbersOrLettersInGunaTextBox(object sender)
        {
            Guna2TextBox senderControl = (Guna2TextBox)sender;
            if (@"/\#%&*|;".Any(senderControl.Text.Contains))
            {
                return true;
            }
            return false;
        }
        public static void OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-')  // Only allow numbers
                || (e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1)  // Only allow one decimal point
                || (e.KeyChar == '-') && ((sender as Guna2TextBox).Text.IndexOf('-') > -1))  // Only allow one minus
            {
                e.Handled = true;
            }
        }
        public static void OnlyAllowNumbersInTextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))  // Only allow numbers
            {
                e.Handled = true;
            }
        }


        // Set max number in a GunaTextBox
        public static void SetMaxNumberInGunaTextbox2(object sender, KeyEventArgs e)
        {
            Guna2TextBox textbox = (Guna2TextBox)sender;
            if (textbox.Text != "")
            {
                if (Convert.ToInt32(textbox.Text) > 2)
                {
                    textbox.Text = "2";
                    textbox.SelectionStart = textbox.Text.Length;
                }
            }
        }
        public static void SetMaxNumberInGunaTextbox12(object sender, KeyEventArgs e)
        {
            Guna2TextBox textbox = (Guna2TextBox)sender;
            if (textbox.Text != "")
            {
                if (Convert.ToInt32(textbox.Text) > 12)
                {
                    textbox.Text = "12";
                    textbox.SelectionStart = textbox.Text.Length;
                }
            }
        }
        public static void SetMaxNumberInGunaTextbox16(object sender, KeyEventArgs e)
        {
            Guna2TextBox textbox = (Guna2TextBox)sender;
            if (textbox.Text != "")
            {
                if (Convert.ToInt32(textbox.Text) > 16)
                {
                    textbox.Text = "16";
                    textbox.SelectionStart = textbox.Text.Length;
                }
            }
        }
        public static void SetMaxNumberInGunaTextbox100(object sender, KeyEventArgs e)
        {
            Guna2TextBox textbox = (Guna2TextBox)sender;
            if (textbox.Text != "")
            {
                if (Convert.ToInt32(textbox.Text) > 100)
                {
                    textbox.Text = "100";
                    textbox.SelectionStart = textbox.Text.Length;
                }
            }
        }
        public static void SetMaxNumberInGunaTextbox360(object sender, KeyEventArgs e)
        {
            Guna2TextBox textbox = (Guna2TextBox)sender;
            if (textbox.Text != "")
            {
                if (Convert.ToInt32(textbox.Text) > 360)
                {
                    textbox.Text = "360";
                    textbox.SelectionStart = textbox.Text.Length;
                }
            }
        }
    }
}