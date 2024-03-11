/*
 * Script used to create the folder layout since I'm lazy.
 */

using System;
using System.IO;
namespace Digital_Signage.Classes
{
    internal class CreateFolders
    {
        public void run()
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
    }
}
