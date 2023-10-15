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
    }
}