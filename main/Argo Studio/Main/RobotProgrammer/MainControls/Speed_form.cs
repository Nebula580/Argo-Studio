using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using System;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    public partial class Speed_form : Form
    {
        // Init.
        public static Speed_form instance;
        public Speed_form()
        {
            InitializeComponent();
            instance = this;

            speed_textBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            acceleration_textBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            deceleration_textBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            ramp_textBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }

            // Update
            Speed.speed = speed_textBox.Text;
            Speed.acceleration = acceleration_textBox.Text;
            Speed.deceleration = deceleration_textBox.Text;
            Speed.ramp = ramp_textBox.Text;
        }

        private void Speed_textBox_TextChanged(object sender, EventArgs e)
        {
            Speed.speed = speed_textBox.Text;
        }
        private void Acceleration_textBox_TextChanged(object sender, EventArgs e)
        {
            Speed.acceleration = acceleration_textBox.Text;
        }
        private void Deceleration_textBox_TextChanged(object sender, EventArgs e)
        {
            Speed.deceleration = deceleration_textBox.Text;
        }
        private void Ramp_textBox_TextChanged(object sender, EventArgs e)
        {
            Speed.ramp = ramp_textBox.Text;
        }
    }
}