namespace Scores365.Infrastrucrure.Events
{
    public class FootballScoreEvent : BaseEvent
    {
        public override SportType SportType => SportType.Football;
    }
}
