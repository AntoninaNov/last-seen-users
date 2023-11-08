using System;
using LastSeenApplication;

class Program
{
    static void Main()
    {
        string apiUrl = "https://sef.podkolzin.consulting/api/users/lastSeen";
        var userLoader = new UserLoader(new Loader(), apiUrl);
        var lastSeenApp = new LastSeenApplication.LastSeenApplication(userLoader);

        var result = lastSeenApp.Show(DateTimeOffset.Now);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
