namespace LastSeenApplication;

// Holds global metrics, currently only daily average.
public class GlobalMetrics
{
    public int DailyAverage { get; set; }
}

// Responsible for transforming a list of all users.
public class AllUsersTransformer
{
    private readonly IUserTransformer _transformer;
    // The IOnlineDetector is commented out for potential future use.
    // private readonly IOnlineDetector _detector;

    // Constructor is using only IUserTransformer as per the current logic.
    public AllUsersTransformer(IUserTransformer transformer)
    {
        _transformer = transformer;
        // _detector = detector; // This line is commented out as the detector is not currently used.
    }

    // Transforms user data and tracks online status.
    public void Transform(IEnumerable<User> allUsers, List<Guid> onlineUsers, Dictionary<Guid, List<UserTimeSpan>> result)
    {
        foreach (var user in allUsers)
        {
            // Attempt to get the list of UserTimeSpan for the current user.
            if (!result.TryGetValue(user.UserId, out var userTimeSpans))
            {
                userTimeSpans = new List<UserTimeSpan>();
                result.Add(user.UserId, userTimeSpans);
            }

            // Check if the user was online and perform transformation.
            var wasOnline = onlineUsers.Contains(user.UserId);
            _transformer.TransformSingleUser(user, wasOnline, userTimeSpans);

            // Update the online users list based on current user's online status.
            if (!wasOnline && user.IsOnline)
            {
                onlineUsers.Add(user.UserId);
            }
            else if (!user.IsOnline)
            {
                onlineUsers.Remove(user.UserId);
            }
        }
    }

    // The following method is commented out as it's not currently used.
    // However, it's left here for potential future global metrics calculation.
    /*
    public GlobalMetrics CalculateGlobalMetrics(Dictionary<Guid, List<UserTimeSpan>> userTimeSpans)
    {
        var globalMetrics = new GlobalMetrics
        {
            DailyAverage = _detector.CalculateGlobalDailyAverageForAllUsers(userTimeSpans),
        };

        return globalMetrics;
    }
    */
}
