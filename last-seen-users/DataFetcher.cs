using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LastSeenApplication
{
    public static class DataFetcher
    {
        public static async Task<LastSeenUserResult> FetchDataAsync(int offset)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri($"https://sef.podkolzin.consulting/api/users/lastSeen?offset={offset}"));

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LastSeenUserResult>(jsonData);
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
        }
    }
}