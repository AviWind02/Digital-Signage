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
        private DirectoryManager directoryManager;
        private MediaManager mediaManager;
        private DualWriter dualWriter;
        private RegistrationManager registrationManager;

        private bool isnitialize;

        public FormStartWindow()
        {
            InitializeComponent();
            AllocConsole();
            directoryManager = new DirectoryManager();
            mediaManager = new MediaManager();
            dualWriter = new DualWriter();
            registrationManager = new RegistrationManager();
        }

        private void FormStartWindow_Load(object sender, EventArgs e)
        {
            dualWriter.StartLogging();
            buttonStart.Enabled = isnitialize;
        }

        private void buttonInitialize_Click(object sender, EventArgs e)
        {
            try
            {
                directoryManager.Run();// Always do this 
                registrationManager.CreateMainDirectory();// and this too
                if (!areFilesPlacedInFolder() || !directoryManager.CheckMediaFolders())
                {
                    return; // Exit if files are not placed in the folder
                }

                mediaManager.LoadFiles();
                buttonStart.Enabled = true; // Functions above have a check if something fails it'll return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Loading Media: {ex.Message}");
                return; // Prevent further execution if an error occurs
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Code for the Start button click event
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            // Code for the Settings button click event
        }

        // Console Debug
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private bool areFilesPlacedInFolder()
        {
            DialogResult dialogResult = MessageBox.Show("Have you placed media into the folder?", "Aether Corp", MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes;
        }
    }
}
