using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LastSeenApplication.Tests
{
    public class ApiEndpointsUnitTests
    {
        [Test]
        public void GetUserStats_ReturnsCorrectJson_WhenDateExists()
        {
            // Arrange
            DateTime testDate = DateTime.UtcNow;
            UserStatsDataStore.UserStats[testDate] = 5;

            // Act
            var result = ApiEndpoints.GetUserStats(testDate);

            // Assert
            Assert.AreEqual("{\"usersOnline\": 5 }", result);
        }

        [Test]
        public void GetUserStats_ReturnsNullJson_WhenDateDoesNotExist()
        {
            // Arrange
            DateTime testDate = DateTime.UtcNow;

            // Act
            var result = ApiEndpoints.GetUserStats(testDate);

            // Assert
            Assert.AreEqual("{ \"usersOnline\": null }", result);
        }

        [Test]
        public void GetHistoricalUserData_ReturnsCorrectData_WhenUserExists()
        {
            // Arrange
            string userId = "testUser";
            DateTime targetDate = DateTime.UtcNow;
            UserStatsDataStore.UserHistoricalData[userId] = new List<DateTime> { targetDate };

            // Act
            var result = ApiEndpoints.GetHistoricalUserData(userId, targetDate);
            var expected = new
            {
                wasUserOnline = (bool?)true,
                nearestOnlineTime = targetDate
            };

            // Assert
            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }
}

namespace LastSeenApplication.Tests
{
    public class ApiEndpointsTests
    {
        [Test]
        public void GetUserStats_ReturnsCorrectJson_WhenDateExists()
        {
            // Arrange
            DateTime testDate = DateTime.UtcNow;
            UserStatsDataStore.UserStats[testDate] = 5;

            // Act
            var result = ApiEndpoints.GetUserStats(testDate);

            // Assert
            Assert.AreEqual("{\"usersOnline\": 5 }", result);
        }

        [Test]
        public void GetUserStats_ReturnsNullJson_WhenDateDoesNotExist()
        {
            // Arrange
            DateTime testDate = DateTime.UtcNow;

            // Act
            var result = ApiEndpoints.GetUserStats(testDate);

            // Assert
            Assert.AreEqual("{ \"usersOnline\": null }", result);
        }

        [Test]
        public void GetHistoricalUserData_ReturnsCorrectData_WhenUserExists()
        {
            // Arrange
            string userId = "testUser";
            DateTime targetDate = DateTime.UtcNow;
            UserStatsDataStore.UserHistoricalData[userId] = new List<DateTime> { targetDate };

            // Act
            var result = ApiEndpoints.GetHistoricalUserData(userId, targetDate);
            var expected = new
            {
                wasUserOnline = (bool?)true,
                nearestOnlineTime = targetDate
            };

            // Assert
            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }
    }
}