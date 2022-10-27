using PowerDiary.Data;

namespace PowerDiary.Response
{
    public class MinuteChatHistoryResponse : IChatHistoryResponse
    {
        public MinuteChatHistoryResponse(IEnumerable<BaseEvent> value)
        {
            this.Value = value;
        }

        public IEnumerable<BaseEvent> Value { get; set; }

        public void Display()
        {
            foreach (var item in this.Value)
            {
                Console.WriteLine(item.ToStringMinute());
            }
        }
    }
}
