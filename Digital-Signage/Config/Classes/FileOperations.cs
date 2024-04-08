using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signage.Config.Classes
{
    internal class FileOperations
    {

        public void createAndModifyTxtFile(string folderPath, string fileName)
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
