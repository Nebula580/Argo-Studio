using ArgoStudio.Main.Classes;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    public partial class Tutorial_form : Form
    {
        public Tutorial_form()
        {
            InitializeComponent();

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }

            // Play YouTube video in webBrowser1
            // https://stackoverflow.com/questions/73795000/how-do-i-display-a-youtube-video-in-webviewer#73795057

            string url = "https://www.youtube.com/watch?v=5aCbWqKl-wU";
            string html = "<html style='width: 100%; height: 100%; margin: 0; padding: 0;'><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "</head><body style='width: 100%; height: 100%; margin: 0; padding: 0;'>";
            html += "<iframe id='video' src='https://www.youtube.com/embed/{0}' style=\"padding: 0px; width: 100%; height: 100%; border: none; display: block;\"></iframe>";
            html += "</body></html>";
            webBrowser1.DocumentText = string.Format(html, url.Split('=')[1]);
        }
        private void YouTube_label_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.argorobots.ca/about-us/index.html");
        }
        private void Documentation_label_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.argorobots.ca/about-us/index.html");
        }

        private void Next_btn_Click(object sender, EventArgs e)
        {
            // Set RPTutorial to false            
            AppData.SetValue(0, "RPTutorial:false");

            Setup_form.instance.Close();
        }
    }
}