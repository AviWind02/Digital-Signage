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

namespace Digital_Signage
{
    public partial class MainWindow : Window
    {
        private MediaCollection mediaCollection;
        private PowerPointExtractor powerPointExtractor;
        private NumericStringComparer numericStringComparer;
        private int currentIndex = 0; // Index of the currently displayed media
        private int currentIndexOfSlide = 0; // Index of the currently displayed media
        private int imageSlideDelay = 500;// Delay for each image slide
        private int slideCount = 0; // Counter for the number of slides displayed
        private bool isVideoPlaying = false; // Flag to indicate if a video is currently playing
        private int previousVideoIndex = -1; // Index of the previously played video
        private bool isSlidePlaying = false;
        private bool loadingpptx = false;
        private DispatcherTimer timer; // Timer for slideshow
        private int powerpointChance = 25;
        private int videoChance = 50;
        private int imageChance = 50;
        private int levelImageChance = 50;

        private bool isVideo = false; // Flag to indicate if the current media is a video

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

                    Registry.SetValue($"{baseKey}\\{subKey}", levelImagesValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", powerPointValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", videosValue, string.Empty);
                    Registry.SetValue($"{baseKey}\\{subKey}", imagesValue, string.Empty);


                    Console.WriteLine("Registry key and values created successfully!");
                }
                else
                {
                    // Key exists, retrieve values and populate textboxes
                    string levelImages = digiSignKey.GetValue(levelImagesValue, string.Empty) as string;
                    string powerPoint = digiSignKey.GetValue(powerPointValue, string.Empty) as string;
                    string videos = digiSignKey.GetValue(videosValue, string.Empty) as string;
                    string images = digiSignKey.GetValue(imagesValue, string.Empty) as string;


                    // Assuming you have four textboxes: textBox1, textBox2, textBox3, textBox4
                    levelImageChance = int.Parse(levelImages);
                    powerpointChance = int.Parse(powerPoint);
                    videoChance = int.Parse(videos);
                    imageChance = int.Parse(images);

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


            //Retreive configuration from registry
            CheckAndRetrieveRegistryValues();

            // Specify the base folder path
            string baseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");

            // Define folder paths for each media type
            string imagesFolderPath = Path.Combine(baseFolderPath, "Images");
            string levelImagesFolderPath = Path.Combine(baseFolderPath, "Level Images");
            string powerpointFolderPath = Path.Combine(baseFolderPath, "PowerPoint");
            string powerpointImagesFolderPath = Path.Combine(baseFolderPath, "Images\\PowerPointImages");
            string videosFolderPath = Path.Combine(baseFolderPath, "Videos");

            // Get media from each folder
            GetMediaFromFolder(imagesFolderPath, mediaCollection.Images);
            GetMediaFromFolder(levelImagesFolderPath, mediaCollection.ImageLevels);
            GetMediaFromFolder(powerpointImagesFolderPath, mediaCollection.PowerpointImages);
            powerPointExtractor.ExtractPowerPointSlides(powerpointFolderPath, powerpointImagesFolderPath);
            GetMediaFromFolder(videosFolderPath, mediaCollection.Videos);


            loadingpptx = true;




            // Display loaded media paths in the console
            Console.WriteLine("Loaded Media:");
            Console.WriteLine("Loaded Images:");
            foreach (string imagePath in mediaCollection.Images)
            {
                Console.WriteLine(imagePath);
            }
            Console.WriteLine("Loaded Image Levels:");
            foreach (string levelImagePath in mediaCollection.ImageLevels)
            {
                Console.WriteLine(levelImagePath);
            }
            Console.WriteLine("Loaded PowerPoint Images:");
            foreach (string pptImagePath in mediaCollection.PowerpointImages)
            {
                Console.WriteLine(pptImagePath);
            }
            Console.WriteLine("Loaded Videos:");
            foreach (string videoPath in mediaCollection.Videos)
            {
                Console.WriteLine(videoPath);
            }
            Console.WriteLine("Files Loaded. Starting Playback.");

            if (mediaCollection.Images.Count > 0)
            {
                imageControl.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(mediaCollection.Images[currentIndex]));
                timer.Interval = TimeSpan.FromMilliseconds(imageSlideDelay);
                timer.Start();
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
            GC.Collect();
            if (isVideoPlaying)
            {
                return;
            }
            slideCount++;

            ShouldPlaySlide();
            if (isSlidePlaying)
            {
                // If we still have PowerPoint slides to show, show the next one
                if (currentIndexOfSlide < mediaCollection.PowerpointImages.Count)
                {
                    //-1 is when the pptx runs out
                    if (currentIndexOfSlide == -1)
                    {
                        isSlidePlaying = false;
                        return;
                    }
                    imageControl.Visibility = Visibility.Visible;
                    mediaElement.Visibility = Visibility.Collapsed;
                    imageControl.Source = new BitmapImage(new Uri(mediaCollection.PowerpointImages[currentIndexOfSlide]));
                    Console.WriteLine($"Showing PowerPoint Slide: {mediaCollection.PowerpointImages[currentIndexOfSlide]}");
                    currentIndexOfSlide = GetNextPowerPointSlideIndex();
                    StartImageSlideDelay(); // Start the delay for image slides
                    return;
                }
                currentIndexOfSlide = 0;
                isSlidePlaying = false;
            }

            if (slideCount % levelImageChance == 0)
            {
                // Show image level
                int levelIndex = 1;
                if (levelIndex >= 0 && levelIndex < mediaCollection.ImageLevels.Count)
                {
                    imageControl.Source = new BitmapImage(new Uri(mediaCollection.ImageLevels[levelIndex]));
                    Console.WriteLine($"Showing LEVEL Image: {mediaCollection.ImageLevels[levelIndex]}");
                    // Log level image path
                    StartImageSlideDelay(); // Start the delay for image slides
                }
            }
            else
            {
                if (ShouldPlayVideo())
                {
                    // Show video
                    currentIndex = GetRandomIndex(mediaCollection.Videos, previousVideoIndex);
                    previousVideoIndex = currentIndex;
                    imageControl.Visibility = Visibility.Collapsed;
                    mediaElement.Visibility = Visibility.Visible;
                    mediaElement.Source = new Uri(mediaCollection.Videos[currentIndex]);
                    mediaElement.Play();
                    Console.WriteLine($"Showing Video: {mediaCollection.Videos[currentIndex]}");
                    isVideoPlaying = true;
                }
                else if (ShouldShowImage())
                {
                    if (currentIndex >= 0 && currentIndex < mediaCollection.PowerpointImages.Count)
                    {
                        imageControl.Visibility = Visibility.Visible;
                        mediaElement.Visibility = Visibility.Collapsed;
                        Console.WriteLine($"Showing PowerPoint Slide: {mediaCollection.PowerpointImages[currentIndex]}");
                        imageControl.Source = new BitmapImage(new Uri(mediaCollection.PowerpointImages[currentIndex]));
                        currentIndexOfSlide = currentIndex + 1; // Move to the next slide index
                        StartImageSlideDelay(); // Start the delay for image slides
                    }
                    else
                    {
                        // No more PowerPoint slides, show regular image
                        currentIndex = GetRandomIndex(mediaCollection.Images);
                        imageControl.Visibility = Visibility.Visible;
                        mediaElement.Visibility = Visibility.Collapsed;
                        Console.WriteLine($"Showing Image: {mediaCollection.Images[currentIndex]}");
                        imageControl.Source = new BitmapImage(new Uri(mediaCollection.Images[currentIndex]));
                        StartImageSlideDelay(); // Start the delay for image slides
                    }
                }
            }
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


        private bool ShouldShowImage()
        {
            // Determine if the current slide should be a video or image based on some condition
            // In this example, we will randomly decide to play a video 10% of the time
            Random random = new Random();
            return random.Next(100) < imageChance;
        }
        private bool ShouldPlayVideo()
        {
            // Determine if the current slide should be a video or image based on some condition
            // In this example, we will randomly decide to play a video 10% of the time
            Random random = new Random();
            return random.Next(100) < videoChance;
        }
        private bool ShouldPlaySlide()
        {
            // Determine if the current slide should be a video or image based on some condition
            // In this example, we will randomly decide to play a slide 10% of the time
            Random random = new Random();
            if (random.Next(100) < powerpointChance)
            {
                isSlidePlaying = true;
                return true;
            }
            return false;

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
