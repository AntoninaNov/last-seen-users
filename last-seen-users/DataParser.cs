namespace LastSeenApplication
{
    public static class DataParser
    {
        public static List<(string Username, DateTime? LastSeen)> ParseUserData(LastSeenUser[] users)
        {
            List<(string Username, DateTime? LastSeen)> parsedData = new List<(string, DateTime?)>();

            try
            {
                parsedData = users.Select(user => 
                (
                    Username: user.Nickname,
                    LastSeen: user.LastSeenDate
                )).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while parsing the data: {e.Message}");
            }

            return parsedData;
        }
    }
}