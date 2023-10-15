using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LastSeenApplication
{
    public static class UserStatsDataStore
    {
        public static ConcurrentDictionary<DateTime, int> UserStats = new ConcurrentDictionary<DateTime, int>();
        public static ConcurrentDictionary<string, List<DateTime>> UserHistoricalData = new ConcurrentDictionary<string, List<DateTime>>();
        // Key is a Tuple of (DayOfWeek, Hour), Value is a List of counts of online users
        public static Dictionary<(DayOfWeek, int), List<int>> HistoricalUserStats = new Dictionary<(DayOfWeek, int), List<int>>();


    }
}