namespace Scores365.Infrastrucrure.Events
{
    public class BaseBallScoreEvent : BaseEvent
    {
        public override SportType SportType => SportType.Baseball;
    }
}
