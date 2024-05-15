using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignage.Utilities
{
    internal static class GlobalVariables
    {
        private static bool _playMedia;
        private static bool _stopMedia;

        private static int _pptPlaybackCounter = 0;
        private static int _videoPlaybackCounter = 0;
        
        private static int _powerpointChance = 30;
        private static int _videoChance = 30;
        
        private static int _delayPerSlide = 5;

        private static int _maxPptPlaybackCount = 10; // Set this to the count after which the media type should switch.
        private static int _maxVideoPlaybackCount = 5; // Set this to the count after which the media type should switch.

        private static string[][] _powerPointFiles;

        public static bool StopMedia
        {
            get { return _stopMedia; }
            set { _stopMedia = value; }
        }
        public static bool PlayMedia
        {
            get { return _playMedia; }
            set { _playMedia = value; }
        }
        public static string[][] PowerPointFiles
        {
            get { return _powerPointFiles; }
            set { _powerPointFiles = value; }
        }

        public static int PptPlaybackCounter
        {
            get { return _pptPlaybackCounter; }
            set { _pptPlaybackCounter = value; }
        }

        public static int VideoPlaybackCounter
        {
            get { return _videoPlaybackCounter; }
            set { _videoPlaybackCounter = value; }
        }

        public static int MaxPptPlaybackCount
        {
            get { return _maxPptPlaybackCount; }
            set { _maxPptPlaybackCount = value; }
        }

        public static int MaxVideoPlaybackCount
        {
            get { return _maxVideoPlaybackCount; }
            set { _maxVideoPlaybackCount = value; }
        }

        public static int PowerpointChance
        {
            get { return _powerpointChance; }
            set { _powerpointChance = value; }
        }

        public static int VideoChance
        {
            get { return _videoChance; }
            set { _videoChance = value; }
        }

        public static int DelayPerSlide
        {
            get { return _delayPerSlide; }
            set { _delayPerSlide = value; }
        }

    }
}
