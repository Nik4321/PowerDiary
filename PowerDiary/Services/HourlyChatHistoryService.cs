using PowerDiary.Data;
using PowerDiary.Response;

namespace PowerDiary.Services
{
    public static class HourlyChatHistoryService
    {
        public static HourlyChatHistoryResponse DisplayChatHistory(IEnumerable<BaseEvent> events)
        {
            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            var orderedEvents = events.OrderBy(x => x.Time);

            // Dictionary with time and types of events
            var timeDictionary = new Dictionary<string, IList<Type>>();

            foreach (var item in orderedEvents)
            {
                var time = item.Time.ToString("h tt");

                if (timeDictionary.ContainsKey(time))
                {
                    timeDictionary[time].Add(item.GetType());
                }
                else
                {
                    timeDictionary.Add(time, new List<Type> { item.GetType() });
                }
            }

            var chatHistoryDictionary = new Dictionary<string, IList<string>>();

            // Adds hour time as keys to the history dictionary
            foreach (var key in timeDictionary.Keys)
            {
                chatHistoryDictionary.Add(key, new List<string>());
            }

            FormatDictionaryResponse<EnterRoomEvent>(timeDictionary, chatHistoryDictionary);
            FormatDictionaryResponse<LeaveRoomEvent>(timeDictionary, chatHistoryDictionary);
            FormatDictionaryResponse<HighFiveEvent>(timeDictionary, chatHistoryDictionary);
            FormatDictionaryResponse<CommentEvent>(timeDictionary, chatHistoryDictionary);

            return new HourlyChatHistoryResponse(chatHistoryDictionary);
        }

        private static void FormatDictionaryResponse<T>(
            IDictionary<string, IList<Type>> dictionary,
            IDictionary<string, IList<string>> result)
            where T : BaseEvent
        {
            foreach (var item in dictionary)
            {
                var events = item.Value.Where(x => x == typeof(T));

                var chatEvents = result[item.Key];

                var property = typeof(T).GetProperty(nameof(EnterRoomEvent.HourlyStringTemplate));

                var hourlyTemplate = (string)property.GetValue(null);

                if (events.Any())
                {
                    chatEvents.Add(string.Format(hourlyTemplate, events.Count().ToString()));
                }
            }
        }
    }
}
