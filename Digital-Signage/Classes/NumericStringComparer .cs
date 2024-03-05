using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Digital_Signage.Classes
{
    //Class used to compare strings numerically (useful for sorting file names with numbers)
    internal class NumericStringComparer : IComparer<string>
    {
        //Compares two strings numerically based on embedded numbers
        public int Compare(string x, string y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            try
            {
                int xNumber = GetNumberFromFileName(x);
                int yNumber = GetNumberFromFileName(y);

                return xNumber.CompareTo(yNumber);
            }
            catch (System.Exception ex)
            {
                //Log any exceptions encountered during comparison
                Console.WriteLine($"Error comparing '{x}' and '{y}': {ex.Message}");
                return 0;
            }
        }

        //Extracts a number from a file name
        private int GetNumberFromFileName(string fileName)
        {
            try
            {
                string fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
                string numericPart = Regex.Match(fileNameOnly, @"\d+").Value;
                return int.Parse(numericPart);
            }
            catch (System.Exception ex)
            {
                //Log any exceptions encountered during number extraction
                Console.WriteLine($"Error extracting number from '{fileName}': {ex.Message}");
                return 0;
            }
        }
    }
}
