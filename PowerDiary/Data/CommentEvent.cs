namespace PowerDiary.Data
{
    public class CommentEvent : BaseEvent
    {
        public CommentEvent(string username, TimeOnly time, string text) : base(username, time)
        {
            this.Text = text;
        }

        public string Text { get; set; }

        public static string HourlyStringTemplate => @"{0} comments";

        public override string ToStringMinute()
        {
            return $"{this.Time}: {this.Username} comments: {this.Text}";
        }
    }
}
