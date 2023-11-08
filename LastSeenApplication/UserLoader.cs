using LastSeenApplication;

public class UserLoader
{
    private readonly ILoader _loader;
    private readonly string _rootUrl;

    public UserLoader(ILoader loader, string rootUrl)
    {
        _loader = loader;
        _rootUrl = rootUrl;
    }

    // LoadAllUsers retrieves all users by making multiple requests
    // to the specified API endpoint with incremental offsets.
    public User[] LoadAllUsers()
    {
        // Create a list to store the retrieved users.
        var users = new List<User>();

        while (true)
        {
            // Construct the URL with an offset parameter to fetch the next batch of users.
            var urlWithOffset = $"{_rootUrl}?offset={users.Count}";

            // Load user data from the API using the provided loader.
            var result = _loader.Load(urlWithOffset);

            // Check if the result contains any users.
            if (result.Data.Length == 0)
            {
                // If no users are returned, exit the loop.
                break;
            }

            // Add the retrieved users to the list.
            users.AddRange(result.Data);
        }

        // Convert the list of users to an array and return it.
        return users.ToArray();
    }
}