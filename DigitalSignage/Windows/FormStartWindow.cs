using DigitalSignage.Media;
using DigitalSignage.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalSignage.Windows
{
    public partial class FormStartWindow : Form
    {
        private RegistrationManager registrationManager;
        private DirectoryManager directoryManager;
        private Configuration configuration;
        private MediaManager mediaManager;
        private MainWindow mediaWindow;
        private DualWriter dualWriter;

        private static bool _isInitialize;


        public static bool IsInitialize()
        {
            return _isInitialize;
        }
        public FormStartWindow(MainWindow _mediaWindow)
        {
            InitializeComponent();
            mediaWindow = _mediaWindow; // Store the reference to MainWindow

            AllocConsole();



            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void FormStartWindow_Load(object sender, EventArgs e)
        {

            registrationManager = new RegistrationManager();
            directoryManager = new DirectoryManager();
            configuration = new Configuration();
            mediaManager = new MediaManager();
            dualWriter = new DualWriter();

            configuration.LoadConfiguration();

            mediaWindow.Hide();
            dualWriter.StartLogging();
            buttonStart.Enabled = _isInitialize;

            //if (directoryManager.CheckMediaFolders())
            //{//If files are already in just skip the other check
            //    loadfiles();
            //}

        }
        void loadfiles()
        {
            mediaManager.LoadFiles();
            buttonStart.Enabled = true; // Functions above have a check if something fails it'll return;
        }

        private void buttonInitialize_Click(object sender, EventArgs e)
        {
            try
            {
                configuration.LoadConfiguration();

                EnsureBasePath();


                directoryManager.Run();// Always do this 
                registrationManager.CreateMainDirectory();// and this too
                if (!AreFilesPlacedInFolder() || !directoryManager.CheckMediaFolders())
                {
                    return; // Exit if files are not placed in the folder
                }

                loadfiles();

                _isInitialize = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Loading Media: {ex.Message}");
                return; // Prevent further execution if an error occurs
            }
        }
        public string EnsureBasePath()
        {
            string basepath = DirectoryManager.GetBasePath();
            if (string.IsNullOrEmpty(basepath))
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Select a folder";
                    folderDialog.ShowNewFolderButton = true;

                    DialogResult result = folderDialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                    {
                        basepath = folderDialog.SelectedPath;
                        DirectoryManager.SetBasePath(basepath);
                        Console.WriteLine($"Selected folder: {basepath}");
                        configuration.SaveFilePath();
                    }
                    else
                    {
                        Console.WriteLine("No folder selected.");
                    }
                }
            }
            return basepath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Check if media files are available before starting playback
            if (!directoryManager.CheckMediaFolders())
            {
                MessageBox.Show("No media files found in any of the folders. Please add media files before starting.", "Aether Corp", MessageBoxButtons.OK);
                return; // Exit if no media files are found
            }

            if (GlobalVariables.PlayMedia)
            {
                StopMediaPlayback();
            }
            else
            {
                StartMediaPlayback();
            }

            UpdateButtonText();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

            mediaWindow.ShowSettingsWindow();
        }

        // Console Debug
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private bool AreFilesPlacedInFolder()
        {
            DialogResult dialogResult = MessageBox.Show("Have you placed media into the folder?", "Aether Corp", MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes;
        }

        // Method to handle media playback logic
        private void StartMediaPlayback()
        {
            GlobalVariables.PlayMedia = true;
            GlobalVariables.StopMedia = false;
            mediaWindow.Show();
            Console.WriteLine("Media playback started.");
            // Add your media playback code here
        }

        // Method to handle media stop logic
        private void StopMediaPlayback()
        {
            GlobalVariables.PlayMedia = false;
            GlobalVariables.StopMedia = true;
            Console.WriteLine("Media playback stopped.");
            // Add your media stop code here
        }
        private void UpdateButtonText()
        {
            if (GlobalVariables.PlayMedia)
            {
                buttonStart.Text = "Stop";
            }
            else
            {
                buttonStart.Text = "Play";
            }
        }
    }
}
