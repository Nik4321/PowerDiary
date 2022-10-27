using PowerDiary.Data;
using PowerDiary.Response;

namespace PowerDiary.Services
{
    public static class MinuteChatHistoryService
    {
        public static MinuteChatHistoryResponse DisplayChatHistory(IEnumerable<BaseEvent> events)
        {
            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            var baseEvents = events.OrderBy(x => x.Time);

            var result = new MinuteChatHistoryResponse(baseEvents);

            return result;
        }
    }
}
