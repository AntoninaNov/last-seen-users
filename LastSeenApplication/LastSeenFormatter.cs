namespace LastSeenApplication;

public class LastSeenFormatter
{
    /// <summary>
    /// Formats the last seen time relative to the current time.
    /// </summary>
    /// <param name="now">The current time.</param>
    /// <param name="lastSeen">The time the user was last seen.</param>
    /// <returns>A string representing how long ago the user was last seen.</returns>
    public string Format(DateTimeOffset now, DateTimeOffset lastSeen)
    {
        TimeSpan span = now - lastSeen;
        
        if (span == TimeSpan.Zero)
        {
            return "Online";
        }
        
        if (span < TimeSpan.FromSeconds(30))
        {
            return "Just Now";
        }
        
        if (span < TimeSpan.FromMinutes(1))
        {
            return "Less than a minute ago";
        }
        
        if (span < TimeSpan.FromMinutes(60))
        {
            return "Couple of minutes ago";
        }
        
        if (span < TimeSpan.FromMinutes(120))
        {
            return "an hour ago";
        }
        
        if (now.Date == lastSeen.Date)
        {
            return "today";
        }
        
        if (now.Date - lastSeen.Date == TimeSpan.FromDays(1))
        {
            return "yesterday";
        }
        
        if (span < TimeSpan.FromDays(7))
        {
            return "this week";
        }
        
        return "long time ago";
    }
}