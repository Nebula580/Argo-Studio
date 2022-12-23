using ArgoStudio.Main.Classes;
using ArgoStudio.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ArgoStudio.Main.BuildMachines.MachineProgrammer
{
    public static class MachineProgrammer
    {
        // Construct panels
        private static List<Guna2Panel>
            appPanel_list = new List<Guna2Panel>(),
            sequencePanel_list = new List<Guna2Panel>(),
            functionPanel_list = new List<Guna2Panel>(),
            eventPanel_list = new List<Guna2Panel>(),
            programEventBackPanel_list = new List<Guna2Panel>(),
            programEventPanel_list = new List<Guna2Panel>(),
            variablePanel_list = new List<Guna2Panel>();
        private static void ConstructAppPanel()
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel.Click += CloseAllPanels;
            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(gPanel);
            appPanel_list.Add(gPanel);
        }
        private static void ConstructSequencePanel()
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel.Click += CloseAllPanels;
            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(gPanel);
            sequencePanel_list.Add(gPanel);
        }
        private static void ConstructFunctionPanel()
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel.Click += CloseAllPanels;
            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(gPanel);
            functionPanel_list.Add(gPanel);
        }
        private static void ConstructEventPanel()
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel.Click += CloseAllPanels;
            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(gPanel);
            eventPanel_list.Add(gPanel);
        }
        private static void ConstructProgramEventPanel(int index, string namePlaceholder)
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Dock = DockStyle.Fill,
                Name = index.ToString(),
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel.Click += CloseAllPanels;

            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(gPanel); ;

            programEventBackPanel_list.Add(gPanel);

            // Name textBox
            Guna2TextBox gTextBox = new Guna2TextBox
            {
                Size = new Size(302, 30),
                Location = new Point(73, 5),
                FillColor = CustomColors.controlBack,
                Font = new Font("Segoe UI", 12),
                ForeColor = CustomColors.text,
                PlaceholderText = namePlaceholder,
                Name = "name",
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3,
                MaxLength = 24
            };
            gPanel.Controls.Add(gTextBox);
            gTextBox.Click += CloseAllPanels;
            gTextBox.TextChanged += (sender, e) =>
            {
                // Update textBox
                Guna2TextBox senderTextBox = (Guna2TextBox)sender;
                Guna2TextBox findname = (Guna2TextBox)selectedCommandBack.Controls.Find("name", false).FirstOrDefault();
                findname.Text = senderTextBox.Text;
            };

            // Description textBox
            gTextBox = new Guna2TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(500, 6),
                MaxLength = 160,
                FillColor = CustomColors.controlBack,
                ForeColor = CustomColors.text,
                Size = new Size(360, 108),
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3,
                PlaceholderText = "Description",
                Name = "description",
                ShortcutsEnabled = false,
                Multiline = true
            };
            gPanel.Controls.Add(gTextBox);
            gTextBox.Click += CloseAllPanels;
            gTextBox.TextChanged += (sender, e) =>
            {
                // Update textBox
                Guna2TextBox senderTextBox = (Guna2TextBox)sender;
                Guna2TextBox findDescription = (Guna2TextBox)eventCommandSelected.Controls.Find("description", false).FirstOrDefault();
                findDescription.Text = senderTextBox.Text;
            };

            // Label
            Label label = UI.ConstructLabel("Event", 12, false, new Point(94, 50), "", gPanel);

            // ComboBox
            Guna2ComboBox gComboBox = new Guna2ComboBox
            {
                Size = new Size(388, 30),
                Location = new Point(94, 78),
                FillColor = CustomColors.controlBack,
                Font = new Font("Segoe UI", 12),
                Name = "event",
                ForeColor = CustomColors.text,
                BorderColor = CustomColors.controlBorder,
                BorderRadius = 3
            };
            gComboBox.Click += CloseAllPanels;
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                // Update ComboBox
                Guna2ComboBox senderComboBox = (Guna2ComboBox)sender;
                Control findEvent = eventCommandSelected.Controls.Find("event", false).FirstOrDefault();
                findEvent.Text = senderComboBox.Text;
            };
            gPanel.Controls.Add(gComboBox);

            // Back button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.BackArrowBlack, null, 2, new Size(35, 35), new Point(12, 10), gPanel);
            gBtn.FillColor = CustomColors.controlBack;
            gBtn.ImageSize = new Size(25, 25);
            gBtn.Click += (sender, e) =>
            {
                selectedCommandBack = eventPanel_list[totalAppCount - 1];
                selectedCommandBack.BringToFront();

                whatIsSelected = "event";
                MachineProgrammer_form.instance.AddCommand_btn.Text = "Add Event";
            };

            // Commands back
            Guna2Panel gPanel2 = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Width = 1026,
                Height = gPanel.Height,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
                Top = 123,
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel2.Click += CloseAllPanels;
            gPanel2.ControlAdded += SaveAmountOfCommandsInEventCommand;
            gPanel2.ControlRemoved += SaveAmountOfCommandsInEventCommand;
            gPanel.Controls.Add(gPanel2);
            programEventPanel_list.Add(gPanel2);
        }
        private static void SaveAmountOfCommandsInEventCommand(object sender, ControlEventArgs e)
        {
            if (!isProgramBeingLoaded)
            {
                Control senderControl = (Control)sender;
                Label findCommandCount = (Label)eventCommandSelected.Controls.Find("commandCount", false).FirstOrDefault();
                findCommandCount.Text = senderControl.Controls.Count.ToString();
            }
        }
        private static void ConstructVariablePanel()
        {
            Guna2Panel gPanel = new Guna2Panel
            {
                BackColor = CustomColors.mainBackground,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMargin = new Size(0, 10)
            };
            gPanel.Click += CloseAllPanels;
            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(gPanel);
            variablePanel_list.Add(gPanel);
        }


        // Get lists from file
        private static List<string> GetListOfAppNames()
        {
            string filePath = Directories.buildMachines_commands_temp_dir;
            return SortAListOfNamesBasedOnItsFolderFileData(filePath);
        }
        private static List<string> GetListOfSequenceNames()
        {
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\";
            return SortAListOfNamesBasedOnItsFolderFileData(filePath);
        }
        private static List<string> GetListOfFunctionNames()
        {
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\functions\";
            return SortAListOfNamesBasedOnItsFileData(filePath);
        }
        private static List<string> GetListOfEventNames()
        {
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<string> list = new List<string>();

            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                list.Add(data[1]);
            }
            return list;
        }

        /// <summary>
        /// Used to sort lists 
        /// </summary>
        private class FileMeta
        {
            public string name;
            public int value;
            public string path;
        }
        public static List<string> SortAListOfNamesBasedOnItsFileData(string filePath)
        {
            // https://stackoverflow.com/questions/73396081/how-to-sort-a-list-of-names-based-on-its-file-data

            if (Directory.Exists(filePath))
            {
                IEnumerable<FileMeta> metaList = Directory.EnumerateFiles(filePath, "*.txt", SearchOption.TopDirectoryOnly)
                    .Select(path =>
                    {
                        int value = 0;
                        string fileName = Path.GetFileNameWithoutExtension(path);
                        string line = File.ReadLines(path).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(line))
                            value = Convert.ToInt32(line);
                        else
                            Log.FailedToSortAListOfNamesBecauseOfNullOrWhitespace(path);

                        return new FileMeta() { name = fileName, value = value };
                    })
                    .OrderBy(meta => meta.value);

                return (from meta in metaList
                        select meta.name).ToList();
            }
            else
            {
                Log.Error_DirectoryDoesNotExist(filePath);
                return new List<string>();
            }
        }
        private static List<string> SortAListOfNamesBasedOnItsFolderFileData(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                IEnumerable<FileMeta> metaList = Directory.EnumerateDirectories(filePath)
                    .Select(path =>
                    {
                        int value = 0;
                        string folderName = new DirectoryInfo(path).Name;
                        path += @"\" + folderName + ".txt";
                        string fileName = Path.GetFileNameWithoutExtension(path);
                        string line = File.ReadLines(path).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(line))
                            value = Convert.ToInt32(line);
                        else
                            Log.FailedToSortAListOfNamesBecauseOfNullOrWhitespace(path);

                        return new FileMeta() { name = fileName, value = value };
                    })
                    .OrderBy(meta => meta.value);

                return (from meta in metaList
                        select meta.name).ToList();
            }
            else
            {
                Log.Error_DirectoryDoesNotExist(filePath);
                return new List<string>();
            }
        }


        // Load in commands
        public static bool isProgramBeingLoaded;
        public static void LoadInCommands()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<string> appNamesList = GetListOfAppNames();
            if (appNamesList.Count > 0)
            {
                List<Thread> threads = new List<Thread>();
                isProgramBeingLoaded = true;

                // Load app commands
                foreach (string appName in appNamesList)
                {
                    AddApp(appName);

                    selectedCommandBack = appPanel_list[selectedAppTag - 1];
                    string filePath1 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\" + selectedAppName + ".txt";
                    ConstructCommands(null, filePath1);

                    // Load sequence commands
                    List<string> sequenceNamesList = GetListOfSequenceNames();
                    foreach (string sequenceName in sequenceNamesList)
                    {
                        AddSequence(sequenceName);

                        selectedCommandBack = sequencePanel_list[totalSequenceCountSelected - 1];
                        string filePath2 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceName + @"\" + sequenceName + ".txt";
                        ConstructCommands(null, filePath2);

                        // Load function commands
                        List<string> functionNamesList = GetListOfFunctionNames();
                        foreach (string functionName in functionNamesList)
                        {
                            AddFunction(functionName);

                            Guna2Panel threadCommandBack = functionPanel_list[functionIndexSelected - 1];
                            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceName + @"\functions\" + functionName + ".txt";
                            ConstructCommands(threadCommandBack, filePath);
                        }
                    }


                    Thread th1 = new Thread(new ThreadStart(LoadVariableCommands))
                    {
                        Name = "loadVariableCommands"
                    };
                    threads.Add(th1);

                    Thread th2 = new Thread(new ThreadStart(LoadEventCommands))
                    {
                        Name = "loadEventCommands"
                    };
                    threads.Add(th2);

                    // Start threads
                    foreach (Thread thread in threads)
                    {
                        thread.Start();
                    }

                    // Join threads
                    foreach (Thread thread in threads)
                    {
                        thread.Join();
                    }
                    threads.Clear();  // Fixes a dumb bug

                    // Add program event commands
                    List<string> eventNames_list = GetListOfEventNames();
                    if (eventNames_list.Count > 0)
                    {
                        whatIsSelected = "programEvent";
                        for (int i2 = 1; i2 <= eventNames_list.Count; i2++)
                        {
                            ConstructProgramEventPanel(i2, "Event " + i2.ToString());
                            eventNameSelected = eventNames_list[i2 - 1];

                            Guna2Panel threadCommandBack = programEventPanel_list[i2 - 1];
                            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\" + eventNames_list[i2 - 1] + ".txt";

                            ConstructCommands(threadCommandBack, filePath);
                        }
                    }
                }

                ShowAppPanel(false, true);
                Log.Write(3, "Loaded App '" + selectedAppName + "'");

                // Save
                isProgramBeingLoaded = false;
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = Tools.FormatTimeSpan(ts);
            Log.Write(1, "Time to load commands: " + elapsedTime);
        }
        private static void LoadVariableCommands()
        {
            Guna2Panel threadCommandBack = variablePanel_list[selectedAppTag - 1];
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\variables.txt";

            if (File.Exists(filePath))
            {
                string[] lines1 = File.ReadAllLines(filePath);

                threadCommandBack.AutoScroll = false;
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] lines2 = lines1[i].Split(',');
                    if (lines2[0] == "addVariable")
                    {
                        List<string> loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3] });
                        ConstructAddVariableCommand(threadCommandBack, loadCommandData);
                    }
                    else { Log.FailedToLoadVariables(selectedAppName, filePath); }
                }
                threadCommandBack.AutoScroll = true;
            }
            else
            {
                Log.Error_FileDoesNotExist(filePath);
                Directories.CreateFile(filePath);
            }
        }
        private static void LoadEventCommands()
        {
            Guna2Panel threadCommandBack = eventPanel_list[selectedAppTag - 1];
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events.txt";

            if (File.Exists(filePath))
            {
                string[] lines1 = File.ReadAllLines(filePath);

                threadCommandBack.AutoScroll = false;
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] lines2 = lines1[i].Split(',');
                    if (lines2[0] == "event")
                    {
                        List<string> loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4], lines2[5] });
                        ConstructAddEventCommand(threadCommandBack, loadCommandData);
                    }
                    else { Log.FailedToLoadEvents(selectedAppName, filePath); }
                }
                threadCommandBack.AutoScroll = true;
            }
            else
            {
                Log.Error_FileDoesNotExist(filePath);
                Directories.CreateFile(filePath);
            }
        }
        private static void ConstructCommands(Guna2Panel threadCommandBack, string filePath)
        {
            if (File.Exists(filePath))
            {
                Guna2Panel cuurentCommandBack;
                if (threadCommandBack != null)
                    cuurentCommandBack = threadCommandBack;
                else
                    cuurentCommandBack = selectedCommandBack;

                cuurentCommandBack.AutoScroll = false;

                List<string> loadCommandData;

                int value = 0;
                if (whatIsSelected == "programEvent" || whatIsSelected == "variable")
                    value = 1;

                string[] lines1 = File.ReadAllLines(filePath);
                for (int i = 1; i < lines1.Length + value; i++)
                {
                    string[] lines2 = lines1[i - value].Split(',');
                    switch (lines2[0])
                    {
                        case "move":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4], lines2[5], lines2[6], lines2[7], lines2[8], lines2[9], lines2[10], lines2[11], lines2[12], lines2[13], lines2[14], lines2[15], lines2[16] });
                            ConstructMotionCommand(cuurentCommandBack, loadCommandData);
                            break;
                        case "delay":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4] });
                            ConstructDelayCommand(cuurentCommandBack, loadCommandData);
                            break;
                        case "run":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4], lines2[5], lines2[6], lines2[7] });
                            ConstructRunCommand(cuurentCommandBack, loadCommandData);
                            break;
                        case "setVariable":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4] });
                            ConstructSetVariableCommand(cuurentCommandBack, loadCommandData);
                            break;
                        case "loop":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4], lines2[5], lines2[6], lines2[7], lines2[8], lines2[9], lines2[10], lines2[11], lines2[12], lines2[13], lines2[14], lines2[15], lines2[16] });
                            ConstructLoopCommand(cuurentCommandBack, loadCommandData);
                            break;
                        case "setOutput":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3] });
                            ConstructSetOutputCommand(cuurentCommandBack, loadCommandData);
                            break;
                        case "home":
                            loadCommandData = new List<string>(new string[] { lines2[1], lines2[2], lines2[3], lines2[4], lines2[5], lines2[6], lines2[7] });
                            ConstructHomeCommand(cuurentCommandBack, loadCommandData);
                            break;
                    }
                }
                cuurentCommandBack.AutoScroll = true;
            }
            else { Log.Error_FileDoesNotExist(filePath); }
        }
        /// <summary>
        /// Load in MachineController_ComboBox.Text from file (data.txt)
        /// </summary>
        public static void LoadInInfo()
        {
            string filePath = Directories.buildMachines_commands_temp_data_file;
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    MachineProgrammer_form.instance.MachineController_ComboBox.Items.Add(lines[0]);
                    MachineProgrammer_form.instance.MachineController_ComboBox.Text = lines[0];
                }
            }
            else
            {
                Log.Error_FileDoesNotExist(filePath);
                Directories.CreateFile(filePath);
            }
        }


        // Set up play app
        public static bool wasStopBtnClicked, isAppPaused, isAppPlaying;
        private static bool didRunCommandJustRunSuccessfully;
        public static string playingMachineControllerSelected;
        private static Guna2Button PlayingFileManagmentButton;
        private static int WaitUntilMachineHasFinishedMoving()
        {
            // Wait until robot is done moving

            // Communicate with RPI here

            return 600;
        }
        private static bool ReadAndRunCommand(int commandIndex)
        {
            // Get command data
            Control findCommand = selectedCommandBack.Controls.Find((commandIndex + 1).ToString(), false).FirstOrDefault();
            Control findTag = findCommand.Controls.Find("numberLabel", false).FirstOrDefault();
            string commandName = findTag.Tag.ToString() + " " + (commandIndex + 1).ToString();

            Log.Write(3, "Running command '" + commandName + "'");

            string commandData;
            string[] parsedCommandData;

            didRunCommandJustRunSuccessfully = false;

            // Read command data
            switch (findTag.Tag.ToString())
            {
                case "moveCommand":
                    break;

                case "homeCommand":
                    break;

                case "delayCommand":
                    break;

                case "runCommand":

                    // Get data from the command
                    commandData = SaveRunCommand(findCommand);
                    parsedCommandData = commandData.Split(',');

                    if (parsedCommandData[1] != "")
                    {
                        switch (parsedCommandData[1])
                        {
                            case "Run sequence":
                                if (parsedCommandData[1] != "" && parsedCommandData[5] != "" && parsedCommandData[6] != "")
                                {
                                    // Find the sequence
                                    int index = GetListOfSequenceNames().IndexOf(parsedCommandData[5]);

                                    Guna2Panel oldSelectedCommandBack = selectedCommandBack;
                                    selectedCommandBack = sequencePanel_list[index];

                                    // Show sequence menu
                                    ShowCommandBackSelected();
                                    UnselectAllCommands(false);

                                    selectedCommandBack.Tag = new Tuple<Guna2Panel, Guna2Button, string>(oldSelectedCommandBack, PlayingFileManagmentButton, whatIsSelected);

                                    Guna2Button button = (Guna2Button)appPanelFlowPanelSelected.Controls[index].Controls[0];
                                    ResetOldFileButtonPlaying();
                                    SelectTheNewFileButtonPlaying(button);

                                    whatIsSelected = "sequence";
                                    appOrSequenceOrFunctionBtnSelected = button;
                                    PlayingFileManagmentButton = button;
                                    Log.Write(3, "Switched to sequence '" + parsedCommandData[5] + "'");
                                }
                                else
                                {
                                    StopPlayingAppBecauseThereIsACommandError(commandName);
                                    return false;
                                }
                                break;

                            case "Run function":
                                if (parsedCommandData[1] != "" && parsedCommandData[2] != "" && parsedCommandData[3] != "" && parsedCommandData[4] != "")
                                {
                                    // Find the sequence
                                    for (int i = 0; i < appPanelFlowPanelSelected.Controls.Count; i++)
                                    {
                                        if (appPanelFlowPanelSelected.Controls[i].Controls[0].Text == parsedCommandData[2])
                                        {
                                            sequenceFlowPanelSelected = (FlowLayoutPanel)appPanelFlowPanelSelected.Controls[i].Controls[1];
                                            break;
                                        }
                                    }

                                    // Find the function
                                    for (int i = 0; i < sequenceFlowPanelSelected.Controls.Count; i++)
                                    {
                                        if (sequenceFlowPanelSelected.Controls[i].Text == parsedCommandData[3])
                                        {
                                            functionIndexSelected = Convert.ToInt32(sequenceFlowPanelSelected.Controls[i].Name);
                                            appOrSequenceOrFunctionBtnSelected = (Guna2Button)sequenceFlowPanelSelected.Controls[i];
                                            break;
                                        }
                                    }

                                    // Show the function panel
                                    Guna2Panel oldSelectedCommandBack = selectedCommandBack;
                                    selectedCommandBack = functionPanel_list[functionIndexSelected - 1];
                                    UnselectAllCommands(false);
                                    ShowCommandBackSelected();

                                    selectedCommandBack.Tag = new Tuple<Guna2Panel, Guna2Button, string>(oldSelectedCommandBack, PlayingFileManagmentButton, whatIsSelected);

                                    ResetOldFileButtonPlaying();
                                    PlayingFileManagmentButton = appOrSequenceOrFunctionBtnSelected;
                                    SelectTheNewFileButtonPlaying(PlayingFileManagmentButton);

                                    whatIsSelected = "function";
                                    Log.Write(3, "Switched to function '" + parsedCommandData[3] + "'");
                                }
                                else
                                {
                                    StopPlayingAppBecauseThereIsACommandError(commandName);
                                    return false;
                                }
                                break;
                        }
                        didRunCommandJustRunSuccessfully = true;
                    }
                    else { StopPlayingAppBecauseThereIsACommandError(commandName); return false; }

                    // Always return false because there is a new selectedCommandBack
                    return false;

                case "setVariableCommand":

                    // Get data from the command
                    commandData = SaveSetVariableCommand(findCommand);
                    parsedCommandData = commandData.Split(',');
                    string variableNameSelected = parsedCommandData[1].ToString();

                    if (variableNameSelected != "" && parsedCommandData[1] != "" && parsedCommandData[2] != "" & parsedCommandData[3] != "")
                    {
                        // Find the variable command
                        Control findVariableCommand = null;
                        foreach (Guna2Button command in variablePanel_list[selectedAppTag - 1].Controls)
                        {
                            Guna2TextBox variableTextBox = (Guna2TextBox)command.Controls.Find("1", false).FirstOrDefault();
                            if (variableTextBox.Text == variableNameSelected)
                            {
                                findVariableCommand = command;
                            }
                        }

                        // Set the variable based on the command data
                        if (findVariableCommand != null)
                        {
                            int variableIndex = Convert.ToInt32(findVariableCommand.Name) - 1;

                            switch (parsedCommandData[2])
                            {
                                case "Set to":
                                    variableValues_list[variableIndex] = Convert.ToInt32(parsedCommandData[3]);
                                    Log.Write(3, "Set variable '" + variableNameSelected + "' to " + variableValues_list[variableIndex]);
                                    break;
                                case "Increase":
                                    int before = variableValues_list[variableIndex];
                                    variableValues_list[variableIndex] += Convert.ToInt32(parsedCommandData[3]);
                                    Log.Write(3, "Increased variable '" + variableNameSelected + "' from " + before + " to " + variableValues_list[variableIndex]);
                                    break;
                                case "Decrease":
                                    int before2 = variableValues_list[variableIndex];
                                    variableValues_list[variableIndex] -= Convert.ToInt32(parsedCommandData[3]);
                                    Log.Write(3, "Decreased variable '" + variableNameSelected + "' from " + before2 + " to " + variableValues_list[variableIndex]);
                                    break;
                            }
                        }
                        else
                        {
                            StopPlayingAppBecauseThereIsACommandError(commandName);
                            return false;
                        }
                    }
                    else
                    {
                        StopPlayingAppBecauseThereIsACommandError(commandName);
                        return false;
                    }
                    break;

                case "loopCommand":
                    break;

                case "setOutputCommand":
                    break;
            }
            return true;
        }
        private static void ResetOldFileButtonPlaying()
        {
            PlayingFileManagmentButton.FillColor = CustomColors.mainBackground;
            PlayingFileManagmentButton.DisabledState.FillColor = CustomColors.mainBackground;
            PlayingFileManagmentButton.BorderThickness = 0;

            // Reset the sequence label arrow
            Guna2Button fArrow = (Guna2Button)PlayingFileManagmentButton.Controls.Find("arrow", false).FirstOrDefault();
            if (fArrow != null)
            {
                fArrow.FillColor = CustomColors.mainBackground;
                fArrow.DisabledState.FillColor = CustomColors.mainBackground;
            }
        }
        private static void SelectTheNewFileButtonPlaying(Guna2Button btn)
        {
            btn.DisabledState.FillColor = CustomColors.accent_green;
            btn.DisabledState.BorderColor = CustomColors.accent_darkerGreen;
            btn.BorderThickness = 1;
            PlayingFileManagmentButton = btn;

            // Reset the sequence label arrow
            Guna2Button fArrow = (Guna2Button)PlayingFileManagmentButton.Controls.Find("arrow", false).FirstOrDefault();
            if (fArrow != null)
            {
                fArrow.FillColor = CustomColors.accent_green;
                fArrow.DisabledState.FillColor = CustomColors.accent_green;
            }
        }
        private static string commandErrorName;
        private static void StopPlayingAppBecauseThereIsACommandError(string commandError)
        {
            MachineProgrammer_form.instance.Stop_btn.PerformClick();
            commandErrorName = commandError;
        }
        private static void SetPlayButtonToDefault()
        {
            MachineProgrammer_form.instance.Stop_btn.Enabled = false;
            MachineProgrammer_form.instance.Play_btn.Image = Resources.Play;
        }
        public static void AppHasFinishedPlaying(bool finishedNormally)
        {
            SetPlayButtonToDefault();
            MachineProgrammer_form.instance.MainCommandBack_panel.Enabled = true;
            MachineProgrammer_form.instance.EnableMoveBtns();
            MachineProgrammer_form.instance.FileBack_panel.Enabled = true;

            // Reset
            wasStopBtnClicked = false;
            wasFWDBtnClicked = false;
            isAppPlaying = false;

            // Update variableValues_list to initial value 
            for (int i = 0; i < variableValues_list.Count - 1; i++)
            {
                // Find variable command
                Control findVariableCommand = variablePanel_list[selectedAppTag - 1].Controls[i];
                Guna2TextBox findVariableValue = (Guna2TextBox)findVariableCommand.Controls.Find("2", false).FirstOrDefault();
                // Set
                variableValues_list[i] = Convert.ToInt32(findVariableValue.Text);
                variableValues_list[i] = 0;
            }

            if (PlayingFileManagmentButton != null)
            {
                // Reset playing file label         
                PlayingFileManagmentButton.FillColor = CustomColors.fileSelected;
                PlayingFileManagmentButton.BorderColor = CustomColors.controlSelectedBorder;

                // Reset playing file label arrow            
                Guna2Button fArrow = (Guna2Button)PlayingFileManagmentButton.Controls.Find("arrow", false).FirstOrDefault();
                if (fArrow != null)
                {
                    fArrow.FillColor = CustomColors.fileSelected;
                }
            }

            if (finishedNormally)
            {
                Log.Write(3, "App '" + selectedAppName + "' has finished playing");
                MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(messagePanel);
                SetMessage("App '" + selectedAppName + "' has finished playing");
            }
        }


        // Play app
        public static void PlayApp()
        {
            Log.Write(3, "Playing app '" + selectedAppName + "'");

            // Find selected app label
            foreach (Guna2Button item in
            from Guna2Button item in appBtnList
            where item.Text == selectedAppName
            select item)
            {
                appPanelSelected = (Guna2Button)item.Parent;
                break;
            }

            // Switch to app
            ShowAppPanel(true, false);

            // Reset
            wasFWDBtnClicked = false;
            wasStopBtnClicked = false;

            MoveForward();
        }
        public static bool wasFWDBtnClicked;
        public async static void MoveForward()
        {
            bool appIsNotDone = false, isAnyCommandSelected = false;
            isAppPlaying = true;
            isAppPaused = false;

            if (selectedCommandBack.Controls.Count > 0)
            {
                for (int i = 0; i < selectedCommandBack.Controls.Count; i++)
                {
                    Guna2Button findCurrentCommand = (Guna2Button)selectedCommandBack.Controls.Find((i + 1).ToString(), false).FirstOrDefault();

                    // If any command is selected
                    if (findCurrentCommand.FillColor == CustomColors.fileSelected)
                    {
                        // Disable controls
                        MachineProgrammer_form.instance.FileBack_panel.Enabled = false;
                        MachineProgrammer_form.instance.MainCommandBack_panel.Enabled = false;
                        MachineProgrammer_form.instance.DisableMoveBtns();
                        MachineProgrammer_form.instance.Stop_btn.Enabled = true;
                        MachineProgrammer_form.instance.Play_btn.Image = Resources.Pause;

                        appIsNotDone = true;
                        if (ReadAndRunCommand(i))
                        {
                            isAnyCommandSelected = true;
                            SetCommandBackgroundToGreen(findCurrentCommand);

                            // Wait until the machine has moved
                            int delay = WaitUntilMachineHasFinishedMoving() / 10;
                            for (int i2 = 0; i2 < delay; i2++)
                            {
                                // Wait
                                await Task.Delay(10);

                                // Check if the stop button has been clicked
                                if (wasStopBtnClicked) break;

                                // Do nothing while the app is paused
                                while (isAppPaused)
                                {
                                    await Task.Delay(10);
                                    Application.DoEvents();
                                }
                            }

                            // Check if the stop button has been clicked
                            if (wasStopBtnClicked)
                            {
                                ChangeCommandBackground(findCurrentCommand, CustomColors.accent_red);
                                break;
                            }
                            else
                            {
                                // Unselect the current command
                                SetCommandBackgroundToControlBack(findCurrentCommand);
                            }

                            // Select the next command
                            if (i + 1 < selectedCommandBack.Controls.Count)
                            {
                                for (int i2 = 0; i2 < selectedCommandBack.Controls.Count; i2++)
                                {
                                    Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find((i + i2 + 2).ToString(), false).FirstOrDefault();

                                    // If the command is not hidden
                                    if (findCommand.FillColor != Color.LightGray)
                                    {
                                        SelectCommand(findCommand, true);
                                        selectedCommandBack.ScrollControlIntoView(findCommand);
                                        break;
                                    }
                                }
                            }
                            else appIsNotDone = false;
                            break;
                        }
                        else if (!didRunCommandJustRunSuccessfully)
                        {
                            ChangeCommandBackground(findCurrentCommand, CustomColors.accent_red);
                            CustomMessageBox.Show("Argo Studio", "Could not run '" + commandErrorName + "' because not all of the fields in the command are filled.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                            return;
                        }
                    }
                }

                if (!isAnyCommandSelected)
                {
                    appIsNotDone = true;
                    if (!wasFWDBtnClicked)
                    {
                        if (selectedCommandBack.Controls.Count == 0)
                        {
                            AppHasFinishedPlaying(false);
                            CustomMessageBox.Show("Argo Studio", "There are no commands in the " + whatIsSelected + " you are trying to play.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                            return;
                        }
                        else  // Select the first command that is not hidden
                        {
                            for (int i2 = 0; i2 < selectedCommandBack.Controls.Count; i2++)
                            {
                                Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find((1 + i2).ToString(), false).FirstOrDefault();
                                if (findCommand.FillColor != Color.LightGray)
                                {
                                    SelectCommand(findCommand, true);
                                    selectedCommandBack.ScrollControlIntoView(findCommand);
                                    isAnyCommandSelected = true;
                                    break;
                                }
                            }
                        }

                        // If all the commands are hidden
                        if (!isAnyCommandSelected)
                        {
                            AppHasFinishedPlaying(false);
                            CustomMessageBox.Show("Argo Studio", "All of the commands are hidden..", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                            return;
                        }
                    }
                    else
                    {
                        AppHasFinishedPlaying(false);
                        CustomMessageBox.Show("Argo Studio", "In order to move forward you need to select a command by double clicking on it.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        return;
                    }
                }
            }
            else
            {
                AppHasFinishedPlaying(false);
                CustomMessageBox.Show("Argo Studio", "There are no commands in the " + whatIsSelected + " you are trying to play.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                return;
            }

            // Is the app done, or should it continue playing
            if (!wasStopBtnClicked)
            {
                // If there are no more commands in the panel to play
                if (!appIsNotDone && !wasFWDBtnClicked)
                {
                    ReturnToPreviousPanel();
                }
                else if (wasFWDBtnClicked)
                {
                    AppHasFinishedPlaying(true);
                }
                else
                {
                    Log.Write(3, "Moved forward by one command");
                    MoveForward();
                }
            }
        }
        private static void ReturnToPreviousPanel()
        {
            // Switch to the previous panel
            if (selectedCommandBack.Tag != null)
            {
                Tuple<Guna2Panel, Guna2Button, string> vals = selectedCommandBack.Tag as Tuple<Guna2Panel, Guna2Button, string>;

                // Show panel
                selectedCommandBack = vals.Item1;
                ShowCommandBackSelected();

                ResetOldFileButtonPlaying();
                PlayingFileManagmentButton = vals.Item2;
                SelectTheNewFileButtonPlaying(PlayingFileManagmentButton);

                whatIsSelected = vals.Item3;
                appOrSequenceOrFunctionBtnSelected = PlayingFileManagmentButton;

                Log.Write(3, "Switched to previous panel '" + vals.Item2.Text + "'");

                // Select next command
                for (int i2 = 1; i2 <= selectedCommandBack.Controls.Count; i2++)
                {
                    Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find(i2.ToString(), false).FirstOrDefault();

                    if (findCommand.FillColor == CustomColors.fileSelected && findCommand.FillColor != Color.LightGray)
                    {
                        Guna2Button findNextCommand = (Guna2Button)selectedCommandBack.Controls.Find((i2 + 1).ToString(), false).FirstOrDefault();
                        UnselectAllCommands(false);

                        if (findNextCommand != null)
                        {
                            SelectCommand(findNextCommand, true);
                            selectedCommandBack.ScrollControlIntoView(findNextCommand);
                            MoveForward();
                            break;
                        }
                        else
                            // The run command is the last command
                            ReturnToPreviousPanel();
                    }
                }
            }
            else AppHasFinishedPlaying(true);
        }
        public async static void MoveBackward()
        {
            bool appIsNotDone = false, isAnyCommandSelected = false;

            if (selectedCommandBack.Controls.Count > 0)
            {
                for (int i = 0; i < selectedCommandBack.Controls.Count; i++)
                {
                    Guna2Button findCurrentCommand = (Guna2Button)selectedCommandBack.Controls.Find((i + 1).ToString(), false).FirstOrDefault();
                    // If any command is selected
                    if (findCurrentCommand.FillColor == CustomColors.fileSelected)
                    {
                        // Disable controls
                        MachineProgrammer_form.instance.FileBack_panel.Enabled = false;
                        MachineProgrammer_form.instance.MainCommandBack_panel.Enabled = false;
                        MachineProgrammer_form.instance.DisableMoveBtns();
                        MachineProgrammer_form.instance.Stop_btn.Enabled = true;
                        MachineProgrammer_form.instance.Play_btn.Image = Resources.Pause;

                        appIsNotDone = true;
                        isAnyCommandSelected = true;

                        // Wait until the machine has moved
                        SetCommandBackgroundToGreen(findCurrentCommand);
                        if (ReadAndRunCommand(i))
                        {
                            int delay = WaitUntilMachineHasFinishedMoving() / 10;
                            for (int i2 = 0; i2 < delay; i2++)
                            {
                                await Task.Delay(10);
                                if (wasStopBtnClicked) break;
                            }

                            // Check if the stop button has been clicked
                            if (wasStopBtnClicked)
                            {
                                ChangeCommandBackground(findCurrentCommand, CustomColors.accent_red);
                                break;
                            }
                            else SetCommandBackgroundToControlBack(findCurrentCommand);

                            // If there is more than one command
                            if (selectedCommandBack.Controls.Count > 1)
                            {
                                // Select the next command
                                if (i < selectedCommandBack.Controls.Count & i > 0)
                                {
                                    for (int i2 = 0; i2 < selectedCommandBack.Controls.Count; i2++)
                                    {
                                        Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find((i - i2).ToString(), false).FirstOrDefault();

                                        // If the command is not hidden
                                        if (findCommand.FillColor != Color.LightGray)
                                        {
                                            SelectCommand(findCommand, true);
                                            selectedCommandBack.ScrollControlIntoView(findCommand);
                                            break;
                                        }
                                    }
                                }
                                else appIsNotDone = false;
                            }
                            break;
                        }
                        else
                        {
                            AppHasFinishedPlaying(false);
                            CustomMessageBox.Show("Argo Studio", "There are no commands in the " + whatIsSelected + " you are trying to play.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                            return;
                        }
                    }
                }

                // If there are no commands selected
                if (!isAnyCommandSelected)
                {
                    appIsNotDone = true;
                    if (!wasStopBtnClicked)
                    {
                        AppHasFinishedPlaying(false);
                        CustomMessageBox.Show("Argo Studio", "In order to move backward you need to select a command by double clicking on it.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                        return;
                    }
                }
            }
            else
            {
                AppHasFinishedPlaying(false);
                CustomMessageBox.Show("Argo Studio", "There are no commands in the " + whatIsSelected + " you are trying to play.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.Ok);
                return;
            }

            if (!appIsNotDone || isAnyCommandSelected)
                AppHasFinishedPlaying(true);
        }


        // Things for right click panels
        private static void ResetControlsInRightClickPanel(FlowLayoutPanel flowPanel)
        {
            List<Guna2Button> sortedControls = flowPanel.Controls.OfType<Guna2Button>().ToList();
            sortedControls.Sort((a, b) => a.TabIndex.CompareTo(b.TabIndex));
            flowPanel.Controls.Clear();
            flowPanel.Controls.AddRange(sortedControls.ToArray());
        }

        // Right click file panel
        public static Guna2Panel rightClickFile_panel, rightClickFileMove_panel;
        private static Guna2Button rightClickFileMove_btn, rightClickFileMoveUp_btn, rightClickFileMoveDown_btn;
        public static Guna2Button rightClickFileDelete_btn;
        public static void ConstructRightClickFilePanel()
        {
            rightClickFile_panel = UI.ConstructPanelForMenu(new Size(200, 10 * 22 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickFile_panel.Controls[0];

            Guna2Button menuBtn = UI.ConstructBtnForMenu("Add app", 190, true, flowPanel);
            menuBtn.Tag = 1;
            menuBtn.Click += (sender, e) =>
            {
                AddApp(null);
                AddSequence(null);
                AddFunction(null);
            };

            menuBtn = UI.ConstructBtnForMenu("Add sequence", 190, true, flowPanel);
            menuBtn.Tag = 2;
            menuBtn.Click += (sender, e) => { AddSequence(null); };

            menuBtn = UI.ConstructBtnForMenu("Add function", 190, true, flowPanel);
            menuBtn.Tag = 3;
            menuBtn.Click += (sender, e) => { AddFunction(null); };

            menuBtn = UI.ConstructBtnForMenu("Move up", 190, true, flowPanel);
            menuBtn.Tag = 4;
            menuBtn.Click += (sender, e) =>
            {
                switch (whatIsSelected)
                {
                    case "app":
                        MoveAppSequenceOrFunctionUpOrDown(MachineProgrammer_form.instance.FileBack_flowPanel, appPanelSelected, true);
                        break;

                    case "sequence":
                        MoveAppSequenceOrFunctionUpOrDown(appPanelFlowPanelSelected, sequencePanelSelected, true);
                        break;

                    case "function":
                        MoveAppSequenceOrFunctionUpOrDown(sequenceFlowPanelSelected, functionBtnSelected, true);
                        break;
                }
            };
            rightClickFileMoveUp_btn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Move down", 190, true, flowPanel);
            menuBtn.Tag = 5;
            menuBtn.Click += (sender, e) =>
            {
                switch (whatIsSelected)
                {
                    case "app":
                        MoveAppSequenceOrFunctionUpOrDown(MachineProgrammer_form.instance.FileBack_flowPanel, appPanelSelected, false);
                        break;

                    case "sequence":
                        MoveAppSequenceOrFunctionUpOrDown(appPanelFlowPanelSelected, sequencePanelSelected, false);
                        break;

                    case "function":
                        MoveAppSequenceOrFunctionUpOrDown(sequenceFlowPanelSelected, functionBtnSelected, false);
                        break;
                }
            };
            rightClickFileMoveDown_btn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Rename", 190, true, flowPanel);
            menuBtn.Tag = 6;
            menuBtn.Click += (sender, e) =>
            {
                switch (whatIsSelected)
                {
                    case "app":
                        UI.rename_textBox.Left = 12 + 8;
                        UI.rename_textBox.Width = 244 - 12 - 15;
                        break;

                    case "sequence":
                        UI.rename_textBox.Left = 25 + 8;
                        UI.rename_textBox.Width = 244 - 25 - 15;
                        break;

                    case "function":
                        UI.rename_textBox.Left = 38 + 8;
                        UI.rename_textBox.Width = 244 - 38 - 15;
                        break;
                }

                appOrSequenceOrFunctionBtnSelected.BorderThickness = 0;
                UI.rename_textBox.Text = appOrSequenceOrFunctionBtnSelected.Text;
                appOrSequenceOrFunctionBtnSelected.Controls.Add(UI.rename_textBox);
                UI.rename_textBox.Focus();
                UI.rename_textBox.SelectAll();
                UI.rename_textBox.BringToFront();
            };

            rightClickFileMove_panel = UI.ConstructPanelForMenu(new Size(250, 0));

            menuBtn = UI.ConstructBtnForMenu("Move to", 190, false, flowPanel);
            menuBtn.Tag = 7;
            menuBtn.Image = Resources.RightArrowGray;
            menuBtn.ImageSize = new Size(11, 11);
            menuBtn.ImageOffset = new Point(80, 0);
            menuBtn.Click += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                SetMoveToMenu();
                btn.Tag = rightClickFileMove_panel;
                MainMenu_form.instance.OpenMenu();
            };
            menuBtn.MouseEnter += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                SetMoveToMenu();
                btn.Tag = rightClickFileMove_panel;
            };
            menuBtn.MouseLeave += MainMenu_form.instance.CloseMenu;
            rightClickFileMove_btn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Import", 190, true, flowPanel);
            menuBtn.Tag = 8;
            menuBtn.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Title = "Import",
                    Filter = "Argo files|*.ArgoApp;*.ArgoSequence;*.ArgoFunction",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    RestoreDirectory = true,
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (Path.GetExtension(openFileDialog1.FileName))
                    {
                        case ".ArgoApp":

                            break;

                        case ".ArgoSequence":

                            break;

                        case ".ArgoFunction":

                            break;
                    }
                }
            };

            menuBtn = UI.ConstructBtnForMenu("Export", 190, true, flowPanel);
            menuBtn.Tag = 9;
            menuBtn.Click += (sender, e) =>
            {
                // Displays a SaveFileDialog so the user can export
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Title = "Export " + whatIsSelected,
                    RestoreDirectory = true,
                    FileName = appOrSequenceOrFunctionBtnSelected.Text
                };
                switch (whatIsSelected)
                {
                    case "app":
                        saveFileDialog1.Filter = "Argo app|*.ArgoApp";
                        break;

                    case "sequence":
                        saveFileDialog1.Filter = "Argo sequence|*.ArgoSequence";
                        break;

                    case "function":
                        saveFileDialog1.Filter = "Argo function|*.ArgoFunction";
                        break;
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Directories.CreateFile(saveFileDialog1.FileName);

                }
            };

            menuBtn = UI.ConstructBtnForMenu("Delete", 190, true, flowPanel);
            menuBtn.Tag = 10;
            menuBtn.Click += (sender, e) =>
            {
                string filePath1 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName;

                switch (whatIsSelected)
                {
                    case "app":
                        // APP
                        CustomMessageBoxResult result = CustomMessageBox.Show("Argo Studio", "App '" + selectedAppName + "' and all of it's contents will be deleted permanently.", CustomMessageBoxIcon.Exclamation, CustomMessageBoxButtons.OkCancel);
                        if (result == CustomMessageBoxResult.Ok)
                        {
                            MachineProgrammer_form.instance.FileBack_flowPanel.Controls.Remove(appPanelSelected);
                            appOrSequenceOrFunctionBtnSelected.Height = 30;
                            appPanel_list[selectedAppTag - 1] = null;
                            selectedCommandBack.Visible = false;

                            // Delete the app directory
                            if (!Directories.DeleteDirectory(filePath1, true)) { return; }

                            Log.Write(3, "Deleted app '" + selectedAppName + "'");
                        }
                        break;

                    case "sequence":

                        // SEQUENCE
                        string filePath4 = filePath1 + @"\sequences\" + sequenceBtnSelected.Text;

                        CustomMessageBoxResult result2 = CustomMessageBox.Show("Argo Studio", "Sequence '\" + appOrSequenceOrFunctionBtnSelected.Text + \"' and all of it's contents will be deleted permanently.", CustomMessageBoxIcon.Exclamation, CustomMessageBoxButtons.OkCancel);

                        if (result2 == CustomMessageBoxResult.Ok)
                        {
                            appPanelSelected.Height -= (25 * sequenceFlowPanelSelected.Controls.Count) + 30;
                            appPanelFlowPanelSelected.Controls.Remove(sequencePanelSelected);
                            sequenceBtnList.Remove(appOrSequenceOrFunctionBtnSelected);
                            sequencePanel_list[totalSequenceCountSelected - 1].Visible = false;
                            sequencePanel_list[totalSequenceCountSelected - 1] = null;
                            selectedCommandBack = null;

                            // Delete the sequence directory
                            if (!Directories.DeleteDirectory(filePath4, true)) { return; }

                            Log.Write(3, "Deleted sequence '" + appOrSequenceOrFunctionBtnSelected.Text + "'");
                            ShowAppPanel(false, false);
                        }
                        break;

                    case "function":

                        // FUNCTION
                        string filePath3 = filePath1 + @"\sequences\" + sequenceBtnSelected.Text + @"\functions\" + appOrSequenceOrFunctionBtnSelected.Text + ".txt";

                        CustomMessageBoxResult result3 = CustomMessageBox.Show("Argo Studio", "Function '\" + appOrSequenceOrFunctionBtnSelected.Text + \"' and all of it's contents will be deleted permanently.", CustomMessageBoxIcon.Exclamation, CustomMessageBoxButtons.OkCancel);

                        if (result3 == CustomMessageBoxResult.Ok)
                        {
                            appPanelSelected.Height -= 25;
                            appPanelFlowPanelSelected.Height -= 25;
                            sequencePanelSelected.Height -= 25;
                            sequenceFlowPanelSelected.Height -= 25;
                            sequenceFlowPanelSelected.Controls.Remove(appOrSequenceOrFunctionBtnSelected);
                            functionPanel_list[functionIndexSelected - 1].Visible = false;
                            functionPanel_list[functionIndexSelected - 1] = null;
                            selectedCommandBack = null;

                            // Delete the function directory
                            if (!Directories.DeleteFile(filePath3)) { return; }

                            Log.Write(3, "Deleted function '" + appOrSequenceOrFunctionBtnSelected.Text + "'");
                            ShowAppPanel(false, false);
                        }
                        break;
                }
            };
            menuBtn.ForeColor = CustomColors.accent_red;
            rightClickFileDelete_btn = menuBtn;
        }
        /// <summary>
        /// If upOrDown is true, move up. If upOrDown is false, move down.
        /// </summary>
        private static void MoveAppSequenceOrFunctionUpOrDown(FlowLayoutPanel flowPanel, Guna2Button selectedBtn, bool upOrDown)
        {
            int num;
            if (upOrDown)
                num = -1;
            else
                num = 1;

            int index = 0;

            // Move the app, sequence, or function up or down
            for (int i = 0; i < flowPanel.Controls.Count; i++)
            {
                if (flowPanel.Controls[i] == selectedBtn)
                {
                    index = i;
                    Guna2Button btn = (Guna2Button)flowPanel.Controls[i];
                    flowPanel.Controls.Remove(btn);
                    List<Guna2Button> sortedControls = flowPanel.Controls.OfType<Guna2Button>().ToList();
                    flowPanel.Controls.Clear();

                    int pass = 0;
                    for (int i2 = 0; i2 <= sortedControls.Count; i2++)
                    {
                        if (i + num == i2)
                        {
                            flowPanel.Controls.Add(btn);
                            pass = 1;
                        }
                        else { flowPanel.Controls.Add(sortedControls[i2 - pass]); }
                    }
                    break;
                }
            }

            // Save in file
            switch (whatIsSelected)
            {
                case "app":
                    string filePath = Directories.buildMachines_commands_temp_dir;
                    SaveMoveUpOrDownForAppOrSequence(filePath, index);
                    break;

                case "sequence":
                    string filePath2 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\";
                    SaveMoveUpOrDownForAppOrSequence(filePath2, index);
                    break;

                case "function":
                    // Get a list of files in order based on .Value
                    string filePath3 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\functions\";

                    IEnumerable<FileMeta> metaList = Directory.EnumerateFiles(filePath3, "*.txt", SearchOption.TopDirectoryOnly)
                        .Select(path =>
                        {
                            string fName = Path.GetFileNameWithoutExtension(path);
                            string line = File.ReadLines(path).FirstOrDefault();
                            int value = Convert.ToInt32(line);

                            return new FileMeta() { name = fName, value = value, path = path };
                        })
                        .OrderBy(x => x.value);

                    WriteToFileForMoveUpOrDownForAppOrSequenceOrFunction(metaList.ToList(), index);
                    break;
            }
        }
        private static void SaveMoveUpOrDownForAppOrSequence(string filePath, int index)
        {
            // Get list of files
            IEnumerable<FileMeta> metaList = Directory.EnumerateDirectories(filePath)
                .Select(path =>
                {
                    string folderName = new DirectoryInfo(path).Name;
                    path += @"\" + folderName + ".txt";
                    string fName = Path.GetFileNameWithoutExtension(path);
                    string line = File.ReadLines(path).FirstOrDefault();
                    int value = Convert.ToInt32(line);

                    return new FileMeta() { name = fName, value = value, path = path };
                })
                .OrderBy(x => x.value);

            WriteToFileForMoveUpOrDownForAppOrSequenceOrFunction(metaList.ToList(), index);
        }
        private static void WriteToFileForMoveUpOrDownForAppOrSequenceOrFunction(List<FileMeta> sortedMetaList, int index)
        {
            int pass = 0;
            for (int i = 0; i < sortedMetaList.Count; i++)
            {
                string[] lines = File.ReadAllLines(sortedMetaList[i].path);

                // This is a weird function. The best way to understand this is to go into debug mode and add "lines" and "sorted" to watch.
                if (i + 1 == index)
                {
                    lines[0] = (i + 2).ToString();
                    pass = 1;
                }
                else { lines[0] = (i + 1 - pass).ToString(); }

                // Write to file
                File.WriteAllLines(sortedMetaList[i].path, lines);
            }
        }
        private static void SetMoveToMenu()
        {
            if (!MachineProgrammer_form.instance.Controls.Contains(rightClickFileMove_panel))
            {
                FlowLayoutPanel moveFlowPanel = (FlowLayoutPanel)rightClickFileMove_panel.Controls[0];

                moveFlowPanel.Controls.Clear();
                switch (whatIsSelected)
                {
                    case "sequence":
                        foreach (Guna2Button btn in MachineProgrammer_form.instance.FileBack_flowPanel.Controls)
                        {
                            Guna2Button appBtn = (Guna2Button)btn.Controls[0];
                            if (appBtn.Text != selectedAppName)
                            {
                                Guna2Button menuBtn = UI.ConstructBtnForMenu(appBtn.Text, 240, false, moveFlowPanel);
                                menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                                menuBtn.Tag = appBtn;
                                menuBtn.Name = "sequence";
                                menuBtn.Click += MoveSequenceOrFunction;
                            }
                        }
                        break;

                    case "function":
                        // Apps
                        foreach (Guna2Button btn in MachineProgrammer_form.instance.FileBack_flowPanel.Controls)
                        {
                            Guna2Button appBtn = (Guna2Button)btn.Controls[0];
                            Guna2Button menuBtn = UI.ConstructBtnForMenu(appBtn.Text, 240, false, moveFlowPanel);
                            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                            // This app button needs to be "disabled". However, setting ".Enabled = false" stops all events, including KeepMenuOpen.
                            // Instead, color the button to make it appear disabled.
                            menuBtn.PressedColor = CustomColors.panelBtn;
                            menuBtn.HoverState.FillColor = CustomColors.panelBtn;
                            menuBtn.HoverState.FillColor = CustomColors.panelBtn;
                            menuBtn.HoverState.BorderColor = CustomColors.panelBtn;
                            menuBtn.ForeColor = CustomColors.grayText;
                            menuBtn.Cursor = Cursors.Default;
                            Guna2Button temp = menuBtn;

                            // Sequences
                            int count = 0;
                            foreach (Guna2Button btn2 in btn.Controls[3].Controls)
                            {
                                Guna2Button sequenceBtn = (Guna2Button)btn2.Controls[0];

                                // Dont add the sequence that the function is in (check the sequence name and the app name)
                                bool pass = true;
                                if (sequenceBtn.Text == sequenceBtnSelected.Text)
                                {
                                    if (sequenceBtn.Parent.Parent.Parent.Controls[0].Text == selectedAppName)
                                        pass = false;
                                }
                                if (pass)
                                {
                                    menuBtn = UI.ConstructBtnForMenu(sequenceBtn.Text, 240, false, moveFlowPanel);
                                    menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                                    menuBtn.TextOffset = new Point(15, 0);
                                    menuBtn.Tag = sequenceBtn;
                                    menuBtn.Name = "function";
                                    menuBtn.Click += MoveSequenceOrFunction;
                                    count++;
                                }
                            }
                            // If there are no sequences in this app to add, delete the app btn
                            if (count == 0)
                                moveFlowPanel.Controls.Remove(temp);
                        }
                        break;
                }

                // rightClickCommandMove_panel
                moveFlowPanel.Height = moveFlowPanel.Controls.Count * 22;
                if (moveFlowPanel.Controls.Count == 1)
                {
                    moveFlowPanel.Height += 10;
                }
                rightClickFileMove_panel.Height = moveFlowPanel.Height + 10;
                rightClickFileMove_panel.Location = new Point(rightClickFile_panel.Left + rightClickFile_panel.Width, rightClickFile_panel.Top + 22 * 4 + 5);

                MachineProgrammer_form.instance.Controls.Add(rightClickFileMove_panel);
                rightClickFileMove_panel.BringToFront();
            }
        }
        private static void ShowRightCickFilePanel(int top, MouseEventArgs e)
        {
            // If it's too far left
            if (e.X - 25 < 0)
            {
                rightClickFile_panel.Left = 0;
            }
            else { rightClickFile_panel.Left = e.X - 25; }

            // If it's too far down
            int difference = MachineProgrammer_form.instance.FileBack_flowPanel.Height - (top + rightClickFile_panel.Height);
            if (difference < 0)
            {
                rightClickFile_panel.Top = top + difference;
                rightClickFile_panel.Left += 40;
            }
            else { rightClickFile_panel.Top = top; }

            MachineProgrammer_form.instance.Controls.Add(rightClickFile_panel);
            rightClickFile_panel.BringToFront();
        }
        private static void AddMoveBtnToPanel_rightClickFile_panel()
        {
            AddBtnToMenu(rightClickFile_panel, rightClickFileMove_btn);
        }
        private static void RemoveMoveBtnFrom_rightClickFile_panel()
        {
            RemoveBtnFromMenu(rightClickFile_panel, rightClickFileMove_btn);
        }
        private static void AddOrRemoveMoveUpAndDownButtonsFor_rightClickFile_panel(int numberOfControls, int index)
        {
            // Is there a file above this one
            if (index != 1 && numberOfControls > 1)
            {
                AddBtnToMenu(rightClickFile_panel, rightClickFileMoveUp_btn);
            }
            else { RemoveBtnFromMenu(rightClickFile_panel, rightClickFileMoveUp_btn); }

            // Is there a file below this one
            if (index != numberOfControls && numberOfControls > 1)
            {
                AddBtnToMenu(rightClickFile_panel, rightClickFileMoveDown_btn);
            }
            else { RemoveBtnFromMenu(rightClickFile_panel, rightClickFileMoveDown_btn); }
        }
        private static void AddBtnToMenu(Guna2Panel menu, Guna2Button btn)
        {
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)menu.Controls[0];
            flowPanel.Controls.Add(btn);
            ResetControlsInRightClickPanel(flowPanel);

            menu.Height = flowPanel.Controls.Count * 22 + 10;
            flowPanel.Height = menu.Height - 10;
        }
        private static void RemoveBtnFromMenu(Guna2Panel menu, Guna2Button btn)
        {
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)menu.Controls[0];
            if (flowPanel.Controls.Contains(btn))
            {
                flowPanel.Controls.Remove(btn);
                ResetControlsInRightClickPanel(flowPanel);

                menu.Height = flowPanel.Controls.Count * 22 + 10;
                flowPanel.Height = menu.Height - 10;
            }
        }

        private static void MoveSequenceOrFunction(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            Guna2Button senderBtn = (Guna2Button)sender;
            Guna2Button appOrSequenceBtnToMoveTo = (Guna2Button)senderBtn.Tag;

            if (senderBtn.Name == "sequence")  // Move sequence to a different app
            {
                bool pass = true;
                string sequenceName = sequenceBtnSelected.Text;
                string oldSelectedAppName = selectedAppName;
                selectedAppName = appOrSequenceBtnToMoveTo.Text;

                // Get a list of names in the new app
                List<string> listOfSequenceNames = GetListOfSequenceNames();

                foreach (string item in listOfSequenceNames)
                {
                    // If a sequence with this name already exists
                    if (sequenceBtnSelected.Text == item)
                    {
                        string suggestedSequenceName = AddNumberForAStringThatAlreadyExists(sequenceBtnSelected.Text, listOfSequenceNames);

                        CustomMessageBoxResult result = CustomMessageBox.Show("Rename sequence", "Do you want to rename '" + sequenceName + "' to '" + suggestedSequenceName + "'? There is already a sequence with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                        if (result == CustomMessageBoxResult.Yes)
                        {
                            sequenceBtnSelected.Text = suggestedSequenceName;
                        }
                        else { pass = false; }
                        break;
                    }
                }

                if (pass)
                {
                    FlowLayoutPanel newAppPanelFlowPanelSelected = (FlowLayoutPanel)appOrSequenceBtnToMoveTo.Parent.Controls[3];
                    Guna2Button newAppPanelSelected = (Guna2Button)appOrSequenceBtnToMoveTo.Parent;

                    newAppPanelFlowPanelSelected.Controls.Add(sequencePanelSelected);

                    // Reduce height of current app, and increase the new app
                    for (int i = 0; i <= sequenceFlowPanelSelected.Controls.Count; i++)
                    {
                        appPanelSelected.Height -= 30;
                        appPanelFlowPanelSelected.Height -= 30;
                        newAppPanelSelected.Height += 30;
                        newAppPanelFlowPanelSelected.Height += 30;
                    }

                    // Save
                    appPanelSelected = newAppPanelSelected;
                    appPanelFlowPanelSelected = newAppPanelFlowPanelSelected;

                    // Move sequence directory in file
                    string oldSequenceDir = Directories.buildMachines_commands_temp_dir + @"\" + oldSelectedAppName + @"\sequences\";
                    string newSequenceDir = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\";
                    Directories.MoveDirectory(oldSequenceDir + sequenceName, newSequenceDir + sequenceBtnSelected.Text);

                    // Rename sequence file
                    Directories.MoveFile(newSequenceDir + sequenceBtnSelected.Text + @"\" + sequenceName + ".txt", newSequenceDir + sequenceBtnSelected.Text + @"\" + sequenceBtnSelected.Text + ".txt");
                }
            }
            else if (senderBtn.Name == "function")  // Move function to a different sequence
            {
                bool pass = true;
                string functionName = functionBtnSelected.Text;
                string oldSelectedAppName = selectedAppName;
                Guna2Button oldSequenceBtnSelected = sequenceBtnSelected;
                selectedAppName = appOrSequenceBtnToMoveTo.Parent.Parent.Parent.Controls[0].Text;
                sequenceBtnSelected = appOrSequenceBtnToMoveTo;

                // Get a list of names in the new sequence
                List<string> listOfFunctionNames = GetListOfFunctionNames();

                foreach (string item in listOfFunctionNames)
                {
                    // If a function with this name already exists
                    if (functionBtnSelected.Text == item)
                    {
                        string tempFuntionName = AddNumberForAStringThatAlreadyExists(functionBtnSelected.Text, listOfFunctionNames);

                        CustomMessageBoxResult result = CustomMessageBox.Show("Rename sequence", "Do you want to rename '" + appOrSequenceBtnToMoveTo.Text + "' to '" + tempFuntionName + "'? There is already a sequence with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                        if (result == CustomMessageBoxResult.Yes)
                        {
                            functionBtnSelected.Text = tempFuntionName;
                        }
                        else { pass = false; }
                        break;
                    }
                }

                if (pass)
                {
                    Guna2Button newAppPanelSelected = (Guna2Button)appOrSequenceBtnToMoveTo.Parent.Parent.Parent;
                    FlowLayoutPanel newAppPanelFlowPanelSelected = (FlowLayoutPanel)appOrSequenceBtnToMoveTo.Parent.Parent;
                    Guna2Button newSequencePanelSelected = (Guna2Button)appOrSequenceBtnToMoveTo.Parent;
                    FlowLayoutPanel newSequenceFlowPanelSelected = (FlowLayoutPanel)appOrSequenceBtnToMoveTo.Parent.Controls[1];

                    newSequenceFlowPanelSelected.Controls.Add(functionBtnSelected);

                    // Reduce height of current app, and increase the new app
                    appPanelSelected.Height -= 30;
                    appPanelFlowPanelSelected.Height -= 30;
                    sequencePanelSelected.Height -= 30;
                    sequenceFlowPanelSelected.Height -= 30;
                    newAppPanelSelected.Height += 30;
                    newAppPanelFlowPanelSelected.Height += 30;
                    newSequencePanelSelected.Height += 30;
                    newSequenceFlowPanelSelected.Height += 30;

                    // Save
                    appPanelSelected = newAppPanelSelected;
                    appPanelFlowPanelSelected = newAppPanelFlowPanelSelected;
                    sequencePanelSelected = newSequencePanelSelected;
                    sequenceFlowPanelSelected = newSequenceFlowPanelSelected;

                    // Move and rename function in file
                    string functionDir = Directories.buildMachines_commands_temp_dir + @"\" + oldSelectedAppName + @"\sequences\" + oldSequenceBtnSelected.Text + @"\functions\" + functionName + ".txt";
                    string newFunctionDir = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + appOrSequenceBtnToMoveTo.Text + @"\functions\" + functionBtnSelected.Text + ".txt";
                    Directories.MoveFile(functionDir, newFunctionDir);

                    // Reset
                    selectedAppName = oldSelectedAppName;
                    sequenceBtnSelected = oldSequenceBtnSelected;
                }
            }
        }


        // Right click file back panel
        public static Guna2Panel rightClickFileBack_panel;
        public static void ConstructRightClickFileBackPanel()
        {
            rightClickFileBack_panel = UI.ConstructPanelForMenu(new Size(200, 2 * 22 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickFileBack_panel.Controls[0];

            Guna2Button menuBtn = UI.ConstructBtnForMenu("Add app", 190, true, flowPanel);
            menuBtn.Click += AddFullApp;

            menuBtn = UI.ConstructBtnForMenu("Import app", 190, true, flowPanel);
            menuBtn.Click += (sender, e) =>
            {

            };
        }


        // Right click command
        public static Guna2Panel rightClickCommand_panel, rightClickCommandMove_panel;
        private static Guna2Button rightClickCommandMove_btn, rightClickCommandDuplicate_btn, rightClickCommandHide_btn, rightClickCommandDelete_btn;
        private static bool isCommandBeingDuplicated, isEventBeingDuplicated;
        public static void ConstructRightClickCommandPanel()
        {
            rightClickCommand_panel = UI.ConstructPanelForMenu(new Size(200, 4 * 22 + 10));
            FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickCommand_panel.Controls[0];

            rightClickCommandMove_panel = UI.ConstructPanelForMenu(new Size(250, 0));

            Guna2Button menuBtn = UI.ConstructBtnForMenu("Move command", 190, false, flowPanel);
            menuBtn.Image = Resources.RightArrowGray;
            menuBtn.ImageSize = new Size(11, 11);
            menuBtn.ImageOffset = new Point(80, 0);
            menuBtn.Click += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                SetMoveCommandMenu();
                btn.Tag = rightClickCommandMove_panel;
                MainMenu_form.instance.OpenMenu();
            };
            menuBtn.MouseEnter += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                SetMoveCommandMenu();
                btn.Tag = rightClickCommandMove_panel;
            };
            menuBtn.MouseLeave += MainMenu_form.instance.CloseMenu;
            rightClickCommandMove_btn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Duplicate command", 190, false, flowPanel);
            menuBtn.Click += DuplicateCommand; ;
            rightClickCommandDuplicate_btn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Hide command", 190, false, flowPanel);
            menuBtn.Click += (sender2, e2) =>
            {
                List<Guna2Button> selectedCommandsList = GetListOfSelectedCommands();

                foreach (Guna2Button command in selectedCommandsList)
                {
                    Guna2Button hideBtn = (Guna2Button)command.Controls.Find("hideBtn", false).FirstOrDefault();

                    if (command.FillColor != Color.LightGray)
                    {
                        hideBtn.Image = Resources.EyeClosed;
                        SetCommandBackgroundToHidden(command);
                        command.BorderColor = Color.Gray;
                    }
                    else
                    {
                        hideBtn.Image = Resources.EyeOpen;
                        SetCommandBackgroundToControlBack(command);
                        command.BorderColor = Color.Gray;
                    }
                }
                if (selectedCommandsList.Count == 0)
                {
                    Guna2Button hideBtn = (Guna2Button)commandClicked.Controls.Find("hideBtn", false).FirstOrDefault();

                    if (hideBtn.FillColor != Color.LightGray)
                    {
                        hideBtn.Image = Resources.EyeClosed;
                        SetCommandBackgroundToHidden(commandClicked);
                    }
                    else
                    {
                        hideBtn.Image = Resources.EyeOpen;
                        SetCommandBackgroundToControlBack(commandClicked);
                    }
                }
                UI.CloseAllPanels();  // This needs to be done after
            };
            rightClickCommandHide_btn = menuBtn;

            menuBtn = UI.ConstructBtnForMenu("Delete command", 190, false, flowPanel);
            menuBtn.Click += (sender2, e2) =>
            {
                List<Guna2Button> selectedCommandsList = GetListOfSelectedCommands();
                foreach (Guna2Button item in selectedCommandsList)
                {
                    PictureBox deleteBtn = (PictureBox)item.Controls.Find("deleteBtn", false).FirstOrDefault();
                    DeleteCommand(deleteBtn, null);
                }
                if (selectedCommandsList.Count == 0)
                {
                    PictureBox deleteBtn = (PictureBox)commandClicked.Controls.Find("deleteBtn", false).FirstOrDefault();
                    DeleteCommand(deleteBtn, null);
                }
                UI.CloseAllPanels();  // This needs to be done after
            };
            rightClickCommandDelete_btn = menuBtn;
        }
        private static void SetMoveCommandMenu()
        {
            FlowLayoutPanel moveFlowPanel = (FlowLayoutPanel)rightClickCommandMove_panel.Controls[0];

            moveFlowPanel.Controls.Clear();

            // Apps
            foreach (Guna2Button btn in MachineProgrammer_form.instance.FileBack_flowPanel.Controls)
            {
                Guna2Button appBtn = (Guna2Button)btn.Controls[0];

                Guna2Button menuBtn = UI.ConstructBtnForMenu(appBtn.Text, 240, false, moveFlowPanel);
                menuBtn.Tag = appBtn;
                menuBtn.Name = "app";
                menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                menuBtn.Click += MoveCommand;
                if (appBtn == appOrSequenceOrFunctionBtnSelected)
                {
                    menuBtn.Enabled = false;
                    menuBtn.DisabledState.FillColor = CustomColors.controlBack;
                }

                // Events
                Guna2Panel eventBack = eventPanel_list[Convert.ToInt32(btn.Controls[2].Name) - 1];

                foreach (Guna2Button eventCommand in eventBack.Controls)
                {
                    if (eventCommandSelected != eventCommand || whatIsSelected != "programEvent")
                    {
                        Guna2Button modifyBtn = (Guna2Button)eventCommand.Controls.Find("modifyBtn", false).FirstOrDefault();
                        Guna2TextBox nameTextBox = (Guna2TextBox)eventCommand.Controls.Find("name", false).FirstOrDefault();

                        menuBtn = UI.ConstructBtnForMenu(nameTextBox.Text, 240, false, moveFlowPanel);
                        menuBtn.TextOffset = new Point(15, 0);
                        menuBtn.Tag = modifyBtn;
                        menuBtn.Name = "event";
                        menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                        menuBtn.Click += MoveCommand;
                    }
                }

                // Sequences
                foreach (Guna2Button sequenceBack in btn.Controls[3].Controls)
                {
                    Guna2Button sequenceBtn = (Guna2Button)sequenceBack.Controls[0];

                    menuBtn = UI.ConstructBtnForMenu(sequenceBtn.Text, 240, false, moveFlowPanel);
                    menuBtn.TextOffset = new Point(15, 0);
                    menuBtn.Tag = sequenceBtn;
                    menuBtn.Name = "sequence";
                    menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                    menuBtn.Click += MoveCommand;
                    if (sequenceBtn == appOrSequenceOrFunctionBtnSelected)
                    {
                        menuBtn.Enabled = false;
                        menuBtn.DisabledState.FillColor = CustomColors.controlBack;
                    }

                    // Functions
                    foreach (Guna2Button functionbtn in sequenceBtn.Parent.Controls[1].Controls)
                    {
                        if (functionbtn != appOrSequenceOrFunctionBtnSelected)
                        {
                            menuBtn = UI.ConstructBtnForMenu(functionbtn.Text, 240, false, moveFlowPanel);
                            menuBtn.TextOffset = new Point(30, 0);
                            menuBtn.Tag = functionbtn;
                            menuBtn.Name = "function";
                            menuBtn.MouseEnter += MainMenu_form.instance.KeepMenuOpen;
                            menuBtn.Click += MoveCommand;
                        }
                    }
                }
            }

            // rightClickCommandMove_panel
            rightClickCommandMove_panel.Height = moveFlowPanel.Controls.Count * 22 + 10;
            moveFlowPanel.Height = rightClickCommandMove_panel.Height - 10;

            // If it's too far right
            if (rightClickCommand_panel.Left + rightClickCommand_panel.Width + rightClickCommandMove_panel.Width > selectedCommandBack.Width)
            {
                rightClickCommandMove_panel.Left = rightClickCommand_panel.Left - rightClickCommandMove_panel.Width;
            }
            else { rightClickCommandMove_panel.Left = rightClickCommand_panel.Left + rightClickCommand_panel.Width; }

            // If it's too far down
            if (rightClickCommand_panel.Top + rightClickCommandMove_panel.Height + 2 < selectedCommandBack.Height)
            {
                rightClickCommandMove_panel.Top = rightClickCommand_panel.Top + rightClickCommand_panel.Height - 22 - 5;
            }
            else { rightClickCommandMove_panel.Top = selectedCommandBack.Height - rightClickCommand_panel.Height; }

            selectedCommandBack.Controls.Add(rightClickCommandMove_panel);
            rightClickCommandMove_panel.BringToFront();
        }
        private static void DuplicateCommand(object sender, EventArgs e)
        {
            string filePath = GetFilePath();

            if (File.Exists(filePath))
            {
                string[] allLinesInFile = File.ReadAllLines(filePath);

                int value = 0;
                if (whatIsSelected == "event" || whatIsSelected == "variable")
                    value = 1;

                string[] line = allLinesInFile[Convert.ToInt32(commandClicked.Name) - value].Split(',');
                List<string> loadCommandData;

                isCommandBeingDuplicated = true;

                switch (line[0])
                {
                    case "move":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[9], line[10], line[11], line[12], line[13], line[14], line[15], line[16] });
                        ConstructMotionCommand(null, loadCommandData);
                        break;

                    case "delay":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4] });
                        ConstructDelayCommand(null, loadCommandData);
                        break;

                    case "run":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4], line[5], line[6], line[7] });
                        ConstructRunCommand(null, loadCommandData);
                        break;

                    case "setVariable":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4] });
                        ConstructSetVariableCommand(null, loadCommandData);
                        break;

                    case "loop":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[9], line[10], line[11], line[12], line[13], line[14], line[15], line[16] });
                        ConstructLoopCommand(null, loadCommandData);
                        break;

                    case "setOutput":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3] });
                        ConstructSetOutputCommand(null, loadCommandData);
                        break;

                    case "home":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4], line[5], line[6], line[7] });
                        ConstructHomeCommand(null, loadCommandData);
                        break;

                    case "event":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3], line[4], line[5] });
                        whatIsSelected = "programEvent";
                        string originalEventFilePath = GetFilePath();

                        ConstructAddEventCommand(null, loadCommandData);
                        ConstructProgramEventPanel((int)commandClicked.Tag + 1, eventNameSelected);

                        if (File.Exists(originalEventFilePath))
                        {
                            Guna2Panel tempSelectedCommandBack = selectedCommandBack;

                            // Copy commands in file
                            whatIsSelected = "programEvent";
                            string newEventFilePath = GetFilePath();
                            File.Copy(originalEventFilePath, newEventFilePath);

                            // Construct new commands
                            selectedCommandBack = programEventPanel_list[(int)commandClicked.Tag];
                            isEventBeingDuplicated = true;
                            ConstructCommands(null, newEventFilePath);
                            isEventBeingDuplicated = false;

                            // Reset
                            selectedCommandBack = tempSelectedCommandBack;
                            whatIsSelected = "event";
                        }

                        break;

                    case "addVariable":
                        loadCommandData = new List<string>(new string[] { line[1], line[2], line[3] });
                        ConstructAddVariableCommand(null, loadCommandData);
                        break;
                }
                isCommandBeingDuplicated = false;
            }
            else
            {
                Log.Error_FileDoesNotExist(filePath);
                return;
            }

            UI.CloseAllPanels();
        }
        private static void MoveCommand(object sender, EventArgs e)
        {
            // NOTE: The order of things is very important

            Guna2Button senderBtn = (Guna2Button)sender;
            Guna2Button fileBtnToMoveTo = (Guna2Button)senderBtn.Tag;

            List<Guna2Button> selectedCommandsList = GetListOfSelectedCommands();
            if (commandClicked.FillColor != CustomColors.fileSelected)
            {
                selectedCommandsList.Add(commandClicked);
            }

            // Sort commands based on .Name
            Control[] sortedListOfCommands = selectedCommandsList
                .Cast<Control>()
                .OrderBy(x => Convert.ToInt32(x.Name))
                .ToArray();

            Guna2Panel tempSelectedCommandBack = null;
            // These are needed for GetFilePath()
            string tempSelectedAppName = selectedAppName;
            string tempWhatIsSelected = whatIsSelected;
            Guna2Button tempAppOrSequenceOrFunctionBtnSelected = appOrSequenceOrFunctionBtnSelected;


            // Get things
            switch (senderBtn.Name)
            {
                case "app":
                    selectedAppTag = Convert.ToInt32(fileBtnToMoveTo.Parent.Name);
                    tempSelectedCommandBack = appPanel_list[selectedAppTag - 1];
                    whatIsSelected = "app";
                    selectedAppName = fileBtnToMoveTo.Text;
                    break;

                case "event":
                    int index = (int)fileBtnToMoveTo.Parent.Tag;

                    eventNameSelected = senderBtn.Text;
                    if (programEventBackPanel_list[index - 1] == null)
                    {
                        ConstructProgramEventPanel(index, eventNameSelected);
                    }
                    tempSelectedCommandBack = programEventPanel_list[index - 1];
                    whatIsSelected = "programEvent";
                    selectedAppName = fileBtnToMoveTo.Tag.ToString();
                    break;

                case "sequence":
                    totalSequenceCountSelected = Convert.ToInt32(fileBtnToMoveTo.Parent.Name);
                    tempSelectedCommandBack = sequencePanel_list[totalSequenceCountSelected - 1];
                    whatIsSelected = "sequence";
                    selectedAppName = fileBtnToMoveTo.Parent.Parent.Parent.Controls[0].Text;
                    break;

                case "function":
                    functionIndexSelected = Convert.ToInt32(fileBtnToMoveTo.Name);
                    tempSelectedCommandBack = functionPanel_list[functionIndexSelected - 1];
                    whatIsSelected = "function";
                    selectedAppName = fileBtnToMoveTo.Parent.Parent.Parent.Parent.Controls[0].Text;
                    break;
            }


            // Do things for selectedCommandBack (the current panel)
            for (int i = Convert.ToInt32(sortedListOfCommands[0].Name) + 1; i <= selectedCommandBack.Controls.Count; i++)
            {
                Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find(i.ToString(), false).FirstOrDefault();

                if (findCommand != null)
                {
                    if (findCommand.FillColor != CustomColors.fileSelected)
                    {
                        // Get numberOfSelectedCommandsAbove
                        int numberOfSelectedCommandsAbove = 0;
                        for (int i2 = 1; i2 < i; i2++)
                        {
                            Guna2Button command = (Guna2Button)selectedCommandBack.Controls.Find(i2.ToString(), false).FirstOrDefault();
                            if (command != null)
                            {
                                if (command.FillColor == CustomColors.fileSelected)
                                {
                                    numberOfSelectedCommandsAbove++;
                                }
                            }
                        }
                        if (numberOfSelectedCommandsAbove == 0) { numberOfSelectedCommandsAbove = 1; }

                        // Reset number label of moved command
                        findCommand.Controls.Find("numberLabel", false).FirstOrDefault().Text = (i - numberOfSelectedCommandsAbove).ToString();

                        // Update name of moved command
                        findCommand.Name = (i - numberOfSelectedCommandsAbove).ToString();
                    }
                }
            }


            foreach (Guna2Button command in sortedListOfCommands.Cast<Guna2Button>())
            {
                // Remove the selected commands from selectedCommandBack (the current panel)
                selectedCommandBack.Controls.Remove(command);

                // Save moved commands in file for tempSelectedCommandBack (the new panel)
                switch (command.Controls.Find("numberLabel", false).FirstOrDefault().Tag.ToString())
                {
                    case "moveCommand":
                        SaveMoveCommandInFile(command, true);
                        break;

                    case "homeCommand":
                        SaveHomeCommandInFile(command, true);
                        break;

                    case "delayCommand":
                        SaveDelayCommandInFile(command, true);
                        break;

                    case "runCommand":
                        SaveRunCommandInFile(command, true);
                        break;

                    case "setVariableCommand":
                        SaveSetVariableCommandInFile(command, true);
                        break;

                    case "loopCommand":
                        SaveLoopCommandInFile(command, true);
                        break;

                    case "setOutputCommand":
                        SaveSetOutputCommandInFile(command, true);
                        break;

                        //case "eventCommand":
                        //    SaveEventCommandInFile(command, true);
                        //    break;
                }
            }

            appOrSequenceOrFunctionBtnSelected = fileBtnToMoveTo;

            // Do things for selectedCommandBack (the current panel)
            int totalCommandHeight = 0;
            for (int i = 1; i <= selectedCommandBack.Controls.Count + sortedListOfCommands.Length; i++)
            {
                Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find(i.ToString(), false).FirstOrDefault();
                if (findCommand != null)
                {
                    // Set command.Top
                    findCommand.Top = totalCommandHeight + 6;
                    totalCommandHeight = findCommand.Top + findCommand.Height;
                }
            }


            // Reset
            whatIsSelected = tempWhatIsSelected;
            appOrSequenceOrFunctionBtnSelected = tempAppOrSequenceOrFunctionBtnSelected;
            selectedAppName = tempSelectedAppName;

            // Remove moved commands in file for tempSelectedCommandBack (the current panel)
            string filePath1 = GetFilePath();
            if (File.Exists(filePath1))
            {
                string[] lines = File.ReadAllLines(filePath1);
                foreach (Guna2Button item in sortedListOfCommands.Cast<Guna2Button>())
                {
                    lines[Convert.ToInt32(item.Name)] = null;
                }

                File.WriteAllText(filePath1, RemoveAllEmptyLines(lines));
            }
            else
            {
                Log.Error_FileDoesNotExist(filePath1);
                return;
            }


            // Do things for tempSelectedCommandBack (the new panel)
            foreach (Guna2Button command in sortedListOfCommands.Cast<Guna2Button>())
            {
                // Reset .Top
                if (tempSelectedCommandBack.Controls.Count > 0)
                {
                    Guna2Button lastCommand = (Guna2Button)tempSelectedCommandBack.Controls[tempSelectedCommandBack.Controls.Count - 1];
                    command.Top = lastCommand.Top + lastCommand.Height + 6;
                }
                else { command.Top = 6; }

                // Reset number label
                command.Controls.Find("numberLabel", false).FirstOrDefault().Text = (tempSelectedCommandBack.Controls.Count + 1).ToString();

                // Update name
                command.Name = (tempSelectedCommandBack.Controls.Count + 1).ToString();

                // Add control
                tempSelectedCommandBack.Controls.Add(command);
            }


            // Unselect all commands in tempSelectedCommandBack (the new panel)
            foreach (Guna2Button item in from Guna2Button item in tempSelectedCommandBack.Controls
                                         where item.FillColor != Color.LightGray
                                         select item)
            {
                SetCommandBackgroundToControlBack(item);
                item.BorderColor = Color.Gray;
            }

            UI.CloseAllPanels();
        }


        // Save commands
        private static string SaveMoveCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f2 = (Guna2ComboBox)sender.Controls.Find("2", false).FirstOrDefault();
            Guna2TextBox f3 = (Guna2TextBox)sender.Controls.Find("3", false).FirstOrDefault();
            Guna2ComboBox f4 = (Guna2ComboBox)sender.Controls.Find("4", false).FirstOrDefault();
            Control fAddBtn = sender.Controls.Find("addBtn", false).FirstOrDefault();

            Guna2TextBox f11 = (Guna2TextBox)sender.Controls.Find("11", false).FirstOrDefault();
            Guna2TextBox f22 = (Guna2TextBox)sender.Controls.Find("22", false).FirstOrDefault();
            Guna2TextBox f26 = (Guna2TextBox)sender.Controls.Find("26", false).FirstOrDefault();
            Guna2TextBox f30 = (Guna2TextBox)sender.Controls.Find("30", false).FirstOrDefault();

            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("1", false).FirstOrDefault();
            Guna2ComboBox f20 = (Guna2ComboBox)sender.Controls.Find("20", false).FirstOrDefault();
            Guna2ComboBox f24 = (Guna2ComboBox)sender.Controls.Find("24", false).FirstOrDefault();
            Guna2ComboBox f28 = (Guna2ComboBox)sender.Controls.Find("28", false).FirstOrDefault();

            Guna2ComboBox f14 = (Guna2ComboBox)sender.Controls.Find("14", false).FirstOrDefault();
            Guna2TextBox f16 = (Guna2TextBox)sender.Controls.Find("16", false).FirstOrDefault();
            Guna2TextBox f18 = (Guna2TextBox)sender.Controls.Find("18", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "move";

            // Get command data
            if (f2 != null) { lines += "," + f2.Text; } else { lines += ","; }
            if (f3 != null) { lines += "," + f3.Text; } else { lines += ","; }
            if (f4 != null) { lines += "," + f4.Text; } else { lines += ","; }
            if (fAddBtn != null) { lines += "," + fAddBtn.Tag; } else { lines += ","; }

            if (f11 != null) { lines += "," + f11.Text; } else { lines += ","; }
            if (f22 != null) { lines += "," + f22.Text; } else { lines += ","; }
            if (f26 != null) { lines += "," + f26.Text; } else { lines += ","; }
            if (f30 != null) { lines += "," + f30.Text; } else { lines += ","; }

            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f20 != null) { lines += "," + f20.Text; } else { lines += ","; }
            if (f24 != null) { lines += "," + f24.Text; } else { lines += ","; }
            if (f28 != null) { lines += "," + f28.Text; } else { lines += ","; }

            if (f14 != null) { lines += "," + f14.Text; } else { lines += ","; }
            if (f16 != null) { lines += "," + f16.Text; } else { lines += ","; }
            if (f18 != null) { lines += "," + f18.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveDelayCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("1", false).FirstOrDefault();
            Guna2ComboBox f3 = (Guna2ComboBox)sender.Controls.Find("3", false).FirstOrDefault();
            Guna2TextBox f6 = (Guna2TextBox)sender.Controls.Find("6", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "delay";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f3 != null) { lines += "," + f3.Text; } else { lines += ","; }
            if (f6 != null) { lines += "," + f6.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveRunCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("1", false).FirstOrDefault();
            Guna2ComboBox f3 = (Guna2ComboBox)sender.Controls.Find("3", false).FirstOrDefault();
            Guna2ComboBox f5 = (Guna2ComboBox)sender.Controls.Find("5", false).FirstOrDefault();
            Guna2ComboBox f7 = (Guna2ComboBox)sender.Controls.Find("7", false).FirstOrDefault();
            Guna2ComboBox f9 = (Guna2ComboBox)sender.Controls.Find("9", false).FirstOrDefault();
            Guna2ComboBox f11 = (Guna2ComboBox)sender.Controls.Find("11", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "run";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f3 != null) { lines += "," + f3.Text; } else { lines += ","; }
            if (f5 != null) { lines += "," + f5.Text; } else { lines += ","; }
            if (f7 != null) { lines += "," + f7.Text; } else { lines += ","; }
            if (f9 != null) { lines += "," + f9.Text; } else { lines += ","; }
            if (f11 != null) { lines += "," + f11.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveSetVariableCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("1", false).FirstOrDefault();
            Guna2ComboBox f2 = (Guna2ComboBox)sender.Controls.Find("2", false).FirstOrDefault();
            Guna2TextBox f4 = (Guna2TextBox)sender.Controls.Find("4", false).FirstOrDefault();
            Guna2TextBox f6 = (Guna2TextBox)sender.Controls.Find("6", false).FirstOrDefault();
            Guna2TextBox f8 = (Guna2TextBox)sender.Controls.Find("8", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "setVariable";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f2 != null) { lines += "," + f2.Text; } else { lines += ","; }
            if (f4 != null) { lines += "," + f4.Text; }
            else if (f6 != null) { lines += "," + f6.Text; }
            else if (f8 != null) { lines += "," + f8.Text; }
            else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveLoopCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("loopComboBox", false).FirstOrDefault();
            Guna2ComboBox f2 = (Guna2ComboBox)sender.Controls.Find("2", false).FirstOrDefault();
            Guna2ComboBox f4 = (Guna2ComboBox)sender.Controls.Find("4", false).FirstOrDefault();
            Guna2TextBox f6 = (Guna2TextBox)sender.Controls.Find("6", false).FirstOrDefault();
            Guna2ComboBox f7 = (Guna2ComboBox)sender.Controls.Find("7", false).FirstOrDefault();
            Control fAddBtn = sender.Controls.Find("addBtn", false).FirstOrDefault();

            Guna2TextBox f11 = (Guna2TextBox)sender.Controls.Find("11", false).FirstOrDefault();
            Guna2TextBox f22 = (Guna2TextBox)sender.Controls.Find("22", false).FirstOrDefault();
            Guna2TextBox f26 = (Guna2TextBox)sender.Controls.Find("26", false).FirstOrDefault();
            Guna2TextBox f30 = (Guna2TextBox)sender.Controls.Find("30", false).FirstOrDefault();

            Guna2ComboBox f9 = (Guna2ComboBox)sender.Controls.Find("9", false).FirstOrDefault();
            Guna2ComboBox f20 = (Guna2ComboBox)sender.Controls.Find("20", false).FirstOrDefault();
            Guna2ComboBox f24 = (Guna2ComboBox)sender.Controls.Find("24", false).FirstOrDefault();
            Guna2ComboBox f28 = (Guna2ComboBox)sender.Controls.Find("28", false).FirstOrDefault();

            Guna2ComboBox f14 = (Guna2ComboBox)sender.Controls.Find("14", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "loop";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f2 != null) { lines += "," + f2.Text; } else { lines += ","; }
            if (f4 != null) { lines += "," + f4.Text; } else { lines += ","; }
            if (f6 != null) { lines += "," + f6.Text; } else { lines += ","; }
            if (f7 != null) { lines += "," + f7.Text; } else { lines += ","; }
            if (fAddBtn != null) { lines += "," + fAddBtn.Tag; } else { lines += ","; }
            if (f11 != null) { lines += "," + f11.Text; } else { lines += ","; }
            if (f22 != null) { lines += "," + f22.Text; } else { lines += ","; }
            if (f26 != null) { lines += "," + f26.Text; } else { lines += ","; }
            if (f30 != null) { lines += "," + f30.Text; } else { lines += ","; }

            if (f9 != null) { lines += "," + f9.Text; } else { lines += ","; }
            if (f20 != null) { lines += "," + f20.Text; } else { lines += ","; }
            if (f24 != null) { lines += "," + f24.Text; } else { lines += ","; }
            if (f28 != null) { lines += "," + f28.Text; } else { lines += ","; }

            if (f14 != null) { lines += "," + f14.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveSetOutputCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("1", false).FirstOrDefault();
            Guna2ComboBox f2 = (Guna2ComboBox)sender.Controls.Find("2", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "setOutput";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f2 != null) { lines += "," + f2.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveHomeCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2ComboBox f1 = (Guna2ComboBox)sender.Controls.Find("1", false).FirstOrDefault();
            Control fAddBtn = sender.Controls.Find("addBtn", false).FirstOrDefault();
            Guna2ComboBox f3 = (Guna2ComboBox)sender.Controls.Find("3", false).FirstOrDefault();
            Guna2ComboBox f20 = (Guna2ComboBox)sender.Controls.Find("20", false).FirstOrDefault();
            Guna2ComboBox f22 = (Guna2ComboBox)sender.Controls.Find("22", false).FirstOrDefault();
            Guna2ComboBox f24 = (Guna2ComboBox)sender.Controls.Find("24", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "home";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (fAddBtn != null) { lines += "," + fAddBtn.Tag; } else { lines += ","; }
            if (f3 != null) { lines += "," + f3.Text; } else { lines += ","; }
            if (f20 != null) { lines += "," + f20.Text; } else { lines += ","; }
            if (f22 != null) { lines += "," + f22.Text; } else { lines += ","; }
            if (f24 != null) { lines += "," + f24.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveEventCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2TextBox findName = (Guna2TextBox)sender.Controls.Find("name", false).FirstOrDefault();
            Guna2TextBox findDescription = (Guna2TextBox)sender.Controls.Find("description", false).FirstOrDefault();
            Control findComboBox = sender.Controls.Find("event", false).FirstOrDefault();
            Label findCommandCount = (Label)sender.Controls.Find("commandCount", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "event";
            // Get command data
            if (findName != null) { lines += "," + findName.Text; } else { lines += ","; }
            if (findDescription != null) { lines += "," + findDescription.Text; } else { lines += ","; }
            if (findComboBox != null) { lines += "," + findComboBox.Text; } else { lines += ","; }
            if (findCommandCount != null) { lines += "," + findCommandCount.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }
        private static string SaveAddVariableCommand(Control sender)
        {
            // Save
            commandClickedName = Convert.ToInt32(sender.Name);
            // Find controls
            Guna2TextBox f1 = (Guna2TextBox)sender.Controls.Find("1", false).FirstOrDefault();
            Guna2TextBox f2 = (Guna2TextBox)sender.Controls.Find("2", false).FirstOrDefault();
            Guna2Button fHideBtn = (Guna2Button)sender.Controls.Find("hideBtn", false).FirstOrDefault();

            // Prefix
            string lines = "addVariable";
            // Get command data
            if (f1 != null) { lines += "," + f1.Text; } else { lines += ","; }
            if (f2 != null) { lines += "," + f2.Text; } else { lines += ","; }
            if (fHideBtn.FillColor == CustomColors.commandHidden) { lines += ",1"; } else { lines += ",0"; }

            return lines;
        }


        // Save commands in file
        private static void SaveMoveCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveMoveCommand(sender), false);
        }
        private static void SaveDelayCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveDelayCommand(sender), false);
        }
        private static void SaveRunCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveRunCommand(sender), false);
        }
        private static void SaveSetVariableCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveSetVariableCommand(sender), false);
        }
        private static void SaveLoopCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveLoopCommand(sender), false);
        }
        private static void SaveSetOutputCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveSetOutputCommand(sender), false);
        }
        private static void SaveHomeCommandInFile(Control sender, bool addCommand)
        {
            SaveCommandInFile(GetFilePath(), addCommand, SaveHomeCommand(sender), false);
        }
        private static void SaveEventCommandInFile(Control sender, bool addCommand)
        {
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events.txt";
            SaveCommandInFile(filePath, addCommand, SaveEventCommand(sender), true);
        }
        private static void SaveAddVariableCommandInFile(Control sender, bool addCommand)
        {
            string filePath = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\variables.txt";
            SaveCommandInFile(filePath, addCommand, SaveAddVariableCommand(sender), true);
        }

        private static void SaveCommandInFile(string filePath, bool addCommand, string temp, bool isEventOrVariable)
        {
            if (File.Exists(filePath))
            {
                int value = 0;
                if (isEventOrVariable || whatIsSelected == "programEvent")
                    value = 1;

                // Read data in file
                string[] lines = File.ReadAllLines(filePath);

                if (addCommand)
                {
                    File.AppendAllText(filePath, temp + "\r\n");
                }
                else
                {
                    // Save
                    lines[commandClickedName - value] = temp;

                    // Write data in file
                    File.WriteAllLines(filePath, lines);
                }
            }
            else { Log.Error_FileDoesNotExist(filePath); }
        }


        // File logic
        /// <summary>
        /// Can be "app" "sequence" "funciton" "event" "programEvent" or "variable"
        /// </summary>
        public static string whatIsSelected;
        private static bool isRightClickPanelOpen;
        private static void FilebtnMouseEnter(object sender, EventArgs e)
        {
            Guna2Button fileBtn = (Guna2Button)sender;

            // If right click panel is not open and label is not clicked
            if (!isRightClickPanelOpen)
            {
                if (fileBtn.FillColor != CustomColors.fileSelected)
                {
                    fileBtn.FillColor = CustomColors.fileHover;
                    fileBtn.HoverState.FillColor = CustomColors.fileHover;

                    // Set drop down arrow
                    if (fileBtn.Parent.Tag != null)
                    {
                        if (fileBtn.Parent.Tag.ToString() == "sequence" || fileBtn.Parent.Tag.ToString() == "app" && fileBtn.Text != "Variables" && fileBtn.Text != "Events")
                        {
                            Guna2Button fArrow = (Guna2Button)fileBtn.Controls.Find("arrow", false).FirstOrDefault();
                            fArrow.FillColor = CustomColors.fileHover;
                            fArrow.HoverState.FillColor = CustomColors.fileHover;
                        }
                    }
                }
                else if (Theme.theme == "Light")
                {
                    fileBtn.BorderThickness = 1;
                }
            }
        }
        private static void FileBtnMouseLeave(object sender, EventArgs e)
        {
            // Unselect all file btns
            foreach (Guna2Button fileBtn in appBtnList.Concat(sequenceBtnList).Concat(functionBtnList).Concat(variableBtnList).Concat(eventBtnList))
            {
                if (fileBtn.FillColor != CustomColors.fileSelected)
                {
                    fileBtn.FillColor = CustomColors.mainBackground;

                    // Set drop down arrow
                    if (fileBtn.Parent != null)
                    {
                        if (fileBtn.Parent.Tag != null)
                        {
                            if (fileBtn.Parent.Tag.ToString() == "sequence" || fileBtn.Parent.Tag.ToString() == "app" && fileBtn.Text != "Variables" && fileBtn.Text != "Events")
                            {
                                Guna2Button fArrow = (Guna2Button)fileBtn.Controls.Find("arrow", false).FirstOrDefault();
                                fArrow.FillColor = CustomColors.mainBackground;
                            }
                        }
                    }
                }
                fileBtn.BorderThickness = 0;
            }
        }
        private static void FileBtnMouseDown(object sender)
        {
            UI.CloseAllPanels();
            ResetFilePanelClickedLabels();
            Guna2Button fileBtn = (Guna2Button)sender;

            SetBorderThicknessIfThemeIsLight(fileBtn);
            fileBtn.FillColor = CustomColors.fileSelected;
            fileBtn.HoverState.FillColor = CustomColors.fileSelected;
        }
        private static void FileButtonWithArrow_MouseDown(object sender)
        {
            UI.CloseAllPanels();
            ResetFilePanelClickedLabels();
            Guna2Button btn = (Guna2Button)sender;
            Guna2Button fArrow = (Guna2Button)btn.Controls.Find("arrow", false).FirstOrDefault();

            SetBorderThicknessIfThemeIsLight(btn);

            btn.FillColor = CustomColors.fileSelected;
            btn.HoverState.FillColor = CustomColors.fileSelected;
            btn.PressedColor = CustomColors.fileSelected;

            fArrow.FillColor = CustomColors.fileSelected;
            fArrow.HoverState.FillColor = CustomColors.fileSelected;
            fArrow.PressedColor = CustomColors.fileSelected;
        }
        private static void ResetFilePanelClickedLabels()
        {
            foreach (Guna2Button item in appBtnList)
            {
                Guna2Button fArrow = (Guna2Button)item.Controls.Find("arrow", false).FirstOrDefault();
                item.FillColor = CustomColors.mainBackground;
                item.DisabledState.FillColor = CustomColors.mainBackground;
                item.BorderThickness = 0;
                fArrow.FillColor = CustomColors.mainBackground;
                fArrow.DisabledState.FillColor = CustomColors.mainBackground;
            }
            foreach (Guna2Button item in sequenceBtnList)
            {
                Guna2Button fArrow = (Guna2Button)item.Controls.Find("arrow", false).FirstOrDefault();
                item.FillColor = CustomColors.mainBackground;
                item.DisabledState.FillColor = CustomColors.mainBackground;
                item.BorderThickness = 0;
                fArrow.FillColor = CustomColors.mainBackground;
                fArrow.DisabledState.FillColor = CustomColors.mainBackground;
            }
            foreach (Guna2Button item in functionBtnList)
            {
                item.FillColor = CustomColors.mainBackground;
                item.DisabledState.FillColor = CustomColors.mainBackground;
                item.BorderThickness = 0;
            }
            if (selectedVariableBtn != null)
            {
                selectedVariableBtn.FillColor = CustomColors.mainBackground;
                selectedVariableBtn.BorderThickness = 0;
            }
            if (selectedEventBtn != null)
            {
                selectedEventBtn.FillColor = CustomColors.mainBackground;
                selectedEventBtn.BorderThickness = 0;
            }
        }
        private static void ShowMainCommandButtons()
        {
            MachineProgrammer_form.instance.AddCommand_btn.Text = "Add Command";
        }
        private static void ShowCommandBackSelected()
        {
            selectedCommandBack.Visible = true;
            selectedCommandBack.BringToFront();
        }
        private static Guna2Button ConstructDropDownArrowForFile(Control control)
        {
            // Drop down arrow
            Guna2Button gBtn = new Guna2Button
            {
                Image = Resources.DownArrowGray,
                Size = new Size(23, 23),
                Top = 1,
                Left = 1,
                ImageSize = new Size(10, 10),
                ImageAlign = HorizontalAlignment.Center,
                Name = "arrow",
                Tag = "down",
                FillColor = CustomColors.mainBackground,
                PressedColor = CustomColors.fileSelected
            };
            gBtn.DisabledState.FillColor = CustomColors.fileSelected;
            gBtn.HoverState.FillColor = CustomColors.fileHover;
            gBtn.MouseEnter += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                Guna2Button btnParent = (Guna2Button)btn.Parent;

                if (btnParent.FillColor != CustomColors.fileSelected)
                {
                    btnParent.FillColor = CustomColors.fileHover;
                }
                if (btn.Tag.ToString() == "right")
                {
                    btn.Image = Resources.RightArrowBlack;
                }
                else { btn.Image = Resources.DownArrowBlack; }
            };
            gBtn.MouseLeave += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                Guna2Button btnParent = (Guna2Button)btn.Parent;

                if (btnParent.FillColor != CustomColors.fileSelected)
                {
                    btnParent.FillColor = CustomColors.mainBackground;
                }
                if (btn.Tag.ToString() == "right")
                {
                    btn.Image = Resources.RightArrowGray;
                }
                else { btn.Image = Resources.DownArrowGray; }
            };
            control.Controls.Add(gBtn);
            return gBtn;
        }
        private static void SetBorderThicknessIfThemeIsLight(Guna2Button btn)
        {
            if (Theme.theme == "Light")
            {
                btn.BorderThickness = 1;
            }
        }


        // Add app
        private static List<Guna2Button> appBtnList = new List<Guna2Button>(), variableBtnList = new List<Guna2Button>(), eventBtnList = new List<Guna2Button>();
        private static int selectedAppTag, totalAppCount;
        public static string selectedAppName;
        private static FlowLayoutPanel appPanelFlowPanelSelected;
        private static Guna2Button appPanelSelected;
        public static Guna2Button appOrSequenceOrFunctionBtnSelected, selectedVariableBtn, selectedEventBtn;
        private static void AddApp(string appName)
        {
            selectedAppTag++;
            totalAppCount++;

            // App panel
            Guna2Button gBtn = new Guna2Button
            {
                FillColor = CustomColors.mainBackground,
                PressedColor = CustomColors.mainBackground,
                Size = new Size(244, 90),
                Tag = "app",
                Name = totalAppCount.ToString(),
                Margin = new Padding(0, 0, 0, 30),
            };
            gBtn.HoverState.FillColor = CustomColors.mainBackground;
            gBtn.DisabledState.FillColor = CustomColors.mainBackground;
            gBtn.Click += CloseAllPanels;
            MachineProgrammer_form.instance.FileBack_flowPanel.Controls.Add(gBtn);
            appPanelSelected = gBtn;

            // App btn
            gBtn = new Guna2Button
            {
                ForeColor = CustomColors.text,
                BackColor = CustomColors.mainBackground,
                FillColor = CustomColors.mainBackground,
                Size = new Size(244, 25),
                Margin = new Padding(0),
                Font = new Font("Segoe UI", 10),
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(12, 0),
                BorderColor = CustomColors.controlSelectedBorder,
                PressedColor = CustomColors.fileSelected
            };
            gBtn.DisabledState.FillColor = CustomColors.mainBackground;
            gBtn.MouseEnter += FilebtnMouseEnter;
            gBtn.MouseLeave += FileBtnMouseLeave;
            gBtn.MouseClick += App_MouseClick;
            gBtn.Click += App_Click;

            if (isProgramBeingLoaded)
            {
                gBtn.Text = appName;
            }
            else { gBtn.Text = GetNumberNameForAppSequenceFunctionVariableOrEvent("App ", GetListOfAppNames(), totalAppCount); }
            appBtnList.Add(gBtn);
            appPanelSelected.Controls.Add(gBtn);

            // Save
            selectedAppName = gBtn.Text;
            Guna2Button tempBtn = gBtn;

            // Drop down arrow
            Guna2Button dropDownArrow = ConstructDropDownArrowForFile(tempBtn);
            dropDownArrow.Click += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;

                if (btn.Tag.ToString() == "right")
                {
                    btn.Image = Resources.DownArrowBlack;
                    btn.Tag = "down";
                    btn.Parent.Parent.Height = Convert.ToInt32(btn.Parent.Name);  // Get the height in btn.Parent.Name
                }
                else
                {
                    btn.Image = Resources.RightArrowBlack;
                    btn.Tag = "right";
                    btn.Parent.Name = appPanelSelected.Height.ToString();  // Save the height in btn.Parent.Name
                    btn.Parent.Parent.Height = 30;
                }
            };

            // Variable button
            gBtn = new Guna2Button
            {
                Size = new Size(244, 25),
                Location = new Point(0, 30),
                ForeColor = CustomColors.text,
                FillColor = CustomColors.mainBackground,
                BackColor = CustomColors.mainBackground,
                PressedColor = CustomColors.fileSelected,
                BorderColor = CustomColors.controlSelectedBorder,
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(12, 0),
                Margin = new Padding(0),
                Font = new Font("Segoe UI", 10),
                Text = "Variables",
                Name = totalAppCount.ToString()
            };
            gBtn.DisabledState.FillColor = CustomColors.mainBackground;
            gBtn.MouseEnter += FilebtnMouseEnter;
            gBtn.MouseLeave += FileBtnMouseLeave;
            gBtn.Click += Variable_Click;
            variableBtnList.Add(gBtn);
            appPanelSelected.Controls.Add(gBtn);

            // Event button
            gBtn = new Guna2Button
            {
                Size = new Size(244, 25),
                Location = new Point(0, 60),
                ForeColor = CustomColors.text,
                FillColor = CustomColors.mainBackground,
                PressedColor = CustomColors.fileSelected,
                BorderColor = CustomColors.controlSelectedBorder,
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(12, 0),
                Margin = new Padding(0),
                Font = new Font("Segoe UI", 10),
                Text = "Events",
                Name = totalAppCount.ToString()
            };
            gBtn.DisabledState.FillColor = CustomColors.mainBackground;
            gBtn.MouseEnter += FilebtnMouseEnter;
            gBtn.MouseLeave += FileBtnMouseLeave;
            gBtn.Click += Event_Click;
            eventBtnList.Add(gBtn);
            appPanelSelected.Controls.Add(gBtn);

            // FlowPanel
            FlowLayoutPanel flowPanel = UI.ConstructFlowPanel(new Size(244, 5), new Point(0, 90), appPanelSelected);
            flowPanel.Name = "appFlowPanel";
            appPanelFlowPanelSelected = flowPanel;

            if (!isProgramBeingLoaded)
            {
                // Create app directory
                string filePath1 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\";
                Directories.CreateDirectory(filePath1);

                // Create .txt files to hold command data
                Directories.CreateFile(filePath1 + "events.txt");
                Directories.CreateFile(filePath1 + "variables.txt");
                File.WriteAllText(filePath1 + selectedAppName + ".txt", totalAppCount.ToString() + Environment.NewLine);

                // Create directories
                Directories.CreateDirectory(filePath1 + "events");
                Directories.CreateDirectory(filePath1 + "sequences");

                Log.Write(3, "Created '" + selectedAppName + "'");
            }

            // Construct new menus
            ConstructAppPanel();
            ConstructEventPanel();
            ConstructVariablePanel();

            // Save            
            selectedCommandBack = appPanel_list[totalAppCount - 1];
            ShowCommandBackSelected();
            MachineProgrammer_form.instance.MachineController_ComboBox.Items.Add("None");
            MachineProgrammer_form.instance.MachineController_ComboBox.Text = "None";
            GetListOfVariablesForApp();
        }
        private static void Variable_Click(object sender, EventArgs e)
        {
            FileBtnMouseDown(sender);
            HideForwardAndBackwardBtns();
            MachineProgrammer_form.instance.AddFunction_btn.Enabled = false;

            Guna2Button btn = (Guna2Button)sender;

            // Save
            selectedVariableBtn = btn;
            selectedAppName = selectedVariableBtn.Parent.Controls[0].Text;
            selectedAppTag = Convert.ToInt32(selectedVariableBtn.Name);
            selectedCommandBack = variablePanel_list[selectedAppTag - 1];
            appPanelSelected = (Guna2Button)btn.Parent;
            appPanelFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Controls[3];
            whatIsSelected = "variable";
            appOrSequenceOrFunctionBtnSelected = null;
            MachineProgrammer_form.instance.AddCommand_btn.Text = "Add Variable";

            // show variable menu
            selectedCommandBack.BringToFront();
            selectedCommandBack.Visible = true;
        }
        private static void Event_Click(object sender, EventArgs e)
        {
            FileBtnMouseDown(sender);
            HideForwardAndBackwardBtns();
            MachineProgrammer_form.instance.AddFunction_btn.Enabled = false;

            Guna2Button btn = (Guna2Button)sender;

            // Save
            selectedEventBtn = btn;
            selectedAppName = selectedEventBtn.Parent.Controls[0].Text;
            selectedAppTag = Convert.ToInt32(selectedEventBtn.Name);
            selectedCommandBack = eventPanel_list[selectedAppTag - 1];
            appPanelSelected = (Guna2Button)btn.Parent;
            appPanelFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Controls[3];
            whatIsSelected = "event";
            appOrSequenceOrFunctionBtnSelected = null;
            MachineProgrammer_form.instance.AddCommand_btn.Text = "Add Event";

            // Show event menu
            selectedCommandBack.BringToFront();
            selectedCommandBack.Visible = true;
        }
        private static void HideForwardAndBackwardBtns()
        {
            MachineProgrammer_form.instance.MoveForward_btn.Visible = false;
            MachineProgrammer_form.instance.MoveBackward_btn.Visible = false;
        }
        private static void ShowForwardAndBackwardBtns()
        {
            MachineProgrammer_form.instance.MoveForward_btn.Visible = true;
            MachineProgrammer_form.instance.MoveBackward_btn.Visible = true;
        }
        private static void App_MouseClick(object sender, MouseEventArgs e)
        {
            Control btn = (Control)sender;

            // Right click panel
            if (e.Button == MouseButtons.Right)
            {
                RemoveMoveBtnFrom_rightClickFile_panel();
                AddOrRemoveMoveUpAndDownButtonsFor_rightClickFile_panel(MachineProgrammer_form.instance.FileBack_flowPanel.Controls.Count, selectedAppTag);
                ShowRightCickFilePanel(49 + btn.Parent.Top, e);
            }
        }
        private static void App_Click(object sender, EventArgs e)
        {
            FileButtonWithArrow_MouseDown(sender);
            ShowForwardAndBackwardBtns();
            MachineProgrammer_form.instance.AddFunction_btn.Enabled = false;

            Guna2Button btn = (Guna2Button)sender;

            selectedAppName = btn.Text;
            appPanelSelected = (Guna2Button)btn.Parent;
            appPanelFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Controls[3];
            appOrSequenceOrFunctionBtnSelected = btn;
            selectedAppTag = Convert.ToInt32(btn.Parent.Name);
            try
            {
                sequenceFlowPanelSelected = (FlowLayoutPanel)appPanelFlowPanelSelected.Controls[0].Controls[1];
                sequencePanelSelected = (Guna2Button)sequenceFlowPanelSelected.Parent;
                sequenceBtnSelected = (Guna2Button)sequencePanelSelected.Controls.Find("sequence", false).FirstOrDefault();
            }
            catch { }
            GetListOfVariablesForApp();

            // Save
            whatIsSelected = "app";
            selectedCommandBack = appPanel_list[selectedAppTag - 1];

            // Show
            ShowMainCommandButtons();
            ShowCommandBackSelected();
        }
        private static void ShowAppPanel(bool playFileBtn, bool first)
        {
            if (first) selectedAppTag = 1;

            // Save
            whatIsSelected = "app";
            MachineProgrammer_form.instance.AddFunction_btn.Enabled = false;
            selectedCommandBack = appPanel_list[selectedAppTag - 1];
            ResetFilePanelClickedLabels();

            // Show
            ShowCommandBackSelected();
            ShowMainCommandButtons();

            // Get app in file manager
            Guna2Button btn;
            foreach (Guna2Button item in MachineProgrammer_form.instance.FileBack_flowPanel.Controls)
            {
                if (Convert.ToInt32(item.Name) == selectedAppTag)
                {
                    btn = (Guna2Button)item.Controls[0];
                    appOrSequenceOrFunctionBtnSelected = btn;

                    // Select app in file manager
                    SetBorderThicknessIfThemeIsLight(btn);
                    if (playFileBtn)
                    {
                        Guna2Button fArrow = (Guna2Button)btn.Controls.Find("arrow", false).FirstOrDefault();
                        btn.BorderColor = CustomColors.accent_darkerGreen;
                        btn.DisabledState.FillColor = CustomColors.accent_green;
                        btn.DisabledState.BorderColor = CustomColors.accent_darkerGreen;
                        fArrow.DisabledState.FillColor = CustomColors.accent_green;
                        PlayingFileManagmentButton = btn;
                    }
                    else
                    {
                        Guna2Button fArrow = (Guna2Button)btn.Controls.Find("arrow", false).FirstOrDefault();
                        btn.FillColor = CustomColors.fileSelected;
                        btn.BorderColor = CustomColors.controlSelectedBorder;
                        fArrow.FillColor = CustomColors.fileSelected;
                        fArrow.DisabledState.FillColor = CustomColors.fileSelected;
                    }
                    break;
                }
            }
        }
        public static void AddFullApp(object sender, EventArgs e)
        {
            AddApp(null);
            AddSequence(null);
            AddFunction(null);
        }


        // Add sequence
        private static Guna2Button sequencePanelSelected, sequenceBtnSelected;
        private static int totalSequenceCountSelected, totalSequenceCount;
        private static List<Guna2Button> sequenceBtnList = new List<Guna2Button>();
        public static void AddSequence(string sequenceName)
        {
            Guna2Button arrow = (Guna2Button)appPanelSelected.Controls[0].Controls[0];
            if (arrow.Tag.ToString() == "right")
                arrow.PerformClick();

            totalSequenceCount++;
            ResetFilePanelClickedLabels();
            appPanelSelected.Height += 30;
            appPanelFlowPanelSelected.Height += 30;

            // Sequence panel
            Guna2Button gBtn = new Guna2Button
            {
                Size = new Size(244, 25),
                Tag = "sequence",
                FillColor = CustomColors.mainBackground,
                PressedColor = CustomColors.mainBackground,
                Margin = new Padding(0),
                Name = totalSequenceCount.ToString()
            };
            gBtn.HoverState.FillColor = CustomColors.mainBackground;
            appPanelFlowPanelSelected.Controls.Add(gBtn);
            sequencePanelSelected = gBtn;

            // Sequence btn
            gBtn = new Guna2Button
            {
                Size = new Size(244, 25),
                FillColor = CustomColors.fileSelected,
                PressedColor = CustomColors.fileSelected,
                BorderColor = CustomColors.controlSelectedBorder,
                ForeColor = CustomColors.text,
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(25, 0),
                Name = "sequence",
                Font = new Font("Segoe UI", 10)
            };
            gBtn.DisabledState.FillColor = CustomColors.mainBackground;
            gBtn.MouseEnter += FilebtnMouseEnter;
            gBtn.MouseLeave += FileBtnMouseLeave;
            gBtn.Click += Sequence_Click;
            gBtn.MouseClick += Sequence_MouseClick;

            if (isProgramBeingLoaded)
            {
                gBtn.Text = sequenceName;
            }
            else { gBtn.Text = GetNumberNameForAppSequenceFunctionVariableOrEvent("Sequence ", GetListOfSequenceNames(), sequencePanelSelected.Controls.Count + 1); }
            sequencePanelSelected.Controls.Add(gBtn);
            sequenceBtnList.Add(gBtn);

            // Save
            whatIsSelected = "sequence";
            totalSequenceCountSelected = totalSequenceCount;
            appOrSequenceOrFunctionBtnSelected = gBtn;
            sequenceBtnSelected = gBtn;

            FlowLayoutPanel flowPanel = UI.ConstructFlowPanel(new Size(244, 0), new Point(0, 25), sequencePanelSelected);
            flowPanel.ControlAdded += FlowPanel_ControlAddedOrRemoved;
            flowPanel.ControlRemoved += FlowPanel_ControlAddedOrRemoved;
            sequenceFlowPanelSelected = flowPanel;

            // Drop down arrow
            Guna2Button dropDownArrow = ConstructDropDownArrowForFile(appOrSequenceOrFunctionBtnSelected);
            dropDownArrow.Visible = false;
            dropDownArrow.Left = 14;
            dropDownArrow.Click += (sender, e) =>
            {
                Guna2Button btn = (Guna2Button)sender;
                sequenceFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Parent.Controls[1];
                appPanelSelected = (Guna2Button)sequenceFlowPanelSelected.Parent.Parent.Parent;
                sequencePanelSelected = (Guna2Button)sequenceFlowPanelSelected.Parent;

                if (btn.Tag.ToString() == "right")
                {
                    btn.Image = Resources.DownArrowBlack;
                    btn.Tag = "down";
                    sequencePanelSelected.Height += 30 * sequenceFlowPanelSelected.Controls.Count;
                    appPanelSelected.Height += 30 * sequenceFlowPanelSelected.Controls.Count;
                }
                else
                {
                    btn.Image = Resources.RightArrowBlack;
                    btn.Tag = "right";
                    sequencePanelSelected.Height = 30;
                    appPanelSelected.Height -= 30 * sequenceFlowPanelSelected.Controls.Count;
                }
            };

            // Construct new panel
            ConstructSequencePanel();
            selectedCommandBack = sequencePanel_list[totalSequenceCountSelected - 1];
            ShowMainCommandButtons();

            // Scroll to bottom
            MachineProgrammer_form.instance.FileBack_flowPanel.ScrollControlIntoView(sequenceBtnSelected);
            ShowCommandBackSelected();

            if (!isProgramBeingLoaded)
            {
                Log.Write(3, "Added '" + sequenceBtnSelected.Text + "' to '" + selectedAppName + "'");

                // Create sequence files
                string sequenceDir = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\";
                Directories.CreateDirectory(sequenceDir);
                File.WriteAllText(sequenceDir + sequenceBtnSelected.Text + ".txt", totalSequenceCount.ToString() + Environment.NewLine);
                Directories.CreateDirectory(sequenceDir + "functions");
            }

            MachineProgrammer_form.instance.AddFunction_btn.Enabled = true;
        }
        private static void Sequence_MouseClick(object sender, MouseEventArgs e)
        {
            UI.CloseAllPanels();
            Control btn = (Control)sender;

            // Right click panel
            if (e.Button == MouseButtons.Right)
            {
                // Add "Move" btn if there's more than 1 app
                if (totalAppCount > 1)
                    AddMoveBtnToPanel_rightClickFile_panel();
                else RemoveMoveBtnFrom_rightClickFile_panel();

                int sequenceIndexSelected = 0;
                for (int i = 0; i < appPanelFlowPanelSelected.Controls.Count; i++)
                {
                    if (appPanelFlowPanelSelected.Controls[i] == sequencePanelSelected)
                    {
                        sequenceIndexSelected = i + 1;
                        break;
                    }
                }
                AddOrRemoveMoveUpAndDownButtonsFor_rightClickFile_panel(appPanelFlowPanelSelected.Controls.Count, sequenceIndexSelected);
                ShowRightCickFilePanel(24 + btn.Top + btn.Height + btn.Parent.Top + btn.Parent.Parent.Top + btn.Parent.Parent.Parent.Top, e);

                MachineProgrammer_form.instance.Controls.Add(rightClickFile_panel);
                rightClickFile_panel.BringToFront();
            }
        }
        private static void Sequence_Click(object sender, EventArgs e)
        {
            FileButtonWithArrow_MouseDown(sender);
            ShowForwardAndBackwardBtns();
            MachineProgrammer_form.instance.AddFunction_btn.Enabled = true;

            Guna2Button btn = (Guna2Button)sender;

            appPanelSelected = (Guna2Button)btn.Parent.Parent.Parent;
            appPanelFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Parent;
            selectedAppName = appPanelSelected.Controls[0].Text;
            totalSequenceCountSelected = Convert.ToInt32(btn.Parent.Name);
            appOrSequenceOrFunctionBtnSelected = btn;
            sequenceFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Controls[1];
            sequencePanelSelected = (Guna2Button)btn.Parent;
            sequenceBtnSelected = btn;
            GetListOfVariablesForApp();

            // Save
            whatIsSelected = "sequence";
            selectedCommandBack = sequencePanel_list[totalSequenceCountSelected - 1];

            // Show
            ShowCommandBackSelected();
            ShowMainCommandButtons();
        }
        private static void FlowPanel_ControlAddedOrRemoved(object sender, ControlEventArgs e)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            Guna2Button fArrow = (Guna2Button)panel.Parent.Controls[0].Controls.Find("arrow", false).FirstOrDefault();
            if (panel.Controls.Count == 0)
                fArrow.Visible = false;
            else fArrow.Visible = true;
        }
        private static int GetTotalNumberOfSequences()
        {
            int count = 0;
            foreach (Control item in MachineProgrammer_form.instance.FileBack_flowPanel.Controls)
            {
                FlowLayoutPanel appFlowPanel = (FlowLayoutPanel)item.Controls.Find("appFlowPanel", false).FirstOrDefault();
                count += appFlowPanel.Controls.Count;
                if (count > 1) break;
            }
            return count;
        }


        delegate void DoWorkDelegate(Action action);

        // Add function
        private static Guna2Button functionBtnSelected;
        private static int functionIndexSelected, totalFunctionCount;
        private static List<Guna2Button> functionBtnList = new List<Guna2Button>();
        private static FlowLayoutPanel sequenceFlowPanelSelected;
        public static void AddFunction(string functionName)
        {
            if (appPanelFlowPanelSelected.Controls.Count > 0)
            {
                appPanelSelected.Height += 30;
                appPanelFlowPanelSelected.Height += 30;
                sequencePanelSelected.Height += 30;
                sequenceFlowPanelSelected.Height += 30;

                Guna2Button arrow = (Guna2Button)sequenceFlowPanelSelected.Parent.Controls[0].Controls[0];
                if (arrow.Tag.ToString() == "right")
                    arrow.PerformClick();

                totalFunctionCount++;
                ResetFilePanelClickedLabels();

                // Fucntion btn
                Guna2Button gBtn = new Guna2Button
                {
                    Size = new Size(244, 25),
                    FillColor = CustomColors.fileSelected,
                    PressedColor = CustomColors.fileSelected,
                    BorderColor = CustomColors.controlSelectedBorder,
                    ForeColor = CustomColors.text,
                    TextAlign = HorizontalAlignment.Left,
                    TextOffset = new Point(38, 0),
                    Font = new Font("Segoe UI", 10),
                    Margin = new Padding(0, 5, 0, 0),
                    Name = totalFunctionCount.ToString(),
                    Tag = "function"
                };
                SetBorderThicknessIfThemeIsLight(gBtn);
                gBtn.DisabledState.FillColor = CustomColors.mainBackground;
                gBtn.MouseEnter += FilebtnMouseEnter;
                gBtn.MouseLeave += FileBtnMouseLeave;
                gBtn.Click += Function_Click;
                gBtn.MouseClick += Function_MouseClick;
                functionBtnSelected = gBtn;

                if (isProgramBeingLoaded)
                    gBtn.Text = functionName;
                else
                    gBtn.Text = GetNumberNameForAppSequenceFunctionVariableOrEvent("Function ", GetListOfFunctionNames(), sequenceFlowPanelSelected.Controls.Count + 1);

                functionBtnList.Add(gBtn);
                sequenceFlowPanelSelected.Controls.Add(gBtn);

                // Save
                whatIsSelected = "function";
                functionIndexSelected = totalFunctionCount;
                appOrSequenceOrFunctionBtnSelected = gBtn;

                // Construct new menu
                ConstructFunctionPanel();
                selectedCommandBack = functionPanel_list[functionIndexSelected - 1];
                ShowMainCommandButtons();

                MachineProgrammer_form.instance.FileBack_flowPanel.ScrollControlIntoView(gBtn);
                ShowCommandBackSelected();

                if (!isProgramBeingLoaded)
                {
                    Log.Write(3, "Added '" + gBtn.Text + "' to '" + selectedAppName + "'");

                    // Create function.txt
                    File.WriteAllText(Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\functions\" + appOrSequenceOrFunctionBtnSelected.Text + ".txt", totalFunctionCount.ToString() + Environment.NewLine);
                }
            }
            else
            {
                AddSequence(null);
                AddFunction(null);
            }
        }
        private static void Function_MouseClick(object sender, MouseEventArgs e)
        {
            Control btn = (Control)sender;

            // Right click panel
            if (e.Button == MouseButtons.Right)
            {
                // Add "Move" btn if there's more than 1 sequence
                if (GetTotalNumberOfSequences() > 1)
                    AddMoveBtnToPanel_rightClickFile_panel();
                else RemoveMoveBtnFrom_rightClickFile_panel();

                int functionIndexSelected = 0;
                for (int i = 0; i < sequenceFlowPanelSelected.Controls.Count; i++)
                {
                    if (sequenceFlowPanelSelected.Controls[i] == functionBtnSelected)
                    {
                        functionIndexSelected = i + 1;
                        break;
                    }
                }
                AddOrRemoveMoveUpAndDownButtonsFor_rightClickFile_panel(sequenceFlowPanelSelected.Controls.Count, functionIndexSelected);
                ShowRightCickFilePanel(24 + btn.Top + btn.Height + btn.Parent.Top + btn.Parent.Parent.Top + btn.Parent.Parent.Parent.Top + btn.Parent.Parent.Parent.Parent.Top, e);

                MachineProgrammer_form.instance.Controls.Add(rightClickFile_panel);
                rightClickFile_panel.BringToFront();
            }
        }
        private static void Function_Click(object sender, EventArgs e)
        {
            FileBtnMouseDown(sender);
            ShowForwardAndBackwardBtns();
            MachineProgrammer_form.instance.AddFunction_btn.Enabled = true;

            Guna2Button btn = (Guna2Button)sender;

            appPanelSelected = (Guna2Button)btn.Parent.Parent.Parent.Parent;
            appPanelFlowPanelSelected = (FlowLayoutPanel)btn.Parent.Parent.Parent;
            sequencePanelSelected = (Guna2Button)btn.Parent.Parent;
            sequenceBtnSelected = (Guna2Button)sequencePanelSelected.Controls.Find("sequence", false).FirstOrDefault();
            sequenceFlowPanelSelected = (FlowLayoutPanel)btn.Parent;
            selectedAppName = btn.Parent.Parent.Parent.Parent.Controls[0].Text;
            functionIndexSelected = Convert.ToInt32(btn.Name);
            appOrSequenceOrFunctionBtnSelected = btn;
            functionBtnSelected = btn;
            selectedAppTag = Convert.ToInt32(btn.Parent.Parent.Parent.Parent.Name);
            GetListOfVariablesForApp();

            // Save
            whatIsSelected = "function";
            selectedCommandBack = functionPanel_list[functionIndexSelected - 1];

            // Show
            ShowMainCommandButtons();
            ShowCommandBackSelected();
        }


        // Set command background color
        private static void SetCommandBackgroundToHidden(object sender)
        {
            ChangeCommandBackground(sender, CustomColors.commandHidden);
        }
        private static void SetCommandBackgroundToSelected(object sender)
        {
            ChangeCommandBackground(sender, CustomColors.fileSelected);
            Guna2Button command = (Guna2Button)sender;

            command.BorderColor = CustomColors.accent_blue;
            command.HoverState.BorderColor = CustomColors.accent_blue;
        }
        private static void SetCommandBackgroundToControlBack(object sender)
        {
            ChangeCommandBackground(sender, CustomColors.controlBack);
            Guna2Button command = (Guna2Button)sender;

            command.BorderColor = Color.Gray;
            command.HoverState.BorderColor = Color.Gray;
            command.DisabledState.BorderColor = Color.Gray;
        }
        private static void SetCommandBackgroundToGreen(object sender)
        {
            ChangeCommandBackground(sender, CustomColors.accent_green);
            Guna2Button command = (Guna2Button)sender;

            SetBorderThicknessIfThemeIsLight(command);
            command.BorderColor = CustomColors.accent_darkerGreen;
            command.DisabledState.BorderColor = CustomColors.accent_darkerGreen;
        }
        private static void ChangeCommandBackground(object sender, Color color)
        {
            Guna2Button command = (Guna2Button)sender;
            Guna2Button HideButton = (Guna2Button)command.Controls.Find("hideBtn", false).FirstOrDefault();

            command.FillColor = color;
            command.HoverState.FillColor = color;
            command.PressedColor = color;
            command.DisabledState.FillColor = color;

            foreach (Control contorol in command.Controls)
            {
                try { contorol.BackColor = color; }
                catch { }
            }
            HideButton.FillColor = color;
        }
        private static void UpdateCommandBackgroundColor(object sender)
        {
            Guna2Button command = (Guna2Button)sender;

            if (command.FillColor == CustomColors.commandHidden)
            {
                SetCommandBackgroundToHidden(command);
            }
        }
        public static void SetRedCommandsToWhite()
        {
            if (selectedCommandBack != null)
            {
                foreach (var command in from Guna2Button command in selectedCommandBack.Controls.OfType<Guna2Button>()
                                        where command.FillColor == CustomColors.accent_red
                                        select command)
                {
                    SetCommandBackgroundToControlBack(command);
                }
            }
        }


        // Command logic
        private static bool isRightClickMouseButtonDownOnCommand, commandMoveBringToFront;
        public static Guna2Panel selectedCommandBack;
        public static Guna2Button commandClicked, commandSelected;
        public static int commandClickedName, commandMovedDownCount, commandMovedUpCount, commandMovedAmount, coords, coordsMouseDown, commandClickedTop, mouseMoved, mouseMovedBase;
        private static void Command_MouseDown(object sender, MouseEventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                isRightClickMouseButtonDownOnCommand = true;
            }
            UI.CloseAllPanels();

            if (e.Button == MouseButtons.Left)
            {
                SelectCommand(btn, false);

                // If visibility icon is not clicked
                if (btn.FillColor == CustomColors.controlBack)
                {
                    ChangeCommandBackground(btn, CustomColors.commandMouseDown);
                }

                // Save the command that was clicked
                commandClickedTop = btn.Top;
                coords = Cursor.Position.Y - btn.Top;
                coordsMouseDown = Cursor.Position.Y;
                commandClickedName = Convert.ToInt32(btn.Name);

                // Disable scroll while mouse is down
                selectedCommandBack.SuspendLayout();

                // Start timer
                MachineProgrammer_form.instance.MoveCommand_timer.Enabled = true;
            }
            // Save
            commandClicked = btn;
        }
        private static void Command_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Only run once
                if (!commandMoveBringToFront)
                {
                    mouseMovedBase = Cursor.Position.Y - coords;
                    if (commandClicked != null)
                    {
                        commandClicked.BringToFront();
                    }
                    commandMoveBringToFront = true;
                }
                // Get mouse position
                mouseMoved = Cursor.Position.Y - coords - mouseMovedBase;

                // If mouse position is below top of command background
                if (MachineProgrammer_form.instance.coords > 3)
                {
                    // If clicked command moved up
                    if (mouseMoved < -5)
                    {
                        int MoveItem = commandClickedName - commandMovedUpCount + commandMovedDownCount - 1;
                        if (MoveItem < selectedCommandBack.Controls.Count & MoveItem > 0)
                        {
                            // Find command
                            Control findName = selectedCommandBack.Controls.Find(MoveItem.ToString(), false).FirstOrDefault();
                            if (commandClicked.Top < findName.Top + findName.Height - 30)
                            {
                                // Move command
                                findName.Top += commandClicked.Height + 6;
                                commandMovedUpCount++;

                                // Reset moved command
                                int temp = Convert.ToInt32(findName.Name);
                                findName.Name = (temp + 1).ToString();
                                findName.Controls.Find("numberLabel", false).FirstOrDefault().Text = (temp + 1).ToString();

                                // Reset clicked command
                                commandClicked.Name = temp.ToString();
                                commandClicked.Controls.Find("numberLabel", false).FirstOrDefault().Text = temp.ToString();
                                // Reset
                                mouseMovedBase += mouseMoved;
                            }
                        }
                    }
                    // If clicked command moved down
                    else if (mouseMoved > 5)
                    {
                        int MoveItem = commandClickedName + commandMovedDownCount - commandMovedUpCount + 1;
                        if (MoveItem <= selectedCommandBack.Controls.Count & MoveItem > 0)
                        {
                            // Find command
                            Control findName = selectedCommandBack.Controls.Find(MoveItem.ToString(), false).FirstOrDefault();
                            if (commandClicked.Top + commandClicked.Height > findName.Top + 30)
                            {
                                // Move command
                                findName.Top -= commandClicked.Height + 6;
                                commandMovedDownCount++;

                                // Reset moved command
                                int temp = Convert.ToInt32(findName.Name);
                                findName.Name = (temp - 1).ToString();
                                findName.Controls.Find("numberLabel", false).FirstOrDefault().Text = (temp - 1).ToString();

                                // Reset clicked command
                                commandClicked.Name = temp.ToString();
                                commandClicked.Controls.Find("numberLabel", false).FirstOrDefault().Text = temp.ToString();
                                // Reset
                                mouseMovedBase += mouseMoved;
                            }
                        }
                    }
                }
            }
        }
        private static void Command_MouseUp(object sender, MouseEventArgs e)
        {
            Guna2Button command = (Guna2Button)sender;
            commandClickedName = Convert.ToInt32(command.Name);

            // Reset
            isRightClickMouseButtonDownOnCommand = false;

            // If the command is an event
            if (command.Controls.Find("numberLabel", false).FirstOrDefault().Tag.ToString() == "eventCommand")
            {
                Guna2TextBox name = (Guna2TextBox)command.Controls.Find("name", false).FirstOrDefault();
                eventNameSelected = name.Text;
            }

            if (e.Button == MouseButtons.Left)
            {
                // Stop timer
                MachineProgrammer_form.instance.MoveCommand_timer.Enabled = false;

                // Resume scroll
                selectedCommandBack.ResumeLayout();

                if (command.FillColor == CustomColors.commandMouseDown)
                {
                    SetCommandBackgroundToControlBack(sender);
                }

                // If clicked command did not move or ended up in the same spot
                if (commandMovedDownCount == commandMovedUpCount)
                {
                    if (commandClickedName >= selectedCommandBack.Controls.Count || commandClickedName <= selectedCommandBack.Controls.Count)
                    {
                        // Move command
                        if (commandClickedTop != 0)
                        {
                            command.Top = commandClickedTop;
                        }
                    }
                }

                // If clicked command moved up
                else if (commandMovedDownCount < commandMovedUpCount)
                {
                    commandMovedAmount = commandMovedDownCount - commandMovedUpCount;
                    // Find commands
                    Control findClickedCommand = selectedCommandBack.Controls.Find((commandClickedName).ToString(), false).FirstOrDefault();
                    Control findBelowCommand = selectedCommandBack.Controls.Find((commandClickedName + 1).ToString(), false).FirstOrDefault();

                    // Move command
                    findClickedCommand.Top = findBelowCommand.Top - findClickedCommand.Height - 6;

                    // Read all command data in file
                    string filePath1 = GetFilePath();
                    if (File.Exists(filePath1))
                    {
                        string[] lines = File.ReadAllLines(filePath1);

                        // Move all the command data in file down by one line
                        int temp = commandClickedName + (commandMovedAmount * -1);  // * by -1 to make the negative commandMovedAmount a positive
                        string commandClickedDataInFile = lines[temp];
                        for (int i = temp; i > commandClickedName - 1; i--)
                        {
                            lines[i] = lines[i - 1];
                        }
                        // Move moved command data to it's new location
                        lines[commandClickedName - 1] = commandClickedDataInFile;

                        // Save in File
                        File.WriteAllLines(filePath1, lines);
                    }
                    else
                    {
                        Log.Error_FileDoesNotExist(filePath1);
                        return;
                    }
                }

                // If clicked command moved down
                else if (commandMovedDownCount > commandMovedUpCount)
                {
                    commandMovedAmount = commandMovedUpCount - commandMovedDownCount;
                    // Find commands
                    Control findClickedCommand = selectedCommandBack.Controls.Find((commandClickedName).ToString(), false).FirstOrDefault();
                    Control findAboveCommand = selectedCommandBack.Controls.Find((commandClickedName - 1).ToString(), false).FirstOrDefault();

                    // Move command
                    findClickedCommand.Top = findAboveCommand.Top + findAboveCommand.Height + 6;

                    // Read all command data in file
                    string filePath1 = GetFilePath();
                    if (File.Exists(filePath1))
                    {
                        string[] lines = File.ReadAllLines(filePath1);

                        // Move all the command data in file down by one line
                        int temp = commandClickedName - (commandMovedAmount * -1);  // * by -1 to make it a positive
                        string commandClickedDataInFile = lines[temp];
                        for (int i = temp; i < commandClickedName - 1; i++)
                        {
                            lines[i] = lines[i + 1];
                        }
                        // Move moved command data to it's new location
                        lines[commandClickedName - 1] = commandClickedDataInFile;

                        // Save in File
                        File.WriteAllLines(filePath1, lines);
                    }
                    else
                    {
                        Log.Error_FileDoesNotExist(filePath1);
                        return;
                    }
                }

                // Reset
                commandMovedDownCount = 0;
                commandMovedUpCount = 0;
                commandMovedAmount = 0;
                commandClickedName = 0;
                commandClickedTop = 0;
                commandMoveBringToFront = false;
            }

            // Right click panel
            else if (e.Button == MouseButtons.Right)
            {
                int numberOfSelectedCommands = GetNumberOfSelectedCommands();
                var numberLabelTag = command.Controls.Find("numberLabel", false).FirstOrDefault().Tag.ToString();

                // Get name
                string name = "command";
                if (numberLabelTag == "addVariableCommand")
                    name = "variable";

                else if (numberLabelTag == "eventCommand")
                    name = "event";

                // Set buttons
                FlowLayoutPanel flowPanel = (FlowLayoutPanel)rightClickCommand_panel.Controls[0];
                if (numberLabelTag == "addVariableCommand" || numberLabelTag == "eventCommand")
                {
                    flowPanel.Controls.Remove(rightClickCommandMove_btn);
                    rightClickCommand_panel.Height = 3 * 22 + 10;
                    flowPanel.Height = 3 * 22;
                    rightClickCommandDuplicate_btn.Top = 5;
                    rightClickCommandHide_btn.Top = 27;
                    rightClickCommandDelete_btn.Top = 49;
                }
                else
                {
                    flowPanel.Controls.Add(rightClickCommandMove_btn);
                    rightClickCommand_panel.Height = 4 * 22 + 10;
                    flowPanel.Height = 4 * 22;
                    rightClickCommandDuplicate_btn.Top = 27;
                    rightClickCommandHide_btn.Top = 49;
                    rightClickCommandDelete_btn.Top = 71;
                }

                // Set button text
                if (numberOfSelectedCommands > 1)
                {
                    rightClickCommandMove_btn.Text = "Move " + numberOfSelectedCommands.ToString() + " " + name + "s";
                    rightClickCommandDuplicate_btn.Text = "Duplicate " + numberOfSelectedCommands.ToString() + " " + name + "s";
                    rightClickCommandDelete_btn.Text = "Delete " + numberOfSelectedCommands.ToString() + " " + name + "s";
                }
                else
                {
                    rightClickCommandMove_btn.Text = "Move " + name;
                    rightClickCommandDuplicate_btn.Text = "Duplicate " + name;
                    rightClickCommandDelete_btn.Text = "Delete " + name;
                }

                // Set hide btn
                if (command.FillColor == Color.LightGray)
                {
                    if (numberOfSelectedCommands > 1)
                        rightClickCommandHide_btn.Text = "Unhide " + numberOfSelectedCommands.ToString() + " " + name + "s";
                    else
                        rightClickCommandHide_btn.Text = "Unhide " + name;
                }
                else
                {
                    if (numberOfSelectedCommands > 1)
                        rightClickCommandHide_btn.Text = "Hide " + numberOfSelectedCommands.ToString() + " " + name + "s";
                    else
                        rightClickCommandHide_btn.Text = "Hide " + name;
                }


                // Show rightClickCommand_panel
                // If it's too far right
                bool tooFarRight = false;
                if (e.X - 25 + 17 + rightClickCommand_panel.Width > MachineProgrammer_form.instance.MainCommandBack_panel.Width)
                {
                    rightClickCommand_panel.Left = MachineProgrammer_form.instance.MainCommandBack_panel.Width - rightClickCommand_panel.Width - 17;
                    tooFarRight = true;
                }

                // If it's too far left
                else if (e.X - 25 < 0)
                    rightClickCommand_panel.Left = 0;
                else
                    rightClickCommand_panel.Left = e.X - 25;

                // If it's too far down
                int top = e.Y + command.Top + 2;
                if (top + rightClickCommand_panel.Height + 2 > selectedCommandBack.Height)
                {
                    rightClickCommand_panel.Top = selectedCommandBack.Height - rightClickCommand_panel.Height - 2;
                    if (!tooFarRight)
                        rightClickCommand_panel.Left += 40;
                }
                else { rightClickCommand_panel.Top = top; }

                selectedCommandBack.Controls.Add(rightClickCommand_panel);
                rightClickCommand_panel.BringToFront();
            }
        }
        private static int GetNumberOfSelectedCommands()
        {
            int count = 0;
            foreach (var item in selectedCommandBack.Controls)
            {
                if (item is Guna2Button command)
                {
                    if (command.FillColor == CustomColors.fileSelected)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static void Command_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            SelectCommand(btn, true);
        }
        private static void Command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                PictureBox btn = (PictureBox)commandClicked.Controls.Find("deleteBtn", false).FirstOrDefault();
                DeleteCommand(btn, e);
            }
        }
        private static void SelectCommand(Guna2Button btn, bool alwaysSelect)
        {
            // If command is not hidden
            if (btn.FillColor != CustomColors.commandHidden)
            {
                if (MachineProgrammer_form.instance.isControlKeyDown || alwaysSelect)
                {
                    // If command is not selected
                    if (btn.FillColor != CustomColors.fileSelected)
                    {
                        SetCommandBackgroundToSelected(btn);
                        commandSelected = btn;
                    }
                    // Unselect command
                    else { SetCommandBackgroundToControlBack(btn); }
                }
                else if (MachineProgrammer_form.instance.isShiftKeyDown)
                {
                    if (GetNumberOfSelectedCommands() != 0 && commandSelected != null)
                    {
                        int btnName = Convert.ToInt32(btn.Name);
                        int oldBtnName = Convert.ToInt32(commandSelected.Name);

                        if (btnName < oldBtnName)
                        {
                            for (int i = btnName; i <= oldBtnName; i++)
                            {
                                Control findCommand = selectedCommandBack.Controls.Find(i.ToString(), false).FirstOrDefault();
                                SetCommandBackgroundToSelected(findCommand);
                            }
                        }
                        else if (btnName > oldBtnName)
                        {
                            for (int i = oldBtnName; i <= btnName; i++)
                            {
                                Control findCommand = selectedCommandBack.Controls.Find(i.ToString(), false).FirstOrDefault();
                                SetCommandBackgroundToSelected(findCommand);
                            }
                        }
                    }
                }
            }
        }
        public static void UnselectAllCommands(bool alwaysUnselect)
        {
            if (selectedCommandBack != null)
            {
                if (!MachineProgrammer_form.instance.isControlKeyDown && !MachineProgrammer_form.instance.isShiftKeyDown)
                {
                    if (!selectedCommandBack.Controls.Contains(variableBoxContainer) && !isRightClickMouseButtonDownOnCommand || alwaysUnselect)
                    {
                        foreach (var item in selectedCommandBack.Controls)
                        {
                            if (item is Guna2Button command)
                            {
                                if (command.FillColor != CustomColors.commandHidden && command.FillColor != CustomColors.accent_green)
                                {
                                    SetCommandBackgroundToControlBack(command);
                                    command.BorderColor = Color.Gray;
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void DeleteCommand(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;

            bool pass = false;
            if (btn.Parent.Controls[0].Tag.ToString() == "eventCommand")
            {
                Guna2TextBox findName = (Guna2TextBox)btn.Parent.Controls.Find("name", false).FirstOrDefault();
                eventNameSelected = findName.Text;

                CustomMessageBoxResult result = CustomMessageBox.Show("Delete event", "Event '" + eventNameSelected + "' and all of it's contents will be deleted permanently.", CustomMessageBoxIcon.Info, CustomMessageBoxButtons.OkCancel);
                if (result != CustomMessageBoxResult.Ok)
                    pass = true;
            }

            if (!pass)
            {
                string CommandClosed = btn.Parent.Name;
                bool wasEventFileDeleted = false;

                // Remove command
                selectedCommandBack.Controls.Remove(selectedCommandBack.Controls.Find(CommandClosed, false).FirstOrDefault());

                for (int i = Convert.ToInt32(CommandClosed) + 1; i <= selectedCommandBack.Controls.Count + 1; i++)
                {
                    // Reset command Name
                    Control findName2 = selectedCommandBack.Controls.Find(i.ToString(), false).FirstOrDefault();
                    int before = Convert.ToInt32(findName2.Name);

                    // Reset number name
                    findName2.Name = (before - 1).ToString();

                    // Reset number text
                    findName2.Controls[0].Text = (before - 1).ToString();

                    // Move commands that are below upwards
                    findName2.Top -= btn.Parent.Height + 6;
                }

                if (btn.Parent.Controls[0].Tag != null)
                {
                    // If a variable command was deleted
                    if (btn.Parent.Controls[0].Tag.ToString() == "addVariableCommand")
                    {
                        // Delete variable
                        int variableName = Convert.ToInt32(btn.Parent.Name);
                        variableNames_list.RemoveAt(variableName - 1);
                        variableBtnList.Remove((Guna2Button)btn.Parent);
                    }

                    // If an event command was deleted
                    else if (btn.Parent.Controls[0].Tag.ToString() == "eventCommand")
                    {
                        eventBtnList.Remove((Guna2Button)btn.Parent);

                        // Delete event file
                        Directories.DeleteFile(Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\" + eventNameSelected + ".txt");

                        wasEventFileDeleted = true;
                        programEventPanel_list.RemoveAt((int)commandClicked.Tag);
                    }
                }

                // Move below lines in file up
                string filePath1;

                if (wasEventFileDeleted)
                {
                    filePath1 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events.txt";
                }
                else { filePath1 = GetFilePath(); }

                if (File.Exists(filePath1))
                {
                    string[] lines = File.ReadAllLines(filePath1);

                    // Remove line from file
                    lines[Convert.ToInt32(CommandClosed) - 1] = "";

                    File.WriteAllText(filePath1, RemoveAllEmptyLines(lines));
                }
                else { Log.Error_FileDoesNotExist(filePath1); }
            }
        }
        private static void HideCommand(object sender, EventArgs e)
        {
            Guna2Button hideBtn = (Guna2Button)sender;

            if (hideBtn.FillColor != CustomColors.commandHidden)
            {
                hideBtn.Image = Resources.EyeClosed;
                SetCommandBackgroundToHidden(hideBtn.Parent);
            }
            else
            {
                hideBtn.Image = Resources.EyeOpen;
                SetCommandBackgroundToControlBack(hideBtn.Parent);
            }
        }
        private static List<Guna2Button> GetListOfSelectedCommands()
        {
            List<Guna2Button> selectedCommandsList = new List<Guna2Button>();
            foreach (Control item in selectedCommandBack.Controls)
            {
                if (item is Guna2Button command)
                {
                    if (command.FillColor == CustomColors.fileSelected)
                    {
                        selectedCommandsList.Add(command);
                    }
                }
            }
            return selectedCommandsList;
        }
        private static void MoveBelowCommandsUpOrDown(int btnHeightBefore, int height, string commandDown)
        {
            int btnHeightAfter = btnHeightBefore - height;
            for (int i = Convert.ToInt32(commandDown) + 1; i <= GetTotalNumberOfCommands(selectedCommandBack); i++)
            {
                Guna2Button findCommand = (Guna2Button)selectedCommandBack.Controls.Find(i.ToString(), false).FirstOrDefault();
                findCommand.Top -= btnHeightAfter;
            }
        }
        private static string RemoveAllEmptyLines(string[] lines)
        {
            string linesWithoutEmptyLines = "";
            foreach (var item in from string item in lines
                                 where item != ""
                                 select item)
            {
                linesWithoutEmptyLines += item + "\r\n";
            }

            return linesWithoutEmptyLines;
        }
        private static string GetFilePath()
        {
            switch (whatIsSelected)
            {
                case "app":
                    return Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\" + selectedAppName + ".txt";

                case "sequence":
                    return Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\" + sequenceBtnSelected.Text + ".txt";

                case "function":
                    return Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\functions\" + appOrSequenceOrFunctionBtnSelected.Text + ".txt";

                case "event":
                    // Update command count on event command when a new command is added
                    Label commandCount = (Label)selectedCommandBack.Controls.Find("commandCount", false).FirstOrDefault();
                    if (commandCount != null)
                    {
                        int text = Convert.ToInt32(commandCount.Text);
                        commandCount.Text = (text++).ToString();
                    }
                    return Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events.txt";

                case "programEvent":
                    return Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\" + eventNameSelected + ".txt";

                case "variable":
                    return Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\variables.txt";

            }
            return "ERROR";
        }
        private static int GetTotalCommandHeight(Guna2Panel commandBack)
        {
            if (commandBack.Controls.Count > 0)
            {
                Control findName = commandBack.Controls.Find(GetTotalNumberOfCommands(commandBack).ToString(), false).FirstOrDefault();
                return findName.Height + findName.Top;
            }
            return 0;
        }
        /// <summary>
        /// Returns the total number of commands in selectedCommandBack. It does not count other controls such as panels.
        /// </summary>
        private static int GetTotalNumberOfCommands(Guna2Panel commandBack)
        {
            int count = 0;
            if (commandBack != null)
            {
                foreach (var item in commandBack.Controls)
                {
                    if (item is Guna2Button)
                        count++;
                }
            }
            return count;
        }


        // Motion command
        public static void ConstructMotionCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            Guna2ComboBox gComboBox;
            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 100), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Nmber label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "moveCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Actuator", 11, true, new Point(50, 5), "", command);
            // ComboBox
            gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.Name = "1";
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[8];  // Must be before SelectedIndexChanged
            }
            gComboBox.LostFocus += MoveCommandSave;

            // Label
            Label label = UI.ConstructLabel("Direction", 11, true, new Point(240, 5), "direction", command);
            // ComboBox
            gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
            gComboBox.Items.Add("Clockwise");
            gComboBox.Items.Add("Counter-clockwise");
            gComboBox.Name = "2";
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[0];  // Must be before SelectedIndexChanged
            }
            gComboBox.LostFocus += MoveCommandSave;

            // Label
            UI.ConstructLabel("Speed", 11, true, new Point(430, 5), "", command);
            // TextBox
            Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(120, 36), new Point(430, 30), command);
            gTextBox.LostFocus += MoveCommandSave;
            gTextBox.Name = "3";
            gTextBox.Click += ShowVariableBox;
            gTextBox.TextChanged += VariableTextBoxChanged;
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
                gTextBox.Text = loadCommandData[1];

            // 'Add' button
            Guna2CircleButton gCircleBtn = UI.ConstructGCircleBtn(Resources.Plus, new Size(23, 23), new Point(50, 70), command);
            gCircleBtn.Name = "addBtn";
            gCircleBtn.Tag = 0;
            gCircleBtn.Click += (sender, e) =>
            {
                MoveCommandAddButton_Click(sender, loadCommandData);
            };
            // Label
            label = UI.ConstructLabel("Actuators", 12, false, new Point(80, 70), "actuatorsLabel", command);

            // Label
            label = UI.ConstructLabel("Motion", 11, true, new Point(560, 5), "motionLabel", command);
            label.Tag = 0;
            // ComboBox
            gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(560, 30), command);
            gComboBox.Items.Add("Move to position");
            gComboBox.Items.Add("Move distance");
            gComboBox.Items.Add("Amount of time");
            gComboBox.Items.Add("Until");
            gComboBox.Name = "4";
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                MoveCommandComboBox4_SelectedIndexChanged(sender, loadCommandData);
            };
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[2];  // Must be after SelectedIndexChanged
            }

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                MoveCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);

            // Click add button
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                if (loadCommandData[3] != "")
                {
                    Guna2CircleButton addBtn = gCircleBtn;
                    for (int i = 0; i < Convert.ToInt32(loadCommandData[3]); i++)
                    {
                        addBtn.Tag = i;
                        addBtn.PerformClick();
                    }
                }
            }

            // Should the command be hidden
            if (loadCommandData != null)
            {
                if (loadCommandData[15] == "1")
                    gBtn.PerformClick();
            }

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveMoveCommandInFile(command, true);
            }
        }
        private static void MoveCommandAddButton_Click(object sender, List<string> loadCommandData)
        {
            Control senderBtn = (Control)sender;
            Control command = senderBtn.Parent;
            senderBtn.Tag = (int)senderBtn.Tag + 1;
            commandClickedName = Convert.ToInt32(command.Name);
            UI.CloseAllPanels();

            Label findActuatorsLabel = (Label)command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
            Label findMotionLabel = (Label)command.Controls.Find("motionLabel", false).FirstOrDefault();

            int btnHeightBefore = command.Height;
            for (int i = (int)senderBtn.Tag - 1; i < (int)senderBtn.Tag; i++)
            {
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 75 + 45 * i), command);
                gComboBox.Name = (20 + (i * 4)).ToString();  // 20, 24, 28
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[8 + i];  //8, 9, 10, 11    // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += MoveCommandSave;

                // Minus button
                Guna2CircleButton gCircleBtn = UI.ConstructGCircleBtn(Resources.Minus, new Size(23, 23), new Point(20, 75 + 45 * i), command);
                gCircleBtn.Name = (21 + (i * 4)).ToString();  //21, 25, 29
                gCircleBtn.Click += MoveCommandMinusBtn_Click;

                if ((int)findMotionLabel.Tag == 1)
                {
                    // TextBox
                    Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 75 + 45 * i), command);
                    gTextBox.LostFocus += MoveCommandSave;
                    gTextBox.Name = (22 + (i * 4)).ToString();  // 22, 26, 30
                    gTextBox.Click += ShowVariableBox;
                    gTextBox.TextChanged += VariableTextBoxChanged;
                    if (isProgramBeingLoaded || isCommandBeingDuplicated)
                        gTextBox.Text = loadCommandData[5 + i];  // 5, 6, 7
                }
            }

            if ((int)senderBtn.Tag == 1)
            {
                command.Height = 143;
                senderBtn.Top = 115;
                findActuatorsLabel.Top = 117;
            }
            else if ((int)senderBtn.Tag == 2)
            {
                command.Height = 188;
                senderBtn.Top = 160;
                findActuatorsLabel.Top = 162;
            }
            else if ((int)senderBtn.Tag == 3)
            {
                command.Height = 205;
                senderBtn.Top = 230;
                findActuatorsLabel.Top = 230;  // Hide Actuators Label
            }

            // Scroll to bottom
            selectedCommandBack.ScrollControlIntoView(command);
            appPanel_list[selectedAppTag - 1].ScrollControlIntoView(command);

            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveMoveCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void MoveCommandMinusBtn_Click(object sender, EventArgs e)
        {
            Control senderBtn = (Control)sender;
            Control command = senderBtn.Parent;
            commandClickedName = Convert.ToInt32(command.Name);
            UI.CloseAllPanels();

            Control findActuatorsLabel = command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
            Control findaddButton = command.Controls.Find("addBtn", false).FirstOrDefault();

            findaddButton.Tag = (int)findaddButton.Tag - 1;

            int btnHeightBefore = command.Height;
            if ((int)findaddButton.Tag == 0)
            {
                command.Height = 100;
                findaddButton.Top = 70;
                findActuatorsLabel.Top = 72;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("20", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("21", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("22", false).FirstOrDefault());
            }
            else if ((int)findaddButton.Tag == 1)
            {
                command.Height = 143;
                findaddButton.Top = 115;
                findActuatorsLabel.Top = 117;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("24", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("25", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("26", false).FirstOrDefault());
            }
            else //if ((int)findaddButton.Tag == 2)
            {
                command.Height = 188;
                findaddButton.Top = 160;
                findActuatorsLabel.Top = 162;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("28", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("29", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("30", false).FirstOrDefault());
            }

            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveMoveCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void MoveCommandComboBox4_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox sendercomboBox = (Guna2ComboBox)sender;
            Control command = sendercomboBox.Parent;
            Label findMotionLabel = (Label)command.Controls.Find("motionLabel", false).FirstOrDefault();

            if (sendercomboBox.SelectedItem.ToString() == "Amount Of Time" & (int)findMotionLabel.Tag != 1)
            {
                findMotionLabel.Tag = 1;
                MoveCommandRemoveUntil(command);
                MoveCommandRemoveMoveToPosition(command);
                MoveCommandRemoveMoveDistance(command);

                // Label
                Label label = UI.ConstructLabel("Milliseconds / Variable", 11, true, new Point(750, 5), "10", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 30), command);
                gTextBox.Name = "11";
                gTextBox.LostFocus += MoveCommandSave;
                gTextBox.Click += ShowVariableBox;
                gTextBox.TextChanged += VariableTextBoxChanged;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[4];

                // Label
                label.BackColor = CustomColors.controlBack;
                label.BringToFront();

                Control findAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();
                for (int i = 0; i < (int)findAddBtn.Tag; i++)
                {
                    // TextBox
                    gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 30 + 45 * (i + 1)), command);
                    gTextBox.Name = (22 + (i * 4)).ToString(); // 22, 26, 30
                    gTextBox.LostFocus += MoveCommandSave;
                    gTextBox.Click += ShowVariableBox;
                    gTextBox.TextChanged += VariableTextBoxChanged;
                    if (isProgramBeingLoaded || isCommandBeingDuplicated)
                        gTextBox.Text = loadCommandData[5 + i];  // 5, 6, 7

                    // Label
                    label.BackColor = CustomColors.controlBack;
                    label.BringToFront();
                }
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Until" & (int)findMotionLabel.Tag != 2)
            {
                findMotionLabel.Tag = 2;
                MoveCommandRemoveAmountOfTime(command);
                MoveCommandRemoveMoveToPosition(command);
                MoveCommandRemoveMoveDistance(command);

                // Label
                Label label = UI.ConstructLabel("Event", 11, true, new Point(750, 5), "13", command);
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(750, 30), command);
                gComboBox.Name = "14";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[12];  // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += MoveCommandSave;
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Move To Position" & (int)findMotionLabel.Tag != 3)
            {
                findMotionLabel.Tag = 3;
                MoveCommandRemoveAmountOfTime(command);
                MoveCommandRemoveUntil(command);
                MoveCommandRemoveMoveDistance(command);

                // Label
                Label label = UI.ConstructLabel("Position", 11, true, new Point(750, 5), "15", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 30), command);
                gTextBox.Name = "16";
                gTextBox.LostFocus += MoveCommandSave;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[13];

                // Disable direction ComboBox because it's irrelevant
                Control f2 = command.Controls.Find("2", false).FirstOrDefault();
                f2.Text = "";
                f2.Enabled = false;
                Control fDirection = command.Controls.Find("direction", false).FirstOrDefault();
                fDirection.Enabled = false;
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Move Distance" & (int)findMotionLabel.Tag != 4)
            {
                findMotionLabel.Tag = 4;
                MoveCommandRemoveAmountOfTime(command);
                MoveCommandRemoveUntil(command);
                MoveCommandRemoveMoveToPosition(command);

                // Label
                Label label = UI.ConstructLabel("Distance", 11, true, new Point(750, 5), "17", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 30), command);
                gTextBox.Name = "18";
                gTextBox.LostFocus += MoveCommandSave;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[14];
            }

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveMoveCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void MoveCommandRemoveAmountOfTime(Control control)
        {
            Control addButton = control.Controls.Find("addBtn", false).FirstOrDefault();
            Control f10 = control.Controls.Find("10", false).FirstOrDefault();
            control.Controls.Remove(f10);
            control.Controls.Remove(control.Controls.Find("11", false).FirstOrDefault());

            if ((int)addButton.Tag >= 1)
                control.Controls.Remove(control.Controls.Find("22", false).FirstOrDefault());
            if ((int)addButton.Tag >= 2)
                control.Controls.Remove(control.Controls.Find("26", false).FirstOrDefault());
            if ((int)addButton.Tag == 3)
                control.Controls.Remove(control.Controls.Find("30", false).FirstOrDefault());
        }
        private static void MoveCommandRemoveUntil(Control command)
        {
            command.Controls.Remove(command.Controls.Find("13", false).FirstOrDefault());
            command.Controls.Remove(command.Controls.Find("14", false).FirstOrDefault());
        }
        private static void MoveCommandRemoveMoveToPosition(Control command)
        {
            command.Controls.Remove(command.Controls.Find("15", false).FirstOrDefault());
            command.Controls.Remove(command.Controls.Find("16", false).FirstOrDefault());

            // Enable direction ComboBox
            Control f2 = command.Controls.Find("2", false).FirstOrDefault();
            f2.Enabled = true;
            Control fDirection = command.Controls.Find("direction", false).FirstOrDefault();
            fDirection.Enabled = true;
        }
        private static void MoveCommandRemoveMoveDistance(Control command)
        {
            command.Controls.Remove(command.Controls.Find("17", false).FirstOrDefault());
            command.Controls.Remove(command.Controls.Find("18", false).FirstOrDefault());
        }
        private static void MoveCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control command = (Control)sender;
                SaveMoveCommandInFile(command.Parent, false);
            }
        }


        // Home command
        public static void ConstructHomeCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "homeCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Home", 11, true, new Point(50, 5), "", command);
            // ComboBox
            Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.Name = "1";
            gComboBox.Items.Add("All Actuators");
            gComboBox.Items.Add("Actuator");
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                HomeCommandComboBox_SelectedIndexChanged(sender, loadCommandData);
            };
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[0];  // Must be after SelectedIndexChanged
            }

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                HomeCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveHomeCommandInFile(command, true);
            }
            if (loadCommandData != null)
            {
                if (loadCommandData[6] == "1")  // Should the command be hidden
                    gBtn.PerformClick();
            }
        }
        private static void HomeCommandComboBox_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox sendercomboBox = (Guna2ComboBox)sender;
            Control command = sendercomboBox.Parent;
            int btnHeightBefore = command.Height;

            if (sendercomboBox.SelectedItem.ToString() == "All Actuators")
            {
                command.Height = 75;

                // Remove 'Actuators'
                command.Controls.Remove(command.Controls.Find("2", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("3", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("addBtn", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("actuatorsLabel", false).FirstOrDefault());

                command.Controls.Remove(command.Controls.Find("20", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("21", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("22", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("23", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("24", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("25", false).FirstOrDefault());
            }

            else if (sendercomboBox.SelectedItem.ToString() == "Actuator")
            {
                command.Height = 100;

                // Label
                Label label = UI.ConstructLabel("Actuator", 11, true, new Point(240, 5), "2", command);
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
                gComboBox.Name = "3";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[1];  // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += HomeCommandSave;

                // 'add' button
                Guna2CircleButton gCircleBtn = UI.ConstructGCircleBtn(Resources.Plus, new Size(23, 23), new Point(240, 70), command);
                gCircleBtn.Name = "addBtn";
                gCircleBtn.Tag = 0;
                gCircleBtn.Click += (sender2, e2) =>
                {
                    HomeCommandAddButton_Click(sender2, loadCommandData);
                };
                // Label
                UI.ConstructLabel("Actuators", 12, false, new Point(270, 70), "actuatorsLabel", command);

                // Click add button
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    if (loadCommandData[1] != "")
                    {
                        Guna2CircleButton addBtn = gCircleBtn;
                        for (int i = 0; i < Convert.ToInt32(loadCommandData[1]); i++)
                        {
                            addBtn.Tag = i;
                            addBtn.PerformClick();
                        }
                    }
                }
            }

            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveHomeCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void HomeCommandAddButton_Click(object sender, List<string> loadCommandData)
        {
            Control senderBtn = (Control)sender;
            Control command = senderBtn.Parent;
            senderBtn.Tag = (int)senderBtn.Tag + 1;
            commandClickedName = Convert.ToInt32(command.Name);
            UI.CloseAllPanels();

            Label findActuatorsLabel = (Label)command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
            Label findMotionLabel = (Label)command.Controls.Find("motionLabel", false).FirstOrDefault();

            int btnHeightBefore = command.Height;
            for (int i = (int)senderBtn.Tag - 1; i < (int)senderBtn.Tag; i++)
            {
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 75 + 45 * i), command);
                gComboBox.Name = (20 + (i * 2)).ToString();  // 20, 22, 24
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[2 + i];  // 2, 3, 4, 5    // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += MoveCommandSave;

                // Minus button
                Guna2CircleButton gCircleBtn = UI.ConstructGCircleBtn(Resources.Minus, new Size(23, 23), new Point(210, 75 + 45 * i), command);
                gCircleBtn.Name = (21 + (i * 2)).ToString();  // 21, 23, 25
                gCircleBtn.Click += HomeCommandMinusBtn_Click;
            }

            if ((int)senderBtn.Tag == 1)
            {
                command.Height = 143;
                senderBtn.Top = 115;
                findActuatorsLabel.Top = 117;
            }
            else if ((int)senderBtn.Tag == 2)
            {
                command.Height = 188;
                senderBtn.Top = 160;
                findActuatorsLabel.Top = 162;
            }
            else if ((int)senderBtn.Tag == 3)
            {
                command.Height = 205;
                senderBtn.Top = 230;
                findActuatorsLabel.Top = 230;  // Hide Actuators Label
            }

            // Scroll to bottom
            selectedCommandBack.ScrollControlIntoView(command);
            appPanel_list[selectedAppTag - 1].ScrollControlIntoView(command);

            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveHomeCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void HomeCommandMinusBtn_Click(object sender, EventArgs e)
        {
            Control senderBtn = (Control)sender;
            Control command = senderBtn.Parent;
            commandClickedName = Convert.ToInt32(command.Name);
            UI.CloseAllPanels();

            Control findActuatorsLabel = command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
            Control findaddButton = command.Controls.Find("addBtn", false).FirstOrDefault();

            findaddButton.Tag = (int)findaddButton.Tag - 1;

            int btnHeightBefore = command.Height;
            if ((int)findaddButton.Tag == 0)
            {
                command.Height = 100;
                findaddButton.Top = 70;
                findActuatorsLabel.Top = 72;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("20", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("21", false).FirstOrDefault());
            }
            else if ((int)findaddButton.Tag == 1)
            {
                command.Height = 143;
                findaddButton.Top = 115;
                findActuatorsLabel.Top = 117;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("22", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("23", false).FirstOrDefault());
            }
            else //if ((int)findaddButton.Tag == 2)
            {
                command.Height = 188;
                findaddButton.Top = 160;
                findActuatorsLabel.Top = 162;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("24", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("25", false).FirstOrDefault());
            }
            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveHomeCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void HomeCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveHomeCommandInFile(btn.Parent, false);
            }
        }


        // Delay command
        public static void ConstructDelayCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "delayCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Delay", 11, true, new Point(50, 5), "", command);
            // ComboBox
            Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.Items.Add("Until");
            gComboBox.Items.Add("Amount Of Time");
            gComboBox.Name = "1";
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                DelayComboBox_SelectedIndexChanged(sender, loadCommandData);
            };
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[0];  // Must be after the first SelectedIndexChanged, and before the second
            }
            gComboBox.LostFocus += DelayCommandSave;

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                DelayCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);


            // Should the command be hidden
            if (loadCommandData != null)
            {
                if (loadCommandData[3] == "1")
                    gBtn.PerformClick();
            }

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveDelayCommandInFile(command, true);
            }
        }
        private static void DelayComboBox_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox senderComboBox = (Guna2ComboBox)sender;
            Control command = senderComboBox.Parent;

            if (senderComboBox.SelectedItem.ToString() == "Until")
            {
                // Remove 'Amount Of Time'.
                command.Controls.Remove((Label)command.Controls.Find("5", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("6", false).FirstOrDefault());

                // Label
                Label label = UI.ConstructLabel("Event", 11, true, new Point(240, 5), "2", command);
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
                gComboBox.Name = "3";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[1];  // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += DelayCommandSave;
            }

            else if (senderComboBox.SelectedItem.ToString() == "Amount Of Time")
            {
                // Remove 'Until'.
                command.Controls.Remove((Label)command.Controls.Find("2", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("3", false).FirstOrDefault());

                // Label
                Label label = UI.ConstructLabel("Milliseconds/ Variable", 11, true, new Point(240, 5), "5", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(240, 30), command);
                gTextBox.Name = "6";
                gTextBox.LostFocus += DelayCommandSave;
                gTextBox.Click += ShowVariableBox;
                gTextBox.TextChanged += VariableTextBoxChanged;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[2];
            }

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveDelayCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        public static void DelayCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveDelayCommandInFile(btn.Parent, false);
            }
        }


        // Run command
        public static void ConstructRunCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "runCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Run", 11, true, new Point(50, 5), "", command);
            // ComboBox
            Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.Items.Add("Run sequence");
            gComboBox.Items.Add("Run function");
            gComboBox.Name = "1";
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[0];  // Must be before SelectedIndexChanged
            }
            gComboBox.LostFocus += RunCommandSave;
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                RunComboBox_SelectedIndexChanged(sender, loadCommandData);
            };

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                RunCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";

            // Should the command be hidden
            if (loadCommandData != null)
            {
                if (loadCommandData[6] == "1")
                    gBtn.PerformClick();
            }

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveRunCommandInFile(command, true);
            }
        }
        private static void RunComboBox_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox senderComboBox = (Guna2ComboBox)sender;
            Control command = senderComboBox.Parent;
            Guna2ComboBox gComboBox;

            if (senderComboBox.Text == "Run function")
            {
                Label f8 = (Label)command.Controls.Find("8", false).FirstOrDefault();
                Guna2ComboBox f9 = (Guna2ComboBox)command.Controls.Find("9", false).FirstOrDefault();
                Label f10 = (Label)command.Controls.Find("10", false).FirstOrDefault();
                Guna2ComboBox f11 = (Guna2ComboBox)command.Controls.Find("11", false).FirstOrDefault();

                // Label
                Label label = UI.ConstructLabel("In sequence", 11, true, new Point(240, 5), "2", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
                gComboBox.DropDown += RunInSequenceComboBox_DropDown;
                gComboBox.Name = "3";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Items.Add(loadCommandData[1]);  // Must be before SelectedIndexChanged
                    gComboBox.Text = loadCommandData[1];
                }
                gComboBox.LostFocus += RunCommandSave;

                // Label
                label = UI.ConstructLabel("Function", 11, true, new Point(430, 5), "4", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(430, 30), command);
                gComboBox.DropDown += RunFunctionComboBox_DropDown;
                gComboBox.Name = "5";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Items.Add(loadCommandData[2]);  // Must be before SelectedIndexChanged
                    gComboBox.Text = loadCommandData[2];
                }
                gComboBox.LostFocus += RunCommandSave;

                // Label
                UI.ConstructLabel("Method", 11, true, new Point(620, 5), "6", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(620, 30), command);
                gComboBox.Items.Add("Run synchronously");
                // UIControls.gunaComboBox.Items.Add("Run asynchronously");
                gComboBox.Name = "7";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Items.Add(loadCommandData[3]);  // Must be before SelectedIndexChanged
                    gComboBox.Text = loadCommandData[3];
                }
                gComboBox.LostFocus += RunCommandSave;

                command.Controls.Remove(f8);
                command.Controls.Remove(f9);
                command.Controls.Remove(f10);
                command.Controls.Remove(f11);
            }
            else if (senderComboBox.Text == "Run sequence")
            {
                Label f2 = (Label)command.Controls.Find("2", false).FirstOrDefault();
                Guna2ComboBox f3 = (Guna2ComboBox)command.Controls.Find("3", false).FirstOrDefault();
                Label f4 = (Label)command.Controls.Find("4", false).FirstOrDefault();
                Guna2ComboBox f5 = (Guna2ComboBox)command.Controls.Find("5", false).FirstOrDefault();
                Label f6 = (Label)command.Controls.Find("6", false).FirstOrDefault();
                Guna2ComboBox f7 = (Guna2ComboBox)command.Controls.Find("7", false).FirstOrDefault();

                // Label
                Label label = UI.ConstructLabel("Sequence", 11, true, new Point(240, 5), "8", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
                gComboBox.DropDown += RunInSequenceComboBox_DropDown;
                gComboBox.Name = "9";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Items.Add(loadCommandData[4]);  // Must be before SelectedIndexChanged
                    gComboBox.Text = loadCommandData[4];
                }
                gComboBox.LostFocus += RunCommandSave;

                // Label
                label = UI.ConstructLabel("Method", 11, true, new Point(430, 5), "10", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(430, 30), command);
                gComboBox.Items.Add("Run synchronously");
                // UIControls.gunaComboBox.Items.Add("Run asynchronously");
                gComboBox.Name = "11";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Items.Add(loadCommandData[5]);  // Must be before SelectedIndexChanged
                    gComboBox.Text = loadCommandData[5];
                }
                gComboBox.LostFocus += RunCommandSave;

                command.Controls.Remove(f2);
                command.Controls.Remove(f3);
                command.Controls.Remove(f4);
                command.Controls.Remove(f5);
                command.Controls.Remove(f6);
                command.Controls.Remove(f7);
            }

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveRunCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void RunInSequenceComboBox_DropDown(object sender, EventArgs e)
        {
            Guna2ComboBox senderComboBox = (Guna2ComboBox)sender;
            Guna2Button command = (Guna2Button)senderComboBox.Parent;
            Guna2ComboBox f5 = (Guna2ComboBox)command.Controls.Find("5", false).FirstOrDefault();

            string saveText = senderComboBox.Text;
            senderComboBox.Items.Clear();
            foreach (string item in from item in GetListOfSequenceNames()
                                    where item != ""
                                    select item)
            {
                senderComboBox.Items.Add(item);
            }

            senderComboBox.Text = saveText;

            if (f5 != null)
            {
                f5.Items.Clear();
                f5.Text = "";
            }
        }
        private static void RunFunctionComboBox_DropDown(object sender, EventArgs e)
        {
            Guna2ComboBox senderComboBox = (Guna2ComboBox)sender;
            Guna2Button btn = (Guna2Button)senderComboBox.Parent;
            Guna2ComboBox f5 = (Guna2ComboBox)btn.Controls.Find("3", false).FirstOrDefault();

            string saveText = senderComboBox.Text;
            senderComboBox.Items.Clear();

            // Find the sequence that is selected in the sequence ComboBox
            for (int i = 0; i < appPanelFlowPanelSelected.Controls.Count; i++)
            {
                if (appPanelFlowPanelSelected.Controls[i].Controls[0].Text == f5.Text)
                {
                    sequenceFlowPanelSelected = (FlowLayoutPanel)appPanelFlowPanelSelected.Controls[i].Controls[1];
                    break;
                }
            }

            foreach (var item in
            // Add the functions in the function ComboBox
            from string item in GetListOfFunctionNames()
            where item != ""
            select item)
            {
                senderComboBox.Items.Add(item);
            }

            senderComboBox.Text = saveText;
        }
        private static void RunCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveRunCommandInFile(btn.Parent, false);
            }
        }


        // Add loop command
        public static void ConstructLoopCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "loopCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Loop", 11, true, new Point(50, 5), "", command);

            // ComboBox
            Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.Items.Add("Motion");
            gComboBox.Items.Add("Delay");
            gComboBox.Name = "loopComboBox";
            gComboBox.Tag = 0;
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                LoopComboBox_SelectedIndexChanged(sender, loadCommandData);
            };
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[0];  // Must be after SelectedIndexChanged
            }

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                LoopCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";

            // Should the command be hidden
            if (loadCommandData != null)
            {
                if (loadCommandData[15] == "1")
                    gBtn.PerformClick();
            }

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveLoopCommandInFile(command, true);
            }
        }
        private static void LoopComboBox_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox sendercomboBox = (Guna2ComboBox)sender;
            Control command = sendercomboBox.Parent;
            Guna2ComboBox findloopComboBox = (Guna2ComboBox)command.Controls.Find("loopComboBox", false).FirstOrDefault();
            Guna2ComboBox gComboBox;

            if (sendercomboBox.SelectedItem.ToString() == "Motion" & (int)findloopComboBox.Tag != 1)
            {
                findloopComboBox.Tag = 1;

                // Label
                Label label = UI.ConstructLabel("Actuator", 11, true, new Point(50, 70), "8", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 100), command);
                gComboBox.Name = "9";
                gComboBox.Click += CloseAllPanels;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[10];  // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += LoopCommandSave;

                // Label
                label = UI.ConstructLabel("Direction", 11, true, new Point(240, 70), "3", command);
                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 100), command);
                gComboBox.Name = "4";
                gComboBox.Items.Add("Clockwise");
                gComboBox.Items.Add("Counter-Clockwise");
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[2];  // Must be before SelectedIndexChanged
                }
                gComboBox.LostFocus += LoopCommandSave;

                // Label
                UI.ConstructLabel("Speed", 11, true, new Point(430, 70), "5", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(120, 36), new Point(430, 100), command);
                gTextBox.Name = "6";
                gTextBox.LostFocus += LoopCommandSave;
                gTextBox.Click += ShowVariableBox;
                gTextBox.TextChanged += VariableTextBoxChanged;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[3];

                // Label
                label = UI.ConstructLabel("Motion", 11, true, new Point(560, 70), "motionLabel", command);
                label.Tag = 0;

                // addBtn
                Guna2CircleButton gCircleBtn = UI.ConstructGCircleBtn(Resources.Plus, new Size(23, 23), new Point(50, 140), command);
                gCircleBtn.Name = "addBtn";
                gCircleBtn.Tag = 0;
                gCircleBtn.Click += (sender2, e2) =>
                {
                    LoopAddBtn_Click(sender2, loadCommandData);
                };

                // ComboBox
                gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(560, 100), command);
                gComboBox.Name = "7";
                gComboBox.Items.Add("Amount Of Time");
                gComboBox.Items.Add("Until");
                gComboBox.Items.Add("Move To Home");
                gComboBox.SelectedIndexChanged += (sender2, e2) =>
                {
                    LoopComboBox4_SelectedIndexChanged(sender2, loadCommandData);
                };
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gComboBox.Text = loadCommandData[4];  // Must be after SelectedIndexChanged
                }

                // Label
                UI.ConstructLabel("Actuators", 12, false, new Point(80, 140), "actuatorsLabel", command);

                // Click add button
                Guna2CircleButton addBtn = gCircleBtn;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    if (loadCommandData[5] != "")
                    {
                        for (int i = 0; i < int.Parse(loadCommandData[5]); i++)
                        {
                            addBtn.PerformClick();
                        }
                    }
                }

                int btnHeightBefore = command.Height;

                // Set size of backround
                Control findAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();
                Control findactuatorsLabel = command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
                if (findAddBtn != null)
                {
                    if ((int)findAddBtn.Tag == 0)
                    {
                        command.Height = 170;
                    }
                    else if ((int)findAddBtn.Tag == 1)
                    {
                        command.Height = 213;
                        findAddBtn.Top = 185;
                        findactuatorsLabel.Top = 187;
                    }
                    else if ((int)findAddBtn.Tag == 2)
                    {
                        command.Height = 258;
                        findAddBtn.Top = 230;
                        findactuatorsLabel.Top = 232;
                    }
                    else if ((int)findAddBtn.Tag == 3)
                    {
                        command.Height = 280;
                        findAddBtn.Top = 300;
                        findactuatorsLabel.Top = 300;  // Hide Actuators Label
                    }
                }

                // Scroll to bottom
                selectedCommandBack.ScrollControlIntoView(command);

                MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);
            }

            else if (sendercomboBox.SelectedItem.ToString() == "Delay" & (int)findloopComboBox.Tag != 2)
            {
                findloopComboBox.Tag = 2;

                LoopCommandRemoveAmountOfTime(command);
                LoopCommandRemoveUntil(command);

                // Set height of backround
                int btnHeightBefore = command.Height;
                command.Height = 75;

                MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

                // Remove motion
                Control findMotionLabel = command.Controls.Find("motionLabel", false).FirstOrDefault();
                Control f8 = command.Controls.Find("8", false).FirstOrDefault();
                if (f8 != null)
                {
                    Control fAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();
                    command.Controls.Remove(f8);
                    command.Controls.Remove(command.Controls.Find("9", false).FirstOrDefault());
                    command.Controls.Remove(command.Controls.Find("3", false).FirstOrDefault());
                    command.Controls.Remove(command.Controls.Find("4", false).FirstOrDefault());
                    command.Controls.Remove(command.Controls.Find("5", false).FirstOrDefault());
                    command.Controls.Remove(command.Controls.Find("6", false).FirstOrDefault());
                    command.Controls.Remove(command.Controls.Find("7", false).FirstOrDefault());
                    command.Controls.Remove(findMotionLabel);
                    command.Controls.Remove(command.Controls.Find("actuatorsLabel", false).FirstOrDefault());

                    Control findAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();
                    if ((int)findAddBtn.Tag >= 0)
                    {
                        command.Controls.Remove(command.Controls.Find("20", false).FirstOrDefault());
                        command.Controls.Remove(command.Controls.Find("21", false).FirstOrDefault());
                        if ((int)findMotionLabel.Tag == 1)
                            command.Controls.Remove(command.Controls.Find("22", false).FirstOrDefault());
                    }
                    if ((int)findAddBtn.Tag >= 1)
                    {
                        command.Controls.Remove(command.Controls.Find("24", false).FirstOrDefault());
                        command.Controls.Remove(command.Controls.Find("25", false).FirstOrDefault());
                        if ((int)findMotionLabel.Tag == 1)
                            command.Controls.Remove(command.Controls.Find("26", false).FirstOrDefault());
                    }
                    if ((int)findAddBtn.Tag >= 2)
                    {
                        command.Controls.Remove(command.Controls.Find("28", false).FirstOrDefault());
                        command.Controls.Remove(command.Controls.Find("29", false).FirstOrDefault());
                        if ((int)findMotionLabel.Tag == 1)
                            command.Controls.Remove(command.Controls.Find("30", false).FirstOrDefault());
                    }
                    command.Controls.Remove(fAddBtn);
                }
            }

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveLoopCommandInFile(command, false);
        }
        private static void LoopComboBox4_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox sendercomboBox = (Guna2ComboBox)sender;
            Control command = sendercomboBox.Parent;
            Label findMotionLabel = (Label)command.Controls.Find("motionLabel", false).FirstOrDefault();

            if (sendercomboBox.SelectedItem.ToString() == "Amount Of Time" & (int)findMotionLabel.Tag != 1)
            {
                findMotionLabel.Tag = 1;
                LoopCommandRemoveUntil(command);
                LoopCommandRemoveMoveToHome(command);

                // Label
                Label label = UI.ConstructLabel("Milliseconds/ Variable", 11, true, new Point(750, 70), "10", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 100), command);
                gTextBox.Name = "11";
                gTextBox.LostFocus += LoopCommandSave;
                gTextBox.Click += ShowVariableBox;
                gTextBox.TextChanged += VariableTextBoxChanged;
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                {
                    gTextBox.Text = loadCommandData[6];
                }
                // Label
                label.BackColor = CustomColors.controlBack;
                label.BringToFront();

                Control findAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();
                for (int i = 0; i < (int)findAddBtn.Tag; i++)
                {
                    // TextBox
                    gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 100 + 45 * (i + 1)), command);
                    gTextBox.Name = (22 + (i * 4)).ToString(); // 22, 26, 30
                    gTextBox.LostFocus += LoopCommandSave;
                    // Label
                    label.BackColor = CustomColors.controlBack;
                    label.BringToFront();
                }
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Until" & (int)findMotionLabel.Tag != 2)
            {
                findMotionLabel.Tag = 2;
                LoopCommandRemoveAmountOfTime(command);
                LoopCommandRemoveMoveToHome(command);

                // Label
                Label label = UI.ConstructLabel("Event", 11, true, new Point(750, 70), "13", command);
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(750, 100), command);
                gComboBox.Name = "14";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gComboBox.Text = loadCommandData[7];
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Move To Home" & (int)findMotionLabel.Tag != 3)
            {
                findMotionLabel.Tag = 3;

                LoopCommandRemoveUntil(command);
                LoopCommandRemoveAmountOfTime(command);

                // Button
                Guna2Button gBtn = UI.ConstructGBtn(null, "Configure home position", 2, new Size(184, 22), new Point(558, 140), command);
                gBtn.Font = new Font("Segoe UI", 10);
                gBtn.ForeColor = Color.Black;
                gBtn.Name = "15";
                gBtn.Click += (sender1, e1) =>
                {

                };
            }

            // Save
            UpdateCommandBackgroundColor(command);

            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveLoopCommandInFile(command, false);
        }
        private static void LoopCommandRemoveAmountOfTime(Control command)
        {
            command.Controls.Remove(command.Controls.Find("10", false).FirstOrDefault());
            command.Controls.Remove(command.Controls.Find("11", false).FirstOrDefault());
            Control addBtn = command.Controls.Find("addBtn", false).FirstOrDefault();

            if (addBtn != null)
            {
                if ((int)addBtn.Tag >= 1)
                    command.Controls.Remove(command.Controls.Find("22", false).FirstOrDefault());
                if ((int)addBtn.Tag >= 2)
                    command.Controls.Remove(command.Controls.Find("26", false).FirstOrDefault());
                if ((int)addBtn.Tag == 3)
                    command.Controls.Remove(command.Controls.Find("30", false).FirstOrDefault());
            }
        }
        private static void LoopCommandRemoveUntil(Control command)
        {
            command.Controls.Remove(command.Controls.Find("13", false).FirstOrDefault());
            command.Controls.Remove(command.Controls.Find("14", false).FirstOrDefault());
        }
        private static void LoopCommandRemoveMoveToHome(Control command)
        {
            command.Controls.Remove(command.Controls.Find("15", false).FirstOrDefault());
        }
        private static void LoopAddBtn_Click(object sender, List<string> loadCommandData)
        {
            Control senderBtn = (Control)sender;
            Control command = senderBtn.Parent;

            Control findAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();

            findAddBtn.Tag = (int)findAddBtn.Tag + 1;
            commandClickedName = Convert.ToInt32(command.Name);
            UI.CloseAllPanels();

            Label findActuatorsLabel = (Label)command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
            Label findMotionLabel = (Label)command.Controls.Find("motionLabel", false).FirstOrDefault();

            int btnHeightBefore = command.Height;
            for (int i = (int)findAddBtn.Tag - 1; i < (int)findAddBtn.Tag; i++)
            {
                // ComboBox
                Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 145 + 45 * i), command);
                gComboBox.Name = (20 + (i * 4)).ToString();  // 20, 24, 28
                gComboBox.LostFocus += LoopCommandSave;
                // Minus button
                Guna2CircleButton gCircleBtn = UI.ConstructGCircleBtn(Resources.Minus, new Size(23, 23), new Point(20, 145 + 45 * i), command);
                gCircleBtn.Name = (21 + (i * 4)).ToString();  // 21, 25, 29
                gCircleBtn.Click += LoopMinusBtn_Click;

                if ((int)findMotionLabel.Tag == 1)
                {
                    // TextBox
                    Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(750, 145 + 45 * i), command);
                    gTextBox.LostFocus += LoopCommandSave;
                    gTextBox.Name = (22 + (i * 4)).ToString();  // 22, 26, 30
                    gTextBox.Click += ShowVariableBox;
                    gTextBox.TextChanged += VariableTextBoxChanged;
                    if (isProgramBeingLoaded || isCommandBeingDuplicated)
                        gTextBox.Text = loadCommandData[7 + i];
                }
            }

            if ((int)findAddBtn.Tag == 1)
            {
                command.Height = 213;
                senderBtn.Top = 185;
                findActuatorsLabel.Top = 187;
            }
            else if ((int)findAddBtn.Tag == 2)
            {
                command.Height = 258;
                senderBtn.Top = 230;
                findActuatorsLabel.Top = 232;
            }
            else // if ((int)findLoopLabel.Tag == 3)
            {
                command.Height = 280;
                senderBtn.Top = 300;
                findActuatorsLabel.Top = 300;  // Hide Actuators Label
            }

            // Scroll to bottom
            selectedCommandBack.ScrollControlIntoView(command);

            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveLoopCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void LoopMinusBtn_Click(object sender, EventArgs e)
        {
            Control senderBtn = (Control)sender;
            Control command = senderBtn.Parent;
            commandClickedName = Convert.ToInt32(command.Name);
            UI.CloseAllPanels();

            Label findMotionLabel = (Label)command.Controls.Find("motionLabel", false).FirstOrDefault();
            Control findActuatorsLabel = command.Controls.Find("actuatorsLabel", false).FirstOrDefault();
            Control findAddBtn = command.Controls.Find("addBtn", false).FirstOrDefault();

            findAddBtn.Tag = (int)findAddBtn.Tag - 1;

            int btnHeightBefore = command.Height;
            if ((int)findAddBtn.Tag == 0)
            {
                command.Height = 170;
                findAddBtn.Top = 140;
                findActuatorsLabel.Top = 142;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("20", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("21", false).FirstOrDefault());
                if ((int)findMotionLabel.Tag == 1)
                    command.Controls.Remove(command.Controls.Find("22", false).FirstOrDefault());
            }
            else if ((int)findAddBtn.Tag == 1)
            {
                command.Height = 213;
                findAddBtn.Top = 185;
                findActuatorsLabel.Top = 187;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("24", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("25", false).FirstOrDefault());
                if ((int)findMotionLabel.Tag == 1)
                    command.Controls.Remove(command.Controls.Find("26", false).FirstOrDefault());
            }
            else // if ((int)findaddButton.Tag == 2)
            {
                command.Height = 258;
                findAddBtn.Top = 230;
                findActuatorsLabel.Top = 232;
                // Remove controls
                command.Controls.Remove(command.Controls.Find("28", false).FirstOrDefault());
                command.Controls.Remove(command.Controls.Find("29", false).FirstOrDefault());
                if ((int)findMotionLabel.Tag == 1)
                    command.Controls.Remove(command.Controls.Find("30", false).FirstOrDefault());
            }

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveLoopCommandInFile(command, false);

            MoveBelowCommandsUpOrDown(btnHeightBefore, command.Height, command.Name);
            UpdateCommandBackgroundColor(command);
        }
        private static void LoopCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveLoopCommandInFile(btn.Parent, false);
            }
        }


        // Set variable command
        public static void ConstructSetVariableCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "setVariableCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Set varable", 11, true, new Point(50, 5), "", command);
            // ComboBox
            Guna2ComboBox gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.DropDown += (sender, e) =>
            {
                // Add the list of variables to the ComboBox
                Guna2ComboBox comboBox = (Guna2ComboBox)sender;
                comboBox.Items.Clear();
                foreach (string item in variableNames_list)
                {
                    comboBox.Items.Add(item);
                }
            };
            gComboBox.Name = "1";
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Items.Add(loadCommandData[0]);  // Must be before SelectedIndexChanged
                gComboBox.Text = loadCommandData[0];
            }
            gComboBox.LostFocus += SetVariableCommandSave;

            // Label
            UI.ConstructLabel("Style", 11, true, new Point(240, 5), "", command);
            // ComboBox
            gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
            gComboBox.Items.Add("Set to");
            gComboBox.Items.Add("Increase");
            gComboBox.Items.Add("Decrease");
            gComboBox.Name = "2";
            gComboBox.LostFocus += SetVariableCommandSave;

            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[1];  // Must be after first SelectedIndexChanged, and before second
            }
            gComboBox.SelectedIndexChanged += (sender, e) =>
            {
                SetVariableComboBox_SelectedIndexChanged(sender, loadCommandData);
            };

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                SetVariableCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";

            // Should the command be hidden
            if (loadCommandData != null)
            {
                if (loadCommandData[3] == "1")
                    gBtn.PerformClick();
            }

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveSetVariableCommandInFile(command, true);
            }
        }
        private static void SetVariableComboBox_SelectedIndexChanged(object sender, List<string> loadCommandData)
        {
            Guna2ComboBox sendercomboBox = (Guna2ComboBox)sender;
            Control command = sendercomboBox.Parent;

            if (sendercomboBox.SelectedItem.ToString() == "Set to")
            {
                SetVariableCommandRemoveIncrease(command);
                SetVariableCommandRemoveDecrease(command);

                // Label
                Label label = UI.ConstructLabel("To", 11, true, new Point(430, 5), "3", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(430, 30), command);
                gTextBox.LostFocus += SetVariableCommandSave;
                gTextBox.Name = "4";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[2];
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Increase")
            {
                SetVariableCommandRemoveSetTo(command);
                SetVariableCommandRemoveDecrease(command);

                // Label
                Label label = UI.ConstructLabel("By", 11, true, new Point(430, 5), "5", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(430, 30), command);
                gTextBox.LostFocus += SetVariableCommandSave;
                gTextBox.Name = "6";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[2];
            }
            else if (sendercomboBox.SelectedItem.ToString() == "Decrease")
            {
                SetVariableCommandRemoveSetTo(command);
                SetVariableCommandRemoveIncrease(command);

                // Label
                Label label = UI.ConstructLabel("By", 11, true, new Point(430, 5), "7", command);
                // TextBox
                Guna2TextBox gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(430, 30), command);
                gTextBox.LostFocus += SetVariableCommandSave;
                gTextBox.Name = "8";
                if (isProgramBeingLoaded || isCommandBeingDuplicated)
                    gTextBox.Text = loadCommandData[2];
            }

            // Save
            if (!isProgramBeingLoaded && !isCommandBeingDuplicated)
                SaveSetVariableCommandInFile(command, false);

            UpdateCommandBackgroundColor(command);
        }
        private static void SetVariableCommandRemoveSetTo(Control control)
        {
            Label f3 = (Label)control.Controls.Find("3", false).FirstOrDefault();
            if (f3 != null)
            {
                control.Controls.Remove(f3);
                control.Controls.Remove(control.Controls.Find("4", false).FirstOrDefault());
            }
        }
        private static void SetVariableCommandRemoveIncrease(Control control)
        {
            control.Controls.Remove((Label)control.Controls.Find("5", false).FirstOrDefault());
            control.Controls.Remove(control.Controls.Find("6", false).FirstOrDefault());
        }
        private static void SetVariableCommandRemoveDecrease(Control control)
        {
            control.Controls.Remove((Label)control.Controls.Find("7", false).FirstOrDefault());
            control.Controls.Remove(control.Controls.Find("8", false).FirstOrDefault());
        }
        private static void SetVariableCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveSetVariableCommandInFile(btn.Parent, false);
            }
        }


        // Set output command
        public static void ConstructSetOutputCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            Guna2ComboBox gComboBox;
            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "setOutputCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Set output", 11, true, new Point(50, 5), "", command);
            // ComboBox
            gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(50, 30), command);
            gComboBox.Name = "1";
            for (int i = 1; i <= 12; i++)
            {
                gComboBox.Items.Add(i);
            }
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[0];  // Must be before SelectedIndexChanged
            }
            gComboBox.LostFocus += SetOutputCommandSave;

            // Label
            UI.ConstructLabel("To", 11, true, new Point(240, 5), "", command);
            // ComboBox
            gComboBox = UI.ConstructGComboBox(new Size(180, 30), new Point(240, 30), command);
            gComboBox.Name = "2";
            gComboBox.Items.Add("High");
            gComboBox.Items.Add("Low");
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gComboBox.Text = loadCommandData[1];  // Must be before SelectedIndexChanged
            }
            gComboBox.LostFocus += SetOutputCommandSave;

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                HideCommand(sender, e);
                SetOutputCommandSave(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";


            // Should the command be hidden
            if (loadCommandData != null)
            {
                if (loadCommandData[2] == "1")
                    gBtn.PerformClick();
            }

            // Save
            if (!isEventBeingDuplicated)
            {
                if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                    SaveSetOutputCommandInFile(command, true);
            }
        }
        private static void SetOutputCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveSetOutputCommandInFile(btn.Parent, false);
            }
        }


        // Add event command
        private static string eventNameSelected;
        private static int[] amountOfEvents = new int[1000];
        public static int totalEventCount;
        private static bool isEventBeingRenamed;
        private static Guna2TextBox EventNameTextBoxSelected;
        private static Guna2Button eventCommandSelected;
        public static void ConstructAddEventCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            totalEventCount++;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 100), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.Tag = totalEventCount;
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "eventCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Name textBox
            Guna2TextBox gTextBox = UI.ConstructGTextBox(false, new Size(220, 36), new Point(60, 20), command);
            gTextBox.ShortcutsEnabled = true;
            gTextBox.MaxLength = 24;
            gTextBox.WordWrap = false;
            gTextBox.Name = "name";
            gTextBox.LostFocus += AddEventCommandSave;
            gTextBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter) { RenameEvent(); }
            };
            gTextBox.Click += (sender, e) =>
            {
                Guna2TextBox textBox = (Guna2TextBox)sender;
                eventNameSelected = textBox.Text;
                eventCommandSelected = (Guna2Button)textBox.Parent;
                EventNameTextBoxSelected = textBox;
                isEventBeingRenamed = true;
            };
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                // Set default name. Choose a name that doesn't already exist in the directory
                if (isProgramBeingLoaded || !File.Exists(Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\" + loadCommandData[0] + ".txt"))
                {
                    gTextBox.Text = loadCommandData[0];
                }
                else
                {
                    int count = 2;
                    while (true)
                    {
                        if (!File.Exists(Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\" + loadCommandData[0] + " (" + count + ")" + ".txt"))
                        {
                            gTextBox.Text = loadCommandData[0] + " (" + count + ")";
                            break;
                        }
                        count++;
                    }
                }
            }
            else
            {
                gTextBox.Text = GetNumberNameForAppSequenceFunctionVariableOrEvent("Event ", GetListOfEventNames(), GetTotalNumberOfCommands(selectedCommandBack));
                // Create event.txt
                Directories.CreateFile(Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\" + gTextBox.Text + ".txt");
            }
            eventNameSelected = gTextBox.Text;

            // Construct program event panel
            if (currentThreadCommandBack == null)
            {
                ConstructProgramEventPanel(totalEventCount, gTextBox.Text);
            }

            // Description textBox
            gTextBox = UI.ConstructGTextBox(false, new Size(320, 90), new Point(300, 5), command);
            gTextBox.ShortcutsEnabled = true;
            gTextBox.MaxLength = 160;
            gTextBox.Multiline = true;
            gTextBox.Name = "description";
            gTextBox.PlaceholderText = "Description";
            gTextBox.LostFocus += AddEventCommandSave;
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
            {
                gTextBox.Text = loadCommandData[1];
            }

            // Event (not visible, but it's still used for the programEvent)
            Label label = new Label
            {
                Name = "event",
                Visible = false
            };
            label.LostFocus += AddEventCommandSave;
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
                label.Text = loadCommandData[2];

            command.Controls.Add(label);

            // Modify button
            Guna2Button gBtn = UI.ConstructGBtn(null, "Modify", 2, new Size(120, 30), new Point(670, 35), command);
            gBtn.Name = "modifyBtn";
            gBtn.Tag = selectedAppName;
            gBtn.AutoRoundedCorners = true;
            gBtn.FillColor = Color.FromArgb(26, 200, 118);
            gBtn.Click += (sender, e) =>
            {
                Control btn = (Control)sender;
                int index = (int)btn.Parent.Tag;

                Guna2TextBox name = (Guna2TextBox)btn.Parent.Controls[2];
                Guna2TextBox description = (Guna2TextBox)btn.Parent.Controls[3];

                // Save
                selectedCommandBack = programEventBackPanel_list[index - 1];
                ShowCommandBackSelected();
                ShowMainCommandButtons();
                whatIsSelected = "programEvent";
                eventCommandSelected = (Guna2Button)btn.Parent;
                eventNameSelected = name.Text;

                // Set name, desription and comboBox in ProgramEventBackPanelList
                Guna2TextBox findName = (Guna2TextBox)selectedCommandBack.Controls.Find("name", false).FirstOrDefault();
                Guna2TextBox findDescription = (Guna2TextBox)selectedCommandBack.Controls.Find("description", false).FirstOrDefault();
                Guna2ComboBox findEvent = (Guna2ComboBox)selectedCommandBack.Controls.Find("event", false).FirstOrDefault();
                findName.Text = name.Text;
                findDescription.Text = description.Text;

                // Save
                selectedCommandBack = programEventPanel_list[index - 1];
            };

            // Label
            label = UI.ConstructLabel(amountOfEvents[GetTotalNumberOfCommands(selectedCommandBack)].ToString(), 12, false, new Point(850, 38), "commandCount", command);
            label.TextChanged += AddEventCommandSave;
            if (isProgramBeingLoaded || isCommandBeingDuplicated)
                label.Text = loadCommandData[3];

            // Hide button
            gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += (sender, e) =>
            {
                AddEventCommandSave(sender, e);
                HideCommand(sender, e);
            };
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";

            // Save
            if (!isProgramBeingLoaded || isCommandBeingDuplicated)
                SaveEventCommandInFile(command, true);

            else if (loadCommandData[4] == "1")  // Should the command be hidden
                gBtn.PerformClick();
        }
        private static void AddEventCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveEventCommandInFile(btn.Parent, false);
            }
        }


        // Add variable command
        public static List<string> variableNames_list = new List<string>();
        public static List<int> variableValues_list = new List<int>();
        public static int totalVariableCount;
        private static string oldVariableName;
        private static Guna2TextBox selectedVariableTextBox;
        public static void ConstructAddVariableCommand(Guna2Panel currentThreadCommandBack, List<string> loadCommandData)
        {
            Guna2Panel commandBack;
            if (currentThreadCommandBack != null)
                commandBack = currentThreadCommandBack;
            else
                commandBack = selectedCommandBack;

            totalVariableCount++;

            // Backround
            Guna2Button command = UI.ConstructCommand(new Size(983, 75), GetTotalCommandHeight(commandBack) + 6, commandBack);
            command.Name = GetTotalNumberOfCommands(commandBack).ToString();
            command.MouseDown += Command_MouseDown;
            command.MouseDoubleClick += Command_MouseDoubleClick;
            command.MouseMove += Command_MouseMove;
            command.MouseUp += Command_MouseUp;
            command.KeyDown += Command_KeyDown;

            commandBack.ScrollControlIntoView(command);

            // Number label
            Label numberLabel = UI.ConstructNumberLabel(GetTotalNumberOfCommands(commandBack).ToString(), "addVariableCommand", command);

            // Picture
            UI.ConstructPicture(Resources.Temp, new Size(25, 25), new Point(10, 30), command);

            // Label
            UI.ConstructLabel("Variable name", 11, true, new Point(50, 5), "", command);
            // TextBox
            Guna2TextBox gTextBox = UI.ConstructGTextBox(false, new Size(180, 36), new Point(50, 30), command);
            gTextBox.Click -= CloseAllPanels;
            gTextBox.Name = "1";
            gTextBox.MaxLength = 20;

            // Set the variable name
            if (isProgramBeingLoaded)
                gTextBox.Text = loadCommandData[0];
            else
                gTextBox.Text = GetNumberNameForAppSequenceFunctionVariableOrEvent("Variable", variableNames_list, GetTotalNumberOfCommands(commandBack));

            gTextBox.LostFocus += (sender, e) =>
            {
                AddVariableCommandSave(sender, e);
                SaveVariableAndResetAllVariableInstances();
            };
            gTextBox.Click += (sender, e) =>
            {
                UI.CloseAllPanels();
                Guna2TextBox textbox = (Guna2TextBox)sender;
                oldVariableName = textbox.Text;
                selectedVariableTextBox = textbox;
            };
            gTextBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    MachineProgrammer_form.instance.Back_panel.Focus();
            };
            gTextBox.TextChanged += (sender, e) =>
            {
                Guna2TextBox textBox = (Guna2TextBox)sender;

                // Valid
                if (IsVariableNameValid(textBox.Text))
                {
                    textBox.BorderColor = CustomColors.controlBorder;
                    textBox.BorderThickness = 1;
                    textBox.HoverState.BorderColor = CustomColors.accent_blue;
                    textBox.FocusedState.BorderColor = CustomColors.accent_blue;
                }
                // Invalid
                else
                {
                    textBox.BorderColor = CustomColors.accent_red;
                    textBox.BorderThickness = 2;
                    textBox.HoverState.BorderColor = CustomColors.accent_red;
                    textBox.FocusedState.BorderColor = CustomColors.accent_red;
                }
            };
            variableNames_list.Add(gTextBox.Text);

            // Label
            UI.ConstructLabel("Initial value", 11, true, new Point(240, 5), "", command);
            // TextBox
            gTextBox = UI.ConstructGTextBox(true, new Size(180, 36), new Point(240, 30), command);
            gTextBox.Name = "2";
            gTextBox.MaxLength = 9;
            gTextBox.KeyPress += Tools.OnlyAllowNumbersInTextBox;

            if (isProgramBeingLoaded)  // This needs to be before the TextChanged event
                gTextBox.Text = loadCommandData[1];
            else
                gTextBox.Text = "0";

            gTextBox.LostFocus += AddVariableCommandSave;
            gTextBox.TextChanged += (sender, e) =>
            {
                Guna2TextBox textbox = (Guna2TextBox)sender;

                // Save variable value
                if (textbox.Text != "")
                {
                    variableValues_list[Convert.ToInt32(textbox.Parent.Name) - 1] = Convert.ToInt32(textbox.Text);
                }
            };
            variableValues_list.Add(Convert.ToInt32(gTextBox.Text));

            // Hide button
            Guna2Button gBtn = UI.ConstructGBtn(Resources.EyeOpen, null, 2, new Size(24, 24), new Point(954, 46), command);
            gBtn.Click += HideCommand;
            gBtn.Click += AddVariableCommandSave;
            gBtn.Name = "hideBtn";

            // Delete button
            PictureBox picture = UI.ConstructPicture(Resources.CloseGrey, new Size(14, 16), new Point(960, 8), command);
            picture.Click += DeleteCommand;
            picture.Padding = new Padding(2);
            picture.Name = "deleteBtn";

            // Save
            if (!isProgramBeingLoaded)
                SaveAddVariableCommandInFile(command, true);

            else if (loadCommandData[2] == "1")  // Should the command be hidden
                gBtn.PerformClick();
        }
        private static bool IsVariableNameValid(string variableName)
        {
            if (variableName != "")
            {
                // Check if the first char is a letter
                bool firstCharIsALetter = false;
                if (char.IsLetter(variableName[0]))
                {
                    firstCharIsALetter = true;
                }

                // If string contains only letters or numbers or certain characters
                if (variableName.All(c => char.IsLetterOrDigit(c) || c.ToString() == "_") && firstCharIsALetter)
                {
                    return true;
                }
            }
            return false;
        }
        private static void AddVariableCommandSave(object sender, EventArgs e)
        {
            if (!isProgramBeingLoaded & !isCommandBeingDuplicated)
            {
                Control btn = (Control)sender;
                SaveAddVariableCommandInFile(btn.Parent, false);
            }
        }
        public static void SaveVariableAndResetAllVariableInstances()
        {
            if (oldVariableName != null && selectedVariableTextBox != null)
            {
                if (oldVariableName != selectedVariableTextBox.Text)
                {
                    foreach (string item in variableNames_list)
                    {
                        // If a variable with this name already exists
                        if (selectedVariableTextBox.Text == item)
                        {
                            string newVariableName = AddNumberForAStringThatAlreadyExists(selectedVariableTextBox.Text, variableNames_list);

                            CustomMessageBoxResult result = CustomMessageBox.Show("Rename variable", "Do you want to rename '" + oldVariableName + "' to '" + newVariableName + "'? There is already a variable with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                            if (result == CustomMessageBoxResult.Yes)
                                selectedVariableTextBox.Text = newVariableName;
                            else
                                selectedVariableTextBox.Text = oldVariableName;

                            break;
                        }
                    }

                    // Save variable name
                    if (selectedVariableTextBox.Parent != null)
                    {
                        variableNames_list[Convert.ToInt32(selectedVariableTextBox.Parent.Name) - 1] = selectedVariableTextBox.Text;
                    }

                    // Update all instances of the variable
                    foreach (Guna2TextBox textBox in textBoxesWithVariables_list)
                    {
                        if (textBox.Text == oldVariableName)
                        {
                            textBox.Text = selectedVariableTextBox.Text;
                        }
                    }

                    // Reset
                    oldVariableName = selectedVariableTextBox.Text;
                }
            }
        }
        /// <summary>
        /// This is based on selectedAppTag
        /// </summary>
        private static void GetListOfVariablesForApp()
        {
            List<string> variableNames = new List<string>();
            foreach (Control control in variablePanel_list[selectedAppTag - 1].Controls)
            {
                if (control is Guna2Button)  // If control is a command (variable)
                {
                    Guna2TextBox findVariableNameTextBox = (Guna2TextBox)control.Controls.Find("1", false).FirstOrDefault();
                    variableNames.Add(findVariableNameTextBox.Text);
                }
            }
            variableNames_list = variableNames;
        }


        // Variable box
        public static Guna2Panel variableBox, variableBoxContainer;
        private static Guna2TextBox selectedTextBox;
        private static List<Guna2TextBox> textBoxesWithVariables_list = new List<Guna2TextBox>();
        public static void ConstructVariableBox()
        {
            variableBoxContainer = new Guna2Panel
            {
                Width = 180,
                BorderStyle = DashStyle.Solid,
                BorderColor = Color.Gray,
                BorderThickness = 1,
                FillColor = CustomColors.controlBack,
                BorderRadius = 1,
                UseTransparentBackground = true
            };
            variableBox = new Guna2Panel
            {
                Width = 177,
                Location = new Point(1, 1),
                FillColor = CustomColors.controlBack
            };
            variableBox.HorizontalScroll.Enabled = false;
            variableBox.HorizontalScroll.Maximum = 0;
            variableBoxContainer.Controls.Add(variableBox);
        }
        /// <summary>
        /// Used for a simple search function for the variable box
        /// </summary>
        public class SuggestedVariablesMeta
        {
            public string name;
            public int score;
        }
        private static void ShowVariableBox(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
            if (variablePanel_list[selectedAppTag - 1].Controls.Count > 0)
            {
                Guna2TextBox textBox = (Guna2TextBox)sender;
                Control controlSender = (Control)sender;
                selectedCommandBack = (Guna2Panel)controlSender.Parent.Parent;

                // Simple search function
                List<SuggestedVariablesMeta> metaList = new List<SuggestedVariablesMeta>();
                foreach (string variable in variableNames_list)
                {
                    if (IsVariableNameValid(variable))
                    {
                        // If the variable contains text that is in the textBox
                        if (variable.ToLower().Contains(textBox.Text.ToLower()) && variable != "")
                        {
                            int scoreValue = 1;

                            // Increase the score if the first character is the same
                            if (textBox.Text != "")
                            {
                                if (variable[0].ToString().ToLower() == textBox.Text[0].ToString().ToLower())
                                {
                                    scoreValue = 2;
                                }
                            }

                            metaList.Add(new SuggestedVariablesMeta() { name = variable, score = scoreValue });
                        }
                    }
                }
                metaList.OrderByDescending(x => x.score).ToList();

                // Add variables to variableBox
                variableBox.Controls.Clear();
                for (int i = 0; i < metaList.Count; i++)
                {
                    Guna2Button gBtn = UI.ConstructGBtn(null, metaList[i].name, 0, new Size(177, 24), new Point(1, i * 24 + 1), variableBox);
                    gBtn.Font = new Font("Segoe UI", 10);
                    gBtn.FillColor = CustomColors.controlBack;
                    gBtn.ForeColor = CustomColors.text;

                    gBtn.Click += (sender2, e2) =>
                    {
                        // Put the variable name into the selected TextBox
                        selectedTextBox.Text = gBtn.Text;
                        textBoxesWithVariables_list.Add(selectedTextBox);

                        CloseVariableBox();
                    };
                }

                // Set the height of variableBox
                if (metaList.Count > 0)
                {
                    if (variableBox.Height > 160)
                    {
                        variableBoxContainer.Height = 163;
                        variableBox.Height = 160;
                        variableBox.AutoScroll = true;
                    }
                    else if (metaList.Count == 1)
                    {
                        variableBoxContainer.Height = 42;
                        variableBox.Height = 40;
                        variableBox.AutoScroll = false;
                    }
                    else
                    {
                        variableBox.Height = metaList.Count * 24 + 2;
                        variableBoxContainer.Height = variableBox.Height + 10;
                        variableBox.AutoScroll = false;
                    }

                    // Show variable box
                    variableBoxContainer.Location = new Point(textBox.Left + textBox.Parent.Left, textBox.Parent.Top + textBox.Top + textBox.Height);
                    selectedCommandBack.Controls.Add(variableBoxContainer);
                    variableBoxContainer.BringToFront();
                    selectedCommandBack.ScrollControlIntoView(variableBoxContainer);
                }

                // Save
                selectedTextBox = textBox;
            }
        }
        private static void VariableTextBoxChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            // Valid
            if (variableNames_list.Contains(textBox.Text) || textBox.Text.All(char.IsDigit))
            {
                if (!textBoxesWithVariables_list.Contains(textBox))
                {
                    textBoxesWithVariables_list.Add(textBox);
                }
                textBox.BorderColor = CustomColors.controlBorder;
                textBox.BorderThickness = 1;
                textBox.HoverState.BorderColor = CustomColors.accent_blue;
                textBox.FocusedState.BorderColor = CustomColors.accent_blue;
            }
            else
            {
                // Invalid
                textBoxesWithVariables_list.Remove(textBox);
                textBox.BorderColor = CustomColors.accent_red;
                textBox.BorderThickness = 2;
                textBox.HoverState.BorderColor = CustomColors.accent_red;
                textBox.FocusedState.BorderColor = CustomColors.accent_red;
            }
        }


        // Misc.
        public static void CloseRightClickPanels()
        {
            if (MachineProgrammer_form.instance != null)
            {
                // Close right click panels
                if (MachineProgrammer_form.instance.Controls.Contains(rightClickFile_panel))
                {
                    MachineProgrammer_form.instance.Controls.Remove(rightClickFile_panel);
                    isRightClickPanelOpen = false;
                }
                MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Remove(rightClickFileMove_panel);
                MachineProgrammer_form.instance.Controls.Remove(rightClickFileBack_panel);
                if (selectedCommandBack != null)
                {
                    selectedCommandBack.Controls.Remove(rightClickCommand_panel);
                    selectedCommandBack.Controls.Remove(rightClickCommandMove_panel);
                }
                MachineProgrammer_form.instance.Controls.Remove(rightClickFileMove_panel);

                CloseVariableBox();
            }
        }
        private static void CloseVariableBox()
        {
            selectedCommandBack.Controls.Remove(variableBoxContainer);
        }
        public static void RenameAppSequenceOrFunction()
        {
            if (appOrSequenceOrFunctionBtnSelected != null)
            {
                if (appOrSequenceOrFunctionBtnSelected.Controls.Contains(UI.rename_textBox))
                {
                    switch (whatIsSelected)
                    {
                        case "app":  // RENAME APP
                            string filePath1 = Directories.buildMachines_commands_temp_dir + @"\",
                                   oldAppName = selectedAppName,
                                   newAppName = UI.rename_textBox.Text,
                                   oldAppDir = filePath1 + oldAppName,
                                   newAppDir = filePath1 + newAppName;
                            bool pass = true;

                            if (oldAppName != newAppName)
                            {
                                if (Directory.Exists(newAppDir))
                                {
                                    List<string> listOfAppNames = GetListOfAppNames();
                                    foreach (string item in listOfAppNames)
                                    {
                                        // If an app with this name already exists
                                        if (newAppName == item)
                                        {
                                            string suggestedAppName = AddNumberForAStringThatAlreadyExists(newAppName, listOfAppNames.ToList());

                                            CustomMessageBoxResult result = CustomMessageBox.Show("Rename app", "Do you want to rename '" + oldAppName + "' to '" + suggestedAppName + "'? There is already an app with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                                            if (result == CustomMessageBoxResult.Yes)
                                                newAppName = suggestedAppName;
                                            else
                                                pass = false;
                                            break;
                                        }
                                    }
                                }

                                if (pass)
                                {
                                    appOrSequenceOrFunctionBtnSelected.Text = newAppName;

                                    // Rename app directory
                                    if (Directory.Exists(oldAppDir))
                                    {
                                        Directory.Move(oldAppDir, filePath1 + newAppName);
                                    }
                                    else
                                    {
                                        Log.Error_DirectoryDoesNotExist(oldAppDir);
                                        return;
                                    }

                                    // Rename app file
                                    string filePath2 = Directories.buildMachines_commands_temp_dir + @"\" + newAppName + @"\",
                                        oldAppFileDir = filePath2 + oldAppName + ".txt",
                                        newAppFileDir = filePath2 + newAppName + ".txt";

                                    if (File.Exists(oldAppFileDir))
                                    {
                                        File.Move(oldAppFileDir, newAppFileDir);
                                        Log.Write(3, "Renamed app '" + oldAppName + "' to '" + newAppName + "'");
                                    }
                                    else
                                    {
                                        Log.Error_FileDoesNotExist(oldAppFileDir);
                                        return;
                                    }
                                }
                            }
                            break;


                        case "sequence":  // RENAME SEQUENCE
                            string filePath3 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\",
                                       oldSequenceName = appOrSequenceOrFunctionBtnSelected.Text,
                                       newSequenceName = UI.rename_textBox.Text,
                                       newSequenceDir = filePath3 + newSequenceName + @"\" + newSequenceName + ".txt";
                            bool pass2 = true;

                            if (oldSequenceName != newSequenceName)
                            {
                                if (File.Exists(newSequenceDir))
                                {
                                    List<string> listOfSequenceNames = GetListOfSequenceNames();
                                    foreach (string item in listOfSequenceNames)
                                    {
                                        // If a sequence with this name already exists
                                        if (newSequenceName == item)
                                        {
                                            string suggestedSequenceName = AddNumberForAStringThatAlreadyExists(newSequenceName, listOfSequenceNames);

                                            CustomMessageBoxResult result = CustomMessageBox.Show("Rename sequence", "Do you want to rename '" + oldSequenceName + "' to '" + suggestedSequenceName + "'? There is already a sequence with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                                            if (result == CustomMessageBoxResult.Yes)
                                            {
                                                newSequenceName = suggestedSequenceName;
                                                newSequenceDir = filePath3 + suggestedSequenceName + @"\" + suggestedSequenceName + ".txt";
                                            }
                                            else pass2 = false;
                                            break;
                                        }
                                    }
                                }

                                if (pass2)
                                {
                                    appOrSequenceOrFunctionBtnSelected.Text = newSequenceName;

                                    // Rename sequence folder
                                    string oldSequenceFolderDir = filePath3 + oldSequenceName;
                                    string newSequenceFolderDir = filePath3 + newSequenceName;
                                    if (Directory.Exists(oldSequenceFolderDir))
                                    {
                                        Directory.Move(oldSequenceFolderDir, newSequenceFolderDir);
                                    }
                                    else
                                    {
                                        Log.Error_DirectoryDoesNotExist(oldSequenceFolderDir);
                                        return;
                                    }

                                    // Rename sequence file
                                    string oldSequenceFileDir = newSequenceFolderDir + @"\" + oldSequenceName + ".txt";
                                    string newSequenceFileDir = newSequenceFolderDir + @"\" + newSequenceName + ".txt";
                                    if (File.Exists(oldSequenceFileDir))
                                    {
                                        File.Move(oldSequenceFileDir, newSequenceFileDir);
                                        Log.Write(3, "Renamed sequence '" + oldSequenceName + "' to '" + newSequenceName + "'");
                                    }
                                    else
                                    {
                                        Log.Error_FileDoesNotExist(oldSequenceFileDir);
                                        return;
                                    }
                                }
                            }
                            break;


                        case "function":  // RENAME FUNCTION
                            string filePath4 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\sequences\" + sequenceBtnSelected.Text + @"\functions\",
                                   oldFunctionName = appOrSequenceOrFunctionBtnSelected.Text,
                                   newFunctionName = UI.rename_textBox.Text,
                                   oldFuntionDir = filePath4 + oldFunctionName + ".txt",
                                   newFuntionDir = filePath4 + newFunctionName + ".txt";
                            bool pass3 = true;

                            if (oldFunctionName != newFunctionName)
                            {
                                if (File.Exists(newFuntionDir))
                                {
                                    List<string> listOfFunctionNames = GetListOfFunctionNames();
                                    foreach (string item in listOfFunctionNames)
                                    {
                                        // If a function with this name already exists
                                        if (newFunctionName == item)
                                        {
                                            string suggestedFunctionName = AddNumberForAStringThatAlreadyExists(newFunctionName, listOfFunctionNames);

                                            CustomMessageBoxResult result = CustomMessageBox.Show("Rename function", "Do you want to rename '" + oldFunctionName + "' to '" + suggestedFunctionName + "'? There is already a Function with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                                            if (result == CustomMessageBoxResult.Yes)
                                                newFunctionName = suggestedFunctionName;
                                            else
                                                pass3 = false;
                                            break;
                                        }
                                    }
                                }

                                if (pass3)
                                {
                                    appOrSequenceOrFunctionBtnSelected.Text = newFunctionName;

                                    // Rename function file
                                    newFuntionDir = filePath4 + newFunctionName + ".txt";
                                    if (File.Exists(oldFuntionDir))
                                    {
                                        File.Move(oldFuntionDir, newFuntionDir);
                                        Log.Write(3, "Renamed function '" + oldFunctionName + "' to '" + newFunctionName + "'");
                                    }
                                    else
                                    {
                                        Log.Error_FileDoesNotExist(oldFuntionDir);
                                        return;
                                    }
                                }
                            }
                            break;
                    }

                    // Reset
                    appOrSequenceOrFunctionBtnSelected.Controls.Remove(UI.rename_textBox);
                    UI.rename_textBox.Text = "";
                }
            }
        }
        public static void RenameEvent()
        {
            if (isEventBeingRenamed)
            {
                // If the event name changed
                if (EventNameTextBoxSelected.Text != eventNameSelected)
                {
                    string fileName1 = Directories.buildMachines_commands_temp_dir + @"\" + selectedAppName + @"\events\",
                           newName = EventNameTextBoxSelected.Text,
                           oldDir = fileName1 + eventNameSelected + ".txt",
                           newDir = fileName1 + newName + ".txt";

                    if (File.Exists(newDir))
                    {
                        List<string> listOfEventNames = GetListOfEventNames();
                        foreach (string item in listOfEventNames)
                        {
                            // If an event with this name already exists
                            if (newName == item)
                            {
                                string tempEventName = AddNumberForAStringThatAlreadyExists(newName, listOfEventNames);

                                DialogResult result = MessageBox.Show("Do you want to rename '" + newName + "' to '" + tempEventName + "'? There is already an event with the same name.", "Rename event", MessageBoxButtons.YesNo);
                                CustomMessageBox.Show("Rename event", "Do you want to rename '\" + newName + \"' to '\" + tempEventName + \"'? There is already an event with the same name.", CustomMessageBoxIcon.Question, CustomMessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    newName = tempEventName;
                                    EventNameTextBoxSelected.Text = newName;
                                    AddEventCommandSave(EventNameTextBoxSelected, null);
                                }
                                break;
                            }
                        }
                    }

                    // Rename event file
                    string newFileName = fileName1 + newName + ".txt";
                    if (oldDir != newFileName)
                    {
                        if (!File.Exists(newFileName))
                        {
                            File.Move(oldDir, newFileName);
                        }
                        else
                        {
                            Log.Error_TheSourceAndDestinationAreTheSame(oldDir, newFileName);
                        }
                    }
                    isEventBeingRenamed = false;
                }
            }
        }
        private static string GetNumberNameForAppSequenceFunctionVariableOrEvent(string name, List<string> list, int minNumber)
        {
            int count = 0;
            while (true)
            {
                bool pass2 = false;
                foreach (string item in list)
                {
                    // If this name already exists
                    if (item == name + (minNumber + count).ToString())
                    {
                        pass2 = true;
                        break;
                    }
                }
                if (pass2) count++;
                else break;
            }
            return name + (minNumber + count).ToString();
        }
        private static string AddNumberForAStringThatAlreadyExists(string name, List<string> list)
        {
            // Check if the selectedVariableTextBox already has " (num)"
            if (name[name.Length - 1].ToString() == ")"     // Check for ")"
               && name[name.Length - 3].ToString() == "("   // Check for "("
               && int.TryParse(name[name.Length - 2].ToString(), out _))   // Check for a number
            {
                name.Remove(name.Length - 3).TrimEnd();  // Remove the " (num)"
            }

            // Add a new " (num)"
            int count = 2;
            while (true)
            {
                bool pass2 = false;
                foreach (string item in list)
                {
                    if (item == name + " (" + count.ToString() + ")")
                    {
                        pass2 = true;
                        break;
                    }
                }
                // If this name already exists
                if (pass2)
                    count++;
                else
                {
                    name += " (" + count.ToString() + ")";
                    break;
                }
            }
            return name;
        }
        private static void CloseAllPanels(object sender, EventArgs e)
        {
            UI.CloseAllPanels();
        }
        public static void ResetVariables()
        {
            UI.CloseAllPanels();  // This prevents a crash

            // Construct panels
            appPanel_list = new List<Guna2Panel>();
            sequencePanel_list = new List<Guna2Panel>();
            functionPanel_list = new List<Guna2Panel>();
            eventPanel_list = new List<Guna2Panel>();
            programEventBackPanel_list = new List<Guna2Panel>();
            programEventPanel_list = new List<Guna2Panel>();
            variablePanel_list = new List<Guna2Panel>();

            // Load in commands
            isProgramBeingLoaded = false;

            // Set up play app
            wasStopBtnClicked = false; isAppPaused = false; isAppPlaying = false; didRunCommandJustRunSuccessfully = false;
            playingMachineControllerSelected = "";
            PlayingFileManagmentButton = null;
            commandErrorName = "";

            // Play app
            wasFWDBtnClicked = false;

            // Right click command
            isCommandBeingDuplicated = false;

            // Command logic
            isRightClickMouseButtonDownOnCommand = false; commandMoveBringToFront = false;
            selectedCommandBack = null;
            commandClicked = null; commandSelected = null;
            commandClickedName = 0; commandMovedDownCount = 0; commandMovedUpCount = 0; commandMovedAmount = 0; coords = 0; coordsMouseDown = 0; commandClickedTop = 0; mouseMoved = 0; mouseMovedBase = 0;

            // File logic
            whatIsSelected = "";
            isRightClickPanelOpen = false;

            // Add app
            appBtnList = new List<Guna2Button>();
            variableBtnList = new List<Guna2Button>();
            eventBtnList = new List<Guna2Button>();
            selectedAppTag = 0; totalAppCount = 0;
            selectedAppName = "";
            appPanelFlowPanelSelected = null;
            appPanelSelected = null; selectedVariableBtn = null; selectedEventBtn = null;
            appOrSequenceOrFunctionBtnSelected = null;

            // Add sequence
            sequencePanelSelected = null; sequenceBtnSelected = null;
            totalSequenceCountSelected = 0;
            sequenceBtnList = new List<Guna2Button>();
            totalSequenceCount = 0;

            // Add function
            functionBtnSelected = null;
            functionIndexSelected = 0;
            functionBtnList = new List<Guna2Button>();
            totalFunctionCount = 0;
            sequenceFlowPanelSelected = null;

            // Add event command
            eventNameSelected = "";
            amountOfEvents = new int[1000];
            totalEventCount = 0;
            isEventBeingRenamed = false;
            EventNameTextBoxSelected = null;
            eventCommandSelected = null;

            // Add variable command
            variableNames_list = new List<string>();
            variableValues_list = new List<int>();
            totalVariableCount = 0;
            oldVariableName = "";
            selectedVariableTextBox = null;

            // Variable box
            selectedTextBox = null;
            textBoxesWithVariables_list = new List<Guna2TextBox>();
        }


        // Message panel
        private static Guna2Panel messagePanel;
        private static Timer message_timer;
        public static void CosntructMessagePanel()
        {
            messagePanel = new Guna2Panel()
            {
                Size = new Size(1028, 45),
                FillColor = CustomColors.controlBack,
                BackColor = Color.Transparent,
                Top = MachineProgrammer_form.instance.MainCommandBack_panel.Height - 45,
                CustomBorderColor = CustomColors.controlPanelBorder,
                CustomBorderThickness = new Padding(0, 1, 0, 0),
            };

            message_timer = new Timer()
            {
                Interval = 4500
            };
            message_timer.Tick += Message_timer_Tick;

            Label messageLabel = new Label()
            {
                Font = new Font("Segoe UI", 12),
                BackColor = CustomColors.controlBack,
                ForeColor = CustomColors.text,
                Width = 1028,
                Name = "label",
                Top = 8,
                TextAlign = ContentAlignment.MiddleCenter
            };
            messageLabel.TextChanged += (sender, e) =>
            {
                if (messageLabel.Text != "")
                {
                    MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Add(messagePanel);
                    messagePanel.BringToFront();
                    // Restart timer
                    message_timer.Enabled = false;
                    message_timer.Enabled = true;
                }
            };
            messagePanel.Controls.Add(messageLabel);
        }
        public static void SetMessage(string text)
        {
            Label label = (Label)messagePanel.Controls.Find("label", false).FirstOrDefault();
            label.Text = text;
        }
        private static void Message_timer_Tick(object sender, EventArgs e)
        {
            message_timer.Enabled = false;
            MachineProgrammer_form.instance.MainCommandBack_panel.Controls.Remove(messagePanel);
            SetMessage("");
        }


        // Serial com.
        //private static void WriteToSerial(string message)
        //{
        //    if (MachineProgrammer_form.instance.serialPort1.IsOpen)
        //    {
        //        MachineProgrammer_form.instance.serialPort1.WriteLine("<" + message + ">");
        //    }
        //}
    }
}