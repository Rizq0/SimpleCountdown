using System;

namespace ArcRaidersCountdown.Services
{
    public static class CountdownService
    {

        public static string GetCountdownMessage(DateTime today, DateTime releaseDate)
        {
            int daysUntilRelease = (releaseDate - today).Days;

            if (daysUntilRelease > 0)
            {
                return $"ARC Raiders releases in {daysUntilRelease} days!";
            }
            else if (daysUntilRelease == 0)
            {
                return "ARC Raiders releases today!";
            }
            else
            {
                return "ARC Raiders has already been released.";
            }
        }
    }
}
