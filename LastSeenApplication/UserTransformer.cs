using System;
using System.Collections.Generic;

namespace LastSeenApplication
{
    // Interface for providing the current date and time.
    public interface IDateTimeProvider
    {
        DateTimeOffset GetCurrentTime();
    }

    // Implementation of the IDateTimeProvider interface.
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetCurrentTime()
        {
            // Get the current UTC time.
            return DateTimeOffset.UtcNow;
        }
    }

    // Interface for transforming user information.
    public interface IUserTransformer
    {
        void TransformSingleUser(User stateOfUserInCurrentTime, bool wasOnline, List<UserTimeSpan> userTimeSpans);
    }

    // Implementation of the IUserTransformer interface.
    public class UserTransformer : IUserTransformer
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        // Constructor to inject the date and time provider.
        public UserTransformer(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        // Method to transform a single user's information based on online status.
        public void TransformSingleUser(User stateOfUserInCurrentTime, bool wasOnline, List<UserTimeSpan> userTimeSpans)
        {
            // If the user was online
            if (wasOnline)
            {
                if (stateOfUserInCurrentTime.IsOnline)
                {
                    // Update the logout time to the current time if still online.
                    userTimeSpans.Last().Logout = _dateTimeProvider.GetCurrentTime();
                }
                else
                {
                    // Update the logout time to the user's last seen time if offline.
                    userTimeSpans.Last().Logout = stateOfUserInCurrentTime.LastSeenDate.Value;
                }
            }
            else // If the user was not online
            {
                if (stateOfUserInCurrentTime.IsOnline)
                {
                    // Add a new user time span with login time.
                    userTimeSpans.Add(new UserTimeSpan() { Login = _dateTimeProvider.GetCurrentTime(), Logout = null });
                }
            }
        }
    }
}
