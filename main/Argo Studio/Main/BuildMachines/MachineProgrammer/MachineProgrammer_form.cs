using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace ArgoStudio.Main.BuildMachines.MachineProgrammer
{
    public partial class MachineProgrammer_form : Form
    {
        // Init.
        public static MachineProgrammer_form instance;
        public MachineProgrammer_form()
        {
            InitializeComponent();
            instance = this;

            UpdateTheme();  // Set theme before loading commands

            // Disable horizontal scroll on FileBack_flowPanel
            FileBack_flowPanel.AutoScroll = false;
            FileBack_flowPanel.HorizontalScroll.Enabled = false;
            FileBack_flowPanel.HorizontalScroll.Maximum = 0;
            FileBack_flowPanel.AutoScroll = true;

            MachineProgrammer.LoadInCommands();
            MachineProgrammer.LoadInInfo();

            // If nothing was loaded, create a new app
            if (FileBack_flowPanel.Controls.Count == 0)
            {
                MachineProgrammer.AddFullApp(null, null);
            }

            MachineProgrammer.CosntructMessagePanel();
        }
        public void UpdateTheme()
        {
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {
                Motion_btn.FillColor = CustomColors.accent_blue;
                Home_btn.FillColor = CustomColors.accent_blue;
                Delay_btn.FillColor = CustomColors.accent_blue;
                Run_btn.FillColor = CustomColors.accent_blue;
                Loop_btn.FillColor = CustomColors.accent_blue;
                SetVariable_btn.FillColor = CustomColors.accent_blue;
                SetOutput_btn.FillColor = CustomColors.accent_blue;

                Motion_btn.ForeColor = Color.White;
                Home_btn.ForeColor = Color.White;
                Delay_btn.ForeColor = Color.White;
                Loop_btn.ForeColor = Color.White;
                SetVariable_btn.ForeColor = Color.White;
                SetOutput_btn.ForeColor = Color.White;
            }
            else if (theme == "Dark")
            {

            }
            MachineProgrammer.variableBoxContainer.FillColor = CustomColors.controlBack;
            MachineProgrammer.variableBox.FillColor = CustomColors.controlBack;
            Play_btn.FillColor = CustomColors.playBtnGreen;
            Stop_btn.FillColor = CustomColors.accent_blue;
            MoveForward_btn.FillColor = CustomColors.accent_blue;
            MoveForward_btn.ForeColor = Color.White;
            MoveBackward_btn.FillColor = CustomColors.accent_blue;
            MoveBackward_btn.ForeColor = Color.White;
            AddCommand_btn.FillColor = CustomColors.accent_blue;
            AddCommand_btn.ForeColor = Color.White;

            SetThemeForControl(new List<Control> { FileBack_flowPanel });
        }
        public static void SetThemeForControl(List<Control> list)
        {
            foreach (Control control in list)
            {
                bool pass = false;
                if (control.HasChildren)
                {
                    // Recursively loop through the child controls
                    List<Control> childList = new List<Control>();
                    foreach (Control item in control.Controls)
                    {
                        childList.Add(item);
                    }
                    SetThemeForControl(childList);
                    pass = true;
                }
                if (!control.HasChildren || pass)
                {
                    switch (control)
                    {
                        case FlowLayoutPanel flowLayoutPanel:
                            flowLayoutPanel.BackColor = CustomColors.mainBackground;
                            break;

                        case Guna2Button guna2Button:

                            // If button is selected
                            if (guna2Button == MachineProgrammer.appOrSequenceOrFunctionBtnSelected || guna2Button == MachineProgrammer.selectedVariableBtn || guna2Button == MachineProgrammer.selectedEventBtn)
                            {
                                guna2Button.FillColor = CustomColors.fileSelected;
                                guna2Button.DisabledState.FillColor = CustomColors.fileSelected;
                                guna2Button.HoverState.FillColor = CustomColors.fileSelected;
                                guna2Button.BorderColor = CustomColors.controlSelectedBorder;
                            }
                            else
                            {
                                guna2Button.FillColor = CustomColors.mainBackground;
                                guna2Button.DisabledState.FillColor = CustomColors.mainBackground;
                                guna2Button.HoverState.FillColor = CustomColors.mainBackground;
                            }
                            break;
                    }
                }
            }
        }

        // Form
        public bool isControlKeyDown, isShiftKeyDown;
        private void FormMachineProgrammer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift) { isShiftKeyDown = true; }
            if (e.Control) { isControlKeyDown = true; }
        }
        private void FormMachineProgrammer_KeyUp(object sender, KeyEventArgs e)
        {
            if (isControlKeyDown)
            {
                switch (AddCommand_btn.Text)
                {
                    case "Add Command":
                        switch (e.KeyCode)
                        {
                            case Keys.M:
                                MachineProgrammer.ConstructMotionCommand(null, null);
                                break;

                            case Keys.H:
                                MachineProgrammer.ConstructHomeCommand(null, null);
                                break;

                            case Keys.D:
                                MachineProgrammer.ConstructDelayCommand(null, null);
                                break;

                            case Keys.R:
                                if (AddCommand_flowPanel.Controls.Contains(Run_btn))
                                {
                                    MachineProgrammer.ConstructRunCommand(null, null);
                                }
                                break;

                            case Keys.L:
                                MachineProgrammer.ConstructLoopCommand(null, null);
                                break;

                            case Keys.I:
                                MachineProgrammer.ConstructSetVariableCommand(null, null);
                                break;

                            case Keys.O:
                                MachineProgrammer.ConstructSetOutputCommand(null, null);
                                break;
                        }
                        break;

                    case "Add Event":
                        if (e.KeyCode == Keys.E)
                        {
                            MachineProgrammer.ConstructAddEventCommand(null, null);
                        }
                        break;

                    case "Add Variable":
                        if (e.KeyCode == Keys.V)
                        {
                            MachineProgrammer.ConstructAddVariableCommand(null, null);
                        }
                        break;
                }
            }

            // Reset
            isControlKeyDown = false;
            isShiftKeyDown = false;
        }
        private void MachineProgrammer_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            UI.CloseAllPanels();
            MainMenu_form.instance.isMachineProgrammerOpen = false;
            MachineProgrammer.ResetVariables();
        }
        private void MachineProgrammer_form_ResizeBegin(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }

        private void MachineController_ComboBox_Enter(object sender, EventArgs e)
        {
            Back_panel.Focus();  // This fixes a bug
        }


        // SERIAL COM
        // Delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(bool error, string text);
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            //data received on serial port is asssigned to "indata" string
            Console.WriteLine("Received data:");
            Console.Write(indata);

            try
            {
                if (serialPort1.IsOpen)
                {
                    string data = serialPort1.ReadLine();
                    // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method
                    // The "Si_DataReceived" method will be executed on the UI thread which allows populating of logTextBox
                    BeginInvoke(new SetTextDeleg(SerialDataReceived), new object[] { false, data });
                }
            }
            catch { }
        }
        private void SerialDataReceived(bool error, string data)
        {
            Log.Write(3, "Recieved: " + data);
            if (error)
            {
                Log.Write(3, "Serial " + selectedCom + " recieved an error: " + error);
            }
            else
            {
                string trimmedData = data.Trim();
                Log.Write(3, trimmedData);
                if (trimmedData == "<hello from pi>")
                {
                    // Connected to serial com succesfully
                    SerialComTimeout_timer.Enabled = false;
                    Log.Write(3, "Recieved hi from Machine Controller");
                    Connected_lbl.ForeColor = Color.FromArgb(26, 200, 118);  // Green
                    Connected_lbl.Text = "Connected";
                }
            }
        }
        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    string data = serialPort1.ReadLine();
                    // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method
                    // The "Si_DataReceived" method will be executed on the UI thread which allows populating of logTextBox
                    BeginInvoke(new SetTextDeleg(SerialDataReceived), new object[] { true, data });
                }
                catch { }
            }
        }



        // Play btns
        private void Play_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.wasStopBtnClicked = false;

            if (!MachineProgrammer.isAppPlaying)
            {
                MachineProgrammer.PlayApp();
            }
            else
            {
                // Unpause app
                if (MachineProgrammer.isAppPaused)
                {
                    instance.Play_btn.Image = Resources.Pause;
                    MachineProgrammer.isAppPaused = false;
                }
                // Pause app
                else
                {
                    MachineProgrammer.wasStopBtnClicked = false;
                    MachineProgrammer.isAppPaused = true;
                    Play_btn.Image = Resources.Play;
                    Log.Write(3, "Paused app '" + MachineProgrammer.selectedAppName + "'");
                }
            }
        }
        private void MoveForward_btn_Click(object sender, EventArgs e)
        {
            MachineProgrammer.wasStopBtnClicked = false;
            MachineProgrammer.wasFWDBtnClicked = true;
            MachineProgrammer.MoveForward();
            UI.CloseAllPanels();
            Log.Write(3, "Moving forward by one command");
        }
        private void MoveBackward_btn_Click(object sender, EventArgs e)
        {
            MachineProgrammer.wasStopBtnClicked = false;
            MachineProgrammer.MoveBackward();
            UI.CloseAllPanels();
            Log.Write(3, "Moving backward by one command");
        }
        private void Stop_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            Stop_btn.Enabled = false;
            Play_btn.Image = Resources.Play;

            Back_panel.Enabled = true;
            MoveForward_btn.Enabled = false;
            MoveBackward_btn.Enabled = false;
            MachineProgrammer.AppHasFinishedPlaying(false);
            MachineProgrammer.wasStopBtnClicked = true;
            Log.Write(3, "Stoped app '" + MachineProgrammer.selectedAppName + "'");
            MachineProgrammer.SetMessage("Stoped app '" + MachineProgrammer.selectedAppName + "'");
        }


        private void SerialComTimeout_timer_Tick(object sender, EventArgs e)
        {
            //SerialComTimeout_timer.Enabled = false;
            //Log.Write(3, "Could not connect to '" + selectedCom + "'");
            //MachineController_ComboBox.Items.Clear();
            //ComboBoxMachineController_SelectedIndexChanged(null, null);
            //serialPort1.Close();
            //Connected_lbl.ForeColor = Color.FromArgb(15, 13, 74);  // Blue
            //Connected_lbl.Text = "Not Connected";
            //EnablePlayFwdRevBtns();
            //CustomMessageBox.Show("Argo Studio", "Could not connect to '" + selectedCom + "'. Make sure it is fully plugged in, and try again. If you still cannot connect, please see our support page on our website.", CustomMessageBoxIcon.Error, CustomMessageBoxButtons.Ok);
        }
        public void DisableMoveBtns()
        {
            MoveForward_btn.Enabled = false;
            MoveBackward_btn.Enabled = false;
            MachineController_ComboBox.Enabled = false;
        }
        public void EnableMoveBtns()
        {
            MoveForward_btn.Enabled = true;
            MoveBackward_btn.Enabled = true;
            MachineController_ComboBox.Enabled = true;
        }


        // FileBack_flowPanel
        private void FileBack_flowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            UI.CloseAllPanels();
            // Right click panel
            if (e.Button == MouseButtons.Right)
            {
                // If it's too far left
                if (e.X - 25 < 0)
                {
                    MachineProgrammer.rightClickFileBack_panel.Left = 0;
                }
                else { MachineProgrammer.rightClickFileBack_panel.Left = e.X - 25; }

                // If it's too far down
                int difference = FileBack_flowPanel.Height - (e.Y + MachineProgrammer.rightClickFileBack_panel.Height);
                if (difference < 0)
                {
                    MachineProgrammer.rightClickFileBack_panel.Top = e.Y + 24 + difference;
                    MachineProgrammer.rightClickFileBack_panel.Left += 40;
                }
                else { MachineProgrammer.rightClickFileBack_panel.Top = e.Y + 24; }

                Controls.Add(MachineProgrammer.rightClickFileBack_panel);
                MachineProgrammer.rightClickFileBack_panel.BringToFront();
            }
        }

        // File btns
        public void AddFuntion_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.AddFunction(null);
        }
        private void AddSequence_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.AddSequence(null);
        }
        private void AddCommand_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();

            if (MachineProgrammer.whatIsSelected == "app"
                || MachineProgrammer.whatIsSelected == "function"
                || MachineProgrammer.whatIsSelected == "sequence"
                || MachineProgrammer.whatIsSelected == "programEvent")
            {
                if (!AddCommand_flowPanel.Visible)
                {
                    // Don't show the Run_btn for functions
                    if (MachineProgrammer.whatIsSelected == "function"
                        || MachineProgrammer.whatIsSelected == null)
                    {
                        Run_btn.Visible = false;
                        AddCommand_flowPanel.Height = 220;
                        AddCommand_flowPanel.Top = Height - 220 - 129;
                    }
                    else
                    {
                        Run_btn.Visible = true;
                        AddCommand_flowPanel.Height = 256;
                        AddCommand_flowPanel.Top = Height - 356 - 28;
                    }
                    AddCommand_btn.CustomizableEdges.TopLeft = false;
                    AddCommand_btn.CustomizableEdges.TopRight = false;
                    AddCommand_flowPanel.Visible = true;
                }
                else
                {
                    AddCommand_btn.CustomizableEdges.TopLeft = true;
                    AddCommand_btn.CustomizableEdges.TopRight = true;
                    AddCommand_flowPanel.Visible = false;
                }
            }
            else if (MachineProgrammer.whatIsSelected == "event")
            {
                MachineProgrammer.ConstructAddEventCommand(null, null);
            }
            else if (MachineProgrammer.whatIsSelected == "variable")
            {
                MachineProgrammer.ConstructAddVariableCommand(null, null);
            }
        }


        // Command logic
        public int coords;
        private void MoveCommandTimer_Tick(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            coords = Cursor.Position.Y - MachineProgrammer.coords;

            // Don't allow command to move below bottom of command back
            if (coords < MachineProgrammer.commandClicked.Parent.Height - MachineProgrammer.commandClicked.Height)
            {
                // Don't allow command to move above top of command background
                if (coords > 3)
                {
                    // Move command to cursor position
                    MachineProgrammer.commandClicked.Top = coords;
                }
                else { MachineProgrammer.commandClicked.Top = 3; }
            }
            else { MachineProgrammer.commandClicked.Top = MachineProgrammer.selectedCommandBack.Height - MachineProgrammer.commandClicked.Height - 3; }
        }

        // Command btns    
        private void Motion_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructMotionCommand(null, null);
        }
        private void Delay_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructDelayCommand(null, null);
        }
        private void Run_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructRunCommand(null, null);
        }
        private void SetVariable_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructSetVariableCommand(null, null);
        }
        private void Loop_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructLoopCommand(null, null);
        }
        private void SetOutput_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructSetOutputCommand(null, null);
        }
        private void Home_btn_Click(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            MachineProgrammer.ConstructHomeCommand(null, null);
        }



        // Machine controller ComboBox
        public string selectedCom;
        private void ComboBoxMachineController_SelectedIndexChanged(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            if (MachineController_ComboBox.Text != "None" && MachineController_ComboBox.Text != "")
            {
                selectedCom = MachineController_ComboBox.Text;
                MachineProgrammer.playingMachineControllerSelected = selectedCom;

                // Try to connect to serial
                serialPort1.Close();
                serialPort1.PortName = selectedCom;
                serialPort1.Open();
                serialPort1.WriteLine("<hi from argo studio>");

                timer1.Enabled = true;
                Log.Write(3, "Connecting to '" + selectedCom + "'");
                SerialComTimeout_timer.Enabled = true;
                Connected_lbl.ForeColor = Color.Black;
                Connected_lbl.Text = "Connecting..";

                DisableMoveBtns();
            }

            // Save in file
            string[] lines = new string[1];
            lines[0] = MachineController_ComboBox.Text;
            File.WriteAllLines(Directories.buildMachines_commands_temp_data_file, lines);
        }
        //  private int Counter = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Counter ++;
            //serialPort1.WriteLine("<hi from argo studio>" + Counter + "\n");
        }
        private void MachineController_ComboBox_DropDown(object sender, EventArgs e)
        {
            // Get a list of available serial port names
            string[] ports = SerialPort.GetPortNames();

            MachineController_ComboBox.Items.Clear();
            foreach (string portName in ports)
            {
                MachineController_ComboBox.Items.Add(portName);
            }
            MachineController_ComboBox.Items.Add("None");
        }



        // Misc.
        private void CloseAllPanels(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }
    }
}