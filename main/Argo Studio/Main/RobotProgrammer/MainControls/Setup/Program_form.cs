using ArgoStudio.Main.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    public partial class Program_form : Form
    {
        // Init
        public static Program_form instance;
        public Program_form()
        {
            InitializeComponent();
            instance = this;

            // Add events
            CreateProgram_btn.Click += MainControls_form.instance.CreateProgram_btn_Click;
            LoadProgram_gComboBox.DropDown += MainControls_form.instance.LoadProgram_ComboBox_DropDown;
            LoadProgram_gComboBox.SelectedIndexChanged += MainControls_form.instance.LoadProgram_ComboBox_SelectedIndexChanged;
            LoadProgram_btn.Click += MainControls_form.instance.LoadProgram_btn_Click;

            if (MainControls_form.instance.selectedProgramName != null)
                Loaded_label.Text = "'" + MainControls_form.instance.selectedProgramName + "' is loaded";

            if (AppData.RPTutorial)
                Controls.Add(Next_btn);
            else
                Controls.Remove(Next_btn);

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }
        }

        private void OnlyAllowNumbersAndLettersInCreateProgramTextBox(object sender, EventArgs e)
        {
            if (Tools.AreThereAnyNumbersOrLettersInGunaTextBox(sender))
            {
                CreateProgram_gTextBox.BorderColor = Color.Red;
                CreateProgram_gTextBox.FocusedState.BorderColor = Color.Red;
                CreateProgram_btn.Enabled = false;
                Warning_pictureBox.Visible = true;
                Warning_lbl.Visible = true;
            }
            else
            {
                CreateProgram_gTextBox.BorderColor = CustomColors.controlBorder;
                CreateProgram_gTextBox.FocusedState.BorderColor = CustomColors.accent_blue;
                CreateProgram_btn.Enabled = true;
                Warning_pictureBox.Visible = false;
                Warning_lbl.Visible = false;
            }
        }

        private void Loaded_label_TextChanged(object sender, EventArgs e)
        {
            Loaded_label.Left = LoadProgram_gComboBox.Left + (LoadProgram_gComboBox.Width - (Loaded_label.Width + 10 + Checkmark_pictureBox.Width)) / 2;
            Checkmark_pictureBox.Left = Loaded_label.Left + Loaded_label.Width + 10;
            Loaded_label.Visible = true;
            Checkmark_pictureBox.Visible = true;
        }

        private void Export_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void Import_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            MainControls_form.instance.DeleteProgram_btn_Click();
        }

        private void CreateProgram_gTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateProgram_btn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void Next_btn_Click(object sender, EventArgs e)
        {
            Setup_form.instance.FormTutorial.BringToFront();
        }
    }
}