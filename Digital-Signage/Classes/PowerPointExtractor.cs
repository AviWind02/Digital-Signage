
/*
 * The `PowerPointExtractor` class extracts slides from PowerPoint presentations and saves 
 * them as images. It uses the PowerPoint application to open each presentation, creates a 
 * folder for the presentation, and saves each slide as a separate image in that folder. Finally, 
 * it closes the PowerPoint application.
 */
using System;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace Digital_Signage.Classes
{
    internal class PowerPointExtractor
    {

        public void ExtractPowerPointSlides(string inputFolderPath, string outputFolderPath)
        {
            // Create an instance of PowerPoint application
            var app = new Application();

            // Get all PowerPoint files in the input folder
            string[] powerPointFiles = Directory.GetFiles(inputFolderPath, "*.pptx");

            foreach (string filePath in powerPointFiles)
            {
                Console.WriteLine($"Processing file: {filePath}");

                try
                {
                    // Open the PowerPoint presentation
                    var presentation = app.Presentations.Open(filePath, WithWindow: MsoTriState.msoFalse);

                    // Get the name of the PowerPoint file (without extension)
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Create a folder with the PowerPoint file name
                    string presentationFolder = Path.Combine(outputFolderPath, fileName);
                    Directory.CreateDirectory(presentationFolder);

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

                        Console.WriteLine($"Slide {i} extracted and saved as: {slideImagePath}");
                    }

                    // Close the presentation
                    presentation.Close();

                    Console.WriteLine($"Extraction completed for file: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file: {filePath}");
                    Console.WriteLine($"Error message: {ex.Message}");
                }
            }

            // Quit the PowerPoint application
            app.Quit();
            Console.WriteLine("PowerPoint application closed.");
        }
    }

}
