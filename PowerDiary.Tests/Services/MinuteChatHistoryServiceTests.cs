using PowerDiary.Data;
using PowerDiary.Services;
using Xunit;

namespace PowerDiary.Tests.Services
{
    public class MinuteChatHistoryServiceTests
    {
        [Fact]
        public void DisplayChatHistory_ShouldThrowException_WhenNullEventsArePassed()
        {
            Assert.Throws<ArgumentNullException>(() => MinuteChatHistoryService.DisplayChatHistory(null));
        }

        [Fact]
        public void DisplayChatHistory_ShouldReturnOrderedEvents_WhenValidEventsArePassed()
        {
            // Arrange
            var events = new List<BaseEvent>
            {
                new HighFiveEvent("Steve", new TimeOnly(18, 18), "Bob"),
                new EnterRoomEvent("Steve", new TimeOnly(18, 0)),
                new EnterRoomEvent("Bob", new TimeOnly(17, 5)),
            };

            // Act
            var actualResult = MinuteChatHistoryService.DisplayChatHistory(events);

            // Assert
            var expectedResult = new List<BaseEvent>
            {
                new EnterRoomEvent("Bob", new TimeOnly(17, 5)),
                new EnterRoomEvent("Steve", new TimeOnly(18, 0)),
                new HighFiveEvent("Steve", new TimeOnly(18, 18), "Bob"),
            };

            Assert.Equivalent(expectedResult, actualResult.Value);
        }
    }
}
