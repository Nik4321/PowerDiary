using PowerDiary.Data;
using PowerDiary.Services;
using Xunit;

namespace PowerDiary.Tests.Services
{
    public class HourlyChatHistoryServiceTests
    {
        private readonly IList<BaseEvent> dummyEvents = new List<BaseEvent>
        {
            new HighFiveEvent("Steve", new TimeOnly(18, 18), "Bob"),
            new EnterRoomEvent("Steve", new TimeOnly(18, 0)),
            new EnterRoomEvent("Bob", new TimeOnly(15, 4)),
            new CommentEvent("Bob", new TimeOnly(17, 5), "Comment Text"),
            new LeaveRoomEvent("Steve", new TimeOnly(19, 16)),
        };

        [Fact]
        public void DisplayChatHistory_ShouldThrowException_WhenNullEventsArePassed()
        {
            Assert.Throws<ArgumentNullException>(() => HourlyChatHistoryService.DisplayChatHistory(null));
        }

        [Fact]
        public void DisplayChatHistory_ShouldReturnHaveValidHourValues()
        {
            // Act
            var actualResult = HourlyChatHistoryService.DisplayChatHistory(dummyEvents);

            // Assert
            var containsCorrentKeyHours = actualResult.Value.Keys
                .All(x => x == "3 PM" || x == "5 PM" || x == "6 PM" || x == "7 PM");

            Assert.True(containsCorrentKeyHours);
        }

        [Fact]
        public void DisplayChatHistory_ShouldReturnValidEventValues()
        {
            // Act
            var actualResult = HourlyChatHistoryService.DisplayChatHistory(dummyEvents);

            // Assert
            var expectedResult = new Dictionary<string, IList<string>>
            {
                { "3 PM", new List<string> { "1 person entered" } },
                { "5 PM", new List<string> { "1 comments" } },
                { "6 PM", new List<string> { "1 person entered", "1 person high-fived another person" } },
                { "7 PM", new List<string> { "1 left" } }
            };

            Assert.Equal(actualResult.Value, expectedResult);
        }

        [Fact]
        public void DisplayChatHistory_ShouldNotReturnZeroEventStatements()
        {
            // Act
            var actualResult = HourlyChatHistoryService.DisplayChatHistory(dummyEvents);

            // Assert
            var threePmEvents = actualResult.Value.Values.FirstOrDefault();

            Assert.NotEqual(threePmEvents,
                new List<string> { "1 person entered", "0 left", "0 person high-fived another person", "0 comments" });
        }
    }
}
