namespace Scores365.Events
{
    public abstract class BaseEvent
    {
        public abstract SportType SportType { get; }

        public DateTime EventTime { get; set; }

        public string CompetitionName { get; set; }
    }
}
