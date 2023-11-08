using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LastSeenApplication
{
    public class Worker
    {
        private readonly UserLoader _loader;
        private readonly AllUsersTransformer _transformer;
        private readonly List<Guid> _forgottenUsers = new();

        public Worker(UserLoader loader, AllUsersTransformer transformer)
        {
            _loader = loader;
            _transformer = transformer;
            Users = new Dictionary<Guid, List<UserTimeSpan>>();
        }

        // Dictionary to store user activity data
        public Dictionary<Guid, List<UserTimeSpan>> Users { get; set; }
        public List<Guid> OnlineUsers { get; } = new();

        // Periodically load data
        public void LoadDataPeriodically()
        {
            while (true)
            {
                Console.WriteLine("Loading data");
                LoadDataIteration();
                Console.WriteLine("Data loaded");
                Thread.Sleep(5000);
            }
        }

        // Load data for one iteration
        public void LoadDataIteration()
        {
            var allUsers = _loader.LoadAllUsers().ToList();

            // Remove forgotten users
            allUsers.RemoveAll(x => _forgottenUsers.Contains(x.UserId));

            // Transform and update user data
            _transformer.Transform(allUsers, OnlineUsers, Users);
        }

        // Mark a user as forgotten
        public void Forget(Guid userId)
        {
            _forgottenUsers.Add(userId);
            Users.Remove(userId);
            OnlineUsers.Remove(userId);
        }

        // Find the first login date for a user
        public DateTimeOffset? FindFirstSeenDate(Guid userId)
        {
            if (Users.TryGetValue(userId, out var userTimeSpans) && userTimeSpans.Count > 0)
            {
                var sortedTimeSpans = userTimeSpans.OrderBy(uts => uts.Login).ToList();
                return sortedTimeSpans[0].Login;
            }

            return null;
        }
    }
}
