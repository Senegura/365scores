namespace Scores365.Events
{
    public class FootballScoreEvent : BaseEvent
    {
        public override SportType SportType => SportType.Football;
    }
}
