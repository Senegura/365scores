namespace Scores365.Events
{
    public class BaseBallScoreEvent : BaseEvent
    {
        public override SportType SportType => SportType.Baseball;
    }
}
