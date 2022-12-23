using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ArgoStudio.Main.RobotProgrammer.MainControls.Setup
{
    public partial class ConnectRobot_form : Form
    {
        // INIT
        public static ConnectRobot_form instance;
        public ConnectRobot_form()
        {
            InitializeComponent();
            instance = this;

            if (MainControls_form.instance.isProgramLoaded)
                Controls.Remove(Next_btn);
            else
                Controls.Add(Next_btn);

            // Set theme
            string theme = Theme.SetThemeForForm(this);
            if (theme == "Light")
            {

            }
            else if (theme == "Dark")
            {

            }

            UpdatePorts();
        }

        // FORM
        private void ConnectRobot_form_Load(object sender, EventArgs e)
        {
            if (MainControls_form.instance.SerialPort1.IsOpen)
                SetControlToConnected();
        }


        // CONNECT
        private void Connect_btn_Click(object sender, EventArgs e)
        {
            if (MainControls_form.instance.portName != null)
            {
                if (Connect_btn.Text == "Connect")
                {
                    try
                    {
                        // Connect serial
                        MainControls_form.instance.SerialPort1.PortName = MainControls_form.instance.portName;
                        MainControls_form.instance.SerialPort1.Open();
                        Log.Write(4, "Connecting to '" + MainControls_form.instance.portName + "'");
                        MainControls_form.instance.SerialComTimeout_timer.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Argo Studio", ex.Message, CustomMessageBoxIcon.Error, CustomMessageBoxButtons.Ok);
                    }
                }
                else
                {
                    // Disconnect serial
                    MainControls_form.instance.SerialWrite("<close>");
                    MainControls_form.instance.SerialPort1.Close();
                    Log.Write(4, "Disconnected from '" + MainControls_form.instance.portName + "'");

                    MainControls_form.instance.Hide7AxisPanel();
                    MainControls_form.instance.HideServoGripperPanel();
                    MainControls_form.instance.Control_panel.Enabled = false;
                    MainControls_form.instance.SerialComTimeout_timer.Enabled = false;
                    Connected_label.Visible = false;
                    CheckMark_picture.Visible = false;
                    Connect_btn.Text = "Connect";
                    if (Theme.theme == "Dark")
                    {
                        MainMenu_form.instance.Connect_btn.Image = Resources.PlugInWhite;
                    }
                    else { MainMenu_form.instance.Connect_btn.Image = Resources.PlugInBlack; }
                    MainControls_form.instance.robotName = "";
                    MainControls_form.instance.robotFirmware = "";
                    MainControls_form.instance.robotIs7AxisConnected = false;
                    MainControls_form.instance.robotIsServoGripperConnected = false;
                    MainControls_form.instance.isRobotConnected = false;
                    Next_btn.Enabled = false;
                    COMPort_comboBox.Enabled = true;
                }
            }
            else { CustomMessageBox.Show("Argo Studio", "Select a COM before connecting.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok); }
        }

        public void SetControlToConnected()
        {
            Connect_btn.Text = "Disconnect";
            Connected_label.Text = "Connected to " + MainControls_form.instance.portName;
            Connected_label.Visible = true;
            CheckMark_picture.Visible = true;
            MainMenu_form.instance.Connect_btn.Image = Resources.CheckMark;
            Next_btn.Enabled = true;
            COMPort_comboBox.Enabled = false;
        }
        private void COMPort_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainControls_form.instance.portName = ThreadClass.GetPortBasedOnName(COMPort_comboBox.SelectedItem.ToString());
        }

        public Thread timerThread;
        private void GetPorts_timer_Tick(object sender, EventArgs e)
        {
            UpdatePorts();
        }
        private void UpdatePorts()
        {
            if (!ThreadClass.isRunning)
            {
                // This needs to be done in a seperate thread so the UI thread does not freeze on "thread.Join();"
                ThreadClass classInstance = new ThreadClass();
                timerThread = new Thread(classInstance.SetPorts)
                {
                    Name = "SetPorts"
                };
                timerThread.Start();
            }
        }
        private void ConnectAutomatically_timer_Tick(object sender, EventArgs e)
        {
            // If only 1 robot is available
            if (COMPort_comboBox.Items.Count == 1)
            {
                COMPort_comboBox.SelectedIndex = 0;
                Connect_btn.PerformClick();
            }
            ConnectAutomatically_timer.Enabled = false;
        }



        /// <summary>
        /// Try to connect to all of the available ports. If the connection is succesful, then read the serial data to get the name of the robot
        /// </summary>
        public class ThreadClass
        {
            public static bool isRunning = false;
            private static bool shouldTerminateThreads;
            public static List<Tuple<string, string>> portAndName = new List<Tuple<string, string>>();
            public static string GetNameBasedOnPort(string port)
            {
                if (portAndName.Count > 0)
                {
                    Tuple<string, string> getPortAndName = portAndName.First(y => y.Item1 == port);
                    return getPortAndName.Item2;
                }
                return null;
            }
            public static string GetPortBasedOnName(string name)
            {
                if (portAndName.Count > 0)
                {
                    Tuple<string, string> getPortAndName = portAndName.First(y => y.Item2 == name);
                    return getPortAndName.Item1;
                }
                return null;
            }
            public static void TerminateAllThreads()
            {
                shouldTerminateThreads = true;
            }
            public void SetPorts()
            {
                isRunning = true;
                string[] ports_array = SerialPort.GetPortNames();
                List<Thread> threads = new List<Thread>();

                // Check to see if COMPort_comboBox has a com that is no longer available. If so, remove it.
                List<string> collection = new List<string>();
                foreach (string item in ConnectRobot_form.instance.COMPort_comboBox.Items)
                {
                    collection.Add(item);
                }

                foreach (string item in collection)
                {
                    string port = GetPortBasedOnName(item.ToString());
                    if (!ports_array.Contains(port.ToString()))
                    {
                        ConnectRobot_form.instance.COMPort_comboBox.Invoke(new Action(() =>
                        {
                            // Reset portName if the com was removed
                            if (ConnectRobot_form.instance.COMPort_comboBox.SelectedItem == null)
                                return;

                            if (ConnectRobot_form.instance.COMPort_comboBox.SelectedItem.ToString() == item)
                            {
                                MainControls_form.instance.portName = null;
                            }

                            ConnectRobot_form.instance.COMPort_comboBox.Items.Remove(item);
                            portAndName.Remove(new Tuple<string, string>(port, item));
                        }));
                    }
                }

                // Create a thread for each port
                foreach (string port in ports_array)
                {
                    ThreadClass classInstance = new ThreadClass();
                    Thread t = new Thread(() => classInstance.TryToCommunicateWithPort(port))
                    {
                        Name = port
                    };
                    t.Start();
                    threads.Add(t);
                }

                // Reset
                isRunning = false;
            }
            public void TryToCommunicateWithPort(string port)
            {
                SerialPort serialPort = new SerialPort();
                try
                {
                    serialPort.PortName = port;
                    serialPort.Open();
                }
                catch { return; }

                if (shouldTerminateThreads)
                {
                    shouldTerminateThreads = false;
                    return;
                }

                if (serialPort.IsOpen)
                {
                    string data = serialPort.ReadExisting();
                    string[] fullTrimmedData = data.Split(new char[] { '<', ':', '>' });

                    if (fullTrimmedData.Length > 1)
                    {
                        // Have a unique message in the rare case that other devices are also sending serial data
                        if (fullTrimmedData[1] == "argo_hi")
                        {
                            string name = fullTrimmedData[2];
                            portAndName.Add(new Tuple<string, string>(port, name));

                            // Add names to COMPort_comboBox
                            if (ConnectRobot_form.instance.IsHandleCreated)
                            {
                                ConnectRobot_form.instance.COMPort_comboBox.Invoke(new Action(() =>
                                {
                                    if (!ConnectRobot_form.instance.COMPort_comboBox.Items.Contains(name))
                                        ConnectRobot_form.instance.COMPort_comboBox.Items.Add(name);
                                }));
                            }
                        }
                    }
                    serialPort.Close();
                }
            }
        }

        private void TroubleConnecting_label_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.argorobots.ca/about-us/index.html");
        }

        private void Next_btn_Click(object sender, EventArgs e)
        {
            Setup_form.instance.FormProgram.BringToFront();
            Program_form.instance.CreateProgram_gTextBox.Focus();
            GetPorts_timer.Enabled = false;
        }
    }
}