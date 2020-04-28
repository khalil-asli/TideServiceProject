using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TideTableWCF.TideHelper
{
    public class TideHelper
    {
        //Gestion des calculs de marée en appliquant principalement la règle des douzièmes
        public double RuleOfTwelfh(string lowTime, string highTime, string lowheight, string highHeight, string timeToCheck)
        {
            double heightOfTide;
            TimeSpan targetMinutes = DateTime.Parse(timeToCheck).Subtract(DateTime.Parse(lowTime));
            TimeSpan tideHour = DateTime.Parse(highTime).Subtract(DateTime.Parse(lowTime));
            int roundHour = tideHour.Hours + 1;
            TimeSpan twelfhHourResult = TimeSpan.FromTicks(tideHour.Ticks / roundHour);
            var timeSpan = twelfhHourResult;
            double targetTime = timeSpan.Minutes + Convert.ToDouble(targetMinutes.Hours + "," + targetMinutes.Minutes);
            double tidalRange = Convert.ToDouble(highHeight.Replace("." , ",")) - Convert.ToDouble(lowheight.Replace("." , ","));
            heightOfTide = Math.Round(((tidalRange / 12) + targetTime / 100), 2);
            return heightOfTide;
        }

        public bool GetTimeExists(string startTime, string endTime, string timeToCheck)
        {
            bool isExists = false;
            TimeSpan start = TimeSpan.Parse(startTime);
            TimeSpan end = TimeSpan.Parse(endTime);
            TimeSpan now = TimeSpan.Parse(timeToCheck);
            if (now >= start && now <= end)
            {
                isExists = true;
            }
            return isExists;
        }
    }
}
