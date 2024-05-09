/*
 * 
 * The MediaCollection class stores lists of different types of media
 * used in the digital signage application,including images, image levels, 
 * PowerPoint slide images, and videos. It provides a convenient way to 
 * organize and access these media items.
 */
using System.Collections.Generic;

namespace Re_DigitalSignage.Media
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
    internal class MediaCollection_powerpoint
    {
        public List<string> Powerpoint { get; set; }
        public List<string> Powerpointsildes { get; set; }

    }
}