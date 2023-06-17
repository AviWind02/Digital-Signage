using System.Collections.Generic;

namespace Digital_Signage
{
    internal class MediaCollection
    {

        public List<string> Images { get; set; }
        public List<string> ImageLevels { get; set; }
        public List<string> PowerpointImages { get; set; }
        public List<string> Videos { get; set; }

        public MediaCollection()
        {
            Images = new List<string>();
            ImageLevels = new List<string>();
            PowerpointImages = new List<string>();
            Videos = new List<string>();
        }

    }
}