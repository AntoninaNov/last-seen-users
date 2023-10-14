using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LastSeenApplication
{
    public static class DataParser
    {
        public static List<(string Username, DateTime? LastSeen)> ParseUserData(string rawData)
        {
            List<(string Username, DateTime? LastSeen)> parsedData = new List<(string, DateTime?)>();

            try
            {
                JObject jsonResponse = JObject.Parse(rawData);
                JArray users = (JArray)jsonResponse["data"];

                parsedData = users.Select(user => 
                (
                    Username: (string)user["nickname"],
                    LastSeen: user["lastSeenDate"]?.Type == JTokenType.Null ? null : (DateTime?)DateTime.Parse((string)user["lastSeenDate"])
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