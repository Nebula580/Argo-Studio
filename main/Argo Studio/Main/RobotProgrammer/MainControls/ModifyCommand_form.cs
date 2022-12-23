using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    public partial class ModifyCommand_form : Form
    {
        private readonly DataGridViewRow selectedRow;
        public ModifyCommand_form(DataGridViewRow row)
        {
            InitializeComponent();
            selectedRow = row;

            // Get data
            string[] lines = GetData();

            // Set labels
            Old_label.Text = selectedRow.Cells[0].Value.ToString();
            New_label.Text = Old_label.Text;

            // Construct controls
            switch (lines[0])
            {
                // motionMenu
                case "Move to position ":
                    ConstructLabel("J1", 0, panel);
                    ConstructTextBox(0, "1", lines[2].Trim(), 6, panel);

                    ConstructLabel("J2", 78, panel);
                    ConstructTextBox(78, "2", lines[4].Trim(), 6, panel);

                    ConstructLabel("J3", 156, panel);
                    ConstructTextBox(156, "3", lines[6].Trim(), 6, panel);

                    ConstructLabel("J4", 234, panel);
                    ConstructTextBox(234, "4", lines[8].Trim(), 6, panel);

                    ConstructLabel("J5", 312, panel);
                    ConstructTextBox(312, "5", lines[10].Trim(), 6, panel);

                    ConstructLabel("J6", 390, panel);
                    ConstructTextBox(390, "6", lines[12].Trim(), 6, panel);

                    ConstructLabel("A7", 468, panel);
                    ConstructTextBox(468, "7", lines[14].Trim(), 6, panel);

                    ConstructLabel("Speed", 546, panel);
                    ConstructTextBox(546, "8", lines[16].Trim(), 6, panel);

                    Label label = ConstructLabel("Acceleration", 624, panel);
                    label.Font = new Font("Segoe UI", 8);
                    label.Top = 5;
                    ConstructTextBox(624, "9", lines[18].Trim(), 6, panel);

                    label = ConstructLabel("Deceleration", 702, panel);
                    label.Font = new Font("Segoe UI", 8);
                    label.Top = 5;
                    ConstructTextBox(702, "10", lines[20].Trim(), 6, panel);

                    ConstructLabel("Ramp", 780, panel);
                    ConstructTextBox(780, "11", lines[22].Trim(), 6, panel);

                    SetPanel(890);
                    break;

                case "Move ":
                    ConstructLabel("Move", 0, panel);
                    ConstructGunaComboBox(0, "1", new string[] { "Home", "to limit switches" }, lines[1], false, panel);

                    ConstructLabel("Speed", 190, panel);
                    ConstructTextBox(190, "2", lines[3].Trim(), 6, panel);

                    label = ConstructLabel("Acceleration", 268, panel);
                    label.Font = new Font("Segoe UI", 8);
                    label.Top = 5;
                    ConstructTextBox(268, "3", lines[5].Trim(), 6, panel);

                    label = ConstructLabel("Deceleration", 346, panel);
                    label.Font = new Font("Segoe UI", 8);
                    label.Top = 5;
                    ConstructTextBox(346, "4", lines[7].Trim(), 6, panel);

                    ConstructLabel("Ramp", 424, panel);
                    ConstructTextBox(424, "5", lines[9].Trim(), 6, panel);

                    SetPanel(570);
                    break;

                case "Move to SP ":
                    ConstructLabel("SP", 0, panel);
                    Guna2TextBox gTextBox = ConstructTextBox(0, "1", lines[1], 2, panel);
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;

                    ConstructLabel("Speed", 78, panel);
                    ConstructTextBox(78, "2", lines[3].Trim(), 3, panel);

                    label = ConstructLabel("Acceleration", 156, panel);
                    label.Font = new Font("Segoe UI", 8);
                    label.Top = 5;
                    ConstructTextBox(156, "3", lines[5].Trim(), 6, panel);

                    label = ConstructLabel("Deceleration", 234, panel);
                    label.Font = new Font("Segoe UI", 8);
                    label.Top = 5;
                    ConstructTextBox(234, "4", lines[7].Trim(), 6, panel);

                    ConstructLabel("Ramp", 312, panel);
                    ConstructTextBox(312, "5", lines[9].Trim(), 6, panel);

                    SetPanel(450);
                    break;



                // delayMenu
                case "Delay ":
                    ConstructLabel("Delay", 0, panel);
                    ConstructTextBox(0, "1", lines[1], 20, panel);

                    SetPanel(68);
                    break;

                case "Wait until input ":
                    if (lines[2] == " is ON")
                    {
                        ConstructLabel("Input", 0, panel);
                        ConstructTextBox(0, "1", lines[1], 2, panel);
                    }
                    else if (lines[2] == " is OFF")
                    {
                        ConstructLabel("Input", 0, panel);
                        ConstructTextBox(0, "2", lines[1], 2, panel);
                    }
                    SetPanel(68);
                    break;



                // tabsMenu
                case "Jump to tab ":
                    ConstructLabel("Jump to tab", 0, panel);
                    ConstructGunaComboBox(0, "1", new[] { lines[1] }, lines[1], true, panel);

                    SetPanel(180);
                    break;



                // variablesMenu
                case "Set variable ":
                    ConstructLabel("Variable", 0, panel);
                    gTextBox = ConstructTextBox(0, "1", lines[1], 2, panel);
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;

                    ConstructLabel("Num", 78, panel);
                    ConstructTextBox(78, "2", lines[3], 5, panel);

                    SetPanel(146);
                    break;

                case "Variable ":
                    ConstructLabel("SP", 0, panel);
                    gTextBox = ConstructTextBox(0, "1", lines[1], 2, panel);
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;

                    ConstructLabel("", 78, panel);
                    ConstructGunaComboBox(78, "2", new[] { "Increase", "Decrease" }, lines[2].Trim(), false, panel);

                    ConstructLabel("Num", 268, panel);
                    ConstructTextBox(268, "3", lines[4], 5, panel);

                    SetPanel(346);
                    break;

                case "If variable ":
                    ConstructLabel("Variable", 0, panel);
                    gTextBox = ConstructTextBox(0, "1", lines[1], 5, panel);
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;

                    ConstructLabel("Num", 78, panel);
                    ConstructTextBox(78, "2", lines[3], 5, panel);

                    ConstructLabel("Tab", 156, panel);
                    ConstructGunaComboBox(156, "3", new[] { lines[5] }, lines[5], true, panel);

                    SetPanel(336);
                    break;



                // IOMenu
                case "Set output ":
                    if (lines[2] == " ON")
                    {
                        ConstructLabel("Output", 0, panel);
                        ConstructTextBox(0, "1", lines[1], 2, panel);
                    }
                    else if (lines[2] == " OFF")
                    {
                        ConstructLabel("Output", 0, panel);
                        ConstructTextBox(0, "2", lines[1], 2, panel);
                    }
                    SetPanel(68);
                    break;

                case "If input ":
                    if (lines[2] == " is ON")
                    {
                        ConstructLabel("Input", 0, panel);
                        ConstructTextBox(0, "1", lines[1], 2, panel);

                        ConstructLabel("Tab", 78, panel);
                        ConstructGunaComboBox(78, "2", new[] { lines[4] }, lines[4], true, panel);
                    }
                    else if (lines[2] == " is OFF")
                    {
                        ConstructLabel("Input", 0, panel);
                        ConstructTextBox(0, "1", lines[1], 2, panel);

                        ConstructLabel("Tab", 78, panel);
                        ConstructGunaComboBox(78, "2", new[] { lines[4] }, lines[4], true, panel);
                    }
                    SetPanel(268);
                    break;



                // servoMenu
                case "Move servo ":
                    ConstructLabel("Servo", 0, panel);
                    gTextBox = ConstructTextBox(0, "1", lines[1], 1, panel);
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox2;

                    ConstructLabel("Degree", 78, panel);
                    gTextBox = ConstructTextBox(78, "2", lines[3].Trim(), 3, panel);
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox360;

                    ConstructLabel("Speed", 156, panel);
                    gTextBox = ConstructTextBox(156, "3", lines[5].Trim(), 3, panel);
                    gTextBox.KeyPress += Tools.OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox;
                    gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox100;

                    SetPanel(230);
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

        private void SaveControl(object sender, EventArgs e)
        {
            SaveInRowOrUpdateNewLabel(false);
        }

        private string[] GetData()
        {
            return selectedRow.Cells[0].Value.ToString().Split(new char[] { ':', ',', '\'' });
        }

        private void SetPanel(int width)
        {
            panel.Width = width;
            panel.Left = (Width - panel.Width) / 2;
        }
        private bool shouldClose;
        private void Save_btn_Click(object sender, EventArgs e)
        {
            SaveInRowOrUpdateNewLabel(true);
        }
        private void SaveInRowOrUpdateNewLabel(bool saveInRow)
        {
            // Reset
            shouldClose = true;

            string[] lines = GetData();

            switch (lines[0])
            {
                // motionMenu
                case "Move to position ":
                    Guna2TextBox f1_2 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2TextBox f2_2 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();
                    Guna2TextBox f3_2 = (Guna2TextBox)panel.Controls.Find("3", false).FirstOrDefault();
                    Guna2TextBox f4_2 = (Guna2TextBox)panel.Controls.Find("4", false).FirstOrDefault();
                    Guna2TextBox f5_2 = (Guna2TextBox)panel.Controls.Find("5", false).FirstOrDefault();
                    Guna2TextBox f6_2 = (Guna2TextBox)panel.Controls.Find("6", false).FirstOrDefault();
                    Guna2TextBox f7_2 = (Guna2TextBox)panel.Controls.Find("7", false).FirstOrDefault();
                    Guna2TextBox f8_2 = (Guna2TextBox)panel.Controls.Find("8", false).FirstOrDefault();
                    Guna2TextBox f9_2 = (Guna2TextBox)panel.Controls.Find("9", false).FirstOrDefault();
                    Guna2TextBox f10_2 = (Guna2TextBox)panel.Controls.Find("10", false).FirstOrDefault();
                    Guna2TextBox f11_2 = (Guna2TextBox)panel.Controls.Find("11", false).FirstOrDefault();

                    if (f1_2.Text != "" & f2_2.Text != "" & f3_2.Text != "" & f4_2.Text != "" & f5_2.Text != "" & f6_2.Text != "" & f7_2.Text != "" & f8_2.Text != "" & f9_2.Text != "" & f10_2.Text != "" & f11_2.Text != "")
                    {
                        // Set data
                        lines[1] = "'J1: ";
                        lines[2] = f1_2.Text + ",";
                        lines[4] = ": " + f2_2.Text + ",";
                        lines[6] = ": " + f3_2.Text + ",";
                        lines[8] = ": " + f4_2.Text + ",";
                        lines[10] = ": " + f5_2.Text + ",";
                        lines[12] = ": " + f6_2.Text + ",";
                        lines[14] = ": " + f7_2.Text + ",";
                        lines[16] = ": " + f8_2.Text + ",";
                        lines[18] = ": " + f9_2.Text + ",";
                        lines[20] = ": " + f10_2.Text + ",";
                        lines[22] = ": " + f11_2.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;

                case "Move ":
                    Guna2ComboBox f1_3 = (Guna2ComboBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2TextBox f2_3 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();
                    Guna2TextBox f3_3 = (Guna2TextBox)panel.Controls.Find("3", false).FirstOrDefault();
                    Guna2TextBox f4_3 = (Guna2TextBox)panel.Controls.Find("4", false).FirstOrDefault();
                    Guna2TextBox f5_3 = (Guna2TextBox)panel.Controls.Find("5", false).FirstOrDefault();

                    if (f1_3.Text != "" & f2_3.Text != "" & f3_3.Text != "" & f4_3.Text != "" & f5_3.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_3.Text + ",";
                        lines[3] = ": " + f2_3.Text + ",";
                        lines[5] = ": " + f3_3.Text + ",";
                        lines[7] = ": " + f4_3.Text + ",";
                        lines[9] = ": " + f5_3.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;

                case "Move to SP ":
                    Guna2TextBox f1_4 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2TextBox f2_4 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();
                    Guna2TextBox f3_4 = (Guna2TextBox)panel.Controls.Find("3", false).FirstOrDefault();
                    Guna2TextBox f4_4 = (Guna2TextBox)panel.Controls.Find("4", false).FirstOrDefault();
                    Guna2TextBox f5_4 = (Guna2TextBox)panel.Controls.Find("5", false).FirstOrDefault();

                    if (f1_4.Text != "" & f2_4.Text != "" & f3_4.Text != "" & f4_4.Text != "" & f5_4.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_4.Text + ",";
                        lines[3] = ": " + f2_4.Text + ",";
                        lines[5] = ": " + f3_4.Text + ",";
                        lines[7] = ": " + f4_4.Text + ",";
                        lines[9] = ": " + f5_4.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;



                // delayMenu
                case "Delay ":
                    Guna2TextBox f1_5 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();

                    if (f1_5.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_5.Text + ",";
                        lines[3] = "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;

                case "Wait until input ":

                    if (lines[2] == " is ON")
                    {
                        Guna2TextBox f1_6 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();

                        if (f1_6.Text != "")
                        {
                            // Set data
                            lines[1] = "'" + f1_6.Text + ",";
                            lines[3] = "'";
                            // Save data
                            if (saveInRow) { SaveInRow(lines); }
                            else { UpdateNewLabel(lines); }
                        }
                        else { AllInputsMustBeFilledMessage(saveInRow); }
                    }
                    else if (lines[2] == " is OFF")
                    {
                        Guna2TextBox f1_7 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();

                        if (f1_7.Text != "")
                        {
                            // Set data
                            lines[1] = "'" + f1_7.Text + ",";
                            lines[3] = "'";
                            // Save data
                            if (saveInRow) { SaveInRow(lines); }
                            else { UpdateNewLabel(lines); }
                        }
                        else { AllInputsMustBeFilledMessage(saveInRow); }
                    }
                    break;



                // tabsMenu
                case "Jump to tab ":
                    Guna2ComboBox f1_1 = (Guna2ComboBox)panel.Controls.Find("1", false).FirstOrDefault();

                    if (f1_1.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_1.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;



                // variablesMenu
                case "Set variable ":
                    Guna2TextBox f1_12 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2TextBox f2_12 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();

                    if (f1_12.Text != "" & f2_12.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_12.Text + ",";
                        lines[3] = ": " + f2_12.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;

                case "Variable ":
                    Guna2TextBox f1_13 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2ComboBox f2_13 = (Guna2ComboBox)panel.Controls.Find("2", false).FirstOrDefault();
                    Guna2TextBox f3_13 = (Guna2TextBox)panel.Controls.Find("3", false).FirstOrDefault();

                    if (f1_13.Text != "" & f2_13.Text != "" & f3_13.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_13.Text + ", ";
                        lines[2] = f2_13.Text + ",";
                        lines[4] = ": " + f3_13.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;

                case "If variable ":
                    Guna2TextBox f1_14 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2TextBox f2_14 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();
                    Guna2ComboBox f3_14 = (Guna2ComboBox)panel.Controls.Find("3", false).FirstOrDefault();

                    if (f1_14.Text != "" & f2_14.Text != "" & f3_14.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_14.Text + ",";
                        lines[3] = ", " + f2_14.Text + ",";
                        lines[5] = ": " + f3_14.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;




                // IOMenu
                case "Set output ":
                    if (lines[2] == " ON")
                    {
                        Guna2TextBox f1_8 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();

                        if (f1_8.Text != "")
                        {
                            // Set data
                            lines[1] = "'" + f1_8.Text + ",";
                            lines[2] += "'";
                            // Save data
                            if (saveInRow) { SaveInRow(lines); }
                            else { UpdateNewLabel(lines); };
                        }
                        else { AllInputsMustBeFilledMessage(saveInRow); }
                    }
                    else if (lines[2] == " OFF")
                    {
                        Guna2TextBox f1_9 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();

                        if (f1_9.Text != "")
                        {
                            // Set data
                            lines[1] = "'" + f1_9.Text + ",";
                            lines[2] += "'";
                            // Save data
                            if (saveInRow) { SaveInRow(lines); }
                            else { UpdateNewLabel(lines); }
                        }
                        else { AllInputsMustBeFilledMessage(saveInRow); }
                    }
                    break;

                case "If input ":
                    if (lines[2] == " is ON")
                    {
                        Guna2TextBox f1_10 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                        Guna2ComboBox f2_10 = (Guna2ComboBox)panel.Controls.Find("2", false).FirstOrDefault();

                        if (f1_10.Text != "" & f2_10.Text != "")
                        {
                            // Set data
                            lines[1] = "'" + f1_10.Text + ",";
                            lines[3] = ", jump to tab: ";
                            lines[4] = f2_10.Text + "'";
                            // Save data
                            if (saveInRow) { SaveInRow(lines); }
                            else { UpdateNewLabel(lines); }
                        }
                        else { AllInputsMustBeFilledMessage(saveInRow); }
                    }
                    else if (lines[2] == " is OFF")
                    {
                        Guna2TextBox f1_11 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                        Guna2ComboBox f2_11 = (Guna2ComboBox)panel.Controls.Find("2", false).FirstOrDefault();

                        if (f1_11.Text != "" & f2_11.Text != "")
                        {
                            // Set data
                            lines[1] = "'" + f1_11.Text + ",";
                            lines[3] = ", jump to tab: ";
                            lines[4] = f2_11.Text + "'";
                            // Save data
                            if (saveInRow) { SaveInRow(lines); }
                            else { UpdateNewLabel(lines); }
                        }
                        else { AllInputsMustBeFilledMessage(saveInRow); }
                    }
                    break;



                // servoMenu
                case "Move servo ":
                    Guna2TextBox f1_15 = (Guna2TextBox)panel.Controls.Find("1", false).FirstOrDefault();
                    Guna2TextBox f2_15 = (Guna2TextBox)panel.Controls.Find("2", false).FirstOrDefault();
                    Guna2TextBox f3_15 = (Guna2TextBox)panel.Controls.Find("3", false).FirstOrDefault();

                    if (f1_15.Text != "" & f2_15.Text != "" & f3_15.Text != "")
                    {
                        // Set data
                        lines[1] = "'" + f1_15.Text + ",";
                        lines[3] = ": " + f2_15.Text + ",";
                        lines[5] = ": " + f3_15.Text + "'";
                        // Save data
                        if (saveInRow) { SaveInRow(lines); }
                        else { UpdateNewLabel(lines); }
                    }
                    else { AllInputsMustBeFilledMessage(saveInRow); }
                    break;
            }

            if (shouldClose)
                Close();
        }
        /// <summary>
        /// Convert string[] to string and save it in the row
        /// </summary>
        private void SaveInRow(string[] lines)
        {
            selectedRow.Cells[0].Value = string.Join("", lines);
        }
        /// <summary>
        /// Convert string[] to string and save it in New_label.Text
        /// </summary>
        private void UpdateNewLabel(string[] lines)
        {
            New_label.Text = string.Join("", lines);
            shouldClose = false;
        }
        private void AllInputsMustBeFilledMessage(bool saveInRow)
        {
            shouldClose = false;
            if (saveInRow)
                CustomMessageBox.Show("Argo Studio", "All of the inputs must be filled.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
        }
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }



        // Construct controls
        private Guna2ComboBox ConstructGunaComboBox(int left, string name, string[] item2, string text, bool addListOfTabs, Control control)
        {
            Guna2ComboBox gComboBox = new Guna2ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Left = left,
                Top = 25,
                Size = new Size(180, 30),
                FillColor = CustomColors.controlBack,
                ForeColor = CustomColors.text,
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3,
                Name = name
            };
            foreach (string item in item2)
            {
                gComboBox.Items.Add(item);
            }
            gComboBox.Text = text;
            gComboBox.MouseWheel += UI.Combobox_MouseWheel;
            gComboBox.SelectedIndexChanged += SaveControl;
            if (addListOfTabs)
            {
                gComboBox.DropDown += MainControls_form.instance.AddListOfTabsInComboBox;
            }
            control.Controls.Add(gComboBox);

            return gComboBox;
        }
        private Guna2TextBox ConstructTextBox(int left, string name, string text, int maxLength, Control control)
        {
            Guna2TextBox gTextBox = new Guna2TextBox()
            {
                Left = left,
                Top = 25,
                Size = new Size(68, 27),
                Name = name,
                Text = text,
                ForeColor = CustomColors.text,
                BackColor = CustomColors.controlBack,
                Font = new Font("Segoe UI", 10),
                MaxLength = maxLength,
                FillColor = CustomColors.controlBack,
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3,
                ShortcutsEnabled = false,
                Cursor = Cursors.Hand
            };
            gTextBox.FocusedState.FillColor = CustomColors.controlBack;
            gTextBox.HoverState.BorderColor = CustomColors.accent_blue;
            gTextBox.FocusedState.BorderColor = CustomColors.accent_blue;
            gTextBox.KeyPress += Tools.OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox;
            gTextBox.TextChanged += SaveControl;
            control.Controls.Add(gTextBox);

            return gTextBox;
        }
        private Label ConstructLabel(string text, int left, Control control)
        {
            Label label = new Label
            {
                ForeColor = CustomColors.text,
                Cursor = Cursors.Arrow,
                Left = left,
                Text = text,
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };
            control.Controls.Add(label);

            return label;
        }
    }
}