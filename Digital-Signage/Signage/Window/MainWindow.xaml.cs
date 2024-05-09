using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;
using Digital_Signage.Classes;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Globalization;
using Digital_Signage.Signage.Classes.Scripts;


namespace Digital_Signage
{
    public partial class MainWindow : Window
    {
        private MediaCollection mediaCollection;
        private PowerPointExtractor powerPointExtractor;
        private NumericStringComparer numericStringComparer;
        private DispatcherTimer timer; // Timer for slideshow
        private DualWriter dualWriter;

        private int currentIndex = 0; // Index of the currently displayed media
        private int currentIndexOfSlide = 0; // Index of the currently displayed media
        private int imageSlideDelay = 50;// Delay for each image slide
        private int slideCount = 0; // Counter for the number of slides displayed
        private int previousVideoIndex = -1; // Index of the previously played video
        
        private int playbackCounter_PPT = 0;
        private int playbackCounter_Video = 0;
        private int maxPlaybackCount_PPT = 10; // Set this to the count after which the media type should switch
        private int maxPlaybackCount_Video = 5; // Set this to the count after which the media type should switch
        private int powerpointChance = 30;
        private int videoChance = 30;
        private int delayPerSlide = 5;

        private bool isVideoPlaying = false; // Flag to indicate if a video is currently playing
        private bool isSlidePlaying = false;
        private bool loadingpptx = false;
        private bool canSwitchMediaTypeToPPT = false;
        private bool canSwitchMediaTypeToVideo = false;
        private bool canPlaySlide = true;

        private bool isVideo = false; // Flag to indicate if the current media is a video


        private string[][] powerPointFiles;

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
            dualWriter = new DualWriter();
            timer = new DispatcherTimer();
            timer.Tick += timerTick;
            GC.Collect();
        }

