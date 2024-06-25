using DigitalSignage.Media;
using DigitalSignage.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace DigitalSignage.Windows
{
    public partial class FormSettingWindow : Form
    {

        private bool readyToChange;

        private FormStartWindow startWindow;
        private RegistrationManager registrationManager;
        private DirectoryManager directoryManager;
        private LevelConverter levelConverter;
        private Configuration configuration;
        private MainWindow mediaWindow;
        private DualWriter dualwriter;

        public FormSettingWindow(MainWindow _mediaWindow)
        {
            InitializeComponent();
            mediaWindow = _mediaWindow;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ControlBox = false;

        }

        private void FormSettingWindow_Load(object sender, EventArgs e)
        {




            registrationManager = new RegistrationManager();
            directoryManager = new DirectoryManager();
            levelConverter = new LevelConverter();
            configuration = new Configuration();
            dualwriter = new DualWriter();



            textBoxPowerPointRate.Text = registrationManager.ReadRegistryValue("PowerPointChance").ToString();
            textBoxVideoRate.Text = registrationManager.ReadRegistryValue("VideoChance").ToString();
            textBoxVideoRate.Text = registrationManager.ReadRegistryValue("ImageChance").ToString();
            textBoxSlideDelay.Text = registrationManager.ReadRegistryValue("Slide Delay").ToString();

            textBoxCounterPerPPT.Text = registrationManager.ReadRegistryValue("MaxPlaybackCountVideo").ToString();
            textBoxCounterPerVideo.Text = registrationManager.ReadRegistryValue("MaxPlaybackCountVideo").ToString();


            InitComobBox();

        }


        private void CalculateImageRate()
        {
            // Using int.TryParse to avoid FormatException - Kept getting it on Video rate.
            if (int.TryParse(textBoxPowerPointRate.Text, out int powerPointRate) &&
                int.TryParse(textBoxVideoRate.Text, out int videoRate))
            {
                int imageRate = 100 - powerPointRate - videoRate;

                // Ensure imageRate does not go below 0
                if (imageRate < 0)
                {
                    imageRate = 0;
                }

                textBoxImageRate.Text = imageRate.ToString();
                Console.WriteLine("Image rate adjusted: " + imageRate);
            }
            else
            {
                Console.WriteLine("Error: One or more inputs are not valid numbers. - Can be Ignored");
            }
        }




        private void InitComobBox()
        {


            textSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            textSpeedComboBox.Items.Add("Fast");
            textSpeedComboBox.Items.Add("Normal");
            textSpeedComboBox.Items.Add("Slow");
            textSpeedComboBox.Items.Add("Custom");
            Console.WriteLine($"GlobalVariables.VideoChance = {GlobalVariables.VideoChance}");
            Console.WriteLine($"levelConverter.GetChanceLevel(GlobalVariables.VideoChance) = {levelConverter.GetChanceLevel(GlobalVariables.VideoChance)}");
            comboBoxVideoRate.SelectedIndex = levelConverter.GetChanceLevel(GlobalVariables.VideoChance);
            comboBoxPPTRate.SelectedIndex = levelConverter.GetChanceLevel(GlobalVariables.PowerpointChance);
            comboBoxDelay.SelectedIndex = levelConverter.GetSpeedLevel(GlobalVariables.DelayPerSlide);

        }

        private void textSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Avi fix this plz thanks babes

        }


        private void textBoxPowerPointRate_TextChanged(object sender, EventArgs e)
        {
            //CalculateImageRate();
        }

        private void textBoxVideoRate_TextChanged(object sender, EventArgs e)
        {
            //CalculateImageRate();
        }

        private void buttonOpenTxtFile_Click(object sender, EventArgs e)
        {
            directoryManager.CreateAndModifyTxtFile(DirectoryManager.GetBasePath(), "FooterText");
        }
        private void buttonOpenLogs_Click(object sender, EventArgs e)
        {
            dualwriter.OpenDirectory();
        }
        private void button_OpenDirectory(object sender, EventArgs e)
        {
            directoryManager.OpenDirectory();
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSaveValues_Click(object sender, EventArgs e)
        {

            GlobalVariables.MaxPptPlaybackCount = Convert.ToInt32(textBoxCounterPerPPT.Text);
            GlobalVariables.MaxVideoPlaybackCount = Convert.ToInt32(textBoxCounterPerVideo.Text);
            GlobalVariables.PowerpointChance = Convert.ToInt32(textBoxPowerPointRate.Text);
            GlobalVariables.VideoChance = Convert.ToInt32(textBoxVideoRate.Text);
            GlobalVariables.DelayPerSlide = Convert.ToInt32(textBoxSlideDelay.Text);

            configuration.SaveConfiguration();

        }
        



        private void buttonLoadValues_Click(object sender, EventArgs e)// Just in case load fails
        {
            configuration.LoadConfiguration();
            textBoxPowerPointRate.Text = registrationManager.ReadRegistryValue("PowerPointChance").ToString();
            textBoxVideoRate.Text = registrationManager.ReadRegistryValue("VideoChance").ToString();
            textBoxSlideDelay.Text = registrationManager.ReadRegistryValue("Slide Delay").ToString();
            textBoxCounterPerPPT.Text = registrationManager.ReadRegistryValue("MaxPlaybackCountVideo").ToString();
            textBoxCounterPerVideo.Text = registrationManager.ReadRegistryValue("MaxPlaybackCountVideo").ToString();
        }

        private void buttonSetFooterText_Click(object sender, EventArgs e)
        {
            mediaWindow.UpdateScrollingText(directoryManager.ReadTxtFileWithLogging(DirectoryManager.GetBasePath()));



        }

        private void comboBoxPPTRate_SelectedIndexChanged(object sender, EventArgs e)
        {

            int value = levelConverter.GetChanceValue(comboBoxPPTRate.Text);
            GlobalVariables.PowerpointChance = Convert.ToInt32(value);
            textBoxPowerPointRate.Text = Convert.ToString(value);
            Console.WriteLine("PowerPoint rate adjusted(%): " + value);

        }

        private void comboBoxVideoRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = levelConverter.GetChanceValue(comboBoxVideoRate.Text);
            GlobalVariables.VideoChance = Convert.ToInt32(value);
            textBoxVideoRate.Text = Convert.ToString(value);
            Console.WriteLine("Video rate adjusted(%): " + value);
        }

        private void comboBoxDelay_SelectedIndexChanged(object sender, EventArgs e)
        {
            double multiplier = levelConverter.GetSpeedMultiplier(comboBoxDelay.Text);
            GlobalVariables.DelayPerSlide = Convert.ToInt32(multiplier);
            textBoxSlideDelay.Text = Convert.ToString(multiplier);// This for the reg backend I was already doing this before so might as well just keep it
            Console.WriteLine("Slide Delay adjusted(Seconds): " + multiplier);

        }
        private bool AskForRestart()
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                "To change this now, you would need to restart. Would you like to exit the app?",
                "Restart Required",
                MessageBoxButtons.YesNo);

            return dialogResult == DialogResult.Yes;
        }


        private void buttonResetDir_Click(object sender, EventArgs e)
        {
            string basepath;
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

            GlobalVariables.IsNeedingInitialize = true;

            if(AskForRestart())
            {
                Environment.Exit(0);
            }

        }
    }
}
