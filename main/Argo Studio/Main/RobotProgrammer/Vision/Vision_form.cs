using ArgoStudio.Main.Classes;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer
{
    public partial class Vision_form : Form
    {
        public Vision_form()
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
        }
    }
}