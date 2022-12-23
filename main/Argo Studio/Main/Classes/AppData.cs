using System.IO;

namespace ArgoStudio.Main.Classes
{
    /// <summary>
    /// Stores data in the "Environment.SpecialFolder.ApplicationData" file.
    /// </summary>
    internal class AppData
    {
        public static bool RPTutorial;

        /// <summary>
        /// Creates the app data directory and file if it does not already exist.
        /// </summary>
        public static void CreateAppDataDirectoryAndFile()
        {
            // Create app data directory
            if (!Directory.Exists(Directories.appData_dir))
            {
                Directories.CreateDirectory(Directories.appData_dir);
            }

            // Create app data file
            if (!File.Exists(Directories.appDataCongig_file))
            {
                string[] lines = new string[] { "RPTutorial:true", "", "" };
                File.WriteAllLines(Directories.appDataCongig_file, lines);
            }
        }
        /// <summary>
        /// Reads the app data from file, and sets all of the AppData variables.
        /// </summary>
        public static void InitAppDataVariables()
        {
            // RPTutorial
            if (GetValue(0) == "true")
                RPTutorial = true;
            else
                RPTutorial = false;
        }

        /// <summary>
        /// Gets a value from file.
        /// </summary>
        private static string GetValue(int lineIndex)
        {
            string[] lines = File.ReadAllLines(Directories.appDataCongig_file);
            return lines[lineIndex].Split(new char[] { ':' })[1];
        }

        /// <summary>
        /// Sets a value to file.
        /// </summary>
        public static void SetValue(int lineIndex, string value)
        {
            // Set RPTutorial to false
            if (File.Exists(Directories.appDataCongig_file))
            {
                string[] lines = File.ReadAllLines(Directories.appDataCongig_file);
                lines[lineIndex] = value;
                File.WriteAllLines(Directories.appDataCongig_file, lines);
            }
            else
            {

            }
        }
    }
}