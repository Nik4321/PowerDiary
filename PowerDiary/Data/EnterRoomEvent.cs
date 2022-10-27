namespace PowerDiary.Data
{
    public class EnterRoomEvent : BaseEvent
    {
        public EnterRoomEvent(string username, TimeOnly time) : base(username, time)
        {
        }

        public static string HourlyStringTemplate => @"{0} person entered";

        public override string ToStringMinute()
        {
            return $"{this.Time}: {this.Username} enters the room";
        }
    }
}
