using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignage.Utilities
{
    internal class LevelConverter
    {

        private enum levels
        {
            high=0,
            moderate,
            low,
        }
        private enum speed
        {
            fast = 0,
            normal,
            slow,
        }

        public int GetChanceValue(string chanceLevel)//PPT/Video
        {
            switch (chanceLevel.ToLower())
            {
                case "high":
                    return 75;
                case "moderate":
                    return 50;
                case "low":
                    return 10;
                default:
                    return 50;
            }
        }

        public int GetChanceLevel(int chanceValue)//PPT/Video
        {
            switch (chanceValue)
            {
                case 75:
                    return ((int)levels.high);
                case 50:
                    return ((int)levels.moderate);
                case 10:
                    return ((int)levels.low);
                default:
                    return ((int)levels.moderate);
            }
        }

        public double GetSpeedMultiplier(string speedLevel)//delay
        {
            string s = speedLevel.ToLower();
            if (s.Contains("fast"))
            {
                return 2.5;
            }
            else if (s.Contains("normal"))
            {
                return 5.0;
            }
            else if (s.Contains("slow"))
            {
                return 10.0;
            }
            else
            {
                return 5.0;
            }
        }

        public int GetSpeedLevel(double multiplier)//delay
        {
            switch (multiplier)
            {
                case 2.5:
                    return ((int)speed.fast);
                case 5.0:
                    return ((int)speed.normal);
                case 10.0:
                    return ((int)speed.slow);
                default:
                    return ((int)speed.normal);

            }
        }
    }
}
