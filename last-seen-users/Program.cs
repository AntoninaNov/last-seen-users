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
            List<(string Username, DateTime? LastSeen)> parsedData = new List<(string Username, DateTime? LastSeen)>();

            int offset = 0;
            LastSeenUserResult result;

            try
            {
                do
                {
                    result = await DataFetcher.FetchDataAsync(offset);

                    if (result.Data == null || result.Data.Length == 0)
                    {
                        break;
                    }
    
                    // Parsing the fetched data using ParseUserData
                    var currentParsedData = DataParser.ParseUserData(result.Data);
                    parsedData.AddRange(currentParsedData);

                    offset += result.Data.Length;
                }
                while (true);

                // Using TimeFormatter to make time human-readable
                foreach (var data in parsedData)
                {
                    if (data.LastSeen == null)
                    {
                        // If the user is online
                        Console.WriteLine($"{data.Username} is online.");
                    }
                    else
                    {
                        // If the user is not online
                        string humanReadableTime = TimeFormatter.GetHumanReadableTime(data.LastSeen);
                        Console.WriteLine($"{data.Username} was last seen {humanReadableTime}.");
                    }
                }

            }
            catch (HttpRequestException e)
            {
                // Handling HttpRequestException
                Console.WriteLine(e.Message);
            }
        }
    }
}