        public void UpdateConfiguration(int newMaxPlaybackCount_PPT, int newMaxPlaybackCount_Video, int newPowerpointChance, int newVideoChance, int newDelayPerSlide)
        {
            Console.WriteLine("Updating configuration...");

            maxPlaybackCount_PPT = newMaxPlaybackCount_PPT;
            maxPlaybackCount_Video = newMaxPlaybackCount_Video;
            powerpointChance = newPowerpointChance;
            videoChance = newVideoChance;
            delayPerSlide = newDelayPerSlide;

            Console.WriteLine($"Configuration updated: " +
                $"MaxPlaybackCount_PPT = {maxPlaybackCount_PPT}, " +
                $"MaxPlaybackCount_Video = {maxPlaybackCount_Video}, " +
                $"PowerpointChance = {powerpointChance}, " +
                $"VideoChance = {videoChance}, " +
                $"DelayPerSlide = {delayPerSlide}.");
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                dualWriter.StartLogging();

                UpdateScrollingText("This is not the final product; this is an alpha test for the slides.");

                // Set the window to be maximized, but not in true full-screen mode
                this.WindowState = WindowState.Maximized;
                this.ResizeMode = ResizeMode.NoResize;

                //Show ConfigWindowTemp
                Config.ConfigForm configFormOBJ = new Config.ConfigForm(powerpointChance, playbackCounter_Video, 
                    maxPlaybackCount_PPT, maxPlaybackCount_Video, powerpointChance, videoChance, delayPerSlide);

                configFormOBJ.Show();


                //Define base folder path for media storage
                string baseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");
                string specialFolderPath = Path.Combine(baseFolderPath, "SpecialFolder");
                MediaFolderManager pathManager = new MediaFolderManager(baseFolderPath, specialFolderPath);

                //Set baseMainDirPath
                configFormOBJ.miscFolderPath = pathManager.GetMediaFolderPath("Config");

                //Retrieve folder paths for each media type
                string imagesFolderPath = pathManager.GetMediaFolderPath("Images");
                string levelImagesFolderPath = pathManager.GetMediaFolderPath("Level Images");
                string powerpointFolderPath = pathManager.GetMediaFolderPath("PowerPoint");
                string powerpointImagesFolderPath = pathManager.GetMediaFolderPath("PowerPoint\\PowerPointImages");
                string videosFolderPath = pathManager.GetMediaFolderPath("Videos");

                //Retrieve and process media based on the paths provided by pathManager
                GetMediaFromFolder(imagesFolderPath, mediaCollection.Images);
                GetMediaFromFolder(levelImagesFolderPath, mediaCollection.ImageLevels);
                GetMediaFromFolder(powerpointImagesFolderPath, mediaCollection.PowerpointImages);
                powerPointExtractor.ExtractPowerPointSlides(powerpointFolderPath, powerpointImagesFolderPath);
                GetMediaFromFolder(videosFolderPath, mediaCollection.Videos);

                //Create and store PowerPoint files in 2D array
                PowerPointManager powerPointManager = new PowerPointManager();
                powerPointFiles = powerPointManager.StorePowerPointFiles(powerpointImagesFolderPath);

                //Log loaded PPT files for verification
                string horizontalRule = new string('-', 50);
                Console.WriteLine($"{horizontalRule}\nLoaded PPT in Array:\n{horizontalRule}");
                foreach (var folder in powerPointFiles)
                {
                    Console.WriteLine("Folder: " + folder[0]);
                    for (int i = 1; i < folder.Length; i++)
                    {
                        Console.WriteLine("  File: " + folder[i]);
                    }
                }

                //Display loaded media paths in console
                Console.WriteLine($"{horizontalRule}\nLoaded Media:\n{horizontalRule}");
                LogSection("Images", mediaCollection.Images);
                LogSection("Image Levels", mediaCollection.ImageLevels);
                LogSection("Videos", mediaCollection.Videos);

                Console.WriteLine("Files Loaded. Starting Playback.");

                //Set first image as source and start timer
                if (mediaCollection.Images.Count > 0)
                {
                    imageControl.Source = new BitmapImage(new Uri(mediaCollection.Images[currentIndex]));
                    timer.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MainWindow_Loaded: {ex.Message}");
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

        //Retrieves the file paths of all media files within a specified folder and its subfolders.
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
            if (!canPlaySlide)
                return;
            //Caution: Explicitly invoking garbage collection is generally not recommended.
            //GC.Collect();

            // Check if video is playing, if so, let it finish
            if (isVideoPlaying)
            {
                Console.WriteLine("Video is playing, waiting for it to finish...");
                return;
            }

            try
            {
                slideCount++;//Logging - Does nothing in the code; just keep counts
                Console.WriteLine($"Slide count incremented to: {slideCount}");

                //Determine whether to show a PowerPoint slide, video, or regular image
                if ((ShouldPlaySlide() || isSlidePlaying) && canSwitchMediaTypeToPPT)
                {
                    ShowPowerPointSlide();
                }
                else
                {
                    if (ShouldPlayVideo() && canSwitchMediaTypeToVideo)
                    {
                        ShowVideo();
                        ControlMediaPlayback();
                    }
                    else
                    {
                        ShowRegularImage();
                        CountDownDelay();
                        ControlMediaPlayback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during timer tick: {ex.Message}");
            }
        }

        private int currentFolderIndex = 0; // Index of the currently displayed folder in the 2D array
        private int currentSlideIndex = 1; // Index of the currently displayed slide in the current folder (starts at 1 to skip folder name)
        private void ShowPowerPointSlide()
        {
            //Set the slide show flag to true
            isSlidePlaying = true;
            string baseFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");
            baseFolderPath = Path.Combine(baseFolderPath, DateTime.Now.ToString("dddd"));
            string powerpointImagesFolderPath = Path.Combine(baseFolderPath, "PowerPoint\\PowerPointImages");

            Console.WriteLine($"Current Folder Index: {currentFolderIndex}, Current Slide Index: {currentSlideIndex}");

            //Check if the slide index is within the bounds of the current folder
            if (currentSlideIndex < powerPointFiles[currentFolderIndex].Length)
            {
                try
                {
                    string folderName = powerPointFiles[currentFolderIndex][0];
                    string slideFileName = powerPointFiles[currentFolderIndex][currentSlideIndex];

                    //Construct the full path of the current slide
                    string slideFilePath = Path.Combine(powerpointImagesFolderPath, folderName, slideFileName);
                    SetImageSource(slideFilePath);
                    Console.WriteLine($"Showing PowerPoint Slide: {slideFilePath}");

                    //Move to the next slide
                    currentSlideIndex++;
                    Console.WriteLine($"Moving to Next Slide: Folder Index: {currentFolderIndex}, Slide Index: {currentSlideIndex}");

                    CountDownDelay();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in showing PowerPoint slide: {ex.Message}");
                }
            }
            else
            {
                //End of folder reached, stop the slide show
                Console.WriteLine("End of folder reached. Stopping slide show.");

                //Stop the slideshow
                isSlidePlaying = false;
                canSwitchMediaTypeToPPT = false;

                //Move to the next folder
                currentFolderIndex++;
                currentSlideIndex = 1; //Reset to the first slide of the next folder

                //Check if we've gone through all folders
                if (currentFolderIndex >= powerPointFiles.Length)
                {
                    Console.WriteLine("All folders completed. Resetting to the first folder.");
                    currentFolderIndex = 0; //Reset to the first folder
                }
                else
                {
                    Console.WriteLine($"Moving to Next Folder: Folder Index: {currentFolderIndex}");
                }
            }
        }


        private void ShowVideo()
        {
            try
            {
                int index = GetRandomIndex(mediaCollection.Videos, previousVideoIndex);
                previousVideoIndex = index;
                SetVideoSource(mediaCollection.Videos[index]);
                Console.WriteLine($"Showing Video: {mediaCollection.Videos[index]}");
                canSwitchMediaTypeToVideo = false;
                isVideoPlaying = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ShowVideo: {ex.Message}");
            }
        }


        private void ShowRegularImage()
        {
            try
            {
                int index = GetRandomIndex(mediaCollection.Images);
                SetImageSource(mediaCollection.Images[index]);
                Console.WriteLine($"Showing Image: {mediaCollection.Images[index]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ShowRegularImage: {ex.Message}");
            }
        }


        public void ControlMediaPlayback()
        {
            try
            {
                if (!canSwitchMediaTypeToPPT)
                {
                    playbackCounter_PPT++;
                    Console.WriteLine($"Playback Counter PPT: {playbackCounter_PPT}");
                }
                if (!canSwitchMediaTypeToVideo)
                {
                    playbackCounter_Video++;
                    Console.WriteLine($"Playback Counter Video: {playbackCounter_Video}");
                }
                if ((playbackCounter_PPT >= maxPlaybackCount_PPT))
                {
                    canSwitchMediaTypeToPPT = true;
                    playbackCounter_PPT = 0;
                    Console.WriteLine("Reached maximum playback count. Ready to switch media type to PPT.");
                }
                if ((playbackCounter_Video >= maxPlaybackCount_Video))
                {
                    canSwitchMediaTypeToVideo = true;
                    playbackCounter_Video = 0;
                    Console.WriteLine("Reached maximum playback count. Ready to switch media type to Video.");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ControlMediaPlayback: {ex.Message}");
            }
        }


        private void SetImageSource(string imagePath)
        {
            try
            {
                ToggleVisibility(true);
                imageControl.Source = new BitmapImage(new Uri(imagePath));
                //Console.WriteLine($"Image source set to: {imagePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting image source: {ex.Message}");
            }
        }


        private void SetVideoSource(string videoPath)
        {
            try
            {
                ToggleVisibility(false);
                mediaElement.Source = new Uri(videoPath);
                mediaElement.Play();
                //Console.WriteLine($"Video source set to: {videoPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting video source: {ex.Message}");
            }
        }

        private void ToggleVisibility(bool showImageControl)
        {
            //Toggle visibility between image and video controls
            imageControl.Visibility = showImageControl ? Visibility.Visible : Visibility.Collapsed;
            mediaElement.Visibility = !showImageControl ? Visibility.Visible : Visibility.Collapsed;
        }


        private void StartTimer(int delay)
        {
            timer.Interval = TimeSpan.FromMilliseconds(delay);
            timer.Start();
        }

        private void CountDownDelay()
        {
            Console.WriteLine($"Starting countdown for {delayPerSlide} seconds...");

            for (int i = delayPerSlide; i > 0; i--)
            {
                Console.WriteLine($"{i}...");
                Thread.Sleep(1000); 
            }

            Console.WriteLine("Continuing to next slide/image.");
        }
   
        private bool ShouldPlayVideo()
        {
            Random random = new Random();
            return random.Next(100) < videoChance;
        }
        private bool ShouldPlaySlide()
        {

            Random random = new Random();
            if(!canSwitchMediaTypeToPPT)
                return random.Next(100) < powerpointChance;
            return false;
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


        private void UpdateScrollingText(string newText)
        {
            //Update the text
            scrollingText.Text = newText;
            StartScrollingTextAnimation();

        }

        private void StartScrollingTextAnimation()
        {
            double startX = this.ActualWidth; //Start from the right edge of the window

            //Calculate the end position based on the text width
            Size formattedTextSize = MeasureString(scrollingText.Text, scrollingText.FontSize, scrollingText.FontFamily, scrollingText.FontStyle, scrollingText.FontWeight, scrollingText.FontStretch);
            double endX = -formattedTextSize.Width; //Ensure the entire text scrolls out of view

            //Adjust the duration based on the length of the text
            double durationPerCharacter = 0.5; //Duration per character in seconds
            double totalDuration = scrollingText.Text.Length * durationPerCharacter;

            //Create a TranslateTransform for the TextBlock
            TranslateTransform translateTransform = new TranslateTransform();
            scrollingText.RenderTransform = translateTransform;

            //Create and start the animation
            DoubleAnimation scrollAnimation = new DoubleAnimation
            {
                From = startX,
                To = endX,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = new Duration(TimeSpan.FromSeconds(totalDuration))
            };
            translateTransform.BeginAnimation(TranslateTransform.XProperty, scrollAnimation);
        }

        //Method to adjust speed factor - Fuck you danny - idfk how you did it before
        private Size MeasureString(string text, double fontSize, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch)
        {
            var typeface = new Typeface(fontFamily, fontStyle, fontWeight, fontStretch);
            var formattedText = new FormattedText(
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                typeface,
                fontSize,
                Brushes.Black,
                new NumberSubstitution(),
                TextFormattingMode.Display);

            return new Size(formattedText.Width, formattedText.Height);
        }


    }



}

