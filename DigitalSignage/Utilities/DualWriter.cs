using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DigitalSignage.Utilities
{
    public class DualWriter : TextWriter
    {
        private TextWriter originalOut;
        private StreamWriter fileWriter;

        public DualWriter(string path)
        {
            originalOut = Console.Out;  // Preserve the original StreamWriter
            fileWriter = new StreamWriter(path, true, Encoding.UTF8) { AutoFlush = true };
        }
        public DualWriter()
        {

        }
        public override Encoding Encoding => Encoding.UTF8;

        public override void Write(char value)
        {
            originalOut.Write(value);
            fileWriter.Write(value);
        }

        public override void WriteLine(string value)
        {
            originalOut.WriteLine(value);
            fileWriter.WriteLine(value);
        }

        public override void Flush()
        {
            originalOut.Flush();
            fileWriter.Flush();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                originalOut.Dispose();
                fileWriter.Dispose();
            }
        }
        public void OpenDir()
        {

            string baseFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log files Signage");

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
        public void StartLogging()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log files Signage");
            string logFileName = $"Log_{DateTime.Now:yyyy-MM-dd HH-mm-ss}.txt";
            string fullPath = Path.Combine(logDirectory, logFileName);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            Console.SetOut(new DualWriter(fullPath));
        }

        //Used for logging media output
        public void LogSection(string sectionName, List<string> items)
        {
            Console.WriteLine($"\n{sectionName}:\n{new string('-', sectionName.Length)}");
            foreach (var item in items)
            {
                Console.WriteLine($"  - {item}");
            }
        }
    }
}
