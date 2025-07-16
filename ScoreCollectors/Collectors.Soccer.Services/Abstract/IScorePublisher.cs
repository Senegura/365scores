using Collectors.Soccer.Domain;
using Scores365.Infrastrucrure.Events;

namespace Collectors.Soccer.Services.Abstract
{
    public interface IScorePublisher
    {
        void Publish(BaseEvent @event);
    }
}
