using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Re_DigitalSignage.Utilities
{
    internal class GlobalVariables
    {

        private int _pptPlaybackCounter = 0;
        private int _videoPlaybackCounter = 0;
        
        private int _powerpointChance = 30;
        private int _videoChance = 30;
        
        private int _delayPerSlide = 5;

        private int _maxPptPlaybackCount = 10; // Set this to the count after which the media type should switch.
        private int _maxVideoPlaybackCount = 5; // Set this to the count after which the media type should switch.


        public int PptPlaybackCounter
        {
            get { return _pptPlaybackCounter; }
            set { _pptPlaybackCounter = value; }
        }

        public int VideoPlaybackCounter
        {
            get { return _videoPlaybackCounter; }
            set { _videoPlaybackCounter = value; }
        }

        public int MaxPptPlaybackCount
        {
            get { return _maxPptPlaybackCount; }
            set { _maxPptPlaybackCount = value; }
        }

        public int MaxVideoPlaybackCount
        {
            get { return _maxVideoPlaybackCount; }
            set { _maxVideoPlaybackCount = value; }
        }

        public int PowerpointChance
        {
            get { return _powerpointChance; }
            set { _powerpointChance = value; }
        }

        public int VideoChance
        {
            get { return _videoChance; }
            set { _videoChance = value; }
        }

        public int DelayPerSlide
        {
            get { return _delayPerSlide; }
            set { _delayPerSlide = value; }
        }

    }
}
