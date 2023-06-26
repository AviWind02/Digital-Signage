using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
//Not in use atm
namespace Digital_Signage.Classes
{

  internal class NumericStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            int xNumber = GetNumberFromFileName(x);
            int yNumber = GetNumberFromFileName(y);

            return xNumber.CompareTo(yNumber);
        }

        private int GetNumberFromFileName(string fileName)
        {
            string fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
            string numericPart = Regex.Match(fileNameOnly, @"\d+").Value;
            return int.Parse(numericPart);
        }
    }
}
