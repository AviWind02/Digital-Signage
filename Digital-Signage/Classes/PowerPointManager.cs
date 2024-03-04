using System;
using System.IO;
using System.Linq;

namespace Digital_Signage
{
    public class PowerPointManager
    {
        public string[][] StorePowerPointFiles(string baseFolderPath)
        {
            Console.WriteLine($"Checking if the base folder exists at path: {baseFolderPath}");
            if (!Directory.Exists(baseFolderPath))
            {
                Console.WriteLine("Base folder path does not exist.");
                return new string[0][];
            }

            Console.WriteLine("Retrieving subdirectories...");
            string[] directories = Directory.GetDirectories(baseFolderPath);

            string[][] powerPointFiles = new string[directories.Length][];

            for (int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine($"Processing folder: {directories[i]}");
                string[] files = Directory.GetFiles(directories[i], "*.png", SearchOption.TopDirectoryOnly);

                // Sort the files numerically based on the slide number
                string[] sortedFiles = files.Select(Path.GetFileName)
                                            .OrderBy(f => Convert.ToInt32(f.Replace("Slide", "").Replace(".png", "")))
                                            .ToArray();

                Console.WriteLine($"Found {sortedFiles.Length} PowerPoint files in the folder.");

                powerPointFiles[i] = new string[sortedFiles.Length + 1];
                powerPointFiles[i][0] = Path.GetFileName(directories[i]); // Store the folder name as the first element
                Console.WriteLine($"Folder name '{powerPointFiles[i][0]}' added to array.");

                for (int j = 0; j < sortedFiles.Length; j++)
                {
                    powerPointFiles[i][j + 1] = sortedFiles[j];
                    Console.WriteLine($"Added file '{powerPointFiles[i][j + 1]}' to array.");
                }
            }

            Console.WriteLine("Finished processing all folders and files.");
            return powerPointFiles;
        }
    }
}
