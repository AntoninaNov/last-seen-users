using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace LastSeenApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                List<(string Username, DateTime? LastSeen)> parsedData = await LoadLastSeenDataAsync();
                DisplayLastSeenData(parsedData, "en"); // Language set to English for this example
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }

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

            return parsedData;
        }

        
        static void DisplayLastSeenData(List<(string Username, DateTime? LastSeen)> parsedData, string language = "en")
        {
            foreach (var data in parsedData)
            {
                if (data.LastSeen == null)
                {
                    Console.WriteLine($"{data.Username} {Localization.GetText("Online", language)}.");
                }
                else
                {
                    string humanReadableTime = TimeFormatter.GetHumanReadableTime(data.LastSeen);
                    Console.WriteLine($"{data.Username} {Localization.GetText("WasOnline", language)} {humanReadableTime}.");
                }
            }
        }
    }
}