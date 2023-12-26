using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Office.Interop.PowerPoint;
using System.Drawing;
using Microsoft.Win32;
using Digital_Signage.Classes;
using System.Linq;
using Aspose.Slides.MathText;

namespace Digital_Signage
{
    public partial class MainWindow : Window
    {
        private MediaCollection mediaCollection;
        private PowerPointExtractor powerPointExtractor;
        private NumericStringComparer numericStringComparer;
        private int currentIndex = 0; // Index of the currently displayed media
        private int currentIndexOfSlide = 0; // Index of the currently displayed media
        private int imageSlideDelay = 50;// Delay for each image slide
        private int slideCount = 0; // Counter for the number of slides displayed
        private bool isVideoPlaying = false; // Flag to indicate if a video is currently playing
        private int previousVideoIndex = -1; // Index of the previously played video
        private bool isSlidePlaying = false;
        private bool loadingpptx = false;
        private DispatcherTimer timer; // Timer for slideshow
        private int powerpointChance = 33;
        private int videoChance = 33;

        private bool isVideo = false; // Flag to indicate if the current media is a video


        enum Mediatypes
        {
            Image,
            Video,
            PPT,
            LevelImage
        };



        public MainWindow()
        {
            InitializeComponent();
            mediaCollection = new MediaCollection();
            powerPointExtractor = new PowerPointExtractor();
            numericStringComparer = new NumericStringComparer();
            timer = new DispatcherTimer();
            timer.Tick += timerTick;
            GC.Collect();
        }

