using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

using DigitalSignage.Media;
using DigitalSignage.Utilities;
using DigitalSignage.Windows;

namespace DigitalSignage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FormStartWindow formStartWindow;
        private FormSettingWindow formSettingWindow;
        
        private DispatcherTimer mainTimer;
        private DispatcherTimer delayTimer;
        private MediaCollection MediaCollection;
        private DirectoryManager directoryManager;

        private bool isVideoPlaying = false; 
        private bool isSlidePlaying = false;
        private bool canSwitchMediaTypeToPPT = false;
        private bool canSwitchMediaTypeToVideo = false;


        private int slideCount = 0;
        private int currentFolderIndex = 0;
        private int currentSlideIndex = 1;
        private int previousVideoIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
  


        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            formStartWindow = new FormStartWindow(this);
            formSettingWindow = new FormSettingWindow(this);


            directoryManager = new DirectoryManager();
            MediaCollection = new MediaCollection();

            formStartWindow.Show();
            Trace.WriteLine("Loaded");

            mainTimer = new DispatcherTimer();
            mainTimer.Interval = TimeSpan.FromSeconds(1); // Set the interval to 1 second
            mainTimer.Tick += TimerTick;
            mainTimer.Start();

            delayTimer = new DispatcherTimer();
            delayTimer.Interval = TimeSpan.FromSeconds(1);
            delayTimer.Tick += DelayTimerTick;

            StartScrollingTextAnimation();
            UpdateScrollingText(directoryManager.ReadTxtFileWithLogging(directoryManager.GetBasePath()));

        }

        public void ShowSettingsWindow()
        {
            if(!formSettingWindow.Visible)
                formSettingWindow.Show();
        }


        private void TimerTick(object sender, EventArgs e)
        {
            Console.WriteLine($"GlobalVariables.PlayMedia = {GlobalVariables.PlayMedia}");
            if (GlobalVariables.PlayMedia)
            {

                // Check if video is playing, if so, let it finish
                if (isVideoPlaying)
                {
                    Console.WriteLine("Video is playing, waiting for it to finish...");
                    return;
                }

                try
                {
                    slideCount++; // Logging - Does nothing in the code; just keeps counts
                    Console.WriteLine($"Slide count incremented to: {slideCount}");

                    // Determine whether to show a PowerPoint slide, video, or regular image
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
                            StartCountDownDelay();
                            ControlMediaPlayback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during timer tick: {ex.Message}");
                }
            }
        }

        private void ShowPowerPointSlide()
        {
            // Set the slide show flag to true
            isSlidePlaying = true;
            string baseFolderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Digital-Signage");
            baseFolderPath = System.IO.Path.Combine(baseFolderPath, DateTime.Now.ToString("dddd"));
            string powerpointImagesFolderPath = System.IO.Path.Combine(baseFolderPath, "PowerPoint\\PowerPointImages");

            Console.WriteLine($"Current Folder Index: {currentFolderIndex}, Current Slide Index: {currentSlideIndex}");

            // Check if the slide index is within the bounds of the current folder
            if (currentSlideIndex < GlobalVariables.PowerPointFiles[currentFolderIndex].Length)
            {
                try
                {
                    string folderName = GlobalVariables.PowerPointFiles[currentFolderIndex][0];
                    string slideFileName = GlobalVariables.PowerPointFiles[currentFolderIndex][currentSlideIndex];

                    // Construct the full path of the current slide
                    string slideFilePath = System.IO.Path.Combine(powerpointImagesFolderPath, folderName, slideFileName);
                    SetImageSource(slideFilePath);
                    Console.WriteLine($"Showing PowerPoint Slide: {slideFilePath}");

                    // Move to the next slide
                    currentSlideIndex++;
                    Console.WriteLine($"Moving to Next Slide: Folder Index: {currentFolderIndex}, Slide Index: {currentSlideIndex}");

                    StartCountDownDelay();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in showing PowerPoint slide: {ex.Message}");
                }
            }
            else
            {
                // End of folder reached, stop the slide show
                Console.WriteLine("End of folder reached. Stopping slide show.");

                // Stop the slideshow
                isSlidePlaying = false;
                canSwitchMediaTypeToPPT = false;

                // Move to the next folder
                currentFolderIndex++;
                currentSlideIndex = 1; // Reset to the first slide of the next folder

                // Check if we've gone through all folders
                if (currentFolderIndex >= GlobalVariables.PowerPointFiles.Length)
                {
                    Console.WriteLine("All folders completed. Resetting to the first folder.");
                    currentFolderIndex = 0; // Reset to the first folder
                }
                else
                {
                    Console.WriteLine($"Moving to Next Folder: Folder Index: {currentFolderIndex}");
                }
            }
        }

        private void ShowVideo()
        {
            if (MediaCollection.Videos == null || MediaCollection.Videos.Count == 0)
            {
                Console.WriteLine("Video collection is empty. Skipping video playback.");
                canSwitchMediaTypeToVideo = false;
                return; // Exit the method since there are no videos to show
            }

            try
            {
                int index = GetRandomIndex(MediaCollection.Videos, previousVideoIndex);
                previousVideoIndex = index;
                SetVideoSource(MediaCollection.Videos[index]);
                Console.WriteLine($"Showing Video: {MediaCollection.Videos[index]}");
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
                int index = GetRandomIndex(MediaCollection.Images);
                SetImageSource(MediaCollection.Images[index]);
                Console.WriteLine($"Showing Image: {MediaCollection.Images[index]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ShowRegularImage: {ex.Message}");
            }
        }


        public  void ControlMediaPlayback()
        {
            try
            {
                if (!canSwitchMediaTypeToPPT)
                {
                    GlobalVariables.PptPlaybackCounter++;
                    Console.WriteLine($"Playback Counter PPT: {GlobalVariables.PptPlaybackCounter}");
                }
                if (!canSwitchMediaTypeToVideo)
                {
                    GlobalVariables.VideoPlaybackCounter++;
                    Console.WriteLine($"Playback Counter Video: {GlobalVariables.VideoPlaybackCounter}");
                }
                if ((GlobalVariables.PptPlaybackCounter >= GlobalVariables.MaxPptPlaybackCount))
                {
                    canSwitchMediaTypeToPPT = true;
                    GlobalVariables.PptPlaybackCounter = 0;
                    Console.WriteLine("Reached maximum playback count. Ready to switch media type to PPT.");
                }
                if ((GlobalVariables.VideoPlaybackCounter >= GlobalVariables.MaxVideoPlaybackCount))
                {
                    canSwitchMediaTypeToVideo = true;
                    GlobalVariables.VideoPlaybackCounter = 0;
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
            mainTimer.Interval = TimeSpan.FromMilliseconds(delay);
            mainTimer.Start();
        }

        private void StartCountDownDelay()
        {
            GlobalVariables.DelayPerSlide = 5;
            Console.WriteLine($"Starting countdown for {GlobalVariables.DelayPerSlide} seconds...");
            mainTimer.Stop();
            delayTimer.Start();
        }

        private void DelayTimerTick(object sender, EventArgs e)
        {
            GlobalVariables.DelayPerSlide--;
            Console.WriteLine($"{GlobalVariables.DelayPerSlide} seconds left...");

            if (GlobalVariables.DelayPerSlide <= 0)
            {
                Console.WriteLine("Continuing to next slide/image.");
                delayTimer.Stop();
                mainTimer.Start();
            }
        }


        private bool ShouldPlayVideo()
        {
            Random random = new Random();
            return random.Next(100) < GlobalVariables.VideoChance;
        }   
        private bool ShouldPlaySlide()
        {

            Random random = new Random();
            return random.Next(100) < GlobalVariables.PowerpointChance;
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
            //TimerTick(null, null);
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


        public void UpdateScrollingText(string newText)
        {
            //Update the text
            scrollingText.Text = newText;

        }

        private void StartScrollingTextAnimation()
        {
            double startX = this.ActualWidth; // Start from the right edge of the window
            Size formattedTextSize = MeasureString(scrollingText.Text, scrollingText.FontSize, scrollingText.FontFamily, scrollingText.FontStyle, scrollingText.FontWeight, scrollingText.FontStretch);
            double endX = -formattedTextSize.Width; // Ensure the entire text scrolls out of view

            double durationPerCharacter = 0.5; // Duration per character in seconds
            double totalDuration = scrollingText.Text.Length * durationPerCharacter;

            TranslateTransform translateTransform = scrollingText.RenderTransform as TranslateTransform ?? new TranslateTransform();
            scrollingText.RenderTransform = translateTransform;

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
