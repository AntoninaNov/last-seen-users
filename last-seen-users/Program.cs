using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastSeenApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<LastSeenUser> allUsers = new List<LastSeenUser>();

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
                    
                    allUsers.AddRange(result.Data);
                    
                    offset += result.Data.Length;
                }
                while (true);

                // Proceed with further manipulation of allUsers
                // e.g., display, process, etc.
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}