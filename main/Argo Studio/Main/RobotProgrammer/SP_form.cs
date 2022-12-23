using ArgoStudio.Main.Classes;
using ArgoStudio.Main.RobotProgrammer.MainControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer
{
    public partial class SP_form : Form
    {
        // Init.
        public static SP_form instance;
        private readonly List<Guna2TextBox> SPTextBox_list = new List<Guna2TextBox>();
        public readonly double[] SP_list = new double[96];
        public SP_form()
        {
            InitializeComponent();
            instance = this;

            // Read SP from file
            if (MainControls_form.instance.isProgramLoaded)
            {
                string filePath1 = Directories.robotArms_program_dir + @"\" + MainControls_form.instance.selectedProgramName + @"\sp.txt";
                if (File.Exists(filePath1))
                {
                    string[] lines = File.ReadAllLines(filePath1);
                    if (lines.Length > 0)
                    {
                        string[] sp = lines[0].Split(',');
                        for (int i = 0; i < sp.Length - 1; i++)
                        {
                            if (sp[i] != "")
                            {
                                SP_list[i] = Convert.ToDouble(sp[i]);
                            }
                        }
                    }
                }
                else
                {
                    Log.Error_FileDoesNotExist(filePath1);
                    return;
                }
            }

            // Add all TextBox to list
            SPTextBox_list.Clear();
            SPTextBox_list.AddRange(new List<Guna2TextBox>
            {
                SP1_X_TextBox, SP1_Y_TextBox, SP1_Z_TextBox, SP1_Yaw_TextBox, SP1_Pitch_TextBox, SP1_Roll_TextBox,
                SP2_X_TextBox, SP2_Y_TextBox, SP2_Z_TextBox, SP2_Yaw_TextBox, SP2_Pitch_TextBox, SP2_Roll_TextBox,
                SP3_X_TextBox, SP3_Y_TextBox, SP3_Z_TextBox, SP3_Yaw_TextBox, SP3_Pitch_TextBox, SP3_Roll_TextBox,
                SP4_X_TextBox, SP4_Y_TextBox, SP4_Z_TextBox, SP4_Yaw_TextBox, SP4_Pitch_TextBox, SP4_Roll_TextBox,
                SP5_X_TextBox, SP5_Y_TextBox, SP5_Z_TextBox, SP5_Yaw_TextBox, SP5_Pitch_TextBox, SP5_Roll_TextBox,
                SP6_X_TextBox, SP6_Y_TextBox, SP6_Z_TextBox, SP6_Yaw_TextBox, SP6_Pitch_TextBox, SP6_Roll_TextBox,
                SP7_X_TextBox, SP7_Y_TextBox, SP7_Z_TextBox, SP7_Yaw_TextBox, SP7_Pitch_TextBox, SP7_Roll_TextBox,
                SP8_X_TextBox, SP8_Y_TextBox, SP8_Z_TextBox, SP8_Yaw_TextBox, SP8_Pitch_TextBox, SP8_Roll_TextBox,
                SP9_X_TextBox, SP9_Y_TextBox, SP9_Z_TextBox, SP9_Yaw_TextBox, SP9_Pitch_TextBox, SP9_Roll_TextBox,
                SP10_X_TextBox, SP10_Y_TextBox, SP10_Z_TextBox, SP10_Yaw_TextBox, SP10_Pitch_TextBox, SP10_Roll_TextBox,
                SP11_X_TextBox, SP11_Y_TextBox, SP11_Z_TextBox, SP11_Yaw_TextBox, SP11_Pitch_TextBox, SP11_Roll_TextBox,
                SP12_X_TextBox, SP12_Y_TextBox, SP12_Z_TextBox, SP12_Yaw_TextBox, SP12_Pitch_TextBox, SP12_Roll_TextBox,
                SP13_X_TextBox, SP13_Y_TextBox, SP13_Z_TextBox, SP13_Yaw_TextBox, SP13_Pitch_TextBox, SP13_Roll_TextBox,
                SP14_X_TextBox, SP14_Y_TextBox, SP14_Z_TextBox, SP14_Yaw_TextBox, SP14_Pitch_TextBox, SP14_Roll_TextBox,
                SP15_X_TextBox, SP15_Y_TextBox, SP15_Z_TextBox, SP15_Yaw_TextBox, SP15_Pitch_TextBox, SP15_Roll_TextBox,
                SP16_X_TextBox, SP16_Y_TextBox, SP16_Z_TextBox, SP16_Yaw_TextBox, SP16_Pitch_TextBox, SP16_Roll_TextBox,
            });
            // Load all data from file
            for (int i = 0; i < SPTextBox_list.Count; i++)
            {
                SPTextBox_list[i].Text = SP_list[i].ToString();
            }

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


        private void UpdateSPInFile(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox != null)
            {
                if (textBox.Text != "")
                {
                    SP_list[Convert.ToInt32(textBox.Tag) - 1] = Convert.ToDouble(textBox.Text);
                }
                else { SP_list[Convert.ToInt32(textBox.Tag) - 1] = 0; }

                // Write SP in file
                if (MainControls_form.instance.isProgramLoaded)
                {
                    string filePath1 = Directories.robotArms_program_dir + @"\" + MainControls_form.instance.selectedProgramName + @"\sp.txt";
                    string[] lines = new string[1];
                    foreach (double item in SP_list)
                    {
                        if (item != 0)
                        {
                            lines[0] += item + ",";
                        }
                        else { lines[0] += ","; }
                    }
                    File.WriteAllLines(filePath1, lines);
                }
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            // Put a zero in the textBox if the textBox is empty
            if (textBox.Text == "")
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void SaveSP_btn_Click(object sender, EventArgs e)
        {
            Form saveSPForm = new SaveSP_form();
            saveSPForm.ShowDialog();
        }
        public void SaveSP1(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP1_X_TextBox.Text = x.ToString();
            SP1_Y_TextBox.Text = y.ToString();
            SP1_Z_TextBox.Text = z.ToString();
            SP1_Yaw_TextBox.Text = yaw.ToString();
            SP1_Pitch_TextBox.Text = pitch.ToString();
            SP1_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP2(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP2_X_TextBox.Text = x.ToString();
            SP2_Y_TextBox.Text = y.ToString();
            SP2_Z_TextBox.Text = z.ToString();
            SP2_Yaw_TextBox.Text = yaw.ToString();
            SP2_Pitch_TextBox.Text = pitch.ToString();
            SP2_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP3(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP3_X_TextBox.Text = x.ToString();
            SP3_Y_TextBox.Text = y.ToString();
            SP3_Z_TextBox.Text = z.ToString();
            SP3_Yaw_TextBox.Text = yaw.ToString();
            SP3_Pitch_TextBox.Text = pitch.ToString();
            SP3_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP4(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP4_X_TextBox.Text = x.ToString();
            SP4_Y_TextBox.Text = y.ToString();
            SP4_Z_TextBox.Text = z.ToString();
            SP4_Yaw_TextBox.Text = yaw.ToString();
            SP4_Pitch_TextBox.Text = pitch.ToString();
            SP4_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP5(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP5_X_TextBox.Text = x.ToString();
            SP5_Y_TextBox.Text = y.ToString();
            SP5_Z_TextBox.Text = z.ToString();
            SP5_Yaw_TextBox.Text = yaw.ToString();
            SP5_Pitch_TextBox.Text = pitch.ToString();
            SP5_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP6(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP6_X_TextBox.Text = x.ToString();
            SP6_Y_TextBox.Text = y.ToString();
            SP6_Z_TextBox.Text = z.ToString();
            SP6_Yaw_TextBox.Text = yaw.ToString();
            SP6_Pitch_TextBox.Text = pitch.ToString();
            SP6_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP7(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP7_X_TextBox.Text = x.ToString();
            SP7_Y_TextBox.Text = y.ToString();
            SP7_Z_TextBox.Text = z.ToString();
            SP7_Yaw_TextBox.Text = yaw.ToString();
            SP7_Pitch_TextBox.Text = pitch.ToString();
            SP7_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP8(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP8_X_TextBox.Text = x.ToString();
            SP8_Y_TextBox.Text = y.ToString();
            SP8_Z_TextBox.Text = z.ToString();
            SP8_Yaw_TextBox.Text = yaw.ToString();
            SP8_Pitch_TextBox.Text = pitch.ToString();
            SP8_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP9(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP9_X_TextBox.Text = x.ToString();
            SP9_Y_TextBox.Text = y.ToString();
            SP9_Z_TextBox.Text = z.ToString();
            SP9_Yaw_TextBox.Text = yaw.ToString();
            SP9_Pitch_TextBox.Text = pitch.ToString();
            SP9_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP10(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP10_X_TextBox.Text = x.ToString();
            SP10_Y_TextBox.Text = y.ToString();
            SP10_Z_TextBox.Text = z.ToString();
            SP10_Yaw_TextBox.Text = yaw.ToString();
            SP10_Pitch_TextBox.Text = pitch.ToString();
            SP10_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP11(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP11_X_TextBox.Text = x.ToString();
            SP11_Y_TextBox.Text = y.ToString();
            SP11_Z_TextBox.Text = z.ToString();
            SP11_Yaw_TextBox.Text = yaw.ToString();
            SP11_Pitch_TextBox.Text = pitch.ToString();
            SP11_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP12(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP12_X_TextBox.Text = x.ToString();
            SP12_Y_TextBox.Text = y.ToString();
            SP12_Z_TextBox.Text = z.ToString();
            SP12_Yaw_TextBox.Text = yaw.ToString();
            SP12_Pitch_TextBox.Text = pitch.ToString();
            SP12_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP13(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP13_X_TextBox.Text = x.ToString();
            SP13_Y_TextBox.Text = y.ToString();
            SP13_Z_TextBox.Text = z.ToString();
            SP13_Yaw_TextBox.Text = yaw.ToString();
            SP13_Pitch_TextBox.Text = pitch.ToString();
            SP13_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP14(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP14_X_TextBox.Text = x.ToString();
            SP14_Y_TextBox.Text = y.ToString();
            SP14_Z_TextBox.Text = z.ToString();
            SP14_Yaw_TextBox.Text = yaw.ToString();
            SP14_Pitch_TextBox.Text = pitch.ToString();
            SP14_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP15(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP15_X_TextBox.Text = x.ToString();
            SP15_Y_TextBox.Text = y.ToString();
            SP15_Z_TextBox.Text = z.ToString();
            SP15_Yaw_TextBox.Text = yaw.ToString();
            SP15_Pitch_TextBox.Text = pitch.ToString();
            SP15_Roll_TextBox.Text = roll.ToString();
        }
        public void SaveSP16(double x, double y, double z, double yaw, double pitch, double roll)
        {
            SP16_X_TextBox.Text = x.ToString();
            SP16_Y_TextBox.Text = y.ToString();
            SP16_Z_TextBox.Text = z.ToString();
            SP16_Yaw_TextBox.Text = yaw.ToString();
            SP16_Pitch_TextBox.Text = pitch.ToString();
            SP16_Roll_TextBox.Text = roll.ToString();
        }


        // Misc.
        private void OnlyAllowNumbersAndOneDecimalAndOneMinusInTextBox(object sender, KeyPressEventArgs e)
        {
            Tools.OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox(sender, e);
        }
    }
}