/*
 * 
 * The MediaCollection class stores lists of different types of media
 * used in the digital signage application,including images, image levels, 
 * PowerPoint slide images, and videos. It provides a convenient way to 
 * organize and access these media items.
 */
using System.Collections.Generic;

namespace DigitalSignage.Media
{

 
    internal class MediaCollection
    {

        public static List<string> Images { get; set; }
        public static List<string> ImageLevels { get; set; }
        public static List<string> PowerpointImages { get; set; }
        public static List<string> Videos { get; set; }

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
        public static List<string> Powerpoint { get; set; }
        public static List<string> Powerpointsildes { get; set; }

    }
}