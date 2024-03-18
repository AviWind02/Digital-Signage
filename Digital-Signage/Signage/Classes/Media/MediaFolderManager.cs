using System;
using System.IO;

namespace Digital_Signage.Classes
{
    internal class MediaFolderManager
    {

        private string baseFolderPath;
        private string specialFolderPath;
        private bool useSpecialFolder;

        public MediaFolderManager(string baseFolderPath, string specialFolderPath)
        {
            this.baseFolderPath = baseFolderPath;
            this.specialFolderPath = specialFolderPath;
            useSpecialFolder = false; // Set to true to use the special folder instead
        }

        public string GetMediaFolderPath(string mediaType)
        {
            string dayFolder;
#if DEBUG
            // In debug mode, always use the Monday folder
            dayFolder = Path.Combine(baseFolderPath, "Monday");
#else
    // In release mode, use the special folder or folder based on the current day
    dayFolder = useSpecialFolder
        ? specialFolderPath
        : Path.Combine(baseFolderPath, DateTime.Now.ToString("dddd")); // e.g., "Monday"
#endif

            if (!Directory.Exists(dayFolder))
            {
                dayFolder = Path.Combine(baseFolderPath, "Fallback"); // Fallback folder
            }

            if (!Directory.Exists(dayFolder))
            {
                throw new InvalidOperationException($"No valid folder found for {mediaType}.");
            }

            return Path.Combine(dayFolder, mediaType);
        }

        public void UseSpecialFolder(bool useSpecial)
        {
            useSpecialFolder = useSpecial;
        }

    }
}
