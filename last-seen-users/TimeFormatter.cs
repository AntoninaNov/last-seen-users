using System;

namespace LastSeenApplication
{
    public static class TimeFormatter
    {
        public static string GetHumanReadableTime(DateTime? lastSeenTime, string language)
        {
            if (lastSeenTime == null)
            {
                return LocalizationService.GetText("Online", language);
            }
    
            TimeSpan difference = DateTime.UtcNow - lastSeenTime.Value.ToUniversalTime();
            string timeKey;

            if (difference.TotalSeconds <= 30)
            {
                timeKey = "JustNow";
            }
            else if (difference.TotalSeconds <= 59)
            {
                timeKey = "LessThanMinute";  // Changed key
            }
            else if (difference.TotalMinutes <= 59)
            {
                timeKey = "CoupleOfMinutes";  // Changed key
            }
            else if (difference.TotalMinutes <= 119)
            {
                timeKey = "AnHourAgo";  // Changed key
            }
            else if (DateTime.UtcNow.Date == lastSeenTime.Value.ToUniversalTime().Date)
            {
                timeKey = "Today";
            }
            else if (DateTime.UtcNow.Date.AddDays(-1) == lastSeenTime.Value.ToUniversalTime().Date)
            {
                timeKey = "Yesterday";
            }
            else if (difference.TotalDays < 7)
            {
                timeKey = "ThisWeek";
            }
            else
            {
                timeKey = "LongTimeAgo";
            }

            // Get the localized string based on the time difference and language
            return LocalizationService.GetText(timeKey, language);
        }

    }
}