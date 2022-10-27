namespace PowerDiary.Data
{
    public abstract class BaseEvent
    {
        public BaseEvent(string username, TimeOnly time)
        {
            this.Username = username;
            this.Time = time;
        }

        public string Username { get; set; }
        public TimeOnly Time { get; set; }

        public abstract string ToStringMinute();
    }
}
