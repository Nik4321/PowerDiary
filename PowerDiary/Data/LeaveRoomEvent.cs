namespace PowerDiary.Data
{
    public class LeaveRoomEvent : BaseEvent
    {
        public LeaveRoomEvent(string username, TimeOnly time) : base(username, time)
        {
        }

        public static string HourlyStringTemplate => @"{0} left";

        public override string ToStringMinute()
        {
            return $"{this.Time}: {this.Username} leaves";
        }
    }
}
