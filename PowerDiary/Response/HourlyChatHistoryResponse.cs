namespace PowerDiary.Response
{
    public class HourlyChatHistoryResponse : IChatHistoryResponse
    {
        public HourlyChatHistoryResponse(Dictionary<string, IList<string>> value)
        {
            this.Value = value;
        }

        public Dictionary<string, IList<string>> Value { get; set; }

        public void Display()
        {
            foreach (var item in this.Value)
            {
                Console.WriteLine($"{item.Key}: ");

                foreach (var result in item.Value)
                {
                    Console.Write($"{"", 10} {result}");
                    Console.WriteLine();
                }
            }
        }
    }
}
