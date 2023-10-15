using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace LastSeenApplication.Tests
{
    public class ProgramIntegrationTests
    {
        [Test]
        public async Task LoadLastSeenDataAsync_UpdatesUserStats_WhenCalled()
        {
            // Arrange
            // Simulate the external system call to fetch data.
            var mockData = new LastSeenUserResult { Data = new LastSeenUser[] { new LastSeenUser { UserId = "1", Nickname = "user1", LastSeenDate = null } } };
            var initialCount = UserStatsDataStore.UserStats.Count;

            // Act
            var result = await Program.LoadLastSeenDataAsync();

            // Assert
            Assert.IsTrue(UserStatsDataStore.UserStats.Count > initialCount);
        }
    }
}