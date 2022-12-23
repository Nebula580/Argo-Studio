using ArgoStudio.Main.Classes;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArgoStudio.Main
{
    public partial class Log_form : Form
    {
        // Init
        public static Log_form instance;
        public Log_form()
        {
            InitializeComponent();
            instance = this;

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }

            // Hide caret
            RichTextBox.MouseDown += (sender2, e2) =>
            {
                HideCaret(RichTextBox.Handle);
            };

            // Select "Enable autoscroll"
            AutoScroll_comboBox.SelectedIndex = 0;
        }

        // Form
        private void Log_form_Load(object sender, EventArgs e)
        {
            RichTextBox.Text = Log.logText;
        }
        private void Log_form_Shown(object sender, EventArgs e)
        {
            BtnClear.Focus();  // Remove the caret (blinking text cursor)
        }
        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.isLogFormOpen = false;
        }
        private void RichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        // Caret

        [DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);


        // Controls
        private void BtnClear_Click(object sender, EventArgs e)
        {
            RichTextBox.Clear();
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            // Set autoscroll
            if (AutoScroll_comboBox.Text == "Enable autoscroll")
            {
                RichTextBox.SelectionStart = RichTextBox.Text.Length;
                RichTextBox.ScrollToCaret();
            }

            // Set the time to gray
            // https://stackoverflow.com/questions/74134680/how-to-select-text-between-two-characters-in-a-richtextbox
            var matches = Regex.Matches(RichTextBox.Text, @"<*\d+:\d+:\d+:\d+>*", RegexOptions.Multiline);
            foreach (Match m in matches)
            {
                RichTextBox.SelectionStart = m.Index;
                RichTextBox.SelectionLength = m.Length;
                RichTextBox.SelectionColor = CustomColors.grayText;
            }

            // Set colors
            string text = "[Error]";
            int start = 0;
            int end = RichTextBox.Text.LastIndexOf(text);
            while (start < end)
            {
                RichTextBox.Find(text, start, RichTextBox.TextLength, RichTextBoxFinds.None);
                RichTextBox.SelectionColor = CustomColors.accent_red;
                start = RichTextBox.Text.IndexOf(text, start) + 1;
            }

            text = "[Debug]";
            start = 0;
            end = RichTextBox.Text.LastIndexOf(text);
            while (start < end)
            {
                RichTextBox.Find(text, start, RichTextBox.TextLength, RichTextBoxFinds.None);
                RichTextBox.SelectionColor = Color.Blue;
                start = RichTextBox.Text.IndexOf(text, start) + 1;
            }

            text = "[General]";
            start = 0;
            end = RichTextBox.Text.LastIndexOf(text);
            while (start < end)
            {
                RichTextBox.Find(text, start, RichTextBox.TextLength, RichTextBoxFinds.None);
                RichTextBox.SelectionColor = Color.Blue;
                start = RichTextBox.Text.IndexOf(text, start) + 1;
            }

            text = "[Machine Programmer]";
            start = 0;
            end = RichTextBox.Text.LastIndexOf(text);
            while (start < end)
            {
                RichTextBox.Find(text, start, RichTextBox.TextLength, RichTextBoxFinds.None);
                RichTextBox.SelectionColor = Color.Purple;
                start = RichTextBox.Text.IndexOf(text, start) + 1;
            }

            text = "[Robot Programmer]";
            start = 0;
            end = RichTextBox.Text.LastIndexOf(text);
            while (start < end)
            {
                RichTextBox.Find(text, start, RichTextBox.TextLength, RichTextBoxFinds.None);
                RichTextBox.SelectionColor = Color.DeepPink;
                start = RichTextBox.Text.IndexOf(text, start) + 1;
            }

            // Remove selection
            RichTextBox.SelectionLength = 0;
        }
    }
}