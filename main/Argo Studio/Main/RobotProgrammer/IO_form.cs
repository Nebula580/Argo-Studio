using ArgoStudio.Main.Classes;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer
{
    public partial class IO_form : Form
    {
        public static IO_form instance;
        public IO_form()
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

            }
            else if (theme == "Dark")
            {

            }
        }
    }
}