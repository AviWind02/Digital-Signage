using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiSign_Config_Editor
{
    public partial class Form1 : Form
    {
        const string baseKey = "HKEY_CURRENT_USER";
        const string subKey = "DigiSign";
        const string levelImagesValue = "Level Images";
        const string imagesValue = "Images";
        const string powerPointValue = "PowerPoint";
        const string videosValue = "Videos";
        const string folderPath = "Folder Path";


        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("One of the values is blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

            else
            {
                Registry.SetValue($"{baseKey}\\{subKey}", levelImagesValue, textBox2.Text);
                Registry.SetValue($"{baseKey}\\{subKey}", powerPointValue, textBox3.Text);
                Registry.SetValue($"{baseKey}\\{subKey}", videosValue, textBox4.Text);
                Registry.SetValue($"{baseKey}\\{subKey}", imagesValue, textBox1.Text);
                Registry.SetValue($"{baseKey}\\{subKey}", folderPath, textBox5.Text);
                MessageBox.Show("Values saved successfully", "Take a chance on me", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                bool result = EnsureSubdirectoriesExist(textBox5.Text);

                if (result)
                {
                    MessageBox.Show("All subdirectories exist (created if missing).","Magic", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                else
                {
                    MessageBox.Show("Unable to create one or more subdirectories.");
                }

            }



        }
        
        static bool EnsureSubdirectoriesExist(string baseDirectory)
        {
            string[] subdirectories = { "Images", "Level Images", "PowerPoint", "PowerPointImages", "Videos" };

            bool allDirectoriesExist = true;

            foreach (string subdirectory in subdirectories)
            {
                string subdirectoryPath = Path.Combine(baseDirectory, subdirectory);

                if (!Directory.Exists(subdirectoryPath))
                {
                    try
                    {
                        Directory.CreateDirectory(subdirectoryPath);
                        Console.WriteLine($"Subdirectory '{subdirectory}' created.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to create subdirectory '{subdirectory}': {ex.Message}");
                        allDirectoriesExist = false;
                    }
                }
            }

            return allDirectoriesExist;
        }
    

    //Checks to see if the key "Computer\HKEY_CURRENT_USER\DigiSign" exists and gets the values under that key.

    public void CheckAndRetrieveRegistryValues()
        {
            const string baseKey = "HKEY_CURRENT_USER";
            const string subKey = "DigiSign";
            const string levelImagesValue = "Level Images";
            const string powerPointValue = "PowerPoint";
            const string videosValue = "Videos";

            try
            {
                RegistryKey digiSignKey = Registry.CurrentUser.OpenSubKey(subKey);
                if (digiSignKey == null)
                {
                    // Key doesn't exist, create the key and add values
                    Registry.CurrentUser.CreateSubKey(subKey);

                    Registry.SetValue($"{baseKey}\\{subKey}", levelImagesValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", powerPointValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", videosValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", imagesValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", folderPath, string.Empty);


                    Console.WriteLine("Registry key and values created successfully!");
                }
                else
                {
                    // Key exists, retrieve values and populate textboxes
                    string levelImages = digiSignKey.GetValue(levelImagesValue, string.Empty) as string;
                    string powerPoint = digiSignKey.GetValue(powerPointValue, string.Empty) as string;
                    string videos = digiSignKey.GetValue(videosValue, string.Empty) as string;
                    string images = digiSignKey.GetValue(imagesValue, string.Empty) as string;
                    string folder = digiSignKey.GetValue(folderPath, string.Empty) as string;


                    // Assuming you have four textboxes: textBox1, textBox2, textBox3, textBox4
                    textBox5.Text = folder;
                    textBox2.Text = levelImages;
                    textBox3.Text = powerPoint;
                    textBox4.Text = videos;
                    textBox1.Text = images;

                    Console.WriteLine("Registry values retrieved and populated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckAndRetrieveRegistryValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = folderBrowserDialog1.SelectedPath;
                string baseDirectory = folderBrowserDialog1.SelectedPath;



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }
    }
}
