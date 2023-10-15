using System;
using System.Collections.Generic;

namespace LastSeenApplication
{
    public static class UserStatsDataStore
    {
        // The key is the DateTime, and the value is the number of online users at that time.
        public static Dictionary<DateTime, int> UserStats = new Dictionary<DateTime, int>();
    }
}