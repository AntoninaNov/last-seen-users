using System;

namespace LastSeenApplication
{
    public static class TimeFormatter
    {
        public static string GetHumanReadableTime(DateTime? lastSeenTime)
        {
            if (lastSeenTime == null)
            {
                return "Online";
            }
            
            TimeSpan difference = DateTime.UtcNow - lastSeenTime.Value.ToUniversalTime();

            if (difference.TotalSeconds <= 30)
            {
                return "just now";
            }
            else if (difference.TotalSeconds <= 59)
            {
                return "less than a minute ago";
            }
            else if (difference.TotalMinutes <= 59)
            {
                return "couple of minutes ago";
            }
            else if (difference.TotalMinutes <= 119)
            {
                return "an hour ago";
            }
            else if (DateTime.UtcNow.Date == lastSeenTime.Value.ToUniversalTime().Date)
            {
                return "today";
            }
            else if (DateTime.UtcNow.Date.AddDays(-1) == lastSeenTime.Value.ToUniversalTime().Date)
            {
                return "yesterday";
            }
            else if (difference.TotalDays < 7)
            {
                return "this week";
            }
            else
            {
                return "long time ago";
            }
        }
    }
}