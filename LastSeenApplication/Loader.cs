using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace LastSeenApplication
{
    // Represents a page of users with total count information.
    public class Page
    {
        public int Total { get; set; }
        public User[] Data { get; set; }
    }

    // Represents a user with their last seen information and other attributes.
    public class User
    {
        public Guid UserId { get; set; }
        public DateTimeOffset? LastSeenDate { get; set; }
        public string Nickname { get; set; }
        public bool IsOnline { get; set; }
        public DateTimeOffset? FirstSeen { get; set; }
    }

    // Defines the contract for loading data from a specified URL.
    public interface ILoader
    {
        Page Load(string url);
    }

    // Implements the ILoader interface to load a page of users from a given URL.
    public class Loader : ILoader
    {
        // Loads a page of users from the specified URL.
        public Page Load(string url)
        {
            using var client = new HttpClient();
            using var result = client.GetAsync(url).GetAwaiter().GetResult();
            using var reader = new StreamReader(result.Content.ReadAsStream());
            var stringContent = reader.ReadToEnd();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<Page>(stringContent, options)
                   ?? throw new JsonException("Deserialization failed.");
        }
    }
}