namespace Scores365.Infrastrucrure.Events
{
    public class SoccerScoreEvent : BaseEvent
    {
        public override SportType SportType => SportType.Soccer;

        public string[] Teams { get; set; }
    }
}
