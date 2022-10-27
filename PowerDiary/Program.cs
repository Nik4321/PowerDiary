using PowerDiary.Data;
using PowerDiary.Response;
using PowerDiary.Services;
using Sharprompt;

namespace PowerDiary
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {
                var aggregation = Prompt.Select(
                Constants.PropmtMessage,
                new[] { Constants.PropmtMinuteOption, Constants.PropmtHourlyOption, Constants.PropmtExitOption },
                defaultValue: Constants.PropmtMinuteOption);

                var usernameBob = "Bob";
                var usernameKate = "Kate";

                var data = new List<BaseEvent>
                {
                    new EnterRoomEvent(usernameKate, new TimeOnly(17, 5)),
                    new EnterRoomEvent(usernameBob, new TimeOnly(18, 0)),
                    new LeaveRoomEvent(usernameBob, new TimeOnly(17, 18)),
                    new LeaveRoomEvent(usernameKate, new TimeOnly(18, 21)),
                    new LeaveRoomEvent(usernameKate, new TimeOnly(17, 21)),
                    new CommentEvent(usernameBob, new TimeOnly(17, 15), $"Hey, {usernameKate} - high five?"),
                    new EnterRoomEvent(usernameBob, new TimeOnly(17, 0)),
                    new HighFiveEvent(usernameKate, new TimeOnly(17, 17), usernameBob),
                    new CommentEvent(usernameKate, new TimeOnly(17, 20), "Oh, typical"),
                };

                IChatHistoryResponse chatHistoryResponse = null;

                switch (aggregation)
                {
                    case Constants.PropmtMinuteOption:
                        chatHistoryResponse = MinuteChatHistoryService.DisplayChatHistory(data);
                        break;
                    case Constants.PropmtHourlyOption:
                        chatHistoryResponse = HourlyChatHistoryService.DisplayChatHistory(data);
                        break;
                    case Constants.PropmtExitOption:
                        return;
                }

                chatHistoryResponse.Display();

                // Enter a blank line so that it's displayed nicer.
                Console.WriteLine();
            }
        }
    }
}