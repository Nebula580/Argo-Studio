using System;
using System.IO;

namespace ArgoStudio.Main.Classes
{
    static class Directories
    {
        // Directories
        public static string main_dir, project_dir, appData_dir, appDataCongig_file, buildMachines_commands_dir, buildMachines_commands_temp_dir, buildMachines_dir,
            buildMachines_commands_temp_data_file, buildMachines_python_dir, buildMachines_python_program_dir, robotArm_dir,
            robotArms_program_dir, backups_dir, logs_dir;

        public static void SetDirectoriesFor(string projectDir)
        {
            main_dir = projectDir;
            project_dir = main_dir + @"\project";
            // App data
            appData_dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Argo Studio\";
            appDataCongig_file = appData_dir + "ArgoStudio.config";
            // Build machines
            buildMachines_dir = project_dir + @"\build machines";
            // Commands
            buildMachines_commands_dir = buildMachines_dir + @"\commands";
            buildMachines_commands_temp_dir = buildMachines_commands_dir + @"\temp";
            buildMachines_commands_temp_data_file = buildMachines_commands_temp_dir + @"\data.txt";
            // Python
            buildMachines_python_dir = buildMachines_dir + @"\python";
            buildMachines_python_program_dir = buildMachines_python_dir + @"\programs";
            // Program robot arms
            robotArm_dir = project_dir + @"\robot arms";
            robotArms_program_dir = robotArm_dir + @"\programs";
            // Backups
            backups_dir = project_dir + @"\backups";
            // Logs
            logs_dir = project_dir + @"\logs";
        }


        // Directories
        /// <summary>
        /// Copies an existing directory to a new directory.
        /// </summary>
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive, bool overWrite)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories

            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                File.Copy(file.FullName, targetFilePath, overWrite);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true, overWrite);
                }
            }
        }

        /// <summary>
        /// Creates a directory.
        /// </summary>
        public static bool CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                return true;
            }
            Log.Error_DirectoryAlreadyExists(directory);
            return false;
        }

        /// <summary>
        /// Deletes a directory.
        /// </summary>
        public static bool DeleteDirectory(string directory, bool recursive)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive);
                return true;
            }
            Log.Error_DirectoryDoesNotExist(directory);
            return false;
        }
        /// <summary>
        /// Moves a folder
        /// </summary>
        public static bool MoveDirectory(string source, string destination)
        {
            if (Directory.Exists(source))
            {
                if (!Directory.Exists(destination))
                {
                    Directory.Move(source, destination);
                    return true;
                }
                Log.Error_DestinationDirectoryAlreadyExists(destination);
            }
            Log.Error_SourceDirectoryDoesNotExist(source);
            return false;
        }


        // Files
        /// <summary>
        /// Creates a file.
        /// </summary>
        public static bool CreateFile(string directory)
        {
            if (!File.Exists(directory))
            {
                File.Create(directory).Dispose();
                return true;
            }
            Log.Error_FileAlreadyExists(directory);
            return false;
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        public static bool DeleteFile(string directory)
        {
            if (File.Exists(directory))
            {
                File.Delete(directory);
                return true;
            }
            Log.Error_FileDoesNotExist(directory);
            return false;
        }
        /// <summary>
        /// Moves a file
        /// </summary>
        public static bool MoveFile(string source, string destination)
        {
            if (File.Exists(source))
            {
                if (!File.Exists(destination))
                {
                    File.Move(source, destination);
                    return true;
                }
                Log.Error_DestinationFileAlreadyExists(destination);
            }
            Log.Error_SourceFileDoesNotExist(source);
            return false;
        }
    }
}