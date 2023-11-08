namespace LastSeenApplication
{
    public class LastSeenApplication
    {
        private readonly UserLoader _userLoader;
        
        // Constructor to inject the UserLoader dependency
        public LastSeenApplication(UserLoader userLoader)
        {
            _userLoader = userLoader;
        }

        // Method to show the last-seen status of all users
        public List<string> Show(DateTimeOffset now)
        {
            var users = _userLoader.LoadAllUsers();
            var formatter = new LastSeenFormatter();
            var lastSeenStatusList = users.Select(u => 
                $"{u.Nickname} {formatter.Format(now, u.LastSeenDate ?? now)}").ToList();

            return lastSeenStatusList;
        }
    }
}