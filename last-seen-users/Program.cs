using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;

namespace LastSeenApplication
{
    class Program
    {
        public static async Task<List<(string Username, DateTime? LastSeen)>> LoadLastSeenDataAsync()
        {
            List<(string Username, DateTime? LastSeen)> parsedData = new List<(string Username, DateTime? LastSeen)>();
            int offset = 0;
            LastSeenUserResult result;

            do
            {
                result = await DataFetcher.FetchDataAsync(offset);

                if (result.Data == null || result.Data.Length == 0)
                {
                    break;
                }

                var currentParsedData = DataParser.ParseUserData(result.Data);
                parsedData.AddRange(currentParsedData);

                offset += result.Data.Length;
            }
            while (true);
            
            int onlineCount = parsedData.Count(x => x.LastSeen == null);
            UserStatsDataStore.UserStats[DateTime.UtcNow] = onlineCount;
            
            return parsedData;
        }

        
        static void DisplayLastSeenData(List<(string Username, DateTime? LastSeen)> parsedData, string language = "en")
        {
            foreach (var data in parsedData)
            {
                if (data.LastSeen == null)
                {
                    Console.WriteLine($"{data.Username} {LocalizationService.GetText("Online", language)}.");
                }
                else
                {
                    // The TimeFormatter now accepts the 'language' parameter to return localized time descriptions
                    string humanReadableTime = TimeFormatter.GetHumanReadableTime(data.LastSeen, language);
                    Console.WriteLine($"{data.Username} {LocalizationService.GetText("WasOnline", language)} {humanReadableTime}.");
                }
            }
        }
        
        static async Task Main(string[] args)
        {
            // Ask user to select a language
            Console.WriteLine(
                "Select a language: [en] English, [ua] Ukrainian, [de] German, [es] Spanish, [fr] French");
            string language = Console.ReadLine().ToLower();

            // Fallback to English if input doesn't match any supported languages
            if (!new[] { "en", "ua", "de", "es", "fr" }.Contains(language))
            {
                language = "en";
            }

            try
            {
                List<(string Username, DateTime? LastSeen)> parsedData = await LoadLastSeenDataAsync();
                DisplayLastSeenData(parsedData, language); // Language set by user input
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                // Load all last seen data
                List<(string Username, DateTime? LastSeen)> parsedData = await LoadLastSeenDataAsync();

                // Ask the user for a date and time
                Console.WriteLine(
                    "Please enter a date and time to get the number of online users (format: yyyy-MM-dd-HH:mm): ");
                string inputDate = Console.ReadLine();

                // Parse the date and time
                DateTime targetDate;
                if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd-HH:mm", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out targetDate)) // 2023-09-27-20:00
                {
                    Console.WriteLine("Invalid date format. Exiting.");
                    return;
                }

                // Filter the data to get the count of online users at the given date and time
                int onlineUsersCount = parsedData.Count(x => x.LastSeen != null && x.LastSeen.Value >= targetDate);
                Console.WriteLine($"Number of users online at {targetDate}: {onlineUsersCount}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}