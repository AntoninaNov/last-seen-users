using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LastSeenApplication
{
    public static class UserStatsDataStore
    {
        public static ConcurrentDictionary<DateTime, int> UserStats = new ConcurrentDictionary<DateTime, int>();
        public static ConcurrentDictionary<string, List<DateTime>> UserHistoricalData = new ConcurrentDictionary<string, List<DateTime>>();
    }
}