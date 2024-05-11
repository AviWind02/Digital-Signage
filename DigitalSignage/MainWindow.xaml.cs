using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitalSignage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Loaded");
            UpdateScrollingText("This is not the final product; this is an alpha test for the slides.");

        }

        private void UpdateScrollingText(string newText)
        {
            //Update the text
            scrollingText.Text = newText;
            StartScrollingTextAnimation();

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
