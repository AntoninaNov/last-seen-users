using System;

namespace LastSeenApplication
{
    /// <summary>
    /// Represents a user's login and logout timestamps.
    /// </summary>
    public class UserTimeSpan
    {
        /// <summary>
        /// Gets or sets the timestamp when the user logged in.
        /// </summary>
        public DateTimeOffset Login { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the user logged out (if applicable).
        /// </summary>
        public DateTimeOffset? Logout { get; set; }
    }
}
