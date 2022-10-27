namespace PowerDiary.Data
{
    public class HighFiveEvent : BaseEvent
    {
        public HighFiveEvent(string username, TimeOnly time, string userToHighFive) : base(username, time)
        {
            this.UserToHighFive = userToHighFive;
        }

        public string UserToHighFive { get; set; }

        public static string HourlyStringTemplate => @"{0} person high-fived another person";

        public override string ToStringMinute()
        {
            return $"{this.Time}: {this.Username} high-fives {this.UserToHighFive}";
        }
    }
}