        //Checks to see if the key "Computer\HKEY_CURRENT_USER\DigiSign" exists and gets the values under that key.
        public void CheckAndRetrieveRegistryValues()
        {
            const string baseKey = "HKEY_CURRENT_USER";
            const string subKey = "DigiSign";
            const string levelImagesValue = "Level Images";
            const string powerPointValue = "PowerPoint";
            const string videosValue = "Videos";
            const string imagesValue = "Images";

            try
            {
                RegistryKey digiSignKey = Registry.CurrentUser.OpenSubKey(subKey);
                if (digiSignKey == null)
                {
                    // Key doesn't exist, create the key and add values
                    Registry.CurrentUser.CreateSubKey(subKey);

                    //Registry.SetValue($"{baseKey}\\{subKey}", levelImagesValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", powerPointValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", videosValue, string.Empty);
                   // Registry.SetValue($"{baseKey}\\{subKey}", imagesValue, string.Empty);


                    Console.WriteLine("Registry key and values created successfully!");
                }
                else
                {
                    // Key exists, retrieve values and populate textboxes
                  //  string levelImages = digiSignKey.GetValue(levelImagesValue, string.Empty) as string;
                    string powerPoint = digiSignKey.GetValue(powerPointValue, string.Empty) as string;
                    string videos = digiSignKey.GetValue(videosValue, string.Empty) as string;
                   // string images = digiSignKey.GetValue(imagesValue, string.Empty) as string;


                    // Assuming you have four textboxes: textBox1, textBox2, textBox3, textBox4
                    //levelImageChance = int.Parse(levelImages);
                    powerpointChance = int.Parse(powerPoint);
                    videoChance = int.Parse(videos);
                    //imageChance = int.Parse(images);

                    Console.WriteLine("Registry values retrieved and populated successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {


            //Retreive configuration from registry - Turned off during Debug to use values in editor
#if !DEBUG
            CheckAndRetrieveRegistryValues();
#endif
            // Specify the base folder path
            string baseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");

            // Define folder paths for each media type
            string imagesFolderPath = Path.Combine(baseFolderPath, "Images");
            string levelImagesFolderPath = Path.Combine(baseFolderPath, "Level Images");
            string powerpointFolderPath = Path.Combine(baseFolderPath, "PowerPoint");
            string powerpointImagesFolderPath = Path.Combine(baseFolderPath, "PowerPoint\\PowerPointImages");
            string videosFolderPath = Path.Combine(baseFolderPath, "Videos");

            // Get media from each folder
            GetMediaFromFolder(imagesFolderPath, mediaCollection.Images);
            GetMediaFromFolder(levelImagesFolderPath, mediaCollection.ImageLevels);
            GetMediaFromFolder(powerpointImagesFolderPath, mediaCollection.PowerpointImages);
            powerPointExtractor.ExtractPowerPointSlides(powerpointFolderPath, powerpointImagesFolderPath);
            GetMediaFromFolder(videosFolderPath, mediaCollection.Videos);


            string horizontalRule = new string('-', 50);


            // Display loaded media paths in the console
            Console.WriteLine($"{horizontalRule}\nLoaded Media:\n{horizontalRule}");

            LogSection("Images", mediaCollection.Images);
            LogSection("Image Levels", mediaCollection.ImageLevels);
            LogSection("PowerPoint Images", mediaCollection.PowerpointImages);
            LogSection("Videos", mediaCollection.Videos);
            Console.WriteLine("Files Loaded. Starting Playback.");

            if (mediaCollection.Images.Count > 0)
            {
                imageControl.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(mediaCollection.Images[currentIndex]));
                timer.Interval = TimeSpan.FromMilliseconds(imageSlideDelay);
                timer.Start();
            }
        }

        public static void LogSection(string sectionName, List<string> items)
        {
            Console.WriteLine($"\n{sectionName}:\n{new string('-', sectionName.Length)}");
            foreach (var item in items)
            {
                Console.WriteLine($"  - {item}");
            }
        }

        // Method to get media from a folder and its subfolders
        private void GetMediaFromFolder(string folderPath, List<string> mediaList)
        {
            if (Directory.Exists(folderPath))
            {
                // Get all files from the folder and its subfolders
                string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            
                foreach (string file in files)
                {
                    mediaList.Add(file);
                }
            }
        }


        private void timerTick(object sender, EventArgs e)
        {
            // Caution: Explicitly invoking garbage collection is generally not recommended.
            GC.Collect();

            // If video is playing, let it finish
            //if (isVideoPlaying) 
            //    return;

            slideCount++;
           
            if (ShouldPlaySlide() || isSlidePlaying)
            {
                ShowPowerPointSlide();
            }
            else
            {

                if (ShouldPlayVideo())
                {
                    ShowVideo();
                    return;
                }
                else 
                {
                    ShowRegularImage();
                    return;
                }
            }
        }

        private bool ShouldShowLevelImage()
        {
            return slideCount % 6 == 0 && !isSlidePlaying;
        }

        private void ShowLevelImage()
        {
            int levelIndex = 1;  // Hardcoded for now
            SetImageSource(mediaCollection.ImageLevels[levelIndex]);
            Console.WriteLine($"Showing LEVEL Image: {mediaCollection.ImageLevels[levelIndex]}");
            StartTimer(imageSlideDelay);
        }

        private void ShowPowerPointSlide()
        {
            isSlidePlaying = true;
            if (currentIndexOfSlide < mediaCollection.PowerpointImages.Count && currentIndexOfSlide != -1)
            {
                SetImageSource(mediaCollection.PowerpointImages[currentIndexOfSlide]);
                Console.WriteLine($"Showing PowerPoint Slide: {mediaCollection.PowerpointImages[currentIndexOfSlide]}");
                currentIndexOfSlide = GetNextPowerPointSlideIndex();
                StartTimer(imageSlideDelay);
                return;
            }
            currentIndexOfSlide = 0;
            isSlidePlaying = false;
        }

        private void ShowVideo()
        {
            int index = GetRandomIndex(mediaCollection.Videos, previousVideoIndex);
            previousVideoIndex = index;
            SetVideoSource(mediaCollection.Videos[index]);
            Console.WriteLine($"Showing Video: {mediaCollection.Videos[index]}");
            isVideoPlaying = true;
        }

        private void ShowRegularImage()
        {
            int index = GetRandomIndex(mediaCollection.Images);
            SetImageSource(mediaCollection.Images[index]);
            Console.WriteLine($"Showing Image: {mediaCollection.Images[index]}");
            StartTimer(imageSlideDelay);
        }

        private void SetImageSource(string imagePath)
        {
            ToggleVisibility(true);
            imageControl.Source = new BitmapImage(new Uri(imagePath));
        }

        private void SetVideoSource(string videoPath)
        {
            ToggleVisibility(false);
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play();
        }

        private void ToggleVisibility(bool showImageControl)
        {
            imageControl.Visibility = showImageControl ? Visibility.Visible : Visibility.Collapsed;
            mediaElement.Visibility = !showImageControl ? Visibility.Visible : Visibility.Collapsed;
        }

        private void StartTimer(int delay)
        {
            timer.Interval = TimeSpan.FromMilliseconds(delay);
            timer.Start();
        }


        private int GetNextPowerPointSlideIndex()
        {
            if (currentIndexOfSlide >= 0 && currentIndexOfSlide < mediaCollection.PowerpointImages.Count)
            {
                string currentSlidePath = mediaCollection.PowerpointImages[currentIndexOfSlide];
                string currentSlideFolder = Path.GetDirectoryName(currentSlidePath);
                int currentSlideNumber = GetSlideNumberFromPath(currentSlidePath);

                for (int i = currentIndexOfSlide + 1; i < mediaCollection.PowerpointImages.Count; i++)
                {
                    string slidePath = mediaCollection.PowerpointImages[i];
                    string slideFolder = Path.GetDirectoryName(slidePath);
                    int slideNumber = GetSlideNumberFromPath(slidePath);

                    if (slideFolder == currentSlideFolder && slideNumber == currentSlideNumber + 1)
                    {
                        // Next slide found
                        return i;
                    }
                }
            }

            // If current slide index is out of range or next slide not found in the same folder,
            // search from the beginning for the next slide in the same folder
            if (mediaCollection.PowerpointImages.Count > 0)
            {
                string currentSlidePath = mediaCollection.PowerpointImages[currentIndexOfSlide];
                string currentSlideFolder = Path.GetDirectoryName(currentSlidePath);
                int currentSlideNumber = GetSlideNumberFromPath(currentSlidePath);

                for (int i = 0; i < mediaCollection.PowerpointImages.Count; i++)
                {
                    string slidePath = mediaCollection.PowerpointImages[i];
                    string slideFolder = Path.GetDirectoryName(slidePath);
                    int slideNumber = GetSlideNumberFromPath(slidePath);

                    if (slideFolder == currentSlideFolder && slideNumber == currentSlideNumber + 1)
                    {
                        // Next slide found
                        return i;
                    }
                }
            }

            // Next slide not found or no slides available
            return -1;
        }



        private bool ShouldShowNextPowerPointSlide(string slidePath)
        {
            // Implement your logic to determine if the next PowerPoint slide should be shown
            // based on the provided slidePath. Return true if it should be shown, false otherwise.
            // You can use any condition or criteria specific to your requirements.

            // Example condition: Check if the slide name contains "slide"
            return slidePath.Contains("slide");
        }

        private int GetSlideNumberFromPath(string slidePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(slidePath);
            string slideNumberStr = fileName.Substring(fileName.LastIndexOf("Slide") + 5);
            int slideNumber = 0;
            int.TryParse(slideNumberStr, out slideNumber);
            return slideNumber;
        }


   
        private bool ShouldPlayVideo()
        {
            Random random = new Random();
            return random.Next(100) < videoChance;
        }
        private bool ShouldPlaySlide()
        {
            Random random = new Random();
            return random.Next(100) < powerpointChance;
        }
        private void StartImageSlideDelay()
        {
            timer.Interval = TimeSpan.FromMilliseconds(imageSlideDelay);
            timer.Start();
        }

        private int GetRandomIndex(List<string> mediaList, int excludeIndex)
        {
            Random random = new Random();
            int index;
            do
            {
                index = random.Next(mediaList.Count);
            } while (index == excludeIndex);
            return index;
        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Switch to the next slide
            isVideoPlaying = false;
            timerTick(null, null);
        }
        private int GetRandomIndex(List<string> mediaList)
        {
            Random random = new Random();
            int index;
            do
            {
                index = random.Next(mediaList.Count);
            } while (index == previousVideoIndex);
            return index;
        }

        private void imageControl_Click(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
