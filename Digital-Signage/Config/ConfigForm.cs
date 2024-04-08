using Digital_Signage.Classes;
using Digital_Signage.Config.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Digital_Signage.Config
{
    public partial class ConfigForm : Form
    {

        private int playbackCounter_PPT;
        private int playbackCounter_Video;
        private int maxPlaybackCount_PPT;
        private int maxPlaybackCount_Video;
        private int powerpointChance;
        private int videoChance;
        private int delayPerSlide;
        private MainWindow mainWindow;
        private FileOperations fileOperations;
        private MediaFolderManager mediaFolderManager;

        public string miscFolderPath { get; set; }

        public ConfigForm(int playbackCounter_PPT, int playbackCounter_Video, 
                          int maxPlaybackCount_PPT, int maxPlaybackCount_Video, 
                          int powerpointChance, int videoChance, int delayPerSlide)
        {
            InitializeComponent();
            this.mainWindow = new MainWindow();
            this.fileOperations = new FileOperations();

            this.playbackCounter_PPT = playbackCounter_PPT;
            this.playbackCounter_Video = playbackCounter_Video;
            this.maxPlaybackCount_PPT = maxPlaybackCount_PPT;
            this.maxPlaybackCount_Video = maxPlaybackCount_Video;
            this.powerpointChance = powerpointChance;
            this.videoChance = videoChance;
            this.delayPerSlide = delayPerSlide;

       
            initComobBox();



        }


        RegistryHandler registryConfigManager = new RegistryHandler();


        private void saveConfiguration()
        {
            registryConfigManager.WriteRegistryValue("MaxPlaybackCountPPT", maxPlaybackCount_PPT);
            registryConfigManager.WriteRegistryValue("MaxPlaybackCountVideo", maxPlaybackCount_Video);
            registryConfigManager.WriteRegistryValue("PowerPointChance", powerpointChance);
            registryConfigManager.WriteRegistryValue("VideoChance", videoChance);
            registryConfigManager.WriteRegistryValue("Slide Delay", delayPerSlide);

        }

        private void loadConfiguration()
        {

            maxPlaybackCount_PPT = maxPlaybackCount_PPT = registryConfigManager.ReadRegistryValue("MaxPlaybackCountPPT");
            maxPlaybackCount_Video = registryConfigManager.ReadRegistryValue("MaxPlaybackCountVideo");
            powerpointChance = registryConfigManager.ReadRegistryValue("PowerPointChance");
            videoChance = registryConfigManager.ReadRegistryValue("VideoChance");
            delayPerSlide = registryConfigManager.ReadRegistryValue("Slide Delay");

            mainWindow.UpdateConfiguration(maxPlaybackCount_PPT, 
                maxPlaybackCount_Video, powerpointChance, videoChance, delayPerSlide);

        }

        private void customSpeedScrollBox(bool b)
        {
            textBoxCustomTextSpeedScroll.Visible = b;
            labelCustomTextSpeedScroll.Visible = b;
        }


        private void initComobBox()
        {

            customSpeedScrollBox(false);
            textSpeedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            textSpeedComboBox.Items.Add("Fast");
            textSpeedComboBox.Items.Add("Normal");
            textSpeedComboBox.Items.Add("Slow");
            textSpeedComboBox.Items.Add("Custom");



        }


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            loadConfiguration();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveConfiguration();

        }

        private void textSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string speed = textSpeedComboBox.SelectedItem.ToString();
            if (speed.Equals("Custom"))
                customSpeedScrollBox(true);
            else
                customSpeedScrollBox(false);
        }

        private void textBoxCustomTextSpeedScroll_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCustomTextSpeedScroll.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBoxCustomTextSpeedScroll.Text = textBoxCustomTextSpeedScroll.Text.Remove(textBoxCustomTextSpeedScroll.Text.Length - 1);
            }
        }

        private void buttonOpenTxtFile_Click(object sender, EventArgs e)
        {
            fileOperations.createAndModifyTxtFile(miscFolderPath, "FooterText");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
