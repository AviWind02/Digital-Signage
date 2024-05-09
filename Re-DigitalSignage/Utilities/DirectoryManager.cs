using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Re_DigitalSignage.Utilities
{
    internal class DirectoryManager
    {

        public void OpenDirectory()
        {

            string baseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");

            // Check if the directory exists
            if (!Directory.Exists(baseFolderPath))
            {
                Console.WriteLine("Error: Directory does not exist.");
                return;
            }

            try
            {
                // Start a new process to open the directory using the default file explorer
                Process.Start(new ProcessStartInfo()
                {
                    FileName = baseFolderPath,
                    UseShellExecute = true,
                    Verb = "open"
                });
                Console.WriteLine("Directory opened: " + baseFolderPath);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to open the directory: " + ex.Message);
                return;
            }
        }

        public void Run()
        {
            // Define the base folder path in the user's Documents directory
            string baseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");

            // Define weekday folders
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Fallback", "Special" };

            // Define subfolders for each weekday
            string[] subFolders = { "Images", "Level Images", "PowerPoint", "PowerPoint\\PowerPointImages", "Videos" };

            try
            {
                // Create the base folder if it doesn't exist
                if (!Directory.Exists(baseFolderPath))
                {
                    Directory.CreateDirectory(baseFolderPath);
                    Console.WriteLine($"Created base folder: {baseFolderPath}");
                }

                // Create each weekday folder with subfolders
                foreach (string day in weekdays)
                {
                    string dayFolderPath = Path.Combine(baseFolderPath, day);
                    if (!Directory.Exists(dayFolderPath))
                    {
                        Directory.CreateDirectory(dayFolderPath);
                        Console.WriteLine($"Created weekday folder: {dayFolderPath}");
                    }

                    // Create subfolders in the weekday folder
                    foreach (string subFolder in subFolders)
                    {
                        string subFolderPath = Path.Combine(dayFolderPath, subFolder);
                        if (!Directory.Exists(subFolderPath))
                        {
                            Directory.CreateDirectory(subFolderPath);
                            Console.WriteLine($"Created subfolder: {subFolderPath}");
                        }
                    }
                }

                Console.WriteLine("All folders for each weekday created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating folders: {ex.Message}");
            }
        }


        public void CreateAndModifyTxtFile(string folderPath, string fileName)
        {
            //// Ensure the folder path ends with a backslash
            //if (!folderPath.EndsWith(@"\"))
            //    folderPath += @"\";

            string filePath = folderPath + fileName + ".txt";

            try
            {
                // Check if the folder exists and create if it doesn't
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    // Create file if it doesn't exist
                    using (var fileStream = File.Create(filePath))
                    {
                        // File is automatically closed when exiting the using block
                    }
                }

                // Check if the file is empty
                if (new FileInfo(filePath).Length == 0)
                {
                    // Write placeholder text to the file
                    File.WriteAllText(filePath, "In this text file, anything you type will appear in the footer at the bottom of the document. Please remember to remove this line before using the file for your purposes.");
                }

                // Open the file in the default text editor
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
