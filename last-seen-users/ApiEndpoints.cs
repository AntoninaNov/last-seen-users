using System;
using System.Linq;

namespace LastSeenApplication
{
    public static class ApiEndpoints
    {
        public static string GetUserStats(DateTime date)
        {
            if (UserStatsDataStore.UserStats.TryGetValue(date, out int onlineCount))
            {
                return $"{{ \"usersOnline\": {onlineCount} }}";
            }
            return "{ \"usersOnline\": null }";
        }
        
        public static object GetHistoricalUserData(string userId, DateTime targetDate)
        {
            if (!UserStatsDataStore.UserHistoricalData.ContainsKey(userId))
            {
                // Return 404 if user not found
                return null;
            }

            var userData = UserStatsDataStore.UserHistoricalData[userId];
            var wasUserOnline = userData.Contains(targetDate);
            var nearestOnlineTime = FindNearestOnlineTime(userData, targetDate);

            return new
            {
                wasUserOnline = wasUserOnline ? (bool?)true : userData.Count == 0 ? null : (bool?)false,
                nearestOnlineTime = nearestOnlineTime
            };
        }

        private static DateTime? FindNearestOnlineTime(List<DateTime> userData, DateTime targetDate)
        {
            DateTime? nearestTime = null;
            TimeSpan shortestDifference = TimeSpan.MaxValue;

            foreach (var onlineTime in userData)
            {
                TimeSpan currentDifference = onlineTime - targetDate;

                if (Math.Abs(currentDifference.TotalSeconds) < Math.Abs(shortestDifference.TotalSeconds))
                {
                    shortestDifference = currentDifference;
                    nearestTime = onlineTime;
                }
            }
            return nearestTime;
        }
        
        public static int GetPredictedOnlineUsers(DateTime futureDate)
        {
            DayOfWeek day = futureDate.DayOfWeek;
            int hour = futureDate.Hour;

            // Check if we have historical data for this DayOfWeek and Hour
            if (UserStatsDataStore.HistoricalUserStats.TryGetValue((day, hour), out List<int> historicalCounts))
            {
                if (historicalCounts.Count == 0)
                {
                    return 0; // No data available
                }
        
                // Calculate average
                return (int)Math.Round(historicalCounts.Average());
            }
            else
            {
                return 0; // No data available
            }
        }

    }
}