using Collectors.Soccer.Services.Abstract;
using Confluent.Kafka;
using Scores365.Infrastrucrure.Events;

namespace Collectors.Soccer.Services.MessageBus
{
    public class KafkaScorePublisher(IProducer<string, SoccerScoreEvent> Producer) : IScorePublisher
    {
        public void Publish(BaseEvent @event)
        {
            //Producer.Produce("", new Message<string, SoccerScoreEvent>() { Key =  });
        }
    }
}
