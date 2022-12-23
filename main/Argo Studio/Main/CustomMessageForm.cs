using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ArgoStudio.Main
{
    public partial class CustomMessageForm : Form
    {
        public static CustomMessageForm instance;
        public CustomMessageForm(string title, string message, CustomMessageBoxIcon icon, CustomMessageBoxButtons buttons)
        {
            InitializeComponent();
            instance = this;

            // Set text
            this.Text = title;
            Message_label.Text = message;
            Message_label.LinkArea = new LinkArea(CustomMessageBoxVariables.linkStart, CustomMessageBoxVariables.linkLength);
            CustomMessageBoxVariables.Reset();
            ResizeMessageLabel();
            Message_label.LinkColor = CustomColors.linkColor;
            Message_label.ActiveLinkColor = CustomColors.linkColor;

            // Set size of form
            Message_label.AutoSize = true;
            this.Height = 160 + Message_label.Height;
            this.MinimumSize = this.Size;

            // Set icon
            switch (icon)
            {
                case CustomMessageBoxIcon.Question:
                    pictureBox1.Image = Resources.Minus;
                    break;
                case CustomMessageBoxIcon.Exclamation:
                    pictureBox1.Image = Resources.Minus;
                    break;
                case CustomMessageBoxIcon.Error:
                    pictureBox1.Image = Resources.Minus;
                    break;
                case CustomMessageBoxIcon.Info:
                    pictureBox1.Image = Resources.Minus;
                    break;
            }

            // Set buttons
            switch (buttons)
            {
                case CustomMessageBoxButtons.YesNo:
                    No_btn.Left = 335;
                    Yes_btn.Left = 225;
                    Controls.Add(No_btn);
                    Controls.Add(Yes_btn);
                    Controls.Remove(Cancel_btn);
                    Controls.Remove(Ok_btn);
                    Yes_btn.Focus();
                    break;
                case CustomMessageBoxButtons.Ok:
                    Ok_btn.Left = 335;
                    Controls.Add(Ok_btn);
                    Controls.Remove(Yes_btn);
                    Controls.Remove(No_btn);
                    Controls.Remove(Cancel_btn);
                    Ok_btn.Focus();
                    break;
                case CustomMessageBoxButtons.OkCancel:
                    Ok_btn.Left = 335;
                    Cancel_btn.Left = 225;
                    Controls.Add(Ok_btn);
                    Controls.Add(Cancel_btn);
                    Controls.Remove(Yes_btn);
                    Controls.Remove(No_btn);
                    Ok_btn.Focus();
                    break;
                case CustomMessageBoxButtons.YesNoCancel:
                    Cancel_btn.Left = 335;
                    No_btn.Left = 225;
                    Yes_btn.Left = 115;
                    Controls.Remove(Ok_btn);
                    Controls.Add(Cancel_btn);
                    Controls.Add(Yes_btn);
                    Controls.Add(No_btn);
                    Yes_btn.Focus();
                    break;
            }

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
        private void CustomMessageForm_Resize(object sender, EventArgs e)
        {
            ResizeMessageLabel();
        }


        private void ResizeMessageLabel()
        {
            Message_label.AutoSize = false;
            Message_label.Width = this.Width - 100;
            Message_label.Height = this.Height - 70;
        }

        public CustomMessageBoxResult result;
        private void No_btn_Click(object sender, EventArgs e)
        {
            result = CustomMessageBoxResult.No;
            Close();
        }
        private void Yes_btn_Click(object sender, EventArgs e)
        {
            result = CustomMessageBoxResult.Yes;
            Close();
        }
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            result = CustomMessageBoxResult.Cancel;
            Close();
        }
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            result = CustomMessageBoxResult.Ok;
            Close();
        }

        private void Message_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(CustomMessageBoxVariables.link);
        }
    }
    public static class CustomMessageBoxVariables
    {
        public static string link;
        public static int linkStart;
        public static int linkLength;

        public static void Reset()
        {
            linkStart = 0;
            linkLength = 0;
        }
    }

    public static class CustomMessageBox
    {
        public static CustomMessageBoxResult Show(string title, string message, CustomMessageBoxIcon icon, CustomMessageBoxButtons buttons)
        {
            // Construct a new form to free resources when it closes
            new CustomMessageForm(title, message, icon, buttons).ShowDialog();
            return CustomMessageForm.instance.result;
        }
    }

    public enum CustomMessageBoxIcon
    {
        Question,
        Exclamation,
        Error,
        Info
    }
    public enum CustomMessageBoxButtons
    {
        YesNo,
        Ok,
        OkCancel,
        YesNoCancel
    }
    public enum CustomMessageBoxResult
    {
        Ok,
        Cancel,
        Yes,
        No
    }
}