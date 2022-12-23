using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using System;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    public partial class SaveSP_form : Form
    {
        public SaveSP_form()
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

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (SP_ComboBox.Text != "")
            {
                switch (SP_ComboBox.Text)
                {
                    case "SP 1":
                        SP_form.instance.SaveSP1(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                            Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                            Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                            Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                            Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                            Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 2":
                        SP_form.instance.SaveSP2(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 3":
                        SP_form.instance.SaveSP3(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 4":
                        SP_form.instance.SaveSP4(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 5":
                        SP_form.instance.SaveSP5(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 6":
                        SP_form.instance.SaveSP6(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 7":
                        SP_form.instance.SaveSP7(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 8":
                        SP_form.instance.SaveSP8(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 9":
                        SP_form.instance.SaveSP9(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 10":
                        SP_form.instance.SaveSP10(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 11":
                        SP_form.instance.SaveSP11(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 12":
                        SP_form.instance.SaveSP12(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 13":
                        SP_form.instance.SaveSP13(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 14":
                        SP_form.instance.SaveSP14(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 15":
                        SP_form.instance.SaveSP15(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                    case "SP 16":
                        SP_form.instance.SaveSP16(Convert.ToDouble(MainControls_form.instance.J1_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J2_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J3_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J4_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J5_textBox.Text),
                           Convert.ToDouble(MainControls_form.instance.J6_textBox.Text));
                        break;
                }
            }
            else { CustomMessageBox.Show("Argo Studio", "Select a SP to save the position.", CustomMessageBoxIcon.Error, CustomMessageBoxButtons.Ok); }
        }
    }
}