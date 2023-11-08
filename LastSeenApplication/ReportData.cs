using System;
using System.Collections.Generic;

namespace LastSeenApplication
{
    public class ReportData
    {
        public string ReportName { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public Dictionary<Guid, UserActivitySummary> UserSummaries { get; set; }
    }

    public class UserActivitySummary
    {
        public int TotalSessions { get; set; }
        public TimeSpan TotalDuration { get; set; }
    }
}
