using System;
using System.IO;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;

namespace Re_DigitalSignage.PowerPoint
{
    internal class PowerPointExtractor
    {
        /// <summary>
        /// Converts PowerPoint (.pptx) files in a specified folder into image files.
        /// </summary>
        /// <param name="sourceFolderPath">The folder containing PowerPoint files to be converted.</param>
        /// <param name="destinationFolderPath">The folder where the resulting image files will be saved.</param>
        public void ExtractPowerPointSlides(string inputFolderPath, string outputFolderPath)
        {
            // Create an instance of PowerPoint application
            var app = new Microsoft.Office.Interop.PowerPoint.Application();

            // Get all PowerPoint files in the input folder
            string[] powerPointFiles = Directory.GetFiles(inputFolderPath, "*.pptx");

            // Log start of PowerPoint processing
            LogSection("PowerPoint Extraction", $"Processing {powerPointFiles.Length} files from: {inputFolderPath}");

            foreach (string filePath in powerPointFiles)
            {
                LogSection("Processing File", filePath);

                try
                {
                    // Open the PowerPoint presentation
                    var presentation = app.Presentations.Open(filePath, WithWindow: MsoTriState.msoFalse);

                    // Get the name of the PowerPoint file (without extension)
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Create a folder with the PowerPoint file name
                    string presentationFolder = Path.Combine(outputFolderPath, fileName);
                    Directory.CreateDirectory(presentationFolder);

                    // Log created folder
                    Console.WriteLine($"Created folder for presentation: {presentationFolder}");

                    // Save each slide as an image in the presentation folder
                    for (int i = 1; i <= presentation.Slides.Count; i++)
                    {
                        Slide slide = presentation.Slides[i];
                        string slideImagePath = Path.Combine(presentationFolder, $"Slide{i}.png");

                        // Check if the slide image already exists
                        if (File.Exists(slideImagePath))
                        {
                            Console.WriteLine($"Slide {i} image already exists: {slideImagePath}");
                            continue; // Skip to the next slide
                        }

                        // Save the slide as an image
                        slide.Export(slideImagePath, "PNG", ScaleWidth: 1024, ScaleHeight: 768);
                        Console.WriteLine($"  - Slide {i} extracted and saved as: {slideImagePath}");
                    }

                    // Close the presentation
                    presentation.Close();
                    Console.WriteLine($"Extraction completed for file: {filePath}");
                }
                catch (Exception ex)
                {
                    LogSection("Error", $"Error processing file: {filePath}\nError message: {ex.Message}");
                }
            }

            // Quit the PowerPoint application
            app.Quit();
            LogSection("Completion", "PowerPoint application closed.");
        }

        public static void LogSection(string sectionTitle, string content)
        {
            string separator = new string('-', sectionTitle.Length + 2);
            Console.WriteLine($"\n{sectionTitle}\n{separator}");
            Console.WriteLine(content);
        }
    }
}
