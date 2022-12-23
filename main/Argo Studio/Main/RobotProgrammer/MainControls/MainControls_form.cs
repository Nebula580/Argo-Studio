using ArgoStudio.Main.BuildMachines.MachineProgrammer;
using ArgoStudio.Main.Classes;
using ArgoStudio.Main.RobotProgrammer.MainControls;
using ArgoStudio.Main.RobotProgrammer.MainControls.Setup;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer
{
    public partial class MainControls_form : Form
    {
        // Init
        public static MainControls_form instance;
        public MainControls_form()
        {
            InitializeComponent();
            instance = this;

            // Disable horizontal scroll on Tabs_FlowLayoutPanel
            Tabs_FlowLayoutPanel.HorizontalScroll.Enabled = false;
            Tabs_FlowLayoutPanel.HorizontalScroll.Maximum = 0;
            Tabs_FlowLayoutPanel.AutoScroll = true;

            UpdateTheme();

            Hide7AxisPanel();
            HideServoGripperPanel();
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


        // Form
        public bool isFormOpen;
        private void MainControls_form_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }
        private void MainControls_form_Load(object sender, EventArgs e)
        {
            isFormOpen = true;
        }
        private void MainControls_form_Shown(object sender, EventArgs e)
        {
            new Setup_form().ShowDialog();
        }
        private void MainControls_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
        }


        // Robot info
        public string robotName, robotFirmware;
        public bool robotIs7AxisConnected, robotIsServoGripperConnected;

        // Serial
        public string portName;
        public bool isRobotConnected;
        // Delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (SerialPort1.IsOpen)
            {
                string data = SerialPort1.ReadExisting();
                BeginInvoke(new SetTextDeleg(SerialDataReceived), new object[] { data });
            }
        }
        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (SerialPort1.IsOpen)
            {
                string data = SerialPort1.ReadExisting();
                BeginInvoke(new SetTextDeleg(SerialDataReceived), new object[] { data });
            }
        }
        private void SerialComTimeout_timer_Tick(object sender, EventArgs e)
        {
            // Disconnect serial
            Log.Write(4, "Disconnected from '" + portName + "'");
            Control_panel.Enabled = false;
            SerialComTimeout_timer.Enabled = false;
            SerialPort1.Close();

            Log.Write(1, "Couldn't connect to '" + portName + "'. Last received message from " + SerialPort1.PortName + " (" + ConnectRobot_form.ThreadClass.GetNameBasedOnPort(SerialPort1.PortName) + "): " + lastReceivedSerialMessage);
            CustomMessageBox.Show("Argo Studio", "Couldn't connect to '" + portName + "'. Please try again. If you still cannot connect, visit our support page at support.argorobots.ca.", CustomMessageBoxIcon.Error, CustomMessageBoxButtons.Ok);
        }
        private string lastReceivedSerialMessage;
        private void SerialDataReceived(string data)
        {
            lastReceivedSerialMessage = data;
            string[] trimmedData = data.Split(new char[] { '<', '-', ':', ',', '>' });

            Log.Write(4, "Teensy 4.1: '" + data + "'");

            if (trimmedData.Length > 1)
            {
                if (!isRobotConnected)
                {
                    Log.Write(4, "Teensy 4.1: '" + data + "'");

                    if (trimmedData[1] == "argo_hi")
                    {

                        // Connected to serial
                        SerialWrite("<hi from argo studio>");
                        SerialComTimeout_timer.Enabled = false;
                        Log.Write(4, "Connected to '" + portName + "'");

                        portName = SerialPort1.PortName;
                        ConnectRobot_form.instance.SetControlToConnected();
                        Control_panel.Enabled = true;
                        MainMenu_form.instance.Program_btn.Enabled = true;
                        isRobotConnected = true;
                    }
                }
                if (trimmedData[1] == "info")
                {
                    // Read info
                    robotName = trimmedData[3];
                    robotFirmware = trimmedData[5];

                    if (trimmedData[7] == "0")
                        robotIs7AxisConnected = false;
                    else if (trimmedData[7] == "1")
                        robotIs7AxisConnected = true;
                    else
                        Log.SerialComReceivedIncorrectFormat(SerialPort1.PortName, robotName, data);

                    if (trimmedData[9] == "0")
                        robotIsServoGripperConnected = false;
                    else if (trimmedData[9] == "1")
                        robotIsServoGripperConnected = true;
                    else
                        Log.SerialComReceivedIncorrectFormat(SerialPort1.PortName, robotName, data);

                    // Do things
                    if (robotIs7AxisConnected)
                        Show7AxisPanel();

                    if (robotIsServoGripperConnected)
                        ShowServoGripperPanel();
                }
            }
        }
        public void SerialWrite(string message)
        {
            if (SerialPort1.IsOpen)
                SerialPort1.Write(message);
        }
        public void CloseSerial()
        {
            SerialWrite("<close>");
            SerialPort1.Close();
        }


        // 7th axis panel
        public void Hide7AxisPanel()
        {
            Control_panel.Controls.Remove(Axis7_panel);
            Control_panel.Controls.Remove(Guna2VSeparator1);
            InnerControl_Panel.Left = Control_panel.Width - InnerControl_Panel.Width - 8;
            if (MainMenu_form.instance != null)
            {
                MainMenu_form.instance.MinimumSize = new Size(1000, 670);
            }

            CenterControls();
        }
        private void Show7AxisPanel()
        {
            Control_panel.Controls.Add(Axis7_panel);
            Control_panel.Controls.Add(Guna2VSeparator1);
            InnerControl_Panel.Left = 230;
            Control_panel.Width = 1260;
            if (MainMenu_form.instance != null)
            {
                MainMenu_form.instance.MinimumSize = new Size(1175, 670);
            }

            CenterControls();
        }

        // Servo gripper
        public void HideServoGripperPanel()
        {
            Control_panel.Controls.Remove(ServoGripper_panel);
            Control_panel.Controls.Remove(Guna2VSeparator1);
            InnerControl_Panel.Left = Control_panel.Width - InnerControl_Panel.Width - 8;
            if (MainMenu_form.instance != null)
            {
                MainMenu_form.instance.MinimumSize = new Size(1000, 670);
            }

            CenterControls();
        }
        private void ShowServoGripperPanel()
        {
            Control_panel.Controls.Add(ServoGripper_panel);
            Control_panel.Controls.Add(Guna2VSeparator1);
            InnerControl_Panel.Left = 230;
            Control_panel.Width = 1260;
            if (MainMenu_form.instance != null)
            {
                MainMenu_form.instance.MinimumSize = new Size(1175, 670);
            }

            // Move ServoGripper_panel to the top if Axis7_panel is hidden
            if (!Control_panel.Controls.Contains(Axis7_panel))
            {
                ServoGripper_panel.Top = 12;
            }
            else { ServoGripper_panel.Top = 217; }

            CenterControls();
        }

        private void CenterControls()
        {
            if (Width < 1350)
            {
                InnerControl_Panel.Left = 230 - 130;
                if (Control_panel.Controls.Contains(Axis7_panel) || Control_panel.Controls.Contains(ServoGripper_panel))
                    Control_panel.Width = 1260 - 130;
                else
                    Control_panel.Width = 1260 - 208 - 130 + 7;
            }
            else
            {
                InnerControl_Panel.Left = 230;
                if (Control_panel.Controls.Contains(Axis7_panel) || Control_panel.Controls.Contains(ServoGripper_panel))
                    Control_panel.Width = 1260;
                else
                    Control_panel.Width = 1260 - 130;
            }

            Guna2VSeparator1.Left = 1079;
            Axis7_panel.Left = 1084;
            ServoGripper_panel.Left = 1084;

            Control_panel.Left = (Width - Control_panel.Width) / 2;
            Tab_panel.Left = Control_panel.Left;
            DataGridViewBack_panel.Left = Tab_panel.Left + Tab_panel.Width + 10;
            DataGridViewBack_panel.Width = Control_panel.Width - Tab_panel.Width - 8;
        }


        // Play
        private bool isProgramRunning, WaitUntilRobotHasFinished;
        public string selectedProgramName;
        private int dataGridViewWaitAmount;
        public void Play()
        {
            if (MainMenu_form.instance.Play_btn.Text == "Play")
            {
                if (Tabs_FlowLayoutPanel.Controls.Count > 0)
                {
                    if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                    {
                        SetProgramRunStatus_Running();
                        MainMenu_form.instance.SetMessage("Playing program '" + selectedProgramName + "'");
                        Log.Write(4, "Playing program '" + selectedProgramName + "'");

                        if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                        {
                            isProgramRunning = true;

                            // Switch to first tab
                            tabClickedTag = 1;
                            dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.fileSelected;
                            SwitchDataGridView(tabClickedTag);
                            UnselectAllRowsInCurrentDataGridView();
                            dataGridView_list[tabClickedTag - 1].Rows[0].Cells[0].Selected = true;

                            // Set tab label
                            ResetTabPanelClickedLabels();
                            tabs_list[tabClickedTag - 1].FillColor = CustomColors.accent_green;
                            tabs_list[tabClickedTag - 1].DisabledState.FillColor = CustomColors.accent_green;

                            Forward();
                        }
                    }
                    else
                        CustomMessageBox.Show("Argo Studio", "Add at least one command before playing.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                }
                else
                    CustomMessageBox.Show("Argo Studio", "Select a program before playing.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
            }
            else Stop();
        }
        private int WaitUntilRobotHasFinishedMoving()
        {
            if (dataGridViewWaitAmount != 0)
            {
                return dataGridViewWaitAmount;
            }
            else if (WaitUntilRobotHasFinished)
            {
                // Communicate with RPI here

                return 800;
            }
            return 0;
        }
        private void ReadRowInDataGridView(int grid, int rowIndex)
        {
            if (dataGridView_list[grid - 1].Rows.Count > 0)
            {
                string row = (string)dataGridView_list[grid - 1].Rows[rowIndex].Cells[0].Value;
                string[] lines = row.Split(new char[] { '\'', ':', ',' });

                Log.Write(4, "Running command: " + row);

                switch (lines[0])
                {
                    case "Move to ":
                        if (lines[1] == "Home")
                        {
                            WaitUntilRobotHasFinished = true;
                        }
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;

                    case "Move to SP ":
                        WaitUntilRobotHasFinished = true;
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;

                    case "Move servo ":
                        WaitUntilRobotHasFinished = true;
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;

                    case "If input ":
                        if (lines[2] == " is ON then jump to tab ")
                        {
                            WaitUntilRobotHasFinished = true;
                        }
                        else if (lines[2] == " is OFF then jump to tab ")
                        {
                            WaitUntilRobotHasFinished = true;
                        }
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;

                    case "Set variable ":
                        int oldValue = Variables.variables_list[Convert.ToInt32(lines[1])];
                        Variables.variables_list[Convert.ToInt32(lines[1])] = Convert.ToInt32(lines[3]);
                        Log.Write(4, "Set variable '" + lines[1] + "' from '" + oldValue + "' to '" + Variables.variables_list[Convert.ToInt32(lines[1])] + "'");

                        break;

                    case "Variable ":
                        if (lines[2] == " Increase")
                        {
                            int oldValue2 = Variables.variables_list[Convert.ToInt32(lines[1])];
                            Variables.variables_list[Convert.ToInt32(lines[1])] += Convert.ToInt32(lines[4]);
                            Log.Write(4, "Increased variable '" + lines[1] + "' from '" + oldValue2 + "' to '" + Variables.variables_list[Convert.ToInt32(lines[1])] + "'");
                        }
                        else if (lines[2] == " Decrease")
                        {
                            int oldValue3 = Variables.variables_list[Convert.ToInt32(lines[1])];
                            Variables.variables_list[Convert.ToInt32(lines[1])] -= Convert.ToInt32(lines[4]);
                            Log.Write(4, "Decreased variable '" + lines[1] + "' from '" + oldValue3 + "' to '" + Variables.variables_list[Convert.ToInt32(lines[1])] + "'");
                        }
                        break;

                    case "If Variable ":
                        if (Variables.variables_list[Convert.ToInt32(lines[1])] == Convert.ToInt32(lines[3]))
                        {
                            int tag = TabNames_list.IndexOf(lines[5].TrimStart()) + 1;
                            JumpToTab(tag, lines[5]);
                        }
                        break;

                    case "Jump to tab ":
                        int tag2 = TabNames_list.IndexOf(lines[1]) + 1;
                        JumpToTab(tag2, lines[1]);
                        break;

                    case "Jump to previous tab":
                        JumpToTab(previousTabTag, previousTabName);
                        break;

                    case "Delay ":
                        WaitUntilRobotHasFinished = true;
                        dataGridViewWaitAmount = Convert.ToInt32(lines[1]);
                        break;

                    case "Wait until input ":
                        if (lines[2] == " is ON")
                        {
                            WaitUntilRobotHasFinished = true;
                        }
                        else if (lines[2] == " is OFF")
                        {
                            WaitUntilRobotHasFinished = true;
                        }
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;

                    case "Set output ":
                        if (lines[2] == " ON")
                        {

                        }
                        else if (lines[2] == " OFF")
                        {

                        }
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;

                    case "Move to position ":
                        WaitUntilRobotHasFinished = true;
                        // Send data to RPI
                        if (SerialPort1.IsOpen) { SerialWrite("<" + row + ">"); }
                        break;
                }
            }
        }
        private bool didProgramJustJumpToTab = false;
        private int previousTabTag;
        private string previousTabName;
        private void JumpToTab(int tabNumber, string tabName)
        {
            if (dataGridView_list[tabNumber - 1] != null)
            {
                previousTabTag = tabClickedTag;
                previousTabName = tabName;

                tabClickedTag = dataGridViewNames_list.IndexOf("DataGridView" + tabNumber) + 1;

                // Switch dataGridView
                SwitchDataGridView(tabClickedTag);
                UnselectAllRowsInCurrentDataGridView();

                // Set tab label
                ResetTabPanelClickedLabels();
                tabs_list[tabClickedTag - 1].FillColor = CustomColors.accent_green;
                tabs_list[tabClickedTag - 1].DisabledState.FillColor = CustomColors.accent_green;

                // Select first row
                if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                {
                    dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.fileSelected;
                    dataGridView_list[tabClickedTag - 1].Rows[0].Cells[0].Selected = true;
                }

                didProgramJustJumpToTab = true;
                Log.Write(4, "Jumped to tab '" + tabName + "'");
            }
            else
            {
                CustomMessageBox.Show("Argo Studio", "Could not jump to tab '" + tabName + "' because '" + tabName + "' does not exist.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                Stop();
            }
        }

        // Forward
        public async void Forward()
        {
            if (Tabs_FlowLayoutPanel.Controls.Count > 0)
            {
                if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 1)
                {
                    DataGridViewCell cell = null;
                    bool pass1 = false, areAnyRowsSelected = false;
                    if (tabClickedTag > 0)
                    {
                        for (int i = 0; i < dataGridView_list[tabClickedTag - 1].Rows.Count; i++)
                        {
                            // If any row is selected
                            if (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected)
                            {
                                // Reset
                                wasStopBtnClicked = false;
                                areAnyRowsSelected = true;

                                dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.accent_green;
                                ReadRowInDataGridView(tabClickedTag, i);

                                if (didProgramJustJumpToTab) break;

                                SetProgramRunStatus_Running();

                                // Wait until robot has moved
                                int delay = WaitUntilRobotHasFinishedMoving() / 10;
                                for (int i2 = 0; i2 < delay; i2++)
                                {
                                    await Task.Delay(10);
                                    if (wasStopBtnClicked) break;
                                }
                                if (wasStopBtnClicked) break;

                                // Reset
                                WaitUntilRobotHasFinished = false;
                                dataGridViewWaitAmount = 0;

                                // Unselect current row
                                cell = dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0];
                                cell.Selected = false;

                                // Select next row
                                if (i + 1 < dataGridView_list[tabClickedTag - 1].Rows.Count)
                                {
                                    dataGridView_list[tabClickedTag - 1].Rows[i + 1].Cells[0].Selected = true;
                                    pass1 = true;
                                }
                                else SetProgramRunStatus_Done(true);
                                break;
                            }
                        }
                        if (!areAnyRowsSelected)
                        {
                            if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 0)
                            {
                                CustomMessageBox.Show("Argo Studio", "Select a command to move forward.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                                pass1 = true;
                            }
                            else SetProgramRunStatus_Done(false);
                        }
                    }
                    if (pass1 && !wasStopBtnClicked || didProgramJustJumpToTab)
                    {
                        didProgramJustJumpToTab = false;
                        Log.Write(4, "Moved forward by one command");
                        SerialWrite("<" + cell + ">");

                        if (isProgramRunning)
                            Forward();  // If app is still playing, continue
                        else
                            SetProgramRunStatus_Done(false);  // If app is not playing, then the FWD_btn was clicked
                    }
                }
                else
                    CustomMessageBox.Show("Argo Studio", "You can only select one command to move forward.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
            }
            else
                CustomMessageBox.Show("Argo Studio", "Select a program before playing.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
        }

        // Backward
        public async void Backward()
        {
            if (Tabs_FlowLayoutPanel.Controls.Count > 0)
            {
                if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 1)
                {
                    bool pass1 = false, areAnyRowsSelected = false;
                    if (tabClickedTag > 0)
                    {
                        SetProgramRunStatus_Running();

                        for (int i = 0; i < dataGridView_list[tabClickedTag - 1].Rows.Count; i++)
                        {
                            // If any row is selected
                            if (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected)
                            {
                                // Reset
                                wasStopBtnClicked = false;
                                areAnyRowsSelected = true;

                                // If row is not green
                                if (dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor != CustomColors.accent_green)
                                {
                                    dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.accent_green;
                                    ReadRowInDataGridView(tabClickedTag, i);

                                    if (didProgramJustJumpToTab)
                                    {
                                        didProgramJustJumpToTab = false;
                                        break;
                                    }

                                    SetProgramRunStatus_Running();

                                    // Wait until robot has moved
                                    int delay = WaitUntilRobotHasFinishedMoving() / 10;
                                    for (int i2 = 0; i2 < delay; i2++)
                                    {
                                        await Task.Delay(10);
                                        if (wasStopBtnClicked) break;
                                    }
                                    // Reset
                                    WaitUntilRobotHasFinished = false;
                                    dataGridViewWaitAmount = 0;

                                    // Unselect current row
                                    dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected = false;

                                    // Select next row
                                    if (i > 0)
                                        dataGridView_list[tabClickedTag - 1].Rows[i - 1].Cells[0].Selected = true;
                                    else
                                        SetProgramRunStatus_Done(true);

                                    pass1 = true;
                                    break;
                                }
                            }
                        }
                        if (!areAnyRowsSelected)
                        {
                            if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 0)
                            {
                                CustomMessageBox.Show("Argo Studio", "Select a command to move backward.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                                pass1 = true;
                            }
                            else SetProgramRunStatus_Done(false);
                        }
                    }
                    if (pass1)
                    {
                        Log.Write(4, "Moved backward by one command");
                        SetProgramRunStatus_Done(false);
                    }
                }
                else
                    CustomMessageBox.Show("Argo Studio", "You can only select one command to move forward.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
            }
            else
                CustomMessageBox.Show("Argo Studio", "Select a program before playing.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
        }

        // Stop
        private bool wasStopBtnClicked;
        private void Stop()
        {
            tabs_list[tabClickedTag - 1].FillColor = CustomColors.accent_red;
            dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.accent_red;

            isProgramRunning = false;
            wasStopBtnClicked = true;

            Control_panel.Enabled = true;
            Tab_panel.Enabled = true;
            EnableCommandButtons();
            MainMenu_form.instance.Workspace_btn.Enabled = true;
            MainMenu_form.instance.RobotWorkspace_btn.Enabled = true;
            MainMenu_form.instance.Connect_btn.Enabled = true;
            MainMenu_form.instance.Program_btn.Enabled = true;
            MainMenu_form.instance.Upload_btn.Enabled = true;
            MainMenu_form.instance.RobotSpeed_btn.Enabled = true;
            MainMenu_form.instance.Forward_btn.Enabled = true;
            MainMenu_form.instance.Backward_btn.Enabled = true;

            MainMenu_form.instance.Play_btn.Text = "Play";
            MainMenu_form.instance.Play_btn.FillColor = CustomColors.accent_playBtnGreen;

            MainMenu_form.instance.SetMessage("Stopped program '" + selectedProgramName + "'");
            Log.Write(4, "Stopped program '" + selectedProgramName + "'");
        }


        // Set program run status
        private void SetProgramRunStatus_Running()
        {
            if (WaitUntilRobotHasFinished)
            {
                MainMenu_form.instance.Play_btn.Text = "Stop";
                MainMenu_form.instance.Play_btn.FillColor = Color.Red;

                Control_panel.Enabled = false;
                Tab_panel.Enabled = false;
                DisableCommandButtons();
                MainMenu_form.instance.Workspace_btn.Enabled = false;
                MainMenu_form.instance.RobotWorkspace_btn.Enabled = false;
                MainMenu_form.instance.Connect_btn.Enabled = false;
                MainMenu_form.instance.Program_btn.Enabled = false;
                MainMenu_form.instance.Upload_btn.Enabled = false;
                MainMenu_form.instance.RobotSpeed_btn.Enabled = false;
                MainMenu_form.instance.Forward_btn.Enabled = false;
                MainMenu_form.instance.Backward_btn.Enabled = false;
            }
        }
        private void SetProgramRunStatus_Done(bool didProgramFinishPlaying)
        {
            dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.fileSelected;
            tabs_list[tabClickedTag - 1].FillColor = CustomColors.fileSelected;

            MainMenu_form.instance.Play_btn.Text = "Play";
            MainMenu_form.instance.Play_btn.FillColor = CustomColors.accent_playBtnGreen;

            isProgramRunning = false;

            Control_panel.Enabled = true;
            Tab_panel.Enabled = true;
            EnableCommandButtons();
            MainMenu_form.instance.Workspace_btn.Enabled = true;
            MainMenu_form.instance.RobotWorkspace_btn.Enabled = true;
            MainMenu_form.instance.Connect_btn.Enabled = true;
            MainMenu_form.instance.Program_btn.Enabled = true;
            MainMenu_form.instance.Upload_btn.Enabled = true;
            MainMenu_form.instance.RobotSpeed_btn.Enabled = true;
            MainMenu_form.instance.Forward_btn.Enabled = true;
            MainMenu_form.instance.Backward_btn.Enabled = true;

            if (didProgramFinishPlaying)
            {
                Variables.ResetAllVariablesToInitialValue();
                MainMenu_form.instance.SetMessage("Program '" + selectedProgramName + "' has finished playing");
                Log.Write(4, "Program '" + selectedProgramName + "' has finished playing");
            }
        }


        // Create program
        private int programSelectedTabCount;
        public void CreateProgram_btn_Click(object sender, EventArgs e)
        {
            if (Program_form.instance.CreateProgram_gTextBox.Text == "")
            {
                CustomMessageBox.Show("Argo Studio", "Give your program a name.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
            }
            else
            {
                // Save
                selectedProgramName = Program_form.instance.CreateProgram_gTextBox.Text;

                // Create program directory
                string filePath1 = Directories.robotArms_program_dir + @"\" + selectedProgramName + @"\";
                if (!Directory.Exists(filePath1))
                {
                    Directories.CreateDirectory(filePath1);

                    // Reset
                    Tabs_FlowLayoutPanel.Controls.Clear();
                    TabNames_list.Clear();
                    programSelectedTabCount = 0;
                    totalTabCount = 0;
                    Program_form.instance.CreateProgram_gTextBox.Text = "";

                    // Create files
                    Directories.CreateDirectory(filePath1 + "tabs");
                    Directories.CreateFile(filePath1 + "sp.txt");
                    Directories.CreateFile(filePath1 + "io.txt");
                    Directories.CreateFile(filePath1 + "vision.txt");

                    Log.Write(4, "Program '" + selectedProgramName + "' was created");
                    MainMenu_form.instance.SetMessage("Program '" + selectedProgramName + "' was created");
                    Program_form.instance.Loaded_label.Text = "'" + selectedProgramName + "' is loaded";

                    // Reset
                    Tabs_FlowLayoutPanel.Controls.Clear();
                    programSelectedTabCount = 0;
                    totalTabCount = 0;
                    tabs_list.Clear();

                    // Add tab
                    firstTab = false;
                    AddTab("");
                    dataGridView_list[tabClickedTag - 1].Rows.Clear();

                    Program_form.instance.Next_btn.Enabled = true;
                    Tab_panel.Enabled = true;
                    DataGridViewBack_panel.Enabled = true;
                    MainMenu_form.instance.Play_btn.Enabled = true;
                    MainMenu_form.instance.Forward_btn.Enabled = true;
                    MainMenu_form.instance.Backward_btn.Enabled = true;
                    MainMenu_form.instance.Motion_btn.Enabled = true;
                    MainMenu_form.instance.Delay_btn.Enabled = true;
                    MainMenu_form.instance.Tabs_btn.Enabled = true;
                    MainMenu_form.instance.Variabels_btn.Enabled = true;
                    MainMenu_form.instance.IO_btn.Enabled = true;
                    MainMenu_form.instance.Servo_btn.Enabled = true;
                    MainMenu_form.instance.Program_btn.Enabled = true;
                    MainMenu_form.instance.RobotSpeed_btn.Enabled = true;

                    SwitchToFirstTab();

                    // Save
                    isProgramLoaded = true;
                    selectedLoadedProgramName = selectedProgramName;
                    Program_form.instance.Export_btn.Enabled = true;

                    if (AppData.RPTutorial)
                        Program_form.instance.Next_btn.PerformClick();
                    else
                        Setup_form.instance.Close();
                }
                else
                    CustomMessageBox.Show("Argo Studio", "A program named '" + selectedProgramName + "' already exists.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
            }
        }

        // Load program
        public bool isProgramLoaded, isProgramBeingLoaded;
        private string selectedLoadedProgramName;
        public void LoadProgram_btn_Click(object sender, EventArgs e)
        {
            if (Program_form.instance.LoadProgram_gComboBox.Text != "")
            {
                // Reset
                Tabs_FlowLayoutPanel.Controls.Clear();
                programSelectedTabCount = 0;
                totalTabCount = 0;
                tabs_list.Clear();
                isProgramBeingLoaded = true;
                firstTab = false;

                // Set listOfTabNames
                TabNames_list.Clear();
                string filePath1 = Directories.robotArms_program_dir + @"\" + selectedProgramName + @"\tabs";
                TabNames_list = MachineProgrammer.SortAListOfNamesBasedOnItsFileData(filePath1);

                isDataGridViewBeingCleared = true;

                foreach (string name in TabNames_list)
                {
                    AddTab(name);
                    if (tabClickedTag == 1)
                        tabClicked.Name = "first";

                    // Add all rows to dataGridView_list
                    string filePath2 = Directories.robotArms_program_dir + @"\" + selectedProgramName + @"\tabs\" + tabClicked.Text + ".txt";
                    if (File.Exists(filePath2))
                    {
                        dataGridView_list[tabClickedTag - 1].Rows.Clear();

                        string[] lines = File.ReadAllLines(filePath2);
                        for (int i = 1; i < lines.Length; i++)
                        {
                            dataGridView_list[tabClickedTag - 1].Rows.Add(lines[i]);
                        }
                    }
                    else
                    {
                        Log.FailedToLoadProgram(selectedProgramName, filePath2);
                        return;
                    }
                    UnselectAllRowsInCurrentDataGridView();
                }

                Program_form.instance.Next_btn.Enabled = true;
                isDataGridViewBeingCleared = false;
                isProgramBeingLoaded = false;
                firstTab = true;

                SwitchToFirstTab();
                isProgramLoaded = true;
                Program_form.instance.Export_btn.Enabled = true;

                // Save
                Log.Write(4, "Program '" + selectedProgramName + "' was loaded");
                MainMenu_form.instance.SetMessage("Program '" + selectedProgramName + "' was loaded");
                selectedLoadedProgramName = selectedProgramName;
                Program_form.instance.Loaded_label.Text = "'" + selectedProgramName + "' is loaded";
            }
            else
                CustomMessageBox.Show("Argo Studio", "Select a program to load.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
        }
        public void LoadProgram_ComboBox_DropDown(object sender, EventArgs e)
        {
            // Get list of program names
            List<string> programNames = new List<string>();
            foreach (string dir in Directory.GetDirectories(Directories.robotArms_program_dir))
            {
                programNames.Add(Path.GetFileName(dir));
            }

            Program_form.instance.LoadProgram_gComboBox.Items.Clear();
            foreach (string item in programNames)
            {
                Program_form.instance.LoadProgram_gComboBox.Items.Add(item);
            }
        }
        public void LoadProgram_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProgramName = Program_form.instance.LoadProgram_gComboBox.Text;
        }
        private void SwitchToFirstTab()
        {
            if (programSelectedTabCount > 0)
            {
                // Switch to first tab
                ResetTabPanelClickedLabels();
                tabs_list[0].FillColor = CustomColors.fileSelected;
                tabClickedTag = 1;
                SwitchDataGridView(tabClickedTag);
            }
        }

        public void DeleteProgram_btn_Click()
        {
            CustomMessageBoxResult result = CustomMessageBox.Show("Argo Studio", "Program '" + selectedLoadedProgramName + "' and all of it's contents will be deleted permanently.", CustomMessageBoxIcon.Exclamation, CustomMessageBoxButtons.OkCancel);
            if (result == CustomMessageBoxResult.Ok)
            {
                UI.CloseAllPanels();
                string filePath1 = Directories.robotArms_program_dir + @"\" + selectedLoadedProgramName;

                // Delete program directory
                if (Directory.Exists(filePath1))
                {
                    Directories.DeleteDirectory(filePath1, true);

                    // Clear
                    Tabs_FlowLayoutPanel.Controls.Clear();
                    dataGridView_list[tabClickedTag - 1].Visible = false;
                    Program_form.instance.LoadProgram_gComboBox.Items.Clear();

                    // Disable and enable controls
                    DisableCommandButtons();
                    MainMenu_form.instance.Program_btn.Enabled = true;
                    Tab_panel.Enabled = false;

                    Log.Write(4, "Deleted program '" + selectedLoadedProgramName + "'");
                    MainMenu_form.instance.SetMessage("Deleted program '" + selectedLoadedProgramName);
                }
                else
                {
                    Log.FailedToDeleteProgram(selectedLoadedProgramName, filePath1);
                    return;
                }
            }
        }



        // Tab
        private readonly List<Guna2Button> tabs_list = new List<Guna2Button>();
        private int tabClickedTag, totalTabCount;
        private Control tabClicked;
        private List<string> TabNames_list = new List<string>();
        private bool firstTab = false;
        private void CreateTab_btn_Click(object sender, EventArgs e)
        {
            AddTab("");
        }
        private void Tabs_FlowLayoutPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isProgramRunning)
            {
                UI.CloseAllPanels();
                if (e.Button == MouseButtons.Right)
                {
                    rightClickTabBack_panel.Left = e.X + -40 + Tab_panel.Left;

                    // If it's too far down
                    int top = e.Y + 4 + Tab_panel.Top;
                    if (rightClickTabBack_panel.Height + top + 20 > Height)
                    {
                        rightClickTabBack_panel.Top = Tab_panel.Bottom - rightClickTabBack_panel.Height - 1;
                        rightClickTabBack_panel.Left += 40;
                    }
                    else { rightClickTabBack_panel.Top = top; }

                    Controls.Add(rightClickTabBack_panel);
                    rightClickTabBack_panel.BringToFront();
                }
            }
        }
        private void AddTab(string tabName)
        {
            UI.CloseAllPanels();
            programSelectedTabCount++;
            totalTabCount++;
            ResetTabPanelClickedLabels();

            Guna2Button tab = new Guna2Button
            {
                FillColor = CustomColors.fileSelected,
                Font = new Font("Segoe UI", 12),
                Size = new Size(217, 24),
                ForeColor = CustomColors.text,
                Margin = new Padding(0),
                Tag = programSelectedTabCount,
                BorderRadius = 2,
                BorderColor = CustomColors.controlSelectedBorder
            };
            tab.DisabledState.FillColor = CustomColors.fileSelected;
            tab.DisabledState.ForeColor = Color.Black;
            tab.MouseEnter += (sender, e) =>
            {
                if (!isProgramRunning)
                {
                    Guna2Button btn = (Guna2Button)sender;

                    // If label is not clicked or red
                    if (btn.FillColor != CustomColors.fileSelected & btn.FillColor != CustomColors.accent_red)
                    {
                        btn.FillColor = CustomColors.fileHover;
                        btn.HoverState.FillColor = CustomColors.fileHover;
                    }
                    else if (btn.FillColor == CustomColors.fileSelected)
                    {
                        btn.HoverState.FillColor = CustomColors.fileSelected;
                    }
                }
            };
            tab.MouseLeave += (sender, e) =>
            {
                if (!isProgramRunning)
                {
                    Guna2Button btn = (Guna2Button)sender;
                    // If btn is not clicked
                    if (btn.FillColor != CustomColors.fileSelected)
                        btn.FillColor = CustomColors.mainBackground;
                }
            };
            tab.MouseDown += (sender, e) =>
            {
                if (!isProgramRunning)
                {
                    UI.CloseAllPanels();
                    ResetTabPanelClickedLabels();

                    Guna2Button btn = (Guna2Button)sender;
                    btn.FillColor = CustomColors.fileSelected;
                    btn.HoverState.FillColor = CustomColors.fileSelected;
                    // Save
                    tabClicked = btn;
                    tabClickedTag = (int)btn.Tag;
                }
            };
            tab.MouseUp += (sender, e) =>
            {
                if (!isProgramRunning)
                {
                    SwitchDataGridView(tabClickedTag);

                    // Right click panel
                    if (e.Button == MouseButtons.Right)
                    {
                        Guna2Button btn = (Guna2Button)sender;

                        // Set buttons
                        FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickTab_panel.Controls[0];
                        if (btn.Name == "first")
                        {
                            flowPanel.Controls.Remove(deleteBtn);
                            rightClickTab_panel.Height = 4 * 22 + 10;
                            flowPanel.Height = 4 * 22;
                        }
                        else
                        {
                            flowPanel.Controls.Add(deleteBtn);
                            rightClickTab_panel.Height = 5 * 22 + 10;
                            flowPanel.Height = 5 * 22;
                        }

                        rightClickTab_panel.Left = Tab_panel.Left + e.X - 26;

                        // If it's too far down
                        int top = btn.Top + btn.Height + btn.Parent.Parent.Top;
                        if (rightClickTab_panel.Height + top + 20 > Height)
                        {
                            rightClickTab_panel.Top = Tab_panel.Bottom - rightClickTab_panel.Height - 1;
                            rightClickTab_panel.Left += 40;
                        }
                        else { rightClickTab_panel.Top = top; }

                        Controls.Add(rightClickTab_panel);
                        rightClickTab_panel.BringToFront();
                    }
                }
            };

            // Set text
            if (isProgramBeingLoaded)
            {
                tab.Text = tabName;
            }
            else
            {
                tab.Text = "Tab " + totalTabCount;
                TabNames_list.Add(tab.Text);
                Log.Write(4, "Created '" + tab.Text + "'");

                if (!firstTab)
                {
                    tab.Text += " (Main)";
                    tab.Name = "first";
                    firstTab = true;
                }
            }

            // Save
            tabs_list.Add(tab);
            Tabs_FlowLayoutPanel.Controls.Add(tab);
            tabClickedTag = programSelectedTabCount;
            tabClicked = tab;

            ConstructDataGridView();
            SwitchDataGridView(tabClickedTag);
            MainMenu_form.instance.messagePanel.BringToFront();

            // Scroll to bottom
            Tabs_FlowLayoutPanel.ScrollControlIntoView(tab);

            if (!isProgramBeingLoaded)
                File.WriteAllText(Directories.robotArms_program_dir + @"\" + selectedProgramName + @"\tabs\" + tab.Text + ".txt", programSelectedTabCount.ToString());
        }
        private void SwitchDataGridView(int index)
        {
            DataGridViewBack_panel.Controls.Clear();
            DataGridViewBack_panel.Controls.Add(dataGridView_list[index - 1]);
        }
        private void ResetTabPanelClickedLabels()
        {
            foreach (Guna2Button control in Tabs_FlowLayoutPanel.Controls)
            {
                control.FillColor = CustomColors.mainBackground;
                control.DisabledState.FillColor = CustomColors.mainBackground;
            }
        }
        public void ResetTabButtons()
        {
            foreach (Guna2Button control in Tabs_FlowLayoutPanel.Controls)
            {
                if (control.FillColor == CustomColors.accent_red)
                {
                    control.FillColor = CustomColors.fileSelected;
                }
            }
        }

        // Right click tab
        private Guna2Panel rightClickTab_panel;
        private Guna2Button deleteBtn;
        private bool wasTabRenamed;
        public void ConstructRightClickTabMenu()
        {
            rightClickTab_panel = UI.ConstructPanelForMenu(new Size(210, 5 * 22 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickTab_panel.Controls[0];
            rightClickTab_panel.BringToFront();

            Guna2Button menuBtn = UI.ConstructBtnForMenu("Create tab", 200, false, flowPanel);
            menuBtn.Click += (sender, e) => { AddTab(""); };

            menuBtn = UI.ConstructBtnForMenu("Rename tab", 200, false, flowPanel);
            menuBtn.Click += TabRightClickRename;

            menuBtn = UI.ConstructBtnForMenu("Import tab", 200, false, flowPanel);
            menuBtn.Click += TabRightClickImport;

            menuBtn = UI.ConstructBtnForMenu("Export tab", 200, false, flowPanel);
            menuBtn.Click += TabRightClickExport;

            menuBtn = UI.ConstructBtnForMenu("Delete tab", 200, false, flowPanel);
            menuBtn.Click += DeleteTab;
            deleteBtn = menuBtn;
        }
        private Guna2TextBox renameTextBox;
        public void ConstructRightClickRename_textbox()
        {
            renameTextBox = new Guna2TextBox
            {
                Font = new Font("Segoe UI", 12),
                Location = new Point(-2, 0),
                MaxLength = 25,
                ForeColor = Color.Black,
                FillColor = CustomColors.fileSelected,
                ShortcutsEnabled = false,
                BorderThickness = 0,
                TextAlign = HorizontalAlignment.Center,
                TextOffset = new Point(0, 1)
            };
            renameTextBox.KeyPress += (sender, e) =>
            {
                // Only allow numbers and letters
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };
            renameTextBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CloseRightClickPanels();
                    // Remove windows "ding" noise when user presses enter
                    e.SuppressKeyPress = true;
                }
            };
        }
        private void TabRightClickRename(object sender, EventArgs e)
        {
            CloseRightClickPanels();

            renameTextBox.Text = tabClicked.Text;
            renameTextBox.Size = new Size(tabClicked.Width + 2, tabClicked.Height);
            tabClicked.Controls.Add(renameTextBox);
            renameTextBox.BringToFront();
            renameTextBox.Focus();
            renameTextBox.SelectAll();

            wasTabRenamed = true;
        }
        private void TabRightClickImport(object sender, EventArgs e)
        {

        }
        private void TabRightClickExport(object sender, EventArgs e)
        {

        }
        private void DeleteTab(object sender, EventArgs e)
        {
            CloseRightClickPanels();
            totalTabCount -= 1;

            // Reset selected tab
            if (Tabs_FlowLayoutPanel.Controls.Count > 1)
            {
                for (int i = 0; i < Tabs_FlowLayoutPanel.Controls.Count; i++)
                {
                    Guna2Button tab = (Guna2Button)Tabs_FlowLayoutPanel.Controls[i];
                    if (tab.FillColor == CustomColors.fileSelected)
                    {
                        if (i == 0)
                        {
                            Guna2Button tab2 = (Guna2Button)Tabs_FlowLayoutPanel.Controls[1];
                            tab2.FillColor = CustomColors.fileSelected;
                            tabClicked = tab2;
                            SwitchDataGridView(tabClickedTag - 1);
                        }
                        else
                        {
                            Guna2Button tab2 = (Guna2Button)Tabs_FlowLayoutPanel.Controls[i - 1];
                            tab2.FillColor = CustomColors.fileSelected;
                            tabClicked = tab2;
                            SwitchDataGridView(tabClickedTag - 1);
                        }
                    }
                }
            }
            // Remove tab
            TabNames_list.Remove(tabClicked.Text);
            Tabs_FlowLayoutPanel.Controls.Remove(tabClicked);
            dataGridView_list.RemoveAt(tabClickedTag - 1);
            programSelectedTabCount -= 1;
            tabClickedTag -= 1;

            // Delete tab [num].txt
            Directories.DeleteFile(Directories.robotArms_program_dir + @"\" + selectedProgramName + @"\tabs\" + tabClicked.Text + ".txt");
        }

        // Right click tab back
        private Guna2Panel rightClickTabBack_panel;
        public void ConstructRightClickTabBackMenu()
        {
            rightClickTabBack_panel = UI.ConstructPanelForMenu(new Size(210, 2 * 22 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickTabBack_panel.Controls[0];

            rightClickTabBack_panel.BringToFront();

            Guna2Button menuBtn = UI.ConstructBtnForMenu("Import tab", 200, false, flowPanel);
            menuBtn.Click += TabRightClickImport;

            menuBtn = UI.ConstructBtnForMenu("Export tab", 200, false, flowPanel);
            menuBtn.Click += TabRightClickExport;
        }


        // DataGridView
        private bool isDataGridViewBeingCleared = false;
        private readonly List<Guna2DataGridView> dataGridView_list = new List<Guna2DataGridView>();
        private readonly List<string> dataGridViewNames_list = new List<string>();
        private void ConstructDataGridView()
        {
            Guna2DataGridView dataGridView = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                ColumnHeadersVisible = false,
                ShowCellToolTips = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Theme = CustomColors.dataGridViewTheme,
                Name = "DataGridView" + tabClickedTag.ToString(),
                Tag = tabClickedTag,
                BackgroundColor = CustomColors.controlBack
            };
            dataGridViewNames_list.Add("DataGridView" + tabClickedTag.ToString());
            dataGridView.RowTemplate.Height = 25;
            dataGridView.RowTemplate.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView.Columns.Add(tabClickedTag.ToString(), "header");

            dataGridView.RowsAdded += (sender, e) =>
            {
                SaveDataGridViewToFile();
                UnselectAllRowsInCurrentDataGridView();

                // Select added row
                dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.fileSelected;
                dataGridView_list[tabClickedTag - 1].Rows[e.RowIndex].Selected = true;

                MainMenu_form.instance.Upload_btn.Enabled = true;
            };
            dataGridView.RowsRemoved += (sender, e) =>
            {
                if (!isDataGridViewBeingCleared)
                    SaveDataGridViewToFile();
            };
            dataGridView.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    Guna2DataGridView grid = (Guna2DataGridView)sender;

                    // The right click button does not select rows by default, so implement it here.
                    // If it is not currently selected, unselect others
                    DataGridView.HitTestInfo info = grid.HitTest(e.X, e.Y);
                    if (!grid.Rows[info.RowIndex].Selected)
                    {
                        UnselectAllRowsInCurrentDataGridView();
                    }
                    grid.Rows[info.RowIndex].Selected = true;

                    // Add or remove ModifyBtn
                    FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickDataGridView_panel.Controls[0];
                    if (grid.Rows[info.RowIndex].Cells[0].Value.ToString() == "Jump to previous tab")
                    {
                        flowPanel.Controls.Remove(ModifyBtn);
                        rightClickDataGridView_panel.Height = 4 * 22 + 10;
                        flowPanel.Height = 4 * 22;
                    }
                    else
                    {
                        Control[] controls = new Control[flowPanel.Controls.Count];
                        for (int i = 0; i < flowPanel.Controls.Count; i++)
                        {
                            controls[i] = flowPanel.Controls[i];
                        }
                        flowPanel.Controls.Clear();
                        flowPanel.Controls.Add(ModifyBtn);
                        flowPanel.Controls.AddRange(controls);
                        rightClickDataGridView_panel.Height = 5 * 22 + 10;
                        flowPanel.Height = 5 * 22;
                    }

                    rightClickDataGridView_panel.Location = new Point(DataGridViewBack_panel.Left + e.X, DataGridViewBack_panel.Top + (info.RowIndex + 1) * 25);
                    Controls.Add(rightClickDataGridView_panel);
                    rightClickDataGridView_panel.BringToFront();
                }
                else { UI.CloseAllPanels(); }

                // Set color
                dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.fileSelected;
            };

            DataGridViewBack_panel.Controls.Add(dataGridView);
            dataGridView_list.Add(dataGridView);
        }
        private void SaveDataGridViewToFile()
        {
            string filePath1 = Directories.robotArms_program_dir + @"\" + selectedProgramName + @"\tabs\" + tabClicked.Text + ".txt";
            if (File.Exists(filePath1))
            {
                // Write all the rows in the dataGridView_list in file
                List<string> linesInDataGridView = new List<string>();
                for (int i = 0; i < dataGridView_list[tabClickedTag - 1].Rows.Count; i++)
                {
                    linesInDataGridView.Add(dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value.ToString());
                }
                File.WriteAllLines(filePath1, linesInDataGridView);
            }
            else { Log.FailedToSaveProgram(selectedLoadedProgramName, filePath1); }
        }
        private void UnselectAllRowsInCurrentDataGridView()
        {
            foreach (DataGridViewRow row in dataGridView_list[tabClickedTag - 1].Rows)
            {
                row.Selected = false;
            }
        }
        public void SetDataGridViewColorToFileSelected()
        {
            //if (tabClickedTag > 0 & !isProgramRunning)
            //{
            //    dataGridView_list[tabClickedTag - 1].RowsDefaultCellStyle.SelectionBackColor = CustomColors.fileSelected;
            //}
        }
        public void ClearSelection()
        {
            foreach (Guna2DataGridView item in dataGridView_list)
            {
                item.ClearSelection();
            }
        }

        // Right click DataGridView row
        private Guna2Panel rightClickDataGridView_panel;
        private Guna2Button ModifyBtn;
        public void ConstructRightClickDataGridViewRowMenu()
        {
            rightClickDataGridView_panel = UI.ConstructPanelForMenu(new Size(210, 5 * 22 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickDataGridView_panel.Controls[0];

            rightClickDataGridView_panel.BringToFront();

            Guna2Button menuBtn = UI.ConstructBtnForMenu("Modify", 200, false, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                {
                    if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 1)
                    {
                        for (int i = 0; i < dataGridView_list[tabClickedTag - 1].Rows.Count; i++)
                        {
                            if (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected)
                            {
                                UI.CloseAllPanels();
                                ModifyCommand_form ModifyLine_form = new ModifyCommand_form(dataGridView_list[tabClickedTag - 1].Rows[i]);
                                ModifyLine_form.ShowDialog();
                                return;
                            }
                        }
                    }
                    else { CustomMessageBox.Show("Argo Studio", "You can only select one command to modify.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }
                }
                else { CustomMessageBox.Show("Argo Studio", "Select a command to modify.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }

                UI.CloseAllPanels();
            };
            ModifyBtn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Duplicate", 200, false, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                {
                    if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 1)
                    {
                        int index = dataGridView_list[tabClickedTag - 1].SelectedRows[0].Index;

                        // Duplicate row
                        dataGridView_list[tabClickedTag - 1].Rows.Add(dataGridView_list[tabClickedTag - 1].SelectedRows[0].Cells[0].Value);

                        // The new row is at the bottom by default, so move it up until it's below the row that was duplicated
                        for (int i = dataGridView_list[tabClickedTag - 1].Rows.Count - 1; i > index; i--)
                        {
                            // Use tuple to swap values
                            (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value, dataGridView_list[tabClickedTag - 1].Rows[i - 1].Cells[0].Value) = (dataGridView_list[tabClickedTag - 1].Rows[i - 1].Cells[0].Value, dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value);
                        }

                        UI.CloseAllPanels();  // Do this before selecting a new row

                        // Select the new row
                        dataGridView_list[tabClickedTag - 1].Rows[index].Cells[0].Selected = false;
                        dataGridView_list[tabClickedTag - 1].Rows[index + 1].Cells[0].Selected = true;

                        // Save
                        SaveDataGridViewToFile();

                        return;
                    }
                    else { CustomMessageBox.Show("Argo Studio", "You can only select one command to duplicate.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }
                }
                else { CustomMessageBox.Show("Argo Studio", "Select a command to duplicate.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }

                UI.CloseAllPanels();
            };

            menuBtn = UI.ConstructBtnForMenu("Move up", 200, false, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                {
                    if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 1)
                    {
                        for (int i = 0; i < dataGridView_list[tabClickedTag - 1].Rows.Count; i++)
                        {
                            if (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected)
                            {
                                if (i == 0)
                                {
                                    CustomMessageBox.Show("Argo Studio", "Cannot move the first command up.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                                    return;
                                }
                                UI.CloseAllPanels();  // Do this before selecting a new row

                                // Use tuple to swap values
                                (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value, dataGridView_list[tabClickedTag - 1].Rows[i - 1].Cells[0].Value) = (dataGridView_list[tabClickedTag - 1].Rows[i - 1].Cells[0].Value, dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value);

                                // Reselect
                                dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected = false;
                                dataGridView_list[tabClickedTag - 1].Rows[i - 1].Cells[0].Selected = true;

                                // Save
                                SaveDataGridViewToFile();

                                return;
                            }
                        }
                    }
                    else { CustomMessageBox.Show("Argo Studio", "You can only select one command to move up.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }
                }
                else { CustomMessageBox.Show("Argo Studio", "Select a command to move up.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }

                UI.CloseAllPanels();
            };

            menuBtn = UI.ConstructBtnForMenu("Move down", 200, false, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                {
                    if (dataGridView_list[tabClickedTag - 1].SelectedRows.Count == 1)
                    {
                        for (int i = 0; i < dataGridView_list[tabClickedTag - 1].Rows.Count; i++)
                        {
                            if (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected)
                            {
                                if (i == dataGridView_list[tabClickedTag - 1].Rows.Count - 1)
                                {
                                    CustomMessageBox.Show("Argo Studio", "Cannot move the last command down.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                                    return;
                                }
                                UI.CloseAllPanels();  // Do this before selecting a new row

                                // Use tuple to swap values
                                (dataGridView_list[tabClickedTag - 1].Rows[i + 1].Cells[0].Value, dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value) = (dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Value, dataGridView_list[tabClickedTag - 1].Rows[i + 1].Cells[0].Value);

                                // Reselect
                                dataGridView_list[tabClickedTag - 1].Rows[i].Cells[0].Selected = false;
                                dataGridView_list[tabClickedTag - 1].Rows[i + 1].Cells[0].Selected = true;

                                // Save
                                SaveDataGridViewToFile();

                                return;
                            }
                        }
                    }
                    else { CustomMessageBox.Show("Argo Studio", "You can only select one command to move down.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }
                }
                else { CustomMessageBox.Show("Argo Studio", "Select a command to move down.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }

                UI.CloseAllPanels();
            };

            menuBtn = UI.ConstructBtnForMenu("Delete", 200, false, flowPanel);
            menuBtn.Click += (sender, e) =>
            {
                if (dataGridView_list[tabClickedTag - 1].Rows.Count > 0)
                {
                    int index = dataGridView_list[tabClickedTag - 1].SelectedRows[dataGridView_list[tabClickedTag - 1].SelectedRows.Count - 1].Index;

                    // Delete all selected rows
                    foreach (DataGridViewRow item in dataGridView_list[tabClickedTag - 1].SelectedRows)
                    {
                        dataGridView_list[tabClickedTag - 1].Rows.Remove(item);
                    }

                    UI.CloseAllPanels();  // Do this before selecting a new row

                    // If no rows are automatically selected again, select the row under the row that was just deleted
                    if (dataGridView_list[tabClickedTag - 1].Rows.Count != 0)
                    {
                        // If the deleted row was not at the bottom
                        if (index > dataGridView_list[tabClickedTag - 1].SelectedRows.Count)
                            dataGridView_list[tabClickedTag - 1].Rows[index - 1].Selected = true;
                        else
                            // Select the bottom row
                            dataGridView_list[tabClickedTag - 1].Rows[dataGridView_list[tabClickedTag - 1].Rows.Count - 1].Selected = true;
                    }
                }
                else
                {
                    UI.CloseAllPanels();
                    CustomMessageBox.Show("Argo Studio", "Select a command to delete.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                }
            };
        }


        // Command menus
        public Guna2Panel motionMenu, delayMenu, tabsMenu, variablesMenu, IOMenu, servoMenu;

        // motionMenu
        public void ConstructMotionMenu()
        {
            Guna2Button gBtn;
            motionMenu = UI.ConstructGPanelMainControls(new Size(436, 203), MainMenu_form.instance.Motion_btn.Left, MainMenu_form.instance);

            // Button 1
            gBtn = UI.ConstructGButtonForMainControls("Move to position", 28, motionMenu);
            gBtn.Click += MoveToPosition_btn_Click;

            // Button 2
            gBtn = UI.ConstructGButtonForMainControls("Move", 88, motionMenu);
            gBtn.Click += Move_btn_Click;
            Guna2ComboBox gComboBox = UI.ConstructGComboBoxForMainControls(new Point(176, 82), "motions", motionMenu);
            gComboBox.Items.Add("Home");
            gComboBox.Items.Add("to limit switches");
            UI.ConstructLabelForMainControls(151, new Point(176, 60), "Motion", motionMenu);

            // Button 3
            gBtn = UI.ConstructGButtonForMainControls("Move to SP", 148, motionMenu);
            gBtn.Click += MoveToSP_btn_Click;
            Guna2TextBox gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 148), 2, "storedPosition", motionMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;
            UI.ConstructLabelForMainControls(55, new Point(176, 126), "SP", motionMenu);
        }
        private void MoveToPosition_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            dataGridView_list[tabClickedTag - 1].Rows.Add("Move to position '" + "J1: " + J1_textBox.Text + ", " + "J2: " + J2_textBox.Text + ", " + "J3: " + J3_textBox.Text + ", " + "J4: " + J4_textBox.Text + ", " + "J5: " + J5_textBox.Text + ", " + "J6: " + J6_textBox.Text + ", " + "A7: " + Axis7_textBox.Text + ", speed: " + Speed.speed + ", acceleration: " + Speed.acceleration + ", deceleration: " + Speed.deceleration + ", ramp: " + Speed.ramp + "'");
        }
        private void Move_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2ComboBox motions_ComboBox = (Guna2ComboBox)gBtn.Parent.Controls.Find("motions", false).FirstOrDefault();

            if (motions_ComboBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Move '" + motions_ComboBox.Text + ", speed: " + Speed.speed + ", acceleration: " + Speed.acceleration + ", deceleration: " + Speed.deceleration + ", ramp: " + Speed.ramp + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void MoveToSP_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox storedPosition_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("storedPosition", false).FirstOrDefault();

            if (storedPosition_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Move to SP '" + storedPosition_TextBox.Text + ", speed: " + Speed.speed + ", acceleration: " + Speed.acceleration + ", deceleration: " + Speed.deceleration + ", ramp: " + Speed.ramp + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }

        // delayMenu
        public void ConstructDelayMenu()
        {
            Guna2Button gBtn;
            delayMenu = UI.ConstructGPanelMainControls(new Size(436, 203), MainMenu_form.instance.Delay_btn.Left, MainMenu_form.instance);

            // Button 1
            gBtn = UI.ConstructGButtonForMainControls("Add delay (ms)", 28, delayMenu);
            gBtn.Click += AddDelay_btn_Click;
            Guna2TextBox gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 28), 20, "addDelay", delayMenu);
            gTextBox.Width = 100;
            gTextBox.Text = "1000";
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            UI.ConstructLabelForMainControls(100, new Point(176, 6), "Time", delayMenu);

            // Button 2
            gBtn = UI.ConstructGButtonForMainControls("Wait until input ON", 88, delayMenu);
            gBtn.Click += WaitForInputON_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 88), 2, "waitforInputON", delayMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox12;
            UI.ConstructLabelForMainControls(55, new Point(176, 66), "Input", delayMenu);

            // Button 3
            gBtn = UI.ConstructGButtonForMainControls("Wait until input OFF", 148, delayMenu);
            gBtn.Click += WaitForInputOFF_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 148), 2, "waitforInputOFF", delayMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox12;
            UI.ConstructLabelForMainControls(55, new Point(176, 126), "Input", delayMenu);
        }
        private void AddDelay_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox addDelay_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("addDelay", false).FirstOrDefault();

            if (addDelay_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Delay '" + addDelay_TextBox.Text + ", MS'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void WaitForInputON_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox waitforInputON_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("waitforInputON", false).FirstOrDefault();

            if (waitforInputON_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Wait until input '" + waitforInputON_TextBox.Text + ", is ON'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void WaitForInputOFF_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox waitforInputOFF_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("waitforInputOFF", false).FirstOrDefault();

            if (waitforInputOFF_TextBox.Text != "")
            {
                dataGridView_list[tabClickedTag - 1].Rows.Add("Wait until input '" + waitforInputOFF_TextBox.Text + ", is OFF'");
            }
            else { SelectAValueForAllInputsMsgBox(); }
        }

        // tabsMenu
        public void ConstructTabsMenu()
        {
            Guna2Button gBtn;
            tabsMenu = UI.ConstructGPanelMainControls(new Size(436, 150), MainMenu_form.instance.Tabs_btn.Left, MainMenu_form.instance);

            gBtn = UI.ConstructGButtonForMainControls("Jump to tab", 34, tabsMenu);
            gBtn.Click += JumpToTab_Btn_Click;
            Guna2ComboBox gComboBox = UI.ConstructGComboBoxForMainControls(new Point(176, 28), "jump", tabsMenu);
            gComboBox.DropDown += AddListOfTabsInComboBox;
            UI.ConstructLabelForMainControls(152, new Point(176, 6), "Tab", tabsMenu);

            gBtn = UI.ConstructGButtonForMainControls("Jump to previous tab", 88, tabsMenu);
            gBtn.Width = 180;
            gBtn.Click += JumpToPreviousTab_Btn_Click;
        }
        private void JumpToTab_Btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2ComboBox jump_ComboBox = (Guna2ComboBox)gBtn.Parent.Controls.Find("jump", false).FirstOrDefault();

            if (jump_ComboBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Jump to tab '" + jump_ComboBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void JumpToPreviousTab_Btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            dataGridView_list[tabClickedTag - 1].Rows.Add("Jump to previous tab");
        }

        // variablesMenu
        public void ConstructVariablesMenu()
        {
            Guna2Button gBtn;
            variablesMenu = UI.ConstructGPanelMainControls(new Size(478, 200), MainMenu_form.instance.Variabels_btn.Left, MainMenu_form.instance);

            // Button 1
            gBtn = UI.ConstructGButtonForMainControls("Set Variable", 28, variablesMenu);
            gBtn.Click += SetVariables_btn_Click;
            Guna2TextBox gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 28), 2, "setSP", variablesMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;
            UI.ConstructLabelForMainControls(58, new Point(176, 6), "Variable", variablesMenu);

            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(237, 28), 5, "setSPNum", variablesMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            UI.ConstructLabelForMainControls(58, new Point(237, 6), "Num", variablesMenu);

            // Button 2
            gBtn = UI.ConstructGButtonForMainControls("Change Variable", 88, variablesMenu);
            gBtn.Click += ChangeVariable_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 88), 2, "SP", variablesMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;
            UI.ConstructLabelForMainControls(58, new Point(176, 66), "Variable", variablesMenu);

            Guna2ComboBox gComboBox = UI.ConstructGComboBoxForMainControls(new Point(237, 82), "SP2", variablesMenu);
            gComboBox.Items.Add("Increase");
            gComboBox.Items.Add("Decrease");
            UI.ConstructLabelForMainControls(152, new Point(237, 60), "Change", variablesMenu);

            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(395, 88), 5, "SP_Num", variablesMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            UI.ConstructLabelForMainControls(58, new Point(395, 66), "Num", variablesMenu);

            // Button 3
            gBtn = UI.ConstructGButtonForMainControls("If var = num, jump", 148, variablesMenu);
            gBtn.Click += IfVariable_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 148), 5, "ifSPJump_SP", variablesMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox16;
            UI.ConstructLabelForMainControls(58, new Point(176, 126), "Variable", variablesMenu);

            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(237, 148), 2, "ifSPJump_Num", variablesMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            UI.ConstructLabelForMainControls(58, new Point(237, 126), "Num", variablesMenu);

            gComboBox = UI.ConstructGComboBoxForMainControls(new Point(299, 142), "ifSPJump_Tab", variablesMenu);
            gComboBox.DropDown += AddListOfTabsInComboBox;
            UI.ConstructLabelForMainControls(152, new Point(299, 120), "Tab", variablesMenu);
        }
        private void SetVariables_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox setSP_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("setSP", false).FirstOrDefault();
            Guna2TextBox setSPNum_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("setSPNum", false).FirstOrDefault();

            if (setSP_TextBox.Text != "" & setSPNum_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Set variable '" + setSP_TextBox.Text + ", to: " + setSPNum_TextBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void ChangeVariable_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox SP_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("SP", false).FirstOrDefault();
            Guna2ComboBox SP_ComboBox = (Guna2ComboBox)gBtn.Parent.Controls.Find("SP2", false).FirstOrDefault();
            Guna2TextBox SP_Num_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("SP_Num", false).FirstOrDefault();

            if (SP_TextBox.Text != "" & SP_ComboBox.Text != "" & SP_Num_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Variable '" + SP_TextBox.Text + ", " + SP_ComboBox.Text + ", by: " + SP_Num_TextBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void IfVariable_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox ifSPJump_SP_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("ifSPJump_SP", false).FirstOrDefault();
            Guna2TextBox ifSPJump_Num_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("ifSPJump_Num", false).FirstOrDefault();
            Guna2ComboBox ifSPJump_Tab_ComboBox = (Guna2ComboBox)gBtn.Parent.Controls.Find("ifSPJump_Tab", false).FirstOrDefault();

            if (ifSPJump_SP_TextBox.Text != "" & ifSPJump_Num_TextBox.Text != "" & ifSPJump_Tab_ComboBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("If variable '" + ifSPJump_SP_TextBox.Text + ", == , " + ifSPJump_Num_TextBox.Text + ", then jump to tab: " + ifSPJump_Tab_ComboBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }

        // IOMenu
        public void ConstructIOMenu()
        {
            Guna2Button gBtn;
            Guna2ComboBox gComboBox;
            IOMenu = UI.ConstructGPanelMainControls(new Size(436, 256), MainMenu_form.instance.IO_btn.Left, MainMenu_form.instance);

            // Button 1
            gBtn = UI.ConstructGButtonForMainControls("Set output ON", 28, IOMenu);
            gBtn.Click += SetOutputON_btn_Click;
            Guna2TextBox gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 28), 2, "setOutputON", IOMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox12;
            UI.ConstructLabelForMainControls(55, new Point(176, 6), "Output", IOMenu);

            // Button 2
            gBtn = UI.ConstructGButtonForMainControls("Set output OFF", 88, IOMenu);
            gBtn.Click += SetOutputOFF_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 88), 2, "setOutputOFF", IOMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox12;
            UI.ConstructLabelForMainControls(55, new Point(176, 66), "Output", IOMenu);

            // Button 3
            gBtn = UI.ConstructGButtonForMainControls("If input ON, jump", 148, IOMenu);
            gBtn.Click += IfInputONJump_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 148), 2, "ifInputONJump_Input", IOMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox12;
            UI.ConstructLabelForMainControls(55, new Point(176, 126), "Input", IOMenu);

            gComboBox = UI.ConstructGComboBoxForMainControls(new Point(237, 142), "ifInputONJump_Tab", IOMenu);
            gComboBox.DropDown += AddListOfTabsInComboBox;
            UI.ConstructLabelForMainControls(152, new Point(237, 120), "Tab", IOMenu);

            // Button 4
            gBtn = UI.ConstructGButtonForMainControls("If input OFF, jump", 208, IOMenu);
            gBtn.Click += IfInputOFFJump_btn_Click;
            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 208), 2, "ifInputOFFJump_Input", IOMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox12;
            UI.ConstructLabelForMainControls(55, new Point(176, 186), "Input", IOMenu);

            gComboBox = UI.ConstructGComboBoxForMainControls(new Point(237, 202), "ifInputOFFJump_Tab", IOMenu);
            gComboBox.DropDown += AddListOfTabsInComboBox;
            UI.ConstructLabelForMainControls(152, new Point(237, 180), "Tab", IOMenu);
        }
        private void SetOutputON_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox setOutputON_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("setOutputON", false).FirstOrDefault();

            if (setOutputON_TextBox.Text != "")
            {
                dataGridView_list[tabClickedTag - 1].Rows.Add("Set output '" + setOutputON_TextBox.Text + ", ON'");
            }
            else { SelectAValueForAllInputsMsgBox(); }
        }
        private void SetOutputOFF_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox setOutputOFF_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("setOutputOFF", false).FirstOrDefault();

            if (setOutputOFF_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Set output '" + setOutputOFF_TextBox.Text + ", OFF'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void IfInputONJump_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox ifInputONJump_Input_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("ifInputONJump_Input", false).FirstOrDefault();
            Guna2ComboBox ifInputONJump_Tab_comboBox = (Guna2ComboBox)gBtn.Parent.Controls.Find("ifInputONJump_Tab", false).FirstOrDefault();

            if (ifInputONJump_Input_TextBox.Text != "" & ifInputONJump_Tab_comboBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("If input '" + ifInputONJump_Input_TextBox.Text + ", is ON, jump to tab: " + ifInputONJump_Tab_comboBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }
        private void IfInputOFFJump_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox ifInputOFFJump_Input_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("ifInputOFFJump_Input", false).FirstOrDefault();
            Guna2ComboBox ifInputOFFJump_Tab_comboBox = (Guna2ComboBox)gBtn.Parent.Controls.Find("ifInputOFFJump_Tab", false).FirstOrDefault();

            if (ifInputOFFJump_Input_TextBox.Text != "" & ifInputOFFJump_Tab_comboBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("If input '" + ifInputOFFJump_Input_TextBox.Text + ", is OFF, jump to tab: " + ifInputOFFJump_Tab_comboBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }

        // servoMenu
        public void ConstructServoMenu()
        {
            servoMenu = UI.ConstructGPanelMainControls(new Size(436, 100), MainMenu_form.instance.Servo_btn.Left, MainMenu_form.instance);

            // Button 1
            Guna2Button gBtn = UI.ConstructGButtonForMainControls("Servo", 28, servoMenu);
            gBtn.Click += Servo_btn_Click;
            Guna2TextBox gTextBox = UI.ConstructGTextBoxForMainControls(new Point(176, 28), 1, "servoNum", servoMenu);
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox2;
            UI.ConstructLabelForMainControls(55, new Point(176, 6), "Num", servoMenu);

            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(237, 28), 3, "servoDegree", servoMenu);
            gTextBox.Width = 80;
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox360;
            UI.ConstructLabelForMainControls(80, new Point(237, 6), "Degree", servoMenu);

            gTextBox = UI.ConstructGTextBoxForMainControls(new Point(324, 28), 3, "servo_speed", servoMenu);
            gTextBox.KeyPress += OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox;
            gTextBox.KeyUp += Tools.SetMaxNumberInGunaTextbox100;
            UI.ConstructLabelForMainControls(55, new Point(324, 6), "Speed", servoMenu);
        }
        private void Servo_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            Guna2Button gBtn = (Guna2Button)sender;
            Guna2TextBox servoNum_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("servoNum", false).FirstOrDefault();
            Guna2TextBox servoDegree_TextBox = (Guna2TextBox)gBtn.Parent.Controls.Find("servoDegree", false).FirstOrDefault();
            Guna2TextBox servo_speed_textBox = (Guna2TextBox)gBtn.Parent.Controls.Find("servo_speed", false).FirstOrDefault();

            if (servoNum_TextBox.Text != "" & servoDegree_TextBox.Text != "")
                dataGridView_list[tabClickedTag - 1].Rows.Add("Move servo '" + servoNum_TextBox.Text + ", to degree: " + servoDegree_TextBox.Text + ", speed: " + servo_speed_textBox.Text + "'");
            else
                SelectAValueForAllInputsMsgBox();
        }

        // Message
        private void SelectAValueForAllInputsMsgBox()
        {
            CustomMessageBox.Show("Argo Studio", "Select a value for all of the inputs.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
        }



        // Control_panel       
        private void MoveRobotMinus(Guna2TextBox incrementTextBox, Guna2TextBox textBox, string moveMethod)
        {
            UI.CloseAllPanels();

            if (SerialPort1.IsOpen)
            {
                // Set TextBoxes if they are empty
                if (incrementTextBox.Text == "")
                    incrementTextBox.Text = incrementTextBox.Tag.ToString();

                if (textBox.Text == "")
                    textBox.Text = "0";

                // Increment TextBox
                decimal index = Convert.ToDecimal(textBox.Text) - Convert.ToDecimal(incrementTextBox.Text);
                if (index > 0)
                    textBox.Text = index.ToString();
                else
                    textBox.Text = "0";

                // CP stands for 'Control panel'
                string text = "<CP," + moveMethod + "," + textBox.Text + ">";
                SerialPort1.Write(text);
                Log.Write(1, "Sent: " + text);
            }
        }
        private void MoveRobotAdd(Guna2TextBox incrementTextBox, Guna2TextBox textBox, string moveMethod, int max)
        {
            UI.CloseAllPanels();

            if (SerialPort1.IsOpen)
            {
                // Set TextBoxes if they are empty
                if (incrementTextBox.Text == "")
                    incrementTextBox.Text = "10";

                if (textBox.Text == "")
                    textBox.Text = "0";

                // Increment TextBox
                decimal index = Convert.ToDecimal(textBox.Text) + Convert.ToDecimal(incrementTextBox.Text);
                if (index < max)
                    textBox.Text = index.ToString();
                else
                    textBox.Text = max.ToString();

                // CP stands for 'Control panel'
                string text = "<CP," + moveMethod + "," + textBox.Text + ">";
                SerialPort1.Write(text);
                Log.Write(1, "Sent: " + text);
            }
        }

        // J1 - J6
        private void J1Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, J1_textBox, "J1");
        }
        private void J1Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, J1_textBox, "J1", Convert.ToInt16(J1Add_btn.Tag));
        }
        private void J2Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, J2_textBox, "J2");
        }
        private void J2Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, J2_textBox, "J2", Convert.ToInt16(J2Add_btn.Tag));
        }
        private void J3Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, J3_textBox, "J3");
        }
        private void J3Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, J3_textBox, "J3", Convert.ToInt16(J3Add_btn.Tag));
        }
        private void J4Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, J4_textBox, "J4");
        }
        private void J4Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, J4_textBox, "J4", Convert.ToInt16(J4Add_btn.Tag));
        }
        private void J5Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, J5_textBox, "J5");
        }
        private void J5Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, J5_textBox, "J5", Convert.ToInt16(J5Add_btn.Tag));
        }
        private void J6Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, J6_textBox, "J6");
        }
        private void J6Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, J6_textBox, "J6", Convert.ToInt16(J6Add_btn.Tag));
        }

        // X, Y, Z, yaw, pitch, roll
        private void XMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, X_textBox, "X");
        }
        private void XAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, X_textBox, "X", Convert.ToInt16(XAdd_btn.Tag));
        }
        private void YMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Y_textBox, "Y");
        }
        private void YAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Y_textBox, "Y", Convert.ToInt16(YAdd_btn.Tag));
        }
        private void ZMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Z_textBox, "Z");
        }
        private void ZAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Z_textBox, "Z", Convert.ToInt16(ZAdd_btn.Tag));
        }
        private void YawMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Yaw_textBox, "Yaw");
        }
        private void YawAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Yaw_textBox, "Yaw", Convert.ToInt16(YawAdd_btn.Tag));
        }
        private void PitchMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Pitch_textBox, "Pitch");
        }
        private void PitchAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Pitch_textBox, "Pitch", Convert.ToInt16(PitchAdd_btn.Tag));
        }
        private void RollMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Roll_textBox, "Roll");
        }
        private void RollAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Roll_textBox, "Roll", Convert.ToInt16(RollAdd_btn.Tag));
        }

        // Tool X, Y, Z, yaw, pitch, roll
        private void TxMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, X_textBox, "Tx");
        }
        private void TxAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, X_textBox, "Tx", Convert.ToInt16(TxAdd_btn.Tag));
        }
        private void TyMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Y_textBox, "Ty");
        }
        private void TyAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Y_textBox, "Ty", Convert.ToInt16(TyAdd_btn.Tag));
        }
        private void TzMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Z_textBox, "Tz");
        }
        private void TzAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Z_textBox, "Tz", Convert.ToInt16(TzAdd_btn.Tag));
        }
        private void TYawMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Yaw_textBox, "Tyaw");
        }
        private void TYawAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Yaw_textBox, "Tyaw", Convert.ToInt16(TYawAdd_btn.Tag));
        }
        private void TPitchMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Pitch_textBox, "Tpitch");
        }
        private void TPitchAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Pitch_textBox, "Tpitch", Convert.ToInt16(TPitchAdd_btn.Tag));
        }
        private void TRollMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(DegreesToMove_textBox, Pitch_textBox, "Troll");
        }
        private void TRollAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(DegreesToMove_textBox, Pitch_textBox, "Troll", Convert.ToInt16(TRollAdd_btn.Tag));
        }

        // Axis 7
        private void Axis7Minus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(MMToMoveServo_textBox, Servo_TextBox, "track");
        }
        private void Axis7Add_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(MMToMoveServo_textBox, Servo_TextBox, "track", Convert.ToInt16(Axis7Add_btn.Tag));
        }

        // Servo gripper
        private void ServoMinus_btn_Click(object sender, EventArgs e)
        {
            MoveRobotMinus(MMToMoveServo_textBox, Servo_TextBox, "servo");
        }
        private void ServoAdd_btn_Click(object sender, EventArgs e)
        {
            MoveRobotAdd(MMToMoveServo_textBox, Servo_TextBox, "servo", Convert.ToInt16(ServoAdd_btn.Tag));
        }


        // Controls
        private void DisableCommandButtons()
        {
            MainMenu_form.instance.Motion_btn.Enabled = false;
            MainMenu_form.instance.Delay_btn.Enabled = false;
            MainMenu_form.instance.Tabs_btn.Enabled = false;
            MainMenu_form.instance.Variabels_btn.Enabled = false;
            MainMenu_form.instance.IO_btn.Enabled = false;
            MainMenu_form.instance.Servo_btn.Enabled = false;
            MainMenu_form.instance.Program_btn.Enabled = false;
            MainMenu_form.instance.RobotSpeed_btn.Enabled = false;
        }
        private void EnableCommandButtons()
        {
            MainMenu_form.instance.Motion_btn.Enabled = true;
            MainMenu_form.instance.Delay_btn.Enabled = true;
            MainMenu_form.instance.Tabs_btn.Enabled = true;
            MainMenu_form.instance.Variabels_btn.Enabled = true;
            MainMenu_form.instance.IO_btn.Enabled = true;
            MainMenu_form.instance.Servo_btn.Enabled = true;
            MainMenu_form.instance.Program_btn.Enabled = true;
            MainMenu_form.instance.RobotSpeed_btn.Enabled = true;
        }



        // Only allow certain characters in TextBox
        private void OnlyAllowNumbersAndOneDecimalInGTextBox(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public void OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox(object sender, KeyPressEventArgs e)
        {
            Tools.OnlyAllowNumbersAndOneDecimalAndOneMinusInGunaTextBox(sender, e);
        }


        // Misc.
        public void CloseRightClickPanels()
        {
            Controls.Remove(rightClickTab_panel);
            Controls.Remove(rightClickTabBack_panel);
            Controls.Remove(rightClickDataGridView_panel);

            if (renameTextBox.Parent != null)
                renameTextBox.Parent.Controls.Remove(renameTextBox);

            if (wasTabRenamed && tabClicked.Text != renameTextBox.Text)
            {
                string filePath = Directories.robotArms_program_dir + @"\" + selectedLoadedProgramName + @"\tabs\";
                string oldName = tabClicked.Text;

                if (tabClicked.Name == "first")
                    tabClicked.Text = renameTextBox.Text + " (Main)";
                else
                    tabClicked.Text = renameTextBox.Text;

                Directories.MoveFile(filePath + oldName + ".txt", filePath + tabClicked.Text + ".txt");

                TabNames_list[tabClickedTag - 1] = tabClicked.Text;
                wasTabRenamed = false;
            }
        }
        public void AddListOfTabsInComboBox(object sender, EventArgs e)
        {
            Guna2ComboBox comboBox = (Guna2ComboBox)sender;
            comboBox.Items.Clear();
            foreach (string item in TabNames_list)
            {
                comboBox.Items.Add(item);
            }
        }
        private void CloseAllPanels(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }
    }
}