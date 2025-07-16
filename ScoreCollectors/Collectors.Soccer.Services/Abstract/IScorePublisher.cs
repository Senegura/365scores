using Scores365.Events;

namespace Collectors.Soccer.Services.Abstract
{
    public interface IScorePublisher
    {
        void Publish(BaseEvent @event);
    }
}